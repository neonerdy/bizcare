namespace BizCare.View
{
    partial class ReportParamPeriodUI
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(189, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 23);
            this.btnCancel.TabIndex = 180;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(129, 111);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 23);
            this.btnOk.TabIndex = 179;
            this.btnOk.Text = "Proses";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(30, 44);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(123, 21);
            this.cboMonth.TabIndex = 212;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 215;
            this.label1.Text = "Tahun";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 214;
            this.label2.Text = "Bulan";
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(159, 45);
            this.nudYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.ReadOnly = true;
            this.nudYear.Size = new System.Drawing.Size(84, 20);
            this.nudYear.TabIndex = 216;
            this.nudYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // ReportParamPeriodUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 146);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportParamPeriodUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cetak";
            this.Load += new System.EventHandler(this.ReportParamPeriodUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudYear;
    }
}