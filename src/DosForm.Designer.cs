namespace LZLTetris
{
    partial class DosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DosForm));
            this.txtShowDosOrder = new System.Windows.Forms.TextBox();
            this.txtWrileOreder = new System.Windows.Forms.TextBox();
            this.buttExecOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtShowDosOrder
            // 
            this.txtShowDosOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShowDosOrder.BackColor = System.Drawing.SystemColors.Menu;
            this.txtShowDosOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShowDosOrder.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtShowDosOrder.Location = new System.Drawing.Point(0, 0);
            this.txtShowDosOrder.Multiline = true;
            this.txtShowDosOrder.Name = "txtShowDosOrder";
            this.txtShowDosOrder.ReadOnly = true;
            this.txtShowDosOrder.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtShowDosOrder.Size = new System.Drawing.Size(618, 524);
            this.txtShowDosOrder.TabIndex = 0;
            // 
            // txtWrileOreder
            // 
            this.txtWrileOreder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWrileOreder.BackColor = System.Drawing.SystemColors.Window;
            this.txtWrileOreder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWrileOreder.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWrileOreder.Location = new System.Drawing.Point(6, 530);
            this.txtWrileOreder.Name = "txtWrileOreder";
            this.txtWrileOreder.Size = new System.Drawing.Size(517, 28);
            this.txtWrileOreder.TabIndex = 1;
            this.txtWrileOreder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWrileOreder_KeyDown);
            // 
            // buttExecOrder
            // 
            this.buttExecOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttExecOrder.BackColor = System.Drawing.SystemColors.Window;
            this.buttExecOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttExecOrder.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttExecOrder.Location = new System.Drawing.Point(528, 530);
            this.buttExecOrder.Name = "buttExecOrder";
            this.buttExecOrder.Size = new System.Drawing.Size(86, 28);
            this.buttExecOrder.TabIndex = 2;
            this.buttExecOrder.Text = "执行";
            this.buttExecOrder.UseVisualStyleBackColor = false;
            this.buttExecOrder.Click += new System.EventHandler(this.buttExecOrder_Click);
            // 
            // DosForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(618, 564);
            this.Controls.Add(this.buttExecOrder);
            this.Controls.Add(this.txtWrileOreder);
            this.Controls.Add(this.txtShowDosOrder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DosForm";
            this.Text = "控制台";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DosForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShowDosOrder;
        private System.Windows.Forms.TextBox txtWrileOreder;
        private System.Windows.Forms.Button buttExecOrder;
    }
}