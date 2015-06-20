#region

using System.Collections.Generic;
using System.IO;
using System.Text;

#endregion

namespace server.app
{
    internal class getLanguageStrings : RequestHandler
    {
        public static readonly Dictionary<string, string> Languages = new Dictionary<string, string>
        {
            {"de", File.ReadAllText("app/Languages/de.txt")},
            {"en", File.ReadAllText("app/Languages/en.txt")},
            {"es", File.ReadAllText("app/Languages/es.txt")},
            {"fr", File.ReadAllText("app/Languages/fr.txt")},
            {"it", File.ReadAllText("app/Languages/it.txt")},
            {"ru", File.ReadAllText("app/Languages/ru.txt")}
        };

        protected override void HandleRequest()
        {
            string _language;
            byte[] _buf;
            if (Query.AllKeys.Length > 0)
                if (!Languages.TryGetValue(Query["languageType"], out _language))
                    _buf = Encoding.ASCII.GetBytes("<Error>Invalid langauge type.</Error>");
                else
                    _buf = Encoding.ASCII.GetBytes(_language);
            else
                _buf = Encoding.ASCII.GetBytes("<Error>Invalid langauge type.</Error>");
            Context.Response.OutputStream.Write(_buf, 0, _buf.Length);
        }
    }
}
