using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace TbInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.uSERDOMAINToolStripMenuItem.Checked = tbInfo.Properties.Settings.Default.userdomain;
            this.cOMPUTERNAMEToolStripMenuItem.Checked = tbInfo.Properties.Settings.Default.computername;
            this.uSERNAMEToolStripMenuItem.Checked = tbInfo.Properties.Settings.Default.username;
            this.sESSIONNAMEToolStripMenuItem.Checked = tbInfo.Properties.Settings.Default.sessionname;
            this.updatePosition();
            this.updateTheme();
            this.updateLabel();

            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.updatePosition();
            this.updateTheme();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void uSERDOMAINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.uSERDOMAINToolStripMenuItem.Checked = !this.uSERDOMAINToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.userdomain = this.uSERDOMAINToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.Save();
            this.updateLabel();
        }

        private void cOMPUTERNAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cOMPUTERNAMEToolStripMenuItem.Checked = !this.cOMPUTERNAMEToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.computername = this.cOMPUTERNAMEToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.Save();
            this.updateLabel();
        }

        private void uSERNAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.uSERNAMEToolStripMenuItem.Checked = !this.uSERNAMEToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.username = this.uSERNAMEToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.Save();
            this.updateLabel();
        }

        private void sESSIONNAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.sESSIONNAMEToolStripMenuItem.Checked = !this.sESSIONNAMEToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.sessionname = this.sESSIONNAMEToolStripMenuItem.Checked;
            tbInfo.Properties.Settings.Default.Save();
            this.updateLabel();
        }

        private void customTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            var text = Microsoft.VisualBasic.Interaction.InputBox("input custom text", "custom text", tbInfo.Properties.Settings.Default.custom_text);
            if (text != "")
            {
                tbInfo.Properties.Settings.Default.custom_text = text;
                tbInfo.Properties.Settings.Default.Save();
                this.updateLabel();
            }
            this.timer1.Start();
        }

        private void updatePosition()
        {
            this.Left = 0;
            this.Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 48;
            this.TopMost = false;
            this.TopMost = true;
        }

        private void updateLabel()
        {
            var text = "";
            if (this.uSERDOMAINToolStripMenuItem.Checked)
            {
                text += Environment.UserDomainName + Environment.NewLine;
            }
            if (this.cOMPUTERNAMEToolStripMenuItem.Checked)
            {
                text += Environment.MachineName + Environment.NewLine;
            }
            if (this.uSERNAMEToolStripMenuItem.Checked)
            {
                text += Environment.UserName + Environment.NewLine;
            }
            if (this.sESSIONNAMEToolStripMenuItem.Checked)
            {
                text +=  Environment.GetEnvironmentVariable("SESSIONNAME") + Environment.NewLine;
            }
            text += tbInfo.Properties.Settings.Default.custom_text + Environment.NewLine;
            this.label1.Text = text;
        }

        private void updateTheme()
        {
            if (Form1.IsWindowsThemeLight)
            {
                this.TransparencyKey = System.Drawing.SystemColors.Control;
                this.ForeColor = System.Drawing.SystemColors.ControlText;
                this.BackColor = System.Drawing.SystemColors.Control;
                this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
                this.label1.BackColor = System.Drawing.SystemColors.Control;
            }
            else
            {
                this.TransparencyKey = System.Drawing.SystemColors.ControlText;
                this.ForeColor = System.Drawing.SystemColors.Control;
                this.BackColor = System.Drawing.SystemColors.ControlText;
                this.label1.ForeColor = System.Drawing.SystemColors.Control;
                this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            }
        }

        public static bool IsWindowsThemeLight
        {
            get
            {
                const string WindowsThemeRegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
                const string WindowsThemeRegistryValueName = "SystemUsesLightTheme";

                var key = Registry.CurrentUser.OpenSubKey(WindowsThemeRegistryKeyPath);
                if (key == null)
                    return true;
                var v = (int)key.GetValue(WindowsThemeRegistryValueName);
                return v > 0;
            }
        }
    }
}
