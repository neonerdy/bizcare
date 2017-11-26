namespace BizCare.View
{
    partial class RecordCounterUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecordCounterUI));
            this.label7 = new System.Windows.Forms.Label();
            this.txtPurchaseCounter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpenseCounter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPayablePaymentCounter = new System.Windows.Forms.TextBox();
            this.txtSalesCounter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDebtPaymentCounter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBillReceiptCounter = new System.Windows.Forms.TextBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.chkClosingStatus = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbMenuFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtMonthCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStockCorrectionCounter = new System.Windows.Forms.TextBox();
            this.lvwRecordCounter = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Pembelian";
            // 
            // txtPurchaseCounter
            // 
            this.txtPurchaseCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPurchaseCounter.Enabled = false;
            this.txtPurchaseCounter.Location = new System.Drawing.Point(124, 109);
            this.txtPurchaseCounter.MaxLength = 13;
            this.txtPurchaseCounter.Multiline = true;
            this.txtPurchaseCounter.Name = "txtPurchaseCounter";
            this.txtPurchaseCounter.Size = new System.Drawing.Size(93, 20);
            this.txtPurchaseCounter.TabIndex = 3;
            this.txtPurchaseCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseCounter_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "Penjualan";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(584, 56);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 107;
            this.txtID.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 177;
            this.label2.Text = "Bulan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 179;
            this.label1.Text = "Tahun";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 181;
            this.label3.Text = "Biaya";
            // 
            // txtExpenseCounter
            // 
            this.txtExpenseCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtExpenseCounter.Enabled = false;
            this.txtExpenseCounter.Location = new System.Drawing.Point(236, 56);
            this.txtExpenseCounter.MaxLength = 13;
            this.txtExpenseCounter.Multiline = true;
            this.txtExpenseCounter.Name = "txtExpenseCounter";
            this.txtExpenseCounter.Size = new System.Drawing.Size(93, 20);
            this.txtExpenseCounter.TabIndex = 4;
            this.txtExpenseCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExpenseCounter_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 183;
            this.label4.Text = "Pelunasan Piutang";
            // 
            // txtPayablePaymentCounter
            // 
            this.txtPayablePaymentCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPayablePaymentCounter.Enabled = false;
            this.txtPayablePaymentCounter.Location = new System.Drawing.Point(236, 109);
            this.txtPayablePaymentCounter.MaxLength = 13;
            this.txtPayablePaymentCounter.Multiline = true;
            this.txtPayablePaymentCounter.Name = "txtPayablePaymentCounter";
            this.txtPayablePaymentCounter.Size = new System.Drawing.Size(93, 20);
            this.txtPayablePaymentCounter.TabIndex = 5;
            this.txtPayablePaymentCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayablePaymentCounter_KeyPress);
            // 
            // txtSalesCounter
            // 
            this.txtSalesCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSalesCounter.Enabled = false;
            this.txtSalesCounter.Location = new System.Drawing.Point(124, 56);
            this.txtSalesCounter.MaxLength = 13;
            this.txtSalesCounter.Multiline = true;
            this.txtSalesCounter.Name = "txtSalesCounter";
            this.txtSalesCounter.Size = new System.Drawing.Size(93, 20);
            this.txtSalesCounter.TabIndex = 2;
            this.txtSalesCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesCounter_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 186;
            this.label6.Text = "Pembayaran Hutang";
            // 
            // txtDebtPaymentCounter
            // 
            this.txtDebtPaymentCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDebtPaymentCounter.Enabled = false;
            this.txtDebtPaymentCounter.Location = new System.Drawing.Point(348, 56);
            this.txtDebtPaymentCounter.MaxLength = 13;
            this.txtDebtPaymentCounter.Multiline = true;
            this.txtDebtPaymentCounter.Name = "txtDebtPaymentCounter";
            this.txtDebtPaymentCounter.Size = new System.Drawing.Size(93, 20);
            this.txtDebtPaymentCounter.TabIndex = 6;
            this.txtDebtPaymentCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebtPaymentCounter_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 188;
            this.label8.Text = "TTNT";
            // 
            // txtBillReceiptCounter
            // 
            this.txtBillReceiptCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtBillReceiptCounter.Enabled = false;
            this.txtBillReceiptCounter.Location = new System.Drawing.Point(348, 109);
            this.txtBillReceiptCounter.MaxLength = 13;
            this.txtBillReceiptCounter.Multiline = true;
            this.txtBillReceiptCounter.Name = "txtBillReceiptCounter";
            this.txtBillReceiptCounter.Size = new System.Drawing.Size(93, 20);
            this.txtBillReceiptCounter.TabIndex = 7;
            this.txtBillReceiptCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBillReceiptCounter_KeyPress);
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.Enabled = false;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(13, 55);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(100, 21);
            this.cboMonth.TabIndex = 0;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtYear.Enabled = false;
            this.txtYear.Location = new System.Drawing.Point(13, 109);
            this.txtYear.MaxLength = 4;
            this.txtYear.Multiline = true;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 1;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // chkClosingStatus
            // 
            this.chkClosingStatus.AutoSize = true;
            this.chkClosingStatus.Checked = true;
            this.chkClosingStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClosingStatus.Enabled = false;
            this.chkClosingStatus.Location = new System.Drawing.Point(473, 109);
            this.chkClosingStatus.Name = "chkClosingStatus";
            this.chkClosingStatus.Size = new System.Drawing.Size(82, 17);
            this.chkClosingStatus.TabIndex = 9;
            this.chkClosingStatus.Text = "Tutup Buku";
            this.chkClosingStatus.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbSave,
            this.tsbCancel,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbMenuFilter,
            this.toolStripSeparator2,
            this.txtSearch,
            this.toolStripSeparator3,
            this.tsbFilter,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(776, 25);
            this.toolStrip1.TabIndex = 194;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "tsbRefresh";
            this.tsbRefresh.ToolTipText = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbMenuFilter
            // 
            this.tsbMenuFilter.AutoToolTip = false;
            this.tsbMenuFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbMenuFilter.Image")));
            this.tsbMenuFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMenuFilter.Name = "tsbMenuFilter";
            this.tsbMenuFilter.Size = new System.Drawing.Size(102, 22);
            this.tsbMenuFilter.Text = " Filter Tahun";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtSearch
            // 
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFilter
            // 
            this.tsbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbFilter.Image")));
            this.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilter.Name = "tsbFilter";
            this.tsbFilter.Size = new System.Drawing.Size(23, 22);
            this.tsbFilter.Text = "toolStripButton6";
            this.tsbFilter.ToolTipText = "Filter";
            this.tsbFilter.Click += new System.EventHandler(this.tsbFilter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // txtMonthCode
            // 
            this.txtMonthCode.Location = new System.Drawing.Point(640, 56);
            this.txtMonthCode.Name = "txtMonthCode";
            this.txtMonthCode.Size = new System.Drawing.Size(50, 20);
            this.txtMonthCode.TabIndex = 197;
            this.txtMonthCode.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(464, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 199;
            this.label9.Text = "Koreksi Stok";
            // 
            // txtStockCorrectionCounter
            // 
            this.txtStockCorrectionCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtStockCorrectionCounter.Enabled = false;
            this.txtStockCorrectionCounter.Location = new System.Drawing.Point(467, 56);
            this.txtStockCorrectionCounter.MaxLength = 13;
            this.txtStockCorrectionCounter.Multiline = true;
            this.txtStockCorrectionCounter.Name = "txtStockCorrectionCounter";
            this.txtStockCorrectionCounter.Size = new System.Drawing.Size(93, 20);
            this.txtStockCorrectionCounter.TabIndex = 8;
            this.txtStockCorrectionCounter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockCorrectionCounter_KeyPress);
            // 
            // lvwRecordCounter
            // 
            this.lvwRecordCounter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader14,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader11});
            this.lvwRecordCounter.FullRowSelect = true;
            this.lvwRecordCounter.HideSelection = false;
            this.lvwRecordCounter.Location = new System.Drawing.Point(0, 150);
            this.lvwRecordCounter.Name = "lvwRecordCounter";
            this.lvwRecordCounter.Size = new System.Drawing.Size(775, 345);
            this.lvwRecordCounter.TabIndex = 200;
            this.lvwRecordCounter.UseCompatibleStateImageBehavior = false;
            this.lvwRecordCounter.View = System.Windows.Forms.View.Details;
            this.lvwRecordCounter.SelectedIndexChanged += new System.EventHandler(this.lvwRecordCounter_SelectedIndexChanged);
            this.lvwRecordCounter.DoubleClick += new System.EventHandler(this.lvwRecordCounter_DoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tahun";
            this.columnHeader10.Width = 51;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Bulan";
            this.columnHeader14.Width = 78;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Penjualan";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pembelian";
            this.columnHeader2.Width = 67;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Biaya";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pelunasan Piutang";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pembayaran Hutang";
            this.columnHeader5.Width = 117;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "TTNT";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Koreksi Stok";
            this.columnHeader9.Width = 72;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Tutup Buku";
            this.columnHeader11.Width = 70;
            // 
            // RecordCounterUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 496);
            this.Controls.Add(this.lvwRecordCounter);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStockCorrectionCounter);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.chkClosingStatus);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBillReceiptCounter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDebtPaymentCounter);
            this.Controls.Add(this.txtSalesCounter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPayablePaymentCounter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExpenseCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPurchaseCounter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtMonthCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RecordCounterUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dokumen";
            this.Load += new System.EventHandler(this.RecordCounterUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPurchaseCounter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpenseCounter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPayablePaymentCounter;
        private System.Windows.Forms.TextBox txtSalesCounter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDebtPaymentCounter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBillReceiptCounter;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.CheckBox chkClosingStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripDropDownButton tsbMenuFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TextBox txtMonthCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStockCorrectionCounter;
        private System.Windows.Forms.ListView lvwRecordCounter;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
    }
}