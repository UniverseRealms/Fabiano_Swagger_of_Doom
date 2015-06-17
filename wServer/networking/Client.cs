﻿#region

using db.JsonObjects;
using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using wServer.networking.cliPackets;
using wServer.networking.svrPackets;
using wServer.realm;
using wServer.realm.entities.player;

#endregion

namespace wServer.networking
{
    public enum ProtocalStage
    {
        Connected,
        Handshaked,
        Ready,
        Disconnected
    }

    public class Client : IDisposable
    {
        public const string SERVER_VERSION = "27.3.1";
        private bool disposed;

        private static readonly ILog logger = LogManager.GetLogger(typeof(Client));

        public uint UpdateAckCount = 0;

        private NetworkHandler handler;

        public Client(RealmManager manager, Socket skt)
        {
            Socket = skt;
            Manager = manager;
            ReceiveKey =
                new RC4(new byte[] { 0x31, 0x1f, 0x80, 0x69, 0x14, 0x51, 0xc7, 0x1d, 0x09, 0xa1, 0x3a, 0x2a, 0x6e });
            SendKey = new RC4(new byte[] { 0x72, 0xc5, 0x58, 0x3c, 0xaf, 0xb6, 0x81, 0x89, 0x95, 0xcd, 0xd7, 0x4b, 0x80 });
            BeginProcess();
        }

        public RC4 ReceiveKey { get; private set; }

        public RC4 SendKey { get; private set; }

        public RealmManager Manager { get; private set; }

        public int Id { get; internal set; }

        public Socket Socket { get; internal set; }

        public Char Character { get; internal set; }

        public Account Account { get; internal set; }

        public ProtocalStage Stage { get; internal set; }

        public Player Player { get; internal set; }

        public wRandom Random { get; internal set; }

        public string ConnectedBuild { get; internal set; }

        public int TargetWorld { get; internal set; }

        public void BeginProcess()
        {
            logger.InfoFormat($"Received client @ {Socket.RemoteEndPoint}.");
            handler = new NetworkHandler(this, Socket);
            handler.BeginHandling();
        }

        public void SendPacket(Packet pkt)
        {
            handler?.SendPacket(pkt);
        }

        public void SendPackets(IEnumerable<Packet> pkts)
        {
            handler?.SendPackets(pkts);
        }

        public bool IsReady()
        {
            if (Stage == ProtocalStage.Disconnected)
                return false;
            return Stage != ProtocalStage.Ready || (Player != null && (Player == null || Player.Owner != null));
        }

        internal void ProcessPacket(Packet pkt)
        {
            try
            {
                logger.Logger.Log(typeof(Client), Level.Verbose,
                   $"Handling packet '{pkt}'...", null);
                if (pkt.ID == (PacketID)255) return;
                IPacketHandler handler;
                if (!PacketHandlers.Handlers.TryGetValue(pkt.ID, out handler))
                    logger.Warn($"Unhandled packet '{pkt.ID}'.");
                else
                    handler.Handle(this, (ClientPacket)pkt);
            }
            catch (Exception e)
            {
                logger.Error($"Error when handling packet '{pkt}'...", e);
                Disconnect();
            }
        }

        public void Disconnect()
        {
            try
            {
                if (Stage == ProtocalStage.Disconnected) return;
                Stage = ProtocalStage.Disconnected;
                if (Account != null)
                    DisconnectFromRealm();

                Socket.Close();
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
        }

        public Task Save()
        {
            return Manager.Database.DoActionAsync(db =>
            {
                try
                {
                    string w = null;
                    if (Player != null)
                    {
                        Player.SaveToCharacter();
                        if (Player.Owner != null)
                        {
                            if (Player.Owner.Id == -6) return;
                            w = Player.Owner.Name;
                        }
                    }

                    if (Character != null)
                    {
                        if (w != null) db.UpdateLastSeen(Account.AccountId, Character.CharacterId, w);
                        db.SaveCharacter(Account, Character);
                    }

                    db.UnlockAccount(Account);
                }
                catch (Exception ex)
                {
                    logger.Fatal("SaveException", ex);
                }
            });
        }

        //Following must execute, network loop will discard disconnected client, so logic loop
        private void DisconnectFromRealm()
        {
            Manager.Logic.AddPendingAction(t =>
            {
                Save();
                Manager.Disconnect(this);
            }, PendingPriority.Destruction);
        }

        public void Reconnect(ReconnectPacket pkt)
        {
            Manager.Logic.AddPendingAction(t =>
            {
                Save();
                SendPacket(pkt);
            }, PendingPriority.Destruction);
        }

        public void GiftCodeReceived(string type)
        {
            switch (type)
            {
                case "Pong":
                    AddGiftCode(GiftCode.GenerateRandom(Manager.GameData, 500, minFame: 500, minCharSlots: 2, minVaultChests: 2, maxItemStack: 5, maxItemTypes: 3), type);
                    break;

                case "LevelUp":
                    AddGiftCode(GiftCode.GenerateRandom(Manager.GameData, 300, minFame: 300, minCharSlots: 1, minVaultChests: 1, maxItemStack: 3, maxItemTypes: 2), type);
                    break;

                default:
                    AddGiftCode(GiftCode.GenerateRandom(Manager.GameData));
                    break;
            }
        }

        private void AddGiftCode(GiftCode code, string type = "random")
        {
            Manager.Database.DoActionAsync(db =>
            {
                var key = db.GenerateGiftcode(code.ToJson());
                Player.SendInfo($"You received a {type} Giftcode: {key}. You can redeem it at:\n{Program.ServerDomain}/GiftCode.html");
            });
        }

        public void Dispose()
        {
            if (disposed) return;
            handler?.Dispose();
            handler = null;
            ReceiveKey = null;
            SendKey = null;
            Manager = null;
            Socket = null;
            Character = null;
            Account = null;
            Player?.Dispose();
            Player = null;
            Random = null;
            ConnectedBuild = null;
            disposed = true;
        }
    }
}
