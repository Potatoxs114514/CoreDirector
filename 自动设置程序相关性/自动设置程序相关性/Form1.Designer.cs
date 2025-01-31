namespace 自动设置程序相关性
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SetCoreButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Log = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CoreList = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProcessList = new System.Windows.Forms.ListBox();
            this.CPUHexMask = new System.Windows.Forms.TextBox();
            this.ProcessSelectBox = new System.Windows.Forms.ComboBox();
            this.ExecuteTimer = new System.Windows.Forms.Timer(this.components);
            this.ICON = new System.Windows.Forms.NotifyIcon(this.components);
            this.IconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.性能模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高性能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.平衡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开机启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.IconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetCoreButton
            // 
            this.SetCoreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetCoreButton.Location = new System.Drawing.Point(584, 12);
            this.SetCoreButton.Name = "SetCoreButton";
            this.SetCoreButton.Size = new System.Drawing.Size(75, 23);
            this.SetCoreButton.TabIndex = 2;
            this.SetCoreButton.Text = "分配";
            this.SetCoreButton.UseVisualStyleBackColor = true;
            this.SetCoreButton.Click += new System.EventHandler(this.SetCoreButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 397);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "程序调度";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Log);
            this.groupBox4.Location = new System.Drawing.Point(421, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 370);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "日志";
            // 
            // Log
            // 
            this.Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Log.Location = new System.Drawing.Point(7, 21);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(206, 343);
            this.Log.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CoreList);
            this.groupBox3.Location = new System.Drawing.Point(214, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 370);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "核心";
            // 
            // CoreList
            // 
            this.CoreList.CheckOnClick = true;
            this.CoreList.FormattingEnabled = true;
            this.CoreList.Location = new System.Drawing.Point(6, 20);
            this.CoreList.Name = "CoreList";
            this.CoreList.Size = new System.Drawing.Size(188, 340);
            this.CoreList.TabIndex = 0;
            this.CoreList.Click += new System.EventHandler(this.CoreList_Click);
            this.CoreList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CoreList_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProcessList);
            this.groupBox2.Location = new System.Drawing.Point(7, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 370);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "进程";
            // 
            // ProcessList
            // 
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.ItemHeight = 12;
            this.ProcessList.Location = new System.Drawing.Point(7, 20);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(187, 340);
            this.ProcessList.TabIndex = 0;
            this.ProcessList.SelectedIndexChanged += new System.EventHandler(this.ProcessList_SelectedIndexChanged);
            this.ProcessList.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ProcessList_PreviewKeyDown);
            // 
            // CPUHexMask
            // 
            this.CPUHexMask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CPUHexMask.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPUHexMask.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CPUHexMask.Location = new System.Drawing.Point(433, 13);
            this.CPUHexMask.MaxLength = 50;
            this.CPUHexMask.Multiline = true;
            this.CPUHexMask.Name = "CPUHexMask";
            this.CPUHexMask.ReadOnly = true;
            this.CPUHexMask.Size = new System.Drawing.Size(144, 21);
            this.CPUHexMask.TabIndex = 4;
            this.CPUHexMask.Text = "0x0000000000000000";
            this.CPUHexMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CPUHexMask.TextChanged += new System.EventHandler(this.CPUHexMask_TextChanged);
            // 
            // ProcessSelectBox
            // 
            this.ProcessSelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProcessSelectBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ProcessSelectBox.FormattingEnabled = true;
            this.ProcessSelectBox.Location = new System.Drawing.Point(13, 13);
            this.ProcessSelectBox.Name = "ProcessSelectBox";
            this.ProcessSelectBox.Size = new System.Drawing.Size(414, 20);
            this.ProcessSelectBox.TabIndex = 5;
            this.ProcessSelectBox.Click += new System.EventHandler(this.ProcessSelectBox_Click);
            // 
            // ExecuteTimer
            // 
            this.ExecuteTimer.Enabled = true;
            this.ExecuteTimer.Interval = 10000;
            this.ExecuteTimer.Tick += new System.EventHandler(this.ExecuteTimer_Tick);
            // 
            // ICON
            // 
            this.ICON.ContextMenuStrip = this.IconMenu;
            this.ICON.Icon = ((System.Drawing.Icon)(resources.GetObject("ICON.Icon")));
            this.ICON.Text = "CoreDirector";
            this.ICON.Visible = true;
            this.ICON.DoubleClick += new System.EventHandler(this.ICON_DoubleClick);
            // 
            // IconMenu
            // 
            this.IconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.IconMenu.Name = "IconMenu";
            this.IconMenu.Size = new System.Drawing.Size(101, 70);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.性能模式ToolStripMenuItem,
            this.开机启动ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 性能模式ToolStripMenuItem
            // 
            this.性能模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.默认ToolStripMenuItem,
            this.高性能ToolStripMenuItem,
            this.平衡ToolStripMenuItem});
            this.性能模式ToolStripMenuItem.Name = "性能模式ToolStripMenuItem";
            this.性能模式ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.性能模式ToolStripMenuItem.Text = "电源模式";
            // 
            // 默认ToolStripMenuItem
            // 
            this.默认ToolStripMenuItem.Checked = true;
            this.默认ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.默认ToolStripMenuItem.Name = "默认ToolStripMenuItem";
            this.默认ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.默认ToolStripMenuItem.Text = "跟随系统";
            this.默认ToolStripMenuItem.Click += new System.EventHandler(this.默认ToolStripMenuItem_Click);
            // 
            // 高性能ToolStripMenuItem
            // 
            this.高性能ToolStripMenuItem.Name = "高性能ToolStripMenuItem";
            this.高性能ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.高性能ToolStripMenuItem.Text = "高性能";
            this.高性能ToolStripMenuItem.Click += new System.EventHandler(this.高性能ToolStripMenuItem_Click);
            // 
            // 平衡ToolStripMenuItem
            // 
            this.平衡ToolStripMenuItem.Name = "平衡ToolStripMenuItem";
            this.平衡ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.平衡ToolStripMenuItem.Text = "平衡";
            this.平衡ToolStripMenuItem.Click += new System.EventHandler(this.平衡ToolStripMenuItem_Click);
            // 
            // 开机启动ToolStripMenuItem
            // 
            this.开机启动ToolStripMenuItem.Name = "开机启动ToolStripMenuItem";
            this.开机启动ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开机启动ToolStripMenuItem.Text = "开机启动";
            this.开机启动ToolStripMenuItem.Click += new System.EventHandler(this.开机启动ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 450);
            this.Controls.Add(this.ProcessSelectBox);
            this.Controls.Add(this.CPUHexMask);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SetCoreButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoreDirector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.IconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SetCoreButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.CheckedListBox CoreList;
        private System.Windows.Forms.TextBox CPUHexMask;
        private System.Windows.Forms.ComboBox ProcessSelectBox;
        private System.Windows.Forms.Timer ExecuteTimer;
        private System.Windows.Forms.NotifyIcon ICON;
        private System.Windows.Forms.ContextMenuStrip IconMenu;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ListBox ProcessList;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 性能模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 默认ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高性能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 平衡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开机启动ToolStripMenuItem;
    }
}

