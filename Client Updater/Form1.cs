using MetroFramework.Forms;
using System;

namespace Client_Updater
{
    public partial class Form1 : MetroForm
    {
        private ClientUpdater updater;

        public Form1()
        {
            InitializeComponent();
        }

        private void runUpdater(string ip)
        {
            updater = new ClientUpdater(ip, label1);
            updater.UpdateClient();
        }

        private void metroTile1_Click(object sender, EventArgs e) => runUpdater(textBox1.Text.ToString());

        private void metroTile2_Click(object sender, EventArgs e) => runUpdater("25.103.138.168:8080");
    }
}
