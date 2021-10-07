namespace LZLTetris
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelGame = new System.Windows.Forms.Panel();
            this.Mask = new System.Windows.Forms.Panel();
            this.labelShowStop = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmTheStopMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmList = new System.Windows.Forms.ToolStripMenuItem();
            this.chAchievement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGameSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsResf = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmTheMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExitTheGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStop1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSeeTheHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMAboutTheLZTetris = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsHelpInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelGame.SuspendLayout();
            this.Mask.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelGame.BackgroundImage")));
            this.panelGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelGame.Controls.Add(this.Mask);
            this.panelGame.Controls.Add(this.menuStrip);
            this.panelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGame.Location = new System.Drawing.Point(0, 0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(949, 534);
            this.panelGame.TabIndex = 17;
            this.panelGame.TabStop = true;
            this.panelGame.BackgroundImageChanged += new System.EventHandler(this.panelGame_BackgroundImageChanged);
            // 
            // Mask
            // 
            this.Mask.Controls.Add(this.labelShowStop);
            this.Mask.Location = new System.Drawing.Point(0, 28);
            this.Mask.Name = "Mask";
            this.Mask.Size = new System.Drawing.Size(949, 506);
            this.Mask.TabIndex = 19;
            // 
            // labelShowStop
            // 
            this.labelShowStop.AutoSize = true;
            this.labelShowStop.BackColor = System.Drawing.Color.Transparent;
            this.labelShowStop.Font = new System.Drawing.Font("楷体", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelShowStop.Location = new System.Drawing.Point(367, 218);
            this.labelShowStop.Name = "labelShowStop";
            this.labelShowStop.Size = new System.Drawing.Size(223, 43);
            this.labelShowStop.TabIndex = 0;
            this.labelShowStop.Text = "暂停中...";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.menuStrip.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tsmStop1,
            this.toolStripMenuItem6,
            this.tsmExit});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(949, 28);
            this.menuStrip.TabIndex = 17;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmStop,
            this.toolStripSeparator1,
            this.tsmTheStopMenu,
            this.tsmList,
            this.chAchievement,
            this.tsmGameSet,
            this.toolStripSeparator2,
            this.tsResf,
            this.tsmTheMainMenu,
            this.tsmExitTheGame});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 24);
            this.toolStripMenuItem1.Text = "菜单";
            // 
            // tsmStop
            // 
            this.tsmStop.Name = "tsmStop";
            this.tsmStop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmStop.Size = new System.Drawing.Size(267, 24);
            this.tsmStop.Text = "暂停";
            this.tsmStop.Click += new System.EventHandler(this.tsmStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(264, 6);
            // 
            // tsmTheStopMenu
            // 
            this.tsmTheStopMenu.Name = "tsmTheStopMenu";
            this.tsmTheStopMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmTheStopMenu.Size = new System.Drawing.Size(267, 24);
            this.tsmTheStopMenu.Text = "暂停菜单";
            this.tsmTheStopMenu.Click += new System.EventHandler(this.tsmTheStopMenu_Click);
            // 
            // tsmList
            // 
            this.tsmList.Name = "tsmList";
            this.tsmList.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.tsmList.Size = new System.Drawing.Size(267, 24);
            this.tsmList.Text = "排行榜";
            this.tsmList.Click += new System.EventHandler(this.tsmList_Click);
            // 
            // chAchievement
            // 
            this.chAchievement.Name = "chAchievement";
            this.chAchievement.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.chAchievement.Size = new System.Drawing.Size(267, 24);
            this.chAchievement.Text = "成就";
            this.chAchievement.Click += new System.EventHandler(this.chAchievement_Click);
            // 
            // tsmGameSet
            // 
            this.tsmGameSet.Name = "tsmGameSet";
            this.tsmGameSet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmGameSet.Size = new System.Drawing.Size(267, 24);
            this.tsmGameSet.Text = "游戏设置";
            this.tsmGameSet.Click += new System.EventHandler(this.tsmGameSet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(264, 6);
            // 
            // tsResf
            // 
            this.tsResf.Name = "tsResf";
            this.tsResf.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsResf.Size = new System.Drawing.Size(267, 24);
            this.tsResf.Text = "重新开始游戏";
            this.tsResf.Click += new System.EventHandler(this.tsResf_Click);
            // 
            // tsmTheMainMenu
            // 
            this.tsmTheMainMenu.Name = "tsmTheMainMenu";
            this.tsmTheMainMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.tsmTheMainMenu.Size = new System.Drawing.Size(267, 24);
            this.tsmTheMainMenu.Text = "返回到主菜单";
            this.tsmTheMainMenu.Click += new System.EventHandler(this.tsmTheMainMenu_Click);
            // 
            // tsmExitTheGame
            // 
            this.tsmExitTheGame.Name = "tsmExitTheGame";
            this.tsmExitTheGame.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmExitTheGame.Size = new System.Drawing.Size(267, 24);
            this.tsmExitTheGame.Text = "退出游戏";
            this.tsmExitTheGame.Click += new System.EventHandler(this.tsmExitTheGame_Click);
            // 
            // tsmStop1
            // 
            this.tsmStop1.Name = "tsmStop1";
            this.tsmStop1.Size = new System.Drawing.Size(61, 24);
            this.tsmStop1.Text = "暂停";
            this.tsmStop1.Click += new System.EventHandler(this.tsmStop_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSeeTheHelp,
            this.toolStripSeparator4,
            this.TSMAboutTheLZTetris,
            this.toolStripSeparator3,
            this.tsHelpInformation,
            this.tsmVer});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(61, 24);
            this.toolStripMenuItem6.Text = "帮助";
            // 
            // tsmSeeTheHelp
            // 
            this.tsmSeeTheHelp.Name = "tsmSeeTheHelp";
            this.tsmSeeTheHelp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tsmSeeTheHelp.Size = new System.Drawing.Size(307, 24);
            this.tsmSeeTheHelp.Text = "查看帮助";
            this.tsmSeeTheHelp.Click += new System.EventHandler(this.tsmSeeTheHelp_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(304, 6);
            // 
            // TSMAboutTheLZTetris
            // 
            this.TSMAboutTheLZTetris.Name = "TSMAboutTheLZTetris";
            this.TSMAboutTheLZTetris.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.TSMAboutTheLZTetris.Size = new System.Drawing.Size(307, 24);
            this.TSMAboutTheLZTetris.Text = "关于LZ俄罗斯方块";
            this.TSMAboutTheLZTetris.Click += new System.EventHandler(this.TSMAboutTheLZTetris_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(304, 6);
            // 
            // tsHelpInformation
            // 
            this.tsHelpInformation.Name = "tsHelpInformation";
            this.tsHelpInformation.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsHelpInformation.Size = new System.Drawing.Size(307, 24);
            this.tsHelpInformation.Text = "帮助人员信息";
            this.tsHelpInformation.Click += new System.EventHandler(this.tsHelpInformation_Click);
            // 
            // tsmVer
            // 
            this.tsmVer.Name = "tsmVer";
            this.tsmVer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmVer.Size = new System.Drawing.Size(307, 24);
            this.tsmVer.Text = "当前版本新增内容";
            this.tsmVer.Click += new System.EventHandler(this.tsmVer_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(61, 24);
            this.tsmExit.Text = "退出";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(949, 534);
            this.Controls.Add(this.panelGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LZ俄罗斯方块";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.Mask.ResumeLayout(false);
            this.Mask.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmList;
        private System.Windows.Forms.ToolStripMenuItem tsmGameSet;
        private System.Windows.Forms.ToolStripMenuItem tsmStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmExitTheGame;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmSeeTheHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem TSMAboutTheLZTetris;
        private System.Windows.Forms.ToolStripMenuItem tsmStop1;
        private System.Windows.Forms.Panel Mask;
        private System.Windows.Forms.ToolStripMenuItem tsmTheStopMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmTheMainMenu;
        private System.Windows.Forms.ToolStripMenuItem chAchievement;
        private System.Windows.Forms.Label labelShowStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem tsResf;
        private System.Windows.Forms.ToolStripMenuItem tsHelpInformation;
        private System.Windows.Forms.ToolStripMenuItem tsmVer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;


    }
}

