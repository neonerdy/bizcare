namespace BizCare.View
{
    partial class ReportPrintUI
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
            this.optPreview = new System.Windows.Forms.RadioButton();
            this.optPrinter = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // optPreview
            // 
            this.optPreview.AutoSize = true;
            this.optPreview.Location = new System.Drawing.Point(100, 73);
            this.optPreview.Name = "optPreview";
            this.optPreview.Size = new System.Drawing.Size(63, 17);
            this.optPreview.TabIndex = 347;
            this.optPreview.Text = "Preview";
            this.optPreview.UseVisualStyleBackColor = true;
            // 
            // optPrinter
            // 
            this.optPrinter.AutoSize = true;
            this.optPrinter.Checked = true;
            this.optPrinter.Location = new System.Drawing.Point(29, 73);
            this.optPrinter.Name = "optPrinter";
            this.optPrinter.Size = new System.Drawing.Size(55, 17);
            this.optPrinter.TabIndex = 346;
            this.optPrinter.TabStop = true;
            this.optPrinter.Text = "Printer";
            this.optPrinter.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(114, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(48, 23);
            this.btnCancel.TabIndex = 349;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(30, 112);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 23);
            this.btnOk.TabIndex = 348;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(29, 47);
            this.txtCode.MaxLength = 200;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(134, 20);
            this.txtCode.TabIndex = 350;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 351;
            this.label5.Text = "Dokumen";
            // 
            // ReportPrintUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 168);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.optPreview);
            this.Controls.Add(this.optPrinter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportPrintUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cetak Bukti";
            this.Load += new System.EventHandler(this.ReportPrintUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optPreview;
        private System.Windows.Forms.RadioButton optPrinter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label5;
    }
}