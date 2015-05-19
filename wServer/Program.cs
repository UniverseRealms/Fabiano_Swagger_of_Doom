﻿#region

using db;
using log4net;
using log4net.Config;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using wServer.networking;
using wServer.realm;

#endregion

namespace wServer
{
    internal static class Program
    {
        public static bool WhiteList { get; private set; }

        public static bool Verify { get; private set; }

        public static bool TestingMerchants { get; private set; }

        internal static SimpleSettings Settings;

        private static readonly ILog logger = LogManager.GetLogger("Server");
        private static RealmManager manager;

        public static DateTime WhiteListTurnOff { get; private set; }

        private static void Main(string[] args)
        {
            Console.Title = "Fabiano Swagger of Doom - World Server";
            try
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net_wServer.config"));

                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                Thread.CurrentThread.Name = "Entry";

                Settings = new SimpleSettings("wServer");
                new Database(
                    Settings.GetValue<string>("db_host", "127.0.0.1"),
                    Settings.GetValue<string>("db_database", "rotmgprod"),
                    Settings.GetValue<string>("db_user", "root"),
                    Settings.GetValue<string>("db_auth", ""));

                manager = new RealmManager(
                    Settings.GetValue<int>("maxClients", "100"),
                    Settings.GetValue<int>("tps", "20"));

                WhiteList = Settings.GetValue<bool>("whiteList", "false");
                Verify = Settings.GetValue<bool>("verifyEmail", "false");
                TestingMerchants = Settings.GetValue<bool>("testingMerchants", "false");
                WhiteListTurnOff = Settings.GetValue<DateTime>("whitelistTurnOff");

                manager.Initialize();
                manager.Run();

                Server server = new Server(manager);
                PolicyServer policy = new PolicyServer();

                Console.CancelKeyPress += (sender, e) => e.Cancel = true;

                policy.Start();
                server.Start();
                if (Settings.GetValue<bool>("broadcastNews", "false") && File.Exists("news.txt"))
                    new Thread(AutoBroadcaster).Start();
                logger.Info("Server initialized.");

                uint key = 0;
                while ((key = (uint)Console.ReadKey(true).Key) != (uint)ConsoleKey.Escape)
                {
                    if (key == (2 | 80))
                        Settings.Reload();
                }

                logger.Info("Terminating...");
                server.Stop();
                policy.Stop();
                manager.Stop();
                logger.Info("Server terminated.");
            }
            catch (Exception e)
            {
                logger.Fatal(e);

                foreach (var c in manager.Clients)
                {
                    c.Value.Disconnect();
                }
                Console.ReadLine();
            }
        }

        public static void SendEmail(MailMessage message, bool enableSsl = true)
        {
            SmtpClient client = new SmtpClient
            {
                Host = Settings.GetValue<string>("smtpHost", "smtp.gmail.com"),
                Port = Settings.GetValue<int>("smtpPort", "587"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials =
                    new NetworkCredential(Settings.GetValue<string>("serverEmail"),
                        Settings.GetValue<string>("serverEmailPassword"))
            };

            client.Send(message);
        }

        private static void AutoBroadcaster()
        {
            var news = File.ReadAllLines("news.txt");
            do
            {
                ChatManager chat = new ChatManager(manager);
                string text = news[new Random().Next(news.Length)];
                if (text.StartsWith("$"))
                    chat.Announce(text.Replace("$", string.Empty));
                else chat.News(text);
                Thread.Sleep(300000); // 5 Minutes
            }
            while (true);
        }
    }
}