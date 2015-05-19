namespace Client_Updater
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.localhost_btn = new System.Windows.Forms.Button();
            this.c453_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // localhost_btn
            // 
            this.localhost_btn.Location = new System.Drawing.Point(145, 178);
            this.localhost_btn.Name = "localhost_btn";
            this.localhost_btn.Size = new System.Drawing.Size(127, 23);
            this.localhost_btn.TabIndex = 0;
            this.localhost_btn.Text = "Localhost";
            this.localhost_btn.UseVisualStyleBackColor = true;
            this.localhost_btn.Click += new System.EventHandler(this.localhost_btn_Click);
            // 
            // c453_btn
            // 
            this.c453_btn.Location = new System.Drawing.Point(244, 191);
            this.c453_btn.Name = "c453_btn";
            this.c453_btn.Size = new System.Drawing.Size(127, 23);
            this.c453_btn.TabIndex = 1;
            this.c453_btn.Text = "c453.pw";
            this.c453_btn.UseVisualStyleBackColor = true;
            this.c453_btn.Click += new System.EventHandler(this.c453_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status: Waiting...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 3;
            this.button1.TabStop = false;
            this.button1.Text = "KrazyShank";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 54);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(320, 118);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(312, 76);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Program";
            // 
            // tabPage2
            // 
            this.tabPage2.AllowDrop = true;
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(312, 76);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Credits";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 218);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c453_btn);
            this.Controls.Add(this.localhost_btn);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "Client Updater";
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button localhost_btn;
        private System.Windows.Forms.Button c453_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

