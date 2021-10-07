namespace LZLTetris
{
    partial class GameInteractiveForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.table1 = new WindowsTableControl.Table();
            this.table2 = new WindowsTableControl.Table();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.table5 = new WindowsTableControl.Table();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.table3 = new WindowsTableControl.Table();
            this.table4 = new WindowsTableControl.Table();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.table9 = new WindowsTableControl.Table();
            this.table6 = new WindowsTableControl.Table();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.table7 = new WindowsTableControl.Table();
            this.table8 = new WindowsTableControl.Table();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 567);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Controls.Add(this.table1);
            this.tabPage1.Controls.Add(this.table2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "单人模式";
            // 
            // table1
            // 
            this.table1.BackColor = System.Drawing.Color.Transparent;
            this.table1.BorderColor = System.Drawing.Color.Transparent;
            this.table1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table1.CellCount = 12;
            this.table1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.table1.Location = new System.Drawing.Point(283, 62);
            this.table1.Name = "table1";
            this.table1.RowCount = 20;
            this.table1.Size = new System.Drawing.Size(255, 423);
            this.table1.TabIndex = 16;
            this.table1.TdSize = new System.Drawing.Size(20, 20);
            this.table1.Leave += new System.EventHandler(this.Table_Leave);
            this.table1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Table_PreviewKeyDown);
            // 
            // table2
            // 
            this.table2.BackColor = System.Drawing.Color.Transparent;
            this.table2.BorderColor = System.Drawing.Color.Transparent;
            this.table2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table2.CellCount = 4;
            this.table2.Location = new System.Drawing.Point(590, 62);
            this.table2.Name = "table2";
            this.table2.RowCount = 4;
            this.table2.Size = new System.Drawing.Size(87, 87);
            this.table2.TabIndex = 17;
            this.table2.TabStop = false;
            this.table2.TdSize = new System.Drawing.Size(20, 20);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(567, 419);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "方块数量：350";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(567, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "当前分数：46500";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(567, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "当前关卡：15";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(567, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "消灭行数：310";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.table5);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.table3);
            this.tabPage2.Controls.Add(this.table4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "双人合作";
            // 
            // table5
            // 
            this.table5.BackColor = System.Drawing.Color.Transparent;
            this.table5.BorderColor = System.Drawing.Color.Transparent;
            this.table5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table5.CellCount = 4;
            this.table5.Location = new System.Drawing.Point(106, 61);
            this.table5.Name = "table5";
            this.table5.RowCount = 4;
            this.table5.Size = new System.Drawing.Size(87, 87);
            this.table5.TabIndex = 28;
            this.table5.TabStop = false;
            this.table5.TdSize = new System.Drawing.Size(20, 20);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label9.Location = new System.Drawing.Point(26, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "方块数量：350";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label10.Location = new System.Drawing.Point(26, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "当前分数：46500";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label11.Location = new System.Drawing.Point(26, 327);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "当前关卡：15";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label12.Location = new System.Drawing.Point(26, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "消灭行数：310";
            // 
            // table3
            // 
            this.table3.BackColor = System.Drawing.Color.Transparent;
            this.table3.BorderColor = System.Drawing.Color.Transparent;
            this.table3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table3.CellCount = 24;
            this.table3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.table3.Location = new System.Drawing.Point(226, 61);
            this.table3.Name = "table3";
            this.table3.RowCount = 20;
            this.table3.Size = new System.Drawing.Size(507, 423);
            this.table3.TabIndex = 22;
            this.table3.TdSize = new System.Drawing.Size(20, 20);
            this.table3.Leave += new System.EventHandler(this.Table_Leave);
            this.table3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Table_PreviewKeyDown);
            // 
            // table4
            // 
            this.table4.BackColor = System.Drawing.Color.Transparent;
            this.table4.BorderColor = System.Drawing.Color.Transparent;
            this.table4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table4.CellCount = 4;
            this.table4.Location = new System.Drawing.Point(765, 61);
            this.table4.Name = "table4";
            this.table4.RowCount = 4;
            this.table4.Size = new System.Drawing.Size(87, 87);
            this.table4.TabIndex = 23;
            this.table4.TabStop = false;
            this.table4.TdSize = new System.Drawing.Size(20, 20);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label5.Location = new System.Drawing.Point(742, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "方块数量：350";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(742, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "当前分数：46500";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(742, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "当前关卡：15";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(742, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "消灭行数：310";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.table9);
            this.tabPage3.Controls.Add(this.table6);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.table7);
            this.tabPage3.Controls.Add(this.table8);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(942, 538);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "双人对抗";
            // 
            // table9
            // 
            this.table9.BackColor = System.Drawing.Color.Transparent;
            this.table9.BorderColor = System.Drawing.Color.Transparent;
            this.table9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table9.CellCount = 12;
            this.table9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.table9.Location = new System.Drawing.Point(469, 58);
            this.table9.Name = "table9";
            this.table9.RowCount = 20;
            this.table9.Size = new System.Drawing.Size(255, 423);
            this.table9.TabIndex = 44;
            this.table9.TabStop = false;
            this.table9.TdSize = new System.Drawing.Size(20, 20);
            // 
            // table6
            // 
            this.table6.BackColor = System.Drawing.Color.Transparent;
            this.table6.BorderColor = System.Drawing.Color.Transparent;
            this.table6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table6.CellCount = 4;
            this.table6.Location = new System.Drawing.Point(95, 58);
            this.table6.Name = "table6";
            this.table6.RowCount = 4;
            this.table6.Size = new System.Drawing.Size(87, 87);
            this.table6.TabIndex = 39;
            this.table6.TabStop = false;
            this.table6.TdSize = new System.Drawing.Size(20, 20);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label13.Location = new System.Drawing.Point(12, 415);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(139, 20);
            this.label13.TabIndex = 43;
            this.label13.Text = "方块数量：350";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label14.Location = new System.Drawing.Point(12, 385);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 20);
            this.label14.TabIndex = 42;
            this.label14.Text = "当前分数：46500";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label15.Location = new System.Drawing.Point(12, 324);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 20);
            this.label15.TabIndex = 40;
            this.label15.Text = "当前关卡：15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label16.Location = new System.Drawing.Point(12, 353);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(139, 20);
            this.label16.TabIndex = 41;
            this.label16.Text = "消灭行数：310";
            // 
            // table7
            // 
            this.table7.BackColor = System.Drawing.Color.Transparent;
            this.table7.BorderColor = System.Drawing.Color.Transparent;
            this.table7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table7.CellCount = 12;
            this.table7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.table7.Location = new System.Drawing.Point(208, 58);
            this.table7.Name = "table7";
            this.table7.RowCount = 20;
            this.table7.Size = new System.Drawing.Size(255, 423);
            this.table7.TabIndex = 33;
            this.table7.TdSize = new System.Drawing.Size(20, 20);
            this.table7.Leave += new System.EventHandler(this.Table_Leave);
            this.table7.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Table_PreviewKeyDown);
            // 
            // table8
            // 
            this.table8.BackColor = System.Drawing.Color.Transparent;
            this.table8.BorderColor = System.Drawing.Color.Transparent;
            this.table8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.table8.CellCount = 4;
            this.table8.Location = new System.Drawing.Point(751, 58);
            this.table8.Name = "table8";
            this.table8.RowCount = 4;
            this.table8.Size = new System.Drawing.Size(87, 87);
            this.table8.TabIndex = 34;
            this.table8.TabStop = false;
            this.table8.TdSize = new System.Drawing.Size(20, 20);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label17.Location = new System.Drawing.Point(747, 415);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(139, 20);
            this.label17.TabIndex = 38;
            this.label17.Text = "方块数量：350";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label18.Location = new System.Drawing.Point(747, 385);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(159, 20);
            this.label18.TabIndex = 37;
            this.label18.Text = "当前分数：46500";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label19.Location = new System.Drawing.Point(747, 324);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(129, 20);
            this.label19.TabIndex = 35;
            this.label19.Text = "当前关卡：15";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label20.Location = new System.Drawing.Point(747, 353);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(139, 20);
            this.label20.TabIndex = 36;
            this.label20.Text = "消灭行数：310";
            // 
            // GameInteractiveForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(946, 563);
            this.Controls.Add(this.tabControl1);
            this.Name = "GameInteractiveForm";
            this.Text = "5";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private WindowsTableControl.Table table1;
        private WindowsTableControl.Table table2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private WindowsTableControl.Table table5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private WindowsTableControl.Table table3;
        private WindowsTableControl.Table table4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private WindowsTableControl.Table table9;
        private WindowsTableControl.Table table6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private WindowsTableControl.Table table7;
        private WindowsTableControl.Table table8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TabControl tabControl1;
    }
}