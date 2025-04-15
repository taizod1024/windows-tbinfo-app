namespace TbInfo
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uSERDOMAINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMPUTERNAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uSERNAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sESSIONNAMEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.customTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(18, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "text1 text2 text3 text4 text5 text6 text7 text8 text9";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSERDOMAINToolStripMenuItem,
            this.cOMPUTERNAMEToolStripMenuItem,
            this.uSERNAMEToolStripMenuItem,
            this.sESSIONNAMEToolStripMenuItem,
            this.toolStripSeparator2,
            this.customTextToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(170, 148);
            // 
            // uSERDOMAINToolStripMenuItem
            // 
            this.uSERDOMAINToolStripMenuItem.Name = "uSERDOMAINToolStripMenuItem";
            this.uSERDOMAINToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.uSERDOMAINToolStripMenuItem.Text = "USERDOMAIN";
            this.uSERDOMAINToolStripMenuItem.Click += new System.EventHandler(this.uSERDOMAINToolStripMenuItem_Click);
            // 
            // cOMPUTERNAMEToolStripMenuItem
            // 
            this.cOMPUTERNAMEToolStripMenuItem.Name = "cOMPUTERNAMEToolStripMenuItem";
            this.cOMPUTERNAMEToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cOMPUTERNAMEToolStripMenuItem.Text = "COMPUTERNAME";
            this.cOMPUTERNAMEToolStripMenuItem.Click += new System.EventHandler(this.cOMPUTERNAMEToolStripMenuItem_Click);
            // 
            // uSERNAMEToolStripMenuItem
            // 
            this.uSERNAMEToolStripMenuItem.Name = "uSERNAMEToolStripMenuItem";
            this.uSERNAMEToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.uSERNAMEToolStripMenuItem.Text = "USERNAME";
            this.uSERNAMEToolStripMenuItem.Click += new System.EventHandler(this.uSERNAMEToolStripMenuItem_Click);
            // 
            // sESSIONNAMEToolStripMenuItem
            // 
            this.sESSIONNAMEToolStripMenuItem.Name = "sESSIONNAMEToolStripMenuItem";
            this.sESSIONNAMEToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.sESSIONNAMEToolStripMenuItem.Text = "SESSIONNAME";
            this.sESSIONNAMEToolStripMenuItem.Click += new System.EventHandler(this.sESSIONNAMEToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(166, 6);
            // 
            // customTextToolStripMenuItem
            // 
            this.customTextToolStripMenuItem.Name = "customTextToolStripMenuItem";
            this.customTextToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customTextToolStripMenuItem.Text = "custom text";
            this.customTextToolStripMenuItem.Click += new System.EventHandler(this.customTextToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.ContextMenuStrip = this.contextMenuStrip1;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 40);
            this.label2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(160, 48);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "tbinfo";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem uSERDOMAINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uSERNAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem customTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMPUTERNAMEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sESSIONNAMEToolStripMenuItem;
    }
}

