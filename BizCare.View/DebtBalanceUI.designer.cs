namespace BizCare.View
{
    partial class DebtBalanceUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebtBalanceUI));
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSupplierId = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.chkIsStatus = new System.Windows.Forms.CheckBox();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPurchaseCode = new System.Windows.Forms.TextBox();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbMenuFilter = new System.Windows.Forms.ToolStripLabel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.optCredit = new System.Windows.Forms.RadioButton();
            this.optCash = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.btnBrowseSupplier = new System.Windows.Forms.Button();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwDebtBalance = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.txtTermOfPayment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(350, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // txtSupplierId
            // 
            this.txtSupplierId.Location = new System.Drawing.Point(150, 543);
            this.txtSupplierId.Name = "txtSupplierId";
            this.txtSupplierId.Size = new System.Drawing.Size(50, 20);
            this.txtSupplierId.TabIndex = 121;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(206, 543);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 117;
            this.txtID.Visible = false;
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
            // chkIsStatus
            // 
            this.chkIsStatus.AutoSize = true;
            this.chkIsStatus.Checked = true;
            this.chkIsStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsStatus.Enabled = false;
            this.chkIsStatus.Location = new System.Drawing.Point(643, 153);
            this.chkIsStatus.Name = "chkIsStatus";
            this.chkIsStatus.Size = new System.Drawing.Size(55, 17);
            this.chkIsStatus.TabIndex = 116;
            this.chkIsStatus.Text = "Lunas";
            this.chkIsStatus.UseVisualStyleBackColor = true;
            this.chkIsStatus.Visible = false;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(192, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 115;
            this.label5.Text = "Supplier";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Location = new System.Drawing.Point(382, 104);
            this.txtGrandTotal.MaxLength = 13;
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(80, 20);
            this.txtGrandTotal.TabIndex = 5;
            this.txtGrandTotal.TextChanged += new System.EventHandler(this.txtGrandTotal_TextChanged);
            this.txtGrandTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrandTotal_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(379, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Nilai";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(511, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 112;
            this.label7.Text = "Keterangan";
            // 
            // txtPurchaseCode
            // 
            this.txtPurchaseCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPurchaseCode.Enabled = false;
            this.txtPurchaseCode.Location = new System.Drawing.Point(19, 56);
            this.txtPurchaseCode.MaxLength = 200;
            this.txtPurchaseCode.Name = "txtPurchaseCode";
            this.txtPurchaseCode.Size = new System.Drawing.Size(153, 20);
            this.txtPurchaseCode.TabIndex = 0;
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
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(514, 59);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(274, 66);
            this.txtNotes.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 111;
            this.label1.Text = "Dokumen";
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
            this.toolStrip1.Size = new System.Drawing.Size(819, 25);
            this.toolStrip1.TabIndex = 108;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbMenuFilter
            // 
            this.tsbMenuFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbMenuFilter.Image")));
            this.tsbMenuFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMenuFilter.Name = "tsbMenuFilter";
            this.tsbMenuFilter.Size = new System.Drawing.Size(52, 22);
            this.tsbMenuFilter.Text = " Filter";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(18, 105);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(154, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 175;
            this.label2.Text = "Tanggal";
            // 
            // optCredit
            // 
            this.optCredit.AutoSize = true;
            this.optCredit.Checked = true;
            this.optCredit.Enabled = false;
            this.optCredit.Location = new System.Drawing.Point(77, 561);
            this.optCredit.Name = "optCredit";
            this.optCredit.Size = new System.Drawing.Size(52, 17);
            this.optCredit.TabIndex = 5;
            this.optCredit.TabStop = true;
            this.optCredit.Text = "Kredit";
            this.optCredit.UseVisualStyleBackColor = true;
            this.optCredit.Visible = false;
            // 
            // optCash
            // 
            this.optCash.AutoSize = true;
            this.optCash.Enabled = false;
            this.optCash.Location = new System.Drawing.Point(16, 561);
            this.optCash.Name = "optCash";
            this.optCash.Size = new System.Drawing.Size(49, 17);
            this.optCash.TabIndex = 4;
            this.optCash.Text = "Cash";
            this.optCash.UseVisualStyleBackColor = true;
            this.optCash.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 196;
            this.label4.Text = "Metode Pembayaran";
            this.label4.Visible = false;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Location = new System.Drawing.Point(195, 56);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(268, 20);
            this.txtSupplierName.TabIndex = 201;
            // 
            // btnBrowseSupplier
            // 
            this.btnBrowseSupplier.Enabled = false;
            this.btnBrowseSupplier.Location = new System.Drawing.Point(469, 53);
            this.btnBrowseSupplier.Name = "btnBrowseSupplier";
            this.btnBrowseSupplier.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseSupplier.TabIndex = 2;
            this.btnBrowseSupplier.Text = "...";
            this.btnBrowseSupplier.UseVisualStyleBackColor = true;
            this.btnBrowseSupplier.Click += new System.EventHandler(this.btnBrowseSupplier_Click);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(263, 104);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(108, 20);
            this.dtpDueDate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 240;
            this.label3.Text = "Tanggal Jatuh Tempo";
            // 
            // lvwDebtBalance
            // 
            this.lvwDebtBalance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader10});
            this.lvwDebtBalance.FullRowSelect = true;
            this.lvwDebtBalance.HideSelection = false;
            this.lvwDebtBalance.Location = new System.Drawing.Point(0, 153);
            this.lvwDebtBalance.Name = "lvwDebtBalance";
            this.lvwDebtBalance.Size = new System.Drawing.Size(817, 363);
            this.lvwDebtBalance.TabIndex = 243;
            this.lvwDebtBalance.UseCompatibleStateImageBehavior = false;
            this.lvwDebtBalance.View = System.Windows.Forms.View.Details;
            this.lvwDebtBalance.SelectedIndexChanged += new System.EventHandler(this.lvwDebtBalance_SelectedIndexChanged);
            this.lvwDebtBalance.DoubleClick += new System.EventHandler(this.lvwDebtBalance_DoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dokumen";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tanggal";
            this.columnHeader2.Width = 134;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Supplier";
            this.columnHeader3.Width = 170;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tanggal Jatuh Tempo";
            this.columnHeader7.Width = 123;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Nilai";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 119;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Status";
            this.columnHeader10.Width = 124;
            // 
            // txtTermOfPayment
            // 
            this.txtTermOfPayment.BackColor = System.Drawing.SystemColors.Window;
            this.txtTermOfPayment.Enabled = false;
            this.txtTermOfPayment.Location = new System.Drawing.Point(195, 104);
            this.txtTermOfPayment.MaxLength = 3;
            this.txtTermOfPayment.Name = "txtTermOfPayment";
            this.txtTermOfPayment.Size = new System.Drawing.Size(58, 20);
            this.txtTermOfPayment.TabIndex = 3;
            this.txtTermOfPayment.TextChanged += new System.EventHandler(this.txtTermOfPayment_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 256;
            this.label11.Text = "TOP ( hari )";
            // 
            // DebtBalanceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 519);
            this.Controls.Add(this.txtTermOfPayment);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lvwDebtBalance);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowseSupplier);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.optCredit);
            this.Controls.Add(this.optCash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSupplierId);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.chkIsStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPurchaseCode);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DebtBalanceUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Saldo Awal Hutang";
            this.Load += new System.EventHandler(this.DebtBalanceUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox txtSupplierId;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.CheckBox chkIsStatus;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPurchaseCode;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optCredit;
        private System.Windows.Forms.RadioButton optCash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Button btnBrowseSupplier;
        private System.Windows.Forms.ToolStripLabel tsbMenuFilter;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwDebtBalance;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TextBox txtTermOfPayment;
        private System.Windows.Forms.Label label11;
    }
}