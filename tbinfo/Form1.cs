using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// TODO 他に最大化しているアプリがあるときの判定、マルチウィンドウでの判定も気にする

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
            if (!IsFullscreenAppOnScreen)
            {
                this.Visible = true;
                var rect = GetTaskTray();
                if (!IsTaskbarLeftAligned)
                {
                    this.Left = IsWIndowsWidgetVisible ? 160 : 0;
                }
                else
                {
                    this.Left = rect.Left - this.Width - (IsWIndowsWidgetVisible ? 160 : 0);
                }
                this.Top = rect.Top;
                SetWindowTopmost();
            }
            else
            {
                this.Visible = false;
            }
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
                text += Environment.GetEnvironmentVariable("SESSIONNAME") + Environment.NewLine;
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

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr parentWnd, IntPtr previousWnd, string className, string windowText);

        private void SetWindowTopmost()
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
        }

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static bool IsWindowsThemeLight
        {
            get
            {
                const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
                const string registryValueName = "SystemUsesLightTheme";

                var key = Registry.CurrentUser.OpenSubKey(registryKeyPath);
                if (key == null)
                {
                    return true;
                }
                var v = (int)key.GetValue(registryValueName);
                return v > 0;
            }
        }

        public static bool IsWIndowsWidgetVisible
        {
            get
            {
                const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                const string registryValueName = "TaskbarDa";

                var key = Registry.CurrentUser.OpenSubKey(registryKeyPath);
                if (key == null)
                {
                    return false;
                }
                var v = (int)key.GetValue(registryValueName);
                return v != 0;
            }
        }

        public static bool IsTaskbarLeftAligned
        {
            get
            {
                const string registryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";
                const string registryValueName = "TaskbarAl";

                var key = Registry.CurrentUser.OpenSubKey(registryKeyPath);
                if (key == null)
                    return false;
                var v = (int)key.GetValue(registryValueName);
                return v == 0;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private static Rectangle GetTaskTray()
        {
            // タスクバーのウィンドウハンドルの取得
            IntPtr taskbarWindow = FindWindow("Shell_TrayWnd", null);
            if (taskbarWindow == IntPtr.Zero)
            {
                return new Rectangle(-1, -1, -1, -1);
            }

            // タスクトレイのウィンドウハンドルの取得
            IntPtr tasktrayWindow = FindWindowEx(taskbarWindow, IntPtr.Zero, "TrayNotifyWnd",null);
            if (taskbarWindow == IntPtr.Zero)
            {
                return new Rectangle(-1, -1, -1, -1);
            }

            // タスクバーの位置とサイズの取得
            if (!GetWindowRect(tasktrayWindow, out RECT rect))
            {
                return new Rectangle(-1, -1, -1, -1);
            }

            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        public static bool IsFullscreenAppOnScreen
        {
            get
            {
                var screenBounds = Screen.PrimaryScreen.Bounds;
                var fullscreenWindows = new List<IntPtr>();
                IntPtr foregroundWindow = GetForegroundWindow();

                var result = false;
                EnumWindows((hWnd, lParam) =>
                {
                    if (IsWindowVisible(hWnd) && GetWindowRect(hWnd, out RECT rect))
                    {
                        var windowBounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

                        // ウィンドウがスクリーン全体を覆っているか確認
                        if (windowBounds == screenBounds)
                        {
                            // ウィンドウがフォアグラウンドウィンドウであるか確認
                            if (hWnd == foregroundWindow)
                            {
                                result = true;
                                return false;
                            }
                        }
                    }
                    return true;
                }, IntPtr.Zero);

                return result;
            }
        }

    }
}
