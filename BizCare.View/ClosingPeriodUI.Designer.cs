namespace BizCare.View
{
    partial class ClosingPeriodUI
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtActiveMonth = new System.Windows.Forms.TextBox();
            this.txtActiveYear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Bulan";
            // 
            // txtActiveMonth
            // 
            this.txtActiveMonth.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtActiveMonth.Enabled = false;
            this.txtActiveMonth.Location = new System.Drawing.Point(29, 43);
            this.txtActiveMonth.MaxLength = 200;
            this.txtActiveMonth.Multiline = true;
            this.txtActiveMonth.Name = "txtActiveMonth";
            this.txtActiveMonth.Size = new System.Drawing.Size(100, 20);
            this.txtActiveMonth.TabIndex = 99;
            // 
            // txtActiveYear
            // 
            this.txtActiveYear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtActiveYear.Enabled = false;
            this.txtActiveYear.Location = new System.Drawing.Point(150, 43);
            this.txtActiveYear.MaxLength = 200;
            this.txtActiveYear.Multiline = true;
            this.txtActiveYear.Name = "txtActiveYear";
            this.txtActiveYear.Size = new System.Drawing.Size(114, 20);
            this.txtActiveYear.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 100;
            this.label1.Text = "Tahun";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(150, 84);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 23);
            this.btnOk.TabIndex = 102;
            this.btnOk.Text = "Proses";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 23);
            this.btnCancel.TabIndex = 103;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ClosingPeriodUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 129);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtActiveYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtActiveMonth);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClosingPeriodUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tutup Buku";
            this.Load += new System.EventHandler(this.ClosingPeriodUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtActiveMonth;
        private System.Windows.Forms.TextBox txtActiveYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

    }
}