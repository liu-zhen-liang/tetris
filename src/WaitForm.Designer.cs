namespace LZLTetris
{
    partial class WaitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.pbSchedule = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTitle.Location = new System.Drawing.Point(15, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(129, 19);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "LZ俄罗斯方块";
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.BackColor = System.Drawing.Color.Transparent;
            this.labelInformation.Font = new System.Drawing.Font("楷体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInformation.Location = new System.Drawing.Point(15, 58);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(119, 19);
            this.labelInformation.TabIndex = 1;
            this.labelInformation.Text = "正在加载...";
            // 
            // pbSchedule
            // 
            this.pbSchedule.Location = new System.Drawing.Point(20, 122);
            this.pbSchedule.Name = "pbSchedule";
            this.pbSchedule.Size = new System.Drawing.Size(566, 23);
            this.pbSchedule.TabIndex = 2;
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(605, 166);
            this.Controls.Add(this.pbSchedule);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.ProgressBar pbSchedule;
    }
}