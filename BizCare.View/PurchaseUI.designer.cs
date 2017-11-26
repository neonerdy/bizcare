namespace BizCare.View
{
    partial class PurchaseUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseUI));
            this.lvwPurchase = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lstPurchase = new System.Windows.Forms.ListBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.optCredit = new System.Windows.Forms.RadioButton();
            this.optCash = new System.Windows.Forms.RadioButton();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtSupplierId = new System.Windows.Forms.TextBox();
            this.txtPurchaseId = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.lblCode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.lblPaidStatus = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrintCounter = new System.Windows.Forms.TextBox();
            this.btnBrowseSupplier = new System.Windows.Forms.Button();
            this.txtTermOfPayment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPurchase
            // 
            this.lvwPurchase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2});
            this.lvwPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPurchase.FullRowSelect = true;
            this.lvwPurchase.HideSelection = false;
            this.lvwPurchase.Location = new System.Drawing.Point(3, 3);
            this.lvwPurchase.Name = "lvwPurchase";
            this.lvwPurchase.Size = new System.Drawing.Size(768, 213);
            this.lvwPurchase.TabIndex = 194;
            this.lvwPurchase.UseCompatibleStateImageBehavior = false;
            this.lvwPurchase.View = System.Windows.Forms.View.Details;
            this.lvwPurchase.DoubleClick += new System.EventHandler(this.lvwPurchase_DoubleClick);
            this.lvwPurchase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwPurchase_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ProductID";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nama Barang";
            this.columnHeader5.Width = 287;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Unit";
            this.columnHeader7.Width = 87;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Harga";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 147;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Qty";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Total";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 143;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwPurchase);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 219);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail Pembelian";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(551, 218);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 264);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 245);
            this.tabControl1.TabIndex = 229;
            // 
            // lstPurchase
            // 
            this.lstPurchase.FormattingEnabled = true;
            this.lstPurchase.Location = new System.Drawing.Point(13, 515);
            this.lstPurchase.Name = "lstPurchase";
            this.lstPurchase.Size = new System.Drawing.Size(197, 43);
            this.lstPurchase.TabIndex = 228;
            this.lstPurchase.Visible = false;
            this.lstPurchase.SelectedIndexChanged += new System.EventHandler(this.lstPurchase_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(699, 142);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(42, 20);
            this.txtID.TabIndex = 227;
            this.txtID.Visible = false;
            // 
            // optCredit
            // 
            this.optCredit.AutoSize = true;
            this.optCredit.Checked = true;
            this.optCredit.Enabled = false;
            this.optCredit.Location = new System.Drawing.Point(85, 116);
            this.optCredit.Name = "optCredit";
            this.optCredit.Size = new System.Drawing.Size(52, 17);
            this.optCredit.TabIndex = 2;
            this.optCredit.TabStop = true;
            this.optCredit.Text = "Kredit";
            this.optCredit.UseVisualStyleBackColor = true;
            this.optCredit.CheckedChanged += new System.EventHandler(this.optCredit_CheckedChanged);
            // 
            // optCash
            // 
            this.optCash.AutoSize = true;
            this.optCash.Enabled = false;
            this.optCash.Location = new System.Drawing.Point(24, 116);
            this.optCash.Name = "optCash";
            this.optCash.Size = new System.Drawing.Size(49, 17);
            this.optCash.TabIndex = 1;
            this.optCash.Text = "Cash";
            this.optCash.UseVisualStyleBackColor = true;
            this.optCash.CheckedChanged += new System.EventHandler(this.optCash_CheckedChanged);
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(15, 221);
            this.txtProduct.MaxLength = 200;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(180, 20);
            this.txtProduct.TabIndex = 223;
            // 
            // txtSupplierId
            // 
            this.txtSupplierId.Enabled = false;
            this.txtSupplierId.Location = new System.Drawing.Point(483, 142);
            this.txtSupplierId.Name = "txtSupplierId";
            this.txtSupplierId.Size = new System.Drawing.Size(43, 20);
            this.txtSupplierId.TabIndex = 233;
            this.txtSupplierId.Visible = false;
            // 
            // txtPurchaseId
            // 
            this.txtPurchaseId.Enabled = false;
            this.txtPurchaseId.Location = new System.Drawing.Point(650, 142);
            this.txtPurchaseId.Name = "txtPurchaseId";
            this.txtPurchaseId.Size = new System.Drawing.Size(43, 20);
            this.txtPurchaseId.TabIndex = 232;
            this.txtPurchaseId.Visible = false;
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(653, 218);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(39, 20);
            this.txtUnit.TabIndex = 231;
            this.txtUnit.Visible = false;
            // 
            // txtProductId
            // 
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(698, 218);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(43, 20);
            this.txtProductId.TabIndex = 230;
            this.txtProductId.Visible = false;
            // 
            // tsbHistory
            // 
            this.tsbHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbHistory.Image")));
            this.tsbHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHistory.Name = "tsbHistory";
            this.tsbHistory.Size = new System.Drawing.Size(23, 22);
            this.tsbHistory.ToolTipText = "History Transaksi";
            this.tsbHistory.Click += new System.EventHandler(this.tsbHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(616, 522);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 24);
            this.lblTotal.TabIndex = 221;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(484, 218);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblCode.Location = new System.Drawing.Point(573, 2);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(184, 20);
            this.lblCode.TabIndex = 222;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(378, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 219;
            this.label8.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(381, 222);
            this.txtQty.MaxLength = 13;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(77, 20);
            this.txtQty.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 217;
            this.label6.Text = "Harga";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(244, 222);
            this.txtPrice.MaxLength = 13;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(128, 20);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(444, 61);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(297, 72);
            this.txtNotes.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(441, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 213;
            this.label7.Text = "Keterangan";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBack,
            this.tsbNext,
            this.toolStripSeparator4,
            this.tsbAdd,
            this.tsbEdit,
            this.tsbSave,
            this.tsbCancel,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbHistory});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(772, 25);
            this.toolStrip1.TabIndex = 204;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbBack
            // 
            this.tsbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBack.Image = ((System.Drawing.Image)(resources.GetObject("tsbBack.Image")));
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(23, 22);
            this.tsbBack.ToolTipText = "Sebelumnya";
            this.tsbBack.Click += new System.EventHandler(this.tsbBack_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(23, 22);
            this.tsbNext.ToolTipText = "Selanjutnya";
            this.tsbNext.Click += new System.EventHandler(this.tsbNext_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 215;
            this.label4.Text = "Barang";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 21);
            this.panel1.TabIndex = 214;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 211;
            this.label1.Text = "Supplier";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 210;
            this.label5.Text = "Metode Pembayaran";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(18, 62);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(150, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 208;
            this.label3.Text = "Tanggal";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(198, 219);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Enabled = false;
            this.txtSupplierName.Location = new System.Drawing.Point(198, 62);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(188, 20);
            this.txtSupplierName.TabIndex = 236;
            // 
            // lblPaidStatus
            // 
            this.lblPaidStatus.AutoSize = true;
            this.lblPaidStatus.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidStatus.ForeColor = System.Drawing.Color.Red;
            this.lblPaidStatus.Location = new System.Drawing.Point(12, 515);
            this.lblPaidStatus.Name = "lblPaidStatus";
            this.lblPaidStatus.Size = new System.Drawing.Size(156, 43);
            this.lblPaidStatus.TabIndex = 238;
            this.lblPaidStatus.Text = "L U N A S";
            this.lblPaidStatus.Visible = false;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(274, 112);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(108, 20);
            this.dtpDueDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 240;
            this.label2.Text = "Tanggal Jatuh Tempo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(322, 511);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 244;
            this.label10.Text = "Cetak ke";
            this.label10.Visible = false;
            // 
            // txtPrintCounter
            // 
            this.txtPrintCounter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPrintCounter.Enabled = false;
            this.txtPrintCounter.Location = new System.Drawing.Point(325, 527);
            this.txtPrintCounter.MaxLength = 200;
            this.txtPrintCounter.Multiline = true;
            this.txtPrintCounter.Name = "txtPrintCounter";
            this.txtPrintCounter.Size = new System.Drawing.Size(37, 23);
            this.txtPrintCounter.TabIndex = 243;
            this.txtPrintCounter.Visible = false;
            // 
            // btnBrowseSupplier
            // 
            this.btnBrowseSupplier.Enabled = false;
            this.btnBrowseSupplier.Location = new System.Drawing.Point(390, 61);
            this.btnBrowseSupplier.Name = "btnBrowseSupplier";
            this.btnBrowseSupplier.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseSupplier.TabIndex = 3;
            this.btnBrowseSupplier.Text = "...";
            this.btnBrowseSupplier.UseVisualStyleBackColor = true;
            this.btnBrowseSupplier.Click += new System.EventHandler(this.btnBrowseSupplier_Click);
            // 
            // txtTermOfPayment
            // 
            this.txtTermOfPayment.BackColor = System.Drawing.SystemColors.Window;
            this.txtTermOfPayment.Enabled = false;
            this.txtTermOfPayment.Location = new System.Drawing.Point(198, 112);
            this.txtTermOfPayment.MaxLength = 3;
            this.txtTermOfPayment.Name = "txtTermOfPayment";
            this.txtTermOfPayment.Size = new System.Drawing.Size(58, 20);
            this.txtTermOfPayment.TabIndex = 4;
            this.txtTermOfPayment.TextChanged += new System.EventHandler(this.txtTermOfPayment_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(195, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 254;
            this.label11.Text = "TOP ( hari )";
            // 
            // PurchaseUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 566);
            this.Controls.Add(this.txtTermOfPayment);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPrintCounter);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPaidStatus);
            this.Controls.Add(this.btnBrowseSupplier);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstPurchase);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.optCredit);
            this.Controls.Add(this.optCash);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtSupplierId);
            this.Controls.Add(this.txtPurchaseId);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PurchaseUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pembelian";
            this.Load += new System.EventHandler(this.PurchaseUI_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwPurchase;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox lstPurchase;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.RadioButton optCredit;
        private System.Windows.Forms.RadioButton optCash;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtSupplierId;
        private System.Windows.Forms.TextBox txtPurchaseId;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label lblPaidStatus;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrintCounter;
        private System.Windows.Forms.Button btnBrowseSupplier;
        private System.Windows.Forms.TextBox txtTermOfPayment;
        private System.Windows.Forms.Label label11;
    }
}