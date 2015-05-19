﻿#region

using db;
using db.data;
using log4net;
using log4net.Config;
using MailKit.Net.Smtp;
using MimeKit;
using server.sfx;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

#endregion

namespace server
{
    internal class Program
    {
        private static readonly List<HttpListenerContext> currentRequests = new List<HttpListenerContext>();

        private static HttpListener listener;

        internal static SimpleSettings Settings { get; set; }

        internal static XmlData GameData { get; set; }

        internal static Database Database { get; set; }

        internal static ILog logger { get; } = LogManager.GetLogger("Server");

        internal static string InstanceId { get; set; }
        public static string ServerDomain { get; private set; }
        public static int ServerPort { get; private set; }

        private static void Main(string[] args)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net_server.config"));

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.Name = "Entry";

            Settings = new SimpleSettings("server");
            Database = new Database(
                Settings.GetValue<string>("db_host", "127.0.0.1"),
                Settings.GetValue<string>("db_database", "rotmgprod"),
                Settings.GetValue<string>("db_user", "root"),
                Settings.GetValue<string>("db_auth", ""));
            GameData = new XmlData();

            ServerDomain = Settings.GetValue("serverDomain", "127.0.0.1");
            ServerPort = Settings.GetValue<int>("port", "80");
            InstanceId = Guid.NewGuid().ToString();
            Console.CancelKeyPress += (sender, e) => e.Cancel = true;

            var port = Settings.GetValue<int>("port", "80");

            if (RunPreCheck(port))
            {
                listener = new HttpListener();
                listener.Prefixes.Add($"http://*:{port}/");
                listener.Prefixes.Add("https://*:8443/");
                listener.Start();

                listener.BeginGetContext(ListenerCallback, null);
                logger.Info($"Listening at port {port}...");
            }
            else
                logger.Error($"Port {port} is occupied. Can't start listening...\nPress ESC to exit.");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;

            logger.Info("Terminating...");
            //To prevent a char/list account in use if
            //both servers are closed at the same time
            while (currentRequests.Count > 0) ;
            listener?.Stop();
            GameData.Dispose();
        }

        private static bool RunPreCheck(int port) => IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections().All(_ => _.LocalEndPoint.Port != port) && IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().All(_ => _.Port != port);

        private static void ListenerCallback(IAsyncResult ar)
        {
            try
            {
                if (!listener.IsListening) return;
                var context = listener.EndGetContext(ar);
                listener.BeginGetContext(ListenerCallback, null);
                ProcessRequest(context);
            }
            catch
            {
            }
        }

        private static void ProcessRequest(HttpListenerContext context)
        {
            try
            {
                logger.InfoFormat("Request \"{0}\" from: {1}",
                    context.Request.Url.LocalPath, context.Request.RemoteEndPoint);

                if (context.Request.Url.LocalPath.Contains("sfx") || context.Request.Url.LocalPath.Contains("music"))
                {
                    //To load the sound effects c:
                    new Sfx().HandleRequest(context);
                    context.Response.Close();
                    return;
                }

                Object handler;
                Type t;
                string s;
                if (context.Request.Url.LocalPath.IndexOf(".") == -1)
                    s = "server" + context.Request.Url.LocalPath.Replace("/", ".");
                else
                    s = "server" + context.Request.Url.LocalPath.Remove(context.Request.Url.LocalPath.IndexOf(".")).Replace("/", ".");
                if ((t = Type.GetType(s)) == null)
                {
                    using (var wtr = new StreamWriter(context.Response.OutputStream))
                    {
                        var file = "game" + (context.Request.RawUrl == "/" ? "/index.html" : context.Request.RawUrl);
                        if (file.Contains("?"))
                            file = file.Remove(file.IndexOf('?'));
                        if (File.Exists(file))
                        {
                            if (file.StartsWith("game/Testing.html"))
                                file = Settings.GetValue<bool>("testingOnline", "false") ? "game/Testing.html" : "game/TestingIsOffline.html";
                            SendFile(file, context);
                        }
                        else
                            SendFile("game/404.html", context);
                    }
                }
                else
                {
                    handler = Activator.CreateInstance(t, null, null);
                    if (!(handler is RequestHandler))
                    {
                        if (handler == null)
                            using (var wtr = new StreamWriter(context.Response.OutputStream))
                                wtr.Write("<Error>Class \"{0}\" not found.</Error>", t.FullName);
                        else
                            using (var wtr = new StreamWriter(context.Response.OutputStream))
                                wtr.Write("<Error>Class \"{0}\" is not of the type RequestHandler.</Error>", t.FullName);
                    }
                    else
                        (handler as RequestHandler).HandleRequest(context);
                }
            }
            catch (Exception e)
            {
                currentRequests.Remove(context);
                using (var wtr = new StreamWriter(context.Response.OutputStream))
                    wtr.Write(e.ToString());
                logger.Error(e);
            }

            context.Response.Close();
        }

