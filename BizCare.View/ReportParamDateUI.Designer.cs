namespace BizCare.View
{
    partial class ReportParamDateUI
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
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.CustomFormat = "dd/MM/yyyy";
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateBegin.Location = new System.Drawing.Point(12, 45);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(107, 20);
            this.dtpDateBegin.TabIndex = 172;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 173;
            this.label3.Text = "Tanggal Awal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "s.d";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateEnd.Location = new System.Drawing.Point(152, 45);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.Size = new System.Drawing.Size(114, 20);
            this.dtpDateEnd.TabIndex = 175;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 176;
            this.label2.Text = "Tanggal Akhir";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(212, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 23);
            this.btnCancel.TabIndex = 178;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(152, 111);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(54, 23);
            this.btnOk.TabIndex = 177;
            this.btnOk.Text = "Proses";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ReportParamDateUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 146);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dtpDateEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpDateBegin);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportParamDateUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cetak";
            this.Load += new System.EventHandler(this.ReportParamDateUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}