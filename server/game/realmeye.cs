using db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.game
{
    class realmeye : RequestHandler
    {
        protected override void HandleRequest()
        {
            using (Database db = new Database())
            {
                if (!Query["player"].IsNullOrWhiteSpace())
                {
                    var cmd = db.CreateQuery();
                    cmd.CommandText = "";

                    WriteLine(@"
<html>
    <head>
        <title>Testing Realmeye</title>
    </head>
    <body style='background-color: #333333'>
        <center>
            <h1 style='color: rgb(128, 0, 128)'>xxxx</h1>
        </center>
    </body>
</html>");
                }
                else
                {
                    WriteLine(@"
<html>
    <head>
        <title>Testing Realmeye</title>
    </head>
    <body style='background-color: #333333'>
        <center>
            <h1 style='color: rgb(128, 0, 128)'>No player selected</h1>
        </center>
    </body>
</html>");
                }
            }
        }
    }
}