        private static readonly Dictionary<string, string> replaceVars = new Dictionary<string, string>()
        {
            {"{URL}", "PROPERTYCALL:RawUrl"},
            {"{GAMECLIENT}", "PATH:game/version.txt"},
            {"{TESTINGCLIENT}", "PATH:game/testingVersion.txt"},
            {"{TRANSFERENGINEVERSION}", account.getProdAccount.TRANSFERENGINEVERSION},
        };

        public static void SendFile(string path, HttpListenerContext context)
        {
            context.Response.ContentType = getContentType(new FileInfo(path).Extension);
            byte[] buffer;

            if (context.Response.ContentType == "text/html" || context.Response.ContentType == "text/javascript" || context.Response.ContentType == "text/css")
            {
                using (var rdr = File.OpenText(path))
                {
                    var send = rdr.ReadToEnd();
                    foreach (var toReplace in replaceVars)
                    {
                        var tmp = String.Empty;
                        if (toReplace.Value.StartsWith("PATH"))
                        {
                            using (var r = File.OpenText(toReplace.Value.Split(':')[1]))
                                tmp = r.ReadToEnd();

                            send = send.Replace(toReplace.Key, tmp);
                        }
                        else if (toReplace.Value.StartsWith("PROPERTYCALL"))
                        {
                            var property = context.Request.GetType().GetProperty(toReplace.Value.Split(':')[1]);
                            if (property != null)
                                send = send.Replace(toReplace.Key, property.GetValue(context.Request).ToString());
                        }
                        else
                            send = send.Replace(toReplace.Key, toReplace.Value);
                    }
                    buffer = Encoding.UTF8.GetBytes(send);
                }
            }
            else
            {
                using (Stream s = File.OpenRead(path))
                {
                    buffer = new byte[s.Length];
                    var length = s.Read(buffer, 0, (int)s.Length);
                    Array.Resize(ref buffer, length);
                }
            }
            context.Response.StatusCode = 200;
            context.Response.StatusDescription = "OK";
            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        private static string getContentType(string fileExtention)
        {
            var plain = fileExtention;
            if (fileExtention.StartsWith("."))
                plain = fileExtention.Remove(0, 1);
            var ret = "text/html";

            switch (plain)
            {
                case "html":
                case "shtml":
                case "htm":
                    ret = "text/html";
                    break;

                case "js":
                    ret = "text/javascript";
                    break;

                case "swf":
                    ret = "application/x-shockwave-flash";
                    break;

                case "css":
                    ret = "text/css";
                    break;

                case "png":
                    ret = "image/png";
                    break;

                case "gif":
                    ret = "image/gif";
                    break;
            }

            return ret;
        }

        public static void SendEmail(System.Net.Mail.MailMessage message, bool enableSsl)
        {
            try
            {
                var m = new MimeMessage();
                m.From.Add(new MailboxAddress("Forgot Password", message.From.Address));
                m.To.Add(new MailboxAddress("", message.To[0].Address));
                m.Subject = message.Subject;
                if (message.IsBodyHtml)
                    m.Body = new TextPart("html") { Text = message.Body };
                else
                    m.Body = new TextPart("plain") { Text = message.Body };

                using (var client = new SmtpClient())
                {
                    client.Connect(Settings.GetValue<string>("smtpHost"), Settings.GetValue<int>("smtpPort"), enableSsl);
                    client.Authenticate(new NetworkCredential(Settings.GetValue<string>("serverEmail"), Settings.GetValue<string>("serverEmailPassword")));
                    client.Send(m);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}