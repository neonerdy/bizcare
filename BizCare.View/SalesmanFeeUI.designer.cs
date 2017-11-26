namespace BizCare.View
{
    partial class SalesmanFeeUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesmanFeeUI));
            this.label7 = new System.Windows.Forms.Label();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFeePercentage = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboSalesman = new System.Windows.Forms.ComboBox();
            this.lvwSalesmanFee = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.txtSalesmanId = new System.Windows.Forms.TextBox();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "Komisi (%)";
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "tsbDelete";
            this.tsbDelete.ToolTipText = "Hapus";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancel.Enabled = false;
            this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(23, 22);
            this.tsbCancel.ToolTipText = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbSave,
            this.tsbCancel,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(407, 25);
            this.toolStrip1.TabIndex = 216;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Text = "tsbAdd";
            this.tsbAdd.ToolTipText = "Tambah";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbEdit.Text = "tsbEdit";
            this.tsbEdit.ToolTipText = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Enabled = false;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(13, 58);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(100, 21);
            this.cboMonth.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 210;
            this.label2.Text = "Bulan";
            // 
            // txtFeePercentage
            // 
            this.txtFeePercentage.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtFeePercentage.Enabled = false;
            this.txtFeePercentage.Location = new System.Drawing.Point(148, 116);
            this.txtFeePercentage.MaxLength = 3;
            this.txtFeePercentage.Multiline = true;
            this.txtFeePercentage.Name = "txtFeePercentage";
            this.txtFeePercentage.Size = new System.Drawing.Size(167, 20);
            this.txtFeePercentage.TabIndex = 3;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(347, 62);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 209;
            this.txtID.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 220;
            this.label5.Text = "Salesman";
            // 
            // cboSalesman
            // 
            this.cboSalesman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalesman.Enabled = false;
            this.cboSalesman.FormattingEnabled = true;
            this.cboSalesman.Location = new System.Drawing.Point(148, 58);
            this.cboSalesman.Name = "cboSalesman";
            this.cboSalesman.Size = new System.Drawing.Size(167, 21);
            this.cboSalesman.TabIndex = 2;
            this.cboSalesman.SelectedIndexChanged += new System.EventHandler(this.cboSalesman_SelectedIndexChanged);
            // 
            // lvwSalesmanFee
            // 
            this.lvwSalesmanFee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader14,
            this.columnHeader1,
            this.columnHeader2});
            this.lvwSalesmanFee.FullRowSelect = true;
            this.lvwSalesmanFee.HideSelection = false;
            this.lvwSalesmanFee.Location = new System.Drawing.Point(0, 160);
            this.lvwSalesmanFee.Name = "lvwSalesmanFee";
            this.lvwSalesmanFee.Size = new System.Drawing.Size(407, 237);
            this.lvwSalesmanFee.TabIndex = 221;
            this.lvwSalesmanFee.UseCompatibleStateImageBehavior = false;
            this.lvwSalesmanFee.View = System.Windows.Forms.View.Details;
            this.lvwSalesmanFee.SelectedIndexChanged += new System.EventHandler(this.lvwSalesmanFee_SelectedIndexChanged);
            this.lvwSalesmanFee.DoubleClick += new System.EventHandler(this.lvwSalesmanFee_DoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tahun";
            this.columnHeader10.Width = 62;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Bulan";
            this.columnHeader14.Width = 78;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Salesman";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Komisi  (%)";
            this.columnHeader2.Width = 67;
            // 
            // txtSalesmanId
            // 
            this.txtSalesmanId.Location = new System.Drawing.Point(347, 36);
            this.txtSalesmanId.Name = "txtSalesmanId";
            this.txtSalesmanId.Size = new System.Drawing.Size(50, 20);
            this.txtSalesmanId.TabIndex = 222;
            this.txtSalesmanId.Visible = false;
            // 
            // nudYear
            // 
            this.nudYear.Enabled = false;
            this.nudYear.Location = new System.Drawing.Point(13, 116);
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
            this.nudYear.TabIndex = 1;
            this.nudYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 223;
            this.label1.Text = "Tahun";
            // 
            // SalesmanFeeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 398);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwSalesmanFee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboSalesman);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFeePercentage);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtSalesmanId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SalesmanFeeUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Presentase Komisi Salesman";
            this.Load += new System.EventHandler(this.SalesmanFeeUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFeePercentage;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboSalesman;
        private System.Windows.Forms.ListView lvwSalesmanFee;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtSalesmanId;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label label1;
    }
}