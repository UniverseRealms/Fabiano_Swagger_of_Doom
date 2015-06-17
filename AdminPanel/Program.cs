﻿using System;
using System.Windows.Forms;

namespace AdminPanel
{
    internal static class Program
    {
        /// <summary>Der Haupteinstiegspunkt für die Anwendung.</summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new AdminPanel());
            }
            catch (ObjectDisposedException) { }
        }
    }
}
