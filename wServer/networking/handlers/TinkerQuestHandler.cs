﻿using db;
using wServer.networking.cliPackets;
using wServer.networking.svrPackets;

namespace wServer.networking.handlers
{
    internal class TinkerQuestHandler : PacketHandlerBase<TinkerQuestPacket>
    {
        public override PacketID ID
        {
            get { return PacketID.TINKERQUEST; }
        }

        protected override void HandlePacket(Client client, TinkerQuestPacket packet)
        {
            using (Database db = new Database())
            {
                if (packet.Object.ObjectType == client.Player.Inventory[packet.Object.SlotId].ObjectType &&
                    (int)client.Player.Inventory[packet.Object.SlotId].ObjectType == Utils.FromString(client.Player.DailyQuest.Goal))
                {
                    client.SendPacket(new QuestRedeemResponsePacket
                    {
                        Success = true,
                        Message = client.Player.GetLanguageString("server.quest_complete")
                    });
                    client.Player.Inventory[packet.Object.SlotId] = null;
                    if (client.Player.DailyQuest.Tier == 3)
                        client.Player.Tokens = db.UpdateFortuneToken(client.Account, +2);
                    else
                        client.Player.Tokens = db.UpdateFortuneToken(client.Account, +1);
                    var cmd = db.CreateQuery();
                    int tier = client.Player.DailyQuest.Tier == 3 ? -1 : (client.Player.DailyQuest.Tier + 1);
                    cmd.CommandText = "UPDATE dailyquests SET tier=@tier WHERE accId=@accId;";
                    cmd.Parameters.AddWithValue("@accId", client.Account.AccountId);
                    cmd.Parameters.AddWithValue("@tier", tier);
                    int v = cmd.ExecuteNonQuery();
                    client.Player.DailyQuest = db.GetDailyQuest(client.Account.AccountId, Manager.GameData);
                    client.Player.UpdateCount++;
                    client.Player.SaveToCharacter();
                }
            }
        }
    }
}