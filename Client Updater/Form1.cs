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

        private void localhost_btn_Click(object sender, EventArgs e)
        {
            updater = new ClientUpdater("127.0.0.1", label1);
            updater.UpdateClient();
        }

        private void c453_btn_Click(object sender, EventArgs e)
        {
            updater = new ClientUpdater("25.103.138.168:8080", label1);
            updater.UpdateClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updater = new ClientUpdater("71.231.167.96", label1);
            updater.UpdateClient();
        }
    }
}