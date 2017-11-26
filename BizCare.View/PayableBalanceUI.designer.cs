namespace BizCare.View
{
    partial class PayableBalanceUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayableBalanceUI));
            this.txtID = new System.Windows.Forms.TextBox();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.txtSalesCode = new System.Windows.Forms.TextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtSalesmanId = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseSalesman = new System.Windows.Forms.Button();
            this.txtSalesmanName = new System.Windows.Forms.TextBox();
            this.btnBrowseCustomer = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.optCash = new System.Windows.Forms.RadioButton();
            this.optCredit = new System.Windows.Forms.RadioButton();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblPaidStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwPayableBalance = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.lstDocument = new System.Windows.Forms.ListBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTermOfPayment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(728, 530);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(51, 20);
            this.txtID.TabIndex = 100;
            this.txtID.Visible = false;
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(476, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 94;
            this.label7.Text = "Keterangan";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(479, 109);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(192, 19);
            this.txtNotes.TabIndex = 6;
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
            // txtSalesCode
            // 
            this.txtSalesCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSalesCode.Enabled = false;
            this.txtSalesCode.Location = new System.Drawing.Point(19, 59);
            this.txtSalesCode.MaxLength = 200;
            this.txtSalesCode.Name = "txtSalesCode";
            this.txtSalesCode.Size = new System.Drawing.Size(195, 20);
            this.txtSalesCode.TabIndex = 0;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "Dokumen";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBack,
            this.tsbNext,
            this.toolStripSeparator2,
            this.tsbAdd,
            this.tsbEdit,
            this.tsbSave,
            this.tsbCancel,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbHistory});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 25);
            this.toolStrip1.TabIndex = 85;
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbHistory
            // 
            this.tsbHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbHistory.Image")));
            this.tsbHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHistory.Name = "tsbHistory";
            this.tsbHistory.Size = new System.Drawing.Size(23, 22);
            this.tsbHistory.ToolTipText = "History";
            this.tsbHistory.Click += new System.EventHandler(this.tsbHistory_Click);
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(614, 530);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(51, 20);
            this.txtCustomerId.TabIndex = 105;
            // 
            // txtSalesmanId
            // 
            this.txtSalesmanId.Location = new System.Drawing.Point(671, 530);
            this.txtSalesmanId.Name = "txtSalesmanId";
            this.txtSalesmanId.Size = new System.Drawing.Size(51, 20);
            this.txtSalesmanId.TabIndex = 106;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(19, 107);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(195, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Tanggal";
            // 
            // btnBrowseSalesman
            // 
            this.btnBrowseSalesman.Enabled = false;
            this.btnBrowseSalesman.Location = new System.Drawing.Point(673, 55);
            this.btnBrowseSalesman.Name = "btnBrowseSalesman";
            this.btnBrowseSalesman.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseSalesman.TabIndex = 5;
            this.btnBrowseSalesman.Text = "...";
            this.btnBrowseSalesman.UseVisualStyleBackColor = true;
            this.btnBrowseSalesman.Click += new System.EventHandler(this.btnBrowseSalesman_Click);
            // 
            // txtSalesmanName
            // 
            this.txtSalesmanName.Enabled = false;
            this.txtSalesmanName.Location = new System.Drawing.Point(479, 57);
            this.txtSalesmanName.Name = "txtSalesmanName";
            this.txtSalesmanName.Size = new System.Drawing.Size(192, 20);
            this.txtSalesmanName.TabIndex = 214;
            // 
            // btnBrowseCustomer
            // 
            this.btnBrowseCustomer.Enabled = false;
            this.btnBrowseCustomer.Location = new System.Drawing.Point(418, 57);
            this.btnBrowseCustomer.Name = "btnBrowseCustomer";
            this.btnBrowseCustomer.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseCustomer.TabIndex = 2;
            this.btnBrowseCustomer.Text = "...";
            this.btnBrowseCustomer.UseVisualStyleBackColor = true;
            this.btnBrowseCustomer.Click += new System.EventHandler(this.btnBrowseCustomer_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(238, 59);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(178, 20);
            this.txtCustomerName.TabIndex = 212;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 211;
            this.label3.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 210;
            this.label5.Text = "Salesman";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(308, 109);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(108, 20);
            this.dtpDueDate.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 217;
            this.label8.Text = "Tanggal Jatuh Tempo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(866, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 193;
            this.label4.Text = "Metode Pembayaran";
            this.label4.Visible = false;
            // 
            // optCash
            // 
            this.optCash.AutoSize = true;
            this.optCash.Checked = true;
            this.optCash.Enabled = false;
            this.optCash.Location = new System.Drawing.Point(871, 62);
            this.optCash.Name = "optCash";
            this.optCash.Size = new System.Drawing.Size(49, 17);
            this.optCash.TabIndex = 5;
            this.optCash.TabStop = true;
            this.optCash.Text = "Cash";
            this.optCash.UseVisualStyleBackColor = true;
            this.optCash.Visible = false;
            // 
            // optCredit
            // 
            this.optCredit.AutoSize = true;
            this.optCredit.Enabled = false;
            this.optCredit.Location = new System.Drawing.Point(932, 62);
            this.optCredit.Name = "optCredit";
            this.optCredit.Size = new System.Drawing.Size(52, 17);
            this.optCredit.TabIndex = 6;
            this.optCredit.Text = "Kredit";
            this.optCredit.UseVisualStyleBackColor = true;
            this.optCredit.Visible = false;
            // 
            // txtProductId
            // 
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(673, 192);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(39, 20);
            this.txtProductId.TabIndex = 267;
            this.txtProductId.Visible = false;
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(628, 192);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(39, 20);
            this.txtUnit.TabIndex = 266;
            this.txtUnit.Visible = false;
            // 
            // lblPaidStatus
            // 
            this.lblPaidStatus.AutoSize = true;
            this.lblPaidStatus.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidStatus.ForeColor = System.Drawing.Color.Red;
            this.lblPaidStatus.Location = new System.Drawing.Point(16, 483);
            this.lblPaidStatus.Name = "lblPaidStatus";
            this.lblPaidStatus.Size = new System.Drawing.Size(156, 43);
            this.lblPaidStatus.TabIndex = 265;
            this.lblPaidStatus.Text = "L U N A S";
            this.lblPaidStatus.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(538, 194);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 256;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(4, 230);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 245);
            this.tabControl1.TabIndex = 263;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwPayableBalance);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 219);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail Penjualan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwPayableBalance
            // 
            this.lvwPayableBalance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2});
            this.lvwPayableBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPayableBalance.FullRowSelect = true;
            this.lvwPayableBalance.HideSelection = false;
            this.lvwPayableBalance.Location = new System.Drawing.Point(3, 3);
            this.lvwPayableBalance.Name = "lvwPayableBalance";
            this.lvwPayableBalance.Size = new System.Drawing.Size(768, 213);
            this.lvwPayableBalance.TabIndex = 199;
            this.lvwPayableBalance.UseCompatibleStateImageBehavior = false;
            this.lvwPayableBalance.View = System.Windows.Forms.View.Details;
            this.lvwPayableBalance.DoubleClick += new System.EventHandler(this.lvwPayableBalance_DoubleClick);
            this.lvwPayableBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwPayableBalance_KeyDown);
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
            this.columnHeader2.Width = 147;
            // 
            // lstDocument
            // 
            this.lstDocument.FormattingEnabled = true;
            this.lstDocument.Location = new System.Drawing.Point(19, 483);
            this.lstDocument.Name = "lstDocument";
            this.lstDocument.Size = new System.Drawing.Size(197, 43);
            this.lstDocument.TabIndex = 262;
            this.lstDocument.Visible = false;
            this.lstDocument.SelectedIndexChanged += new System.EventHandler(this.lstDocument_SelectedIndexChanged);
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(16, 194);
            this.txtProduct.MaxLength = 200;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(166, 20);
            this.txtProduct.TabIndex = 261;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(628, 489);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 24);
            this.lblTotal.TabIndex = 260;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(479, 194);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 251;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 259;
            this.label6.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(367, 195);
            this.txtQty.MaxLength = 13;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 20);
            this.txtQty.TabIndex = 255;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 258;
            this.label10.Text = "Harga";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(242, 196);
            this.txtPrice.MaxLength = 13;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(119, 20);
            this.txtPrice.TabIndex = 254;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 257;
            this.label11.Text = "Barang";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(185, 192);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 252;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 21);
            this.panel1.TabIndex = 268;
            // 
            // txtTermOfPayment
            // 
            this.txtTermOfPayment.BackColor = System.Drawing.SystemColors.Window;
            this.txtTermOfPayment.Enabled = false;
            this.txtTermOfPayment.Location = new System.Drawing.Point(238, 107);
            this.txtTermOfPayment.MaxLength = 3;
            this.txtTermOfPayment.Name = "txtTermOfPayment";
            this.txtTermOfPayment.Size = new System.Drawing.Size(58, 20);
            this.txtTermOfPayment.TabIndex = 3;
            this.txtTermOfPayment.TextChanged += new System.EventHandler(this.txtTermOfPayment_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 270;
            this.label9.Text = "TOP ( hari )";
            // 
            // PayableBalanceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 527);
            this.Controls.Add(this.txtTermOfPayment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.lblPaidStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstDocument);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBrowseSalesman);
            this.Controls.Add(this.txtSalesmanName);
            this.Controls.Add(this.btnBrowseCustomer);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.optCredit);
            this.Controls.Add(this.optCash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSalesmanId);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtSalesCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PayableBalanceUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Saldo Awal Piutang";
            this.Load += new System.EventHandler(this.PayableBalanceUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.TextBox txtSalesCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtSalesmanId;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseSalesman;
        private System.Windows.Forms.TextBox txtSalesmanName;
        private System.Windows.Forms.Button btnBrowseCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton optCash;
        private System.Windows.Forms.RadioButton optCredit;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblPaidStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvwPayableBalance;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListBox lstDocument;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TextBox txtTermOfPayment;
        private System.Windows.Forms.Label label9;
    }
}