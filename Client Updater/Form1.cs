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

        private void localhost_btn_Click(object sender, EventArgs e) => runUpdater("127.0.0.1:8080");
        private void c453_btn_Click(object sender, EventArgs e) => runUpdater("25.108.113.162");
        private void button1_Click(object sender, EventArgs e) => runUpdater("71.231.167.96");

        private void runUpdater(string ip)
        {
            updater = new ClientUpdater(ip, label1);
            updater.UpdateClient();
        }
    }
}
