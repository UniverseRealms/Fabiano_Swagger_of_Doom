using db;
using System.Text;

namespace server.account
{
    internal class listGiftCodes : RequestHandler
    {
        protected override void HandleRequest()
        {
            using (Database db = new Database())
            {
                string codes = string.Empty;
                string status = string.Empty;
                var cmd = db.CreateQuery();
                cmd.CommandText = "SELECT * FROM giftCodes ORDER BY code ASC";
                cmd.Parameters.AddWithValue("@code", Query["code"]);

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        foreach (var item in rdr)
                        {
                            status += $"{rdr.GetString("code")} <a href='{Program.ServerDomain}:{Program.ServerPort}/account/checkGiftCode?code={rdr.GetString("code")}' style='color: red'>Check contents</a></br>";
                        }
                    }
                }

                byte[] res = new byte[0];
                if (status.IsNullOrWhiteSpace())
                {
                    res = Encoding.UTF8.GetBytes(
 $@"<html>
	<head>
		<title>Giftcode list</title>
	</head>
	<body style='background: #333333'>
		<h1 style='color: #EEEEEE; text-align: center'>
            {status}
		</h1>
	</body>
</html>");
                }
                else
                {
                    res = Encoding.UTF8.GetBytes(
 $@"<html>
	<head>
		<title>Giftcode list</title>
	</head>
	<body style='background: #333333'>
		<h1 style='color: #EEEEEE; text-align: center'>
			The database contains the following codes:
		</h1>
		<h3 style='color: #EEEEEE; text-align: center'>
	        {status}
		</h3>
    </body>
</html>");
                }

                Context.Response.OutputStream.Write(res, 0, res.Length);
            }
        }
    }
}
