namespace LZLTetris
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSytem = new System.Windows.Forms.TextBox();
            this.txtPlay02 = new System.Windows.Forms.TextBox();
            this.txtPlay01 = new System.Windows.Forms.TextBox();
            this.labelSytem = new System.Windows.Forms.Label();
            this.labelPlay02 = new System.Windows.Forms.Label();
            this.labelPlay01 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSytem);
            this.groupBox1.Controls.Add(this.txtPlay02);
            this.groupBox1.Controls.Add(this.txtPlay01);
            this.groupBox1.Controls.Add(this.labelSytem);
            this.groupBox1.Controls.Add(this.labelPlay02);
            this.groupBox1.Controls.Add(this.labelPlay01);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "键位";
            // 
            // txtSytem
            // 
            this.txtSytem.BackColor = System.Drawing.SystemColors.Control;
            this.txtSytem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSytem.Location = new System.Drawing.Point(104, 26);
            this.txtSytem.Name = "txtSytem";
            this.txtSytem.ReadOnly = true;
            this.txtSytem.Size = new System.Drawing.Size(538, 23);
            this.txtSytem.TabIndex = 5;
            this.txtSytem.TabStop = false;
            // 
            // txtPlay02
            // 
            this.txtPlay02.BackColor = System.Drawing.SystemColors.Control;
            this.txtPlay02.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlay02.Location = new System.Drawing.Point(104, 103);
            this.txtPlay02.Name = "txtPlay02";
            this.txtPlay02.ReadOnly = true;
            this.txtPlay02.Size = new System.Drawing.Size(538, 23);
            this.txtPlay02.TabIndex = 4;
            this.txtPlay02.TabStop = false;
            // 
            // txtPlay01
            // 
            this.txtPlay01.BackColor = System.Drawing.SystemColors.Control;
            this.txtPlay01.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPlay01.Location = new System.Drawing.Point(104, 63);
            this.txtPlay01.Name = "txtPlay01";
            this.txtPlay01.ReadOnly = true;
            this.txtPlay01.Size = new System.Drawing.Size(538, 23);
            this.txtPlay01.TabIndex = 3;
            this.txtPlay01.TabStop = false;
            // 
            // labelSytem
            // 
            this.labelSytem.AutoSize = true;
            this.labelSytem.Location = new System.Drawing.Point(19, 26);
            this.labelSytem.Name = "labelSytem";
            this.labelSytem.Size = new System.Drawing.Size(89, 20);
            this.labelSytem.TabIndex = 2;
            this.labelSytem.Text = "菜单键：";
            // 
            // labelPlay02
            // 
            this.labelPlay02.AutoSize = true;
            this.labelPlay02.Location = new System.Drawing.Point(19, 102);
            this.labelPlay02.Name = "labelPlay02";
            this.labelPlay02.Size = new System.Drawing.Size(89, 20);
            this.labelPlay02.TabIndex = 1;
            this.labelPlay02.Text = "玩家二：";
            // 
            // labelPlay01
            // 
            this.labelPlay01.AutoSize = true;
            this.labelPlay01.Location = new System.Drawing.Point(19, 64);
            this.labelPlay01.Name = "labelPlay01";
            this.labelPlay01.Size = new System.Drawing.Size(89, 20);
            this.labelPlay01.TabIndex = 0;
            this.labelPlay01.Text = "玩家一：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 236);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模式介绍";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(6, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(636, 201);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(670, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Help";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LZ俄罗斯方块 - 帮助";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Help_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPlay02;
        private System.Windows.Forms.Label labelPlay01;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelSytem;
        private System.Windows.Forms.TextBox txtPlay02;
        private System.Windows.Forms.TextBox txtPlay01;
        private System.Windows.Forms.TextBox txtSytem;
    }
}