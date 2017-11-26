namespace BizCare.View
{
    partial class SalesUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesUI));
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.optCash = new System.Windows.Forms.RadioButton();
            this.optCredit = new System.Windows.Forms.RadioButton();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lstSales = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwSales = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.txtSalesmanId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQtyEnd = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnBrowseCustomer = new System.Windows.Forms.Button();
            this.txtSalesmanName = new System.Windows.Forms.TextBox();
            this.btnBrowseSalesman = new System.Windows.Forms.Button();
            this.lblPaidStatus = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtTermOfPayment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(15, 240);
            this.txtProduct.MaxLength = 200;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(166, 20);
            this.txtProduct.TabIndex = 189;
            this.txtProduct.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblCode.Location = new System.Drawing.Point(575, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(184, 20);
            this.lblCode.TabIndex = 188;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(624, 517);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 24);
            this.lblTotal.TabIndex = 187;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(475, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 185;
            this.label8.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(385, 241);
            this.txtQty.MaxLength = 13;
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(49, 20);
            this.txtQty.TabIndex = 10;
            this.txtQty.TextChanged += new System.EventHandler(this.txtQy_TextChanged);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQy_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 183;
            this.label6.Text = "Harga";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(297, 241);
            this.txtPrice.MaxLength = 13;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(82, 20);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(476, 112);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(250, 64);
            this.txtNotes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 181;
            this.label4.Text = "Barang";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(0, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 21);
            this.panel1.TabIndex = 180;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(473, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 179;
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
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 166;
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
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(184, 238);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 177;
            this.label1.Text = "Customer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 173;
            this.label5.Text = "Metode Pembayaran";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(23, 59);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(177, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 171;
            this.label3.Text = "Tanggal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 170;
            this.label2.Text = "Salesman";
            // 
            // optCash
            // 
            this.optCash.AutoSize = true;
            this.optCash.Enabled = false;
            this.optCash.Location = new System.Drawing.Point(28, 108);
            this.optCash.Name = "optCash";
            this.optCash.Size = new System.Drawing.Size(49, 17);
            this.optCash.TabIndex = 1;
            this.optCash.Text = "Cash";
            this.optCash.UseVisualStyleBackColor = true;
            this.optCash.CheckedChanged += new System.EventHandler(this.optCash_CheckedChanged);
            // 
            // optCredit
            // 
            this.optCredit.AutoSize = true;
            this.optCredit.Checked = true;
            this.optCredit.Enabled = false;
            this.optCredit.Location = new System.Drawing.Point(101, 108);
            this.optCredit.Name = "optCredit";
            this.optCredit.Size = new System.Drawing.Size(52, 17);
            this.optCredit.TabIndex = 2;
            this.optCredit.TabStop = true;
            this.optCredit.Text = "Kredit";
            this.optCredit.UseVisualStyleBackColor = true;
            this.optCredit.CheckedChanged += new System.EventHandler(this.optCredit_CheckedChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(733, 250);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(42, 20);
            this.txtID.TabIndex = 194;
            this.txtID.Visible = false;
            // 
            // lstSales
            // 
            this.lstSales.FormattingEnabled = true;
            this.lstSales.Location = new System.Drawing.Point(13, 511);
            this.lstSales.Name = "lstSales";
            this.lstSales.Size = new System.Drawing.Size(197, 43);
            this.lstSales.TabIndex = 195;
            this.lstSales.Visible = false;
            this.lstSales.SelectedIndexChanged += new System.EventHandler(this.lstSales_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 281);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 222);
            this.tabControl1.TabIndex = 196;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwSales);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 196);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail Penjualan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwSales
            // 
            this.lvwSales.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2});
            this.lvwSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSales.FullRowSelect = true;
            this.lvwSales.HideSelection = false;
            this.lvwSales.Location = new System.Drawing.Point(3, 3);
            this.lvwSales.Name = "lvwSales";
            this.lvwSales.Size = new System.Drawing.Size(768, 190);
            this.lvwSales.TabIndex = 199;
            this.lvwSales.UseCompatibleStateImageBehavior = false;
            this.lvwSales.View = System.Windows.Forms.View.Details;
            this.lvwSales.DoubleClick += new System.EventHandler(this.lvwSales_DoubleClick);
            this.lvwSales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwSales_KeyDown);
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
            // txtSalesId
            // 
            this.txtSalesId.Enabled = false;
            this.txtSalesId.Location = new System.Drawing.Point(687, 250);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(43, 20);
            this.txtSalesId.TabIndex = 200;
            this.txtSalesId.Visible = false;
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Enabled = false;
            this.txtCustomerId.Location = new System.Drawing.Point(589, 250);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.Size = new System.Drawing.Size(43, 20);
            this.txtCustomerId.TabIndex = 201;
            this.txtCustomerId.Visible = false;
            // 
            // txtSalesmanId
            // 
            this.txtSalesmanId.Enabled = false;
            this.txtSalesmanId.Location = new System.Drawing.Point(638, 250);
            this.txtSalesmanId.Name = "txtSalesmanId";
            this.txtSalesmanId.Size = new System.Drawing.Size(43, 20);
            this.txtSalesmanId.TabIndex = 202;
            this.txtSalesmanId.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(534, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(231, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 205;
            this.label9.Text = "Qty Akhir";
            // 
            // txtQtyEnd
            // 
            this.txtQtyEnd.Enabled = false;
            this.txtQtyEnd.Location = new System.Drawing.Point(234, 241);
            this.txtQtyEnd.MaxLength = 13;
            this.txtQtyEnd.Name = "txtQtyEnd";
            this.txtQtyEnd.Size = new System.Drawing.Size(56, 20);
            this.txtQtyEnd.TabIndex = 8;
            this.txtQtyEnd.TextChanged += new System.EventHandler(this.txtQtyEnd_TextChanged_1);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(234, 62);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(195, 20);
            this.txtCustomerName.TabIndex = 206;
            // 
            // btnBrowseCustomer
            // 
            this.btnBrowseCustomer.Enabled = false;
            this.btnBrowseCustomer.Location = new System.Drawing.Point(433, 61);
            this.btnBrowseCustomer.Name = "btnBrowseCustomer";
            this.btnBrowseCustomer.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseCustomer.TabIndex = 3;
            this.btnBrowseCustomer.Text = "...";
            this.btnBrowseCustomer.UseVisualStyleBackColor = true;
            this.btnBrowseCustomer.Click += new System.EventHandler(this.btnBrowseCustomer_Click);
            // 
            // txtSalesmanName
            // 
            this.txtSalesmanName.Enabled = false;
            this.txtSalesmanName.Location = new System.Drawing.Point(475, 60);
            this.txtSalesmanName.Name = "txtSalesmanName";
            this.txtSalesmanName.Size = new System.Drawing.Size(219, 20);
            this.txtSalesmanName.TabIndex = 208;
            // 
            // btnBrowseSalesman
            // 
            this.btnBrowseSalesman.Enabled = false;
            this.btnBrowseSalesman.Location = new System.Drawing.Point(698, 59);
            this.btnBrowseSalesman.Name = "btnBrowseSalesman";
            this.btnBrowseSalesman.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseSalesman.TabIndex = 6;
            this.btnBrowseSalesman.Text = "...";
            this.btnBrowseSalesman.UseVisualStyleBackColor = true;
            this.btnBrowseSalesman.Click += new System.EventHandler(this.btnBrowseSalesman_Click);
            // 
            // lblPaidStatus
            // 
            this.lblPaidStatus.AutoSize = true;
            this.lblPaidStatus.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidStatus.ForeColor = System.Drawing.Color.Red;
            this.lblPaidStatus.Location = new System.Drawing.Point(12, 508);
            this.lblPaidStatus.Name = "lblPaidStatus";
            this.lblPaidStatus.Size = new System.Drawing.Size(156, 43);
            this.lblPaidStatus.TabIndex = 210;
            this.lblPaidStatus.Text = "L U N A S";
            this.lblPaidStatus.Visible = false;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDueDate.Enabled = false;
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDueDate.Location = new System.Drawing.Point(92, 156);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(108, 20);
            this.dtpDueDate.TabIndex = 5;
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 212;
            this.label10.Text = "Tanggal Jatuh Tempo";
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(636, 225);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(39, 20);
            this.txtUnit.TabIndex = 249;
            this.txtUnit.Visible = false;
            // 
            // txtProductId
            // 
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(681, 225);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(39, 20);
            this.txtProductId.TabIndex = 250;
            this.txtProductId.Visible = false;
            // 
            // txtTermOfPayment
            // 
            this.txtTermOfPayment.BackColor = System.Drawing.SystemColors.Window;
            this.txtTermOfPayment.Enabled = false;
            this.txtTermOfPayment.Location = new System.Drawing.Point(24, 156);
            this.txtTermOfPayment.MaxLength = 3;
            this.txtTermOfPayment.Name = "txtTermOfPayment";
            this.txtTermOfPayment.Size = new System.Drawing.Size(53, 20);
            this.txtTermOfPayment.TabIndex = 4;
            this.txtTermOfPayment.TextChanged += new System.EventHandler(this.txtTermOfPayment_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 252;
            this.label11.Text = "TOP ( hari )";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(234, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 253;
            this.label12.Text = "Alamat";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCustomerAddress.Enabled = false;
            this.txtCustomerAddress.Location = new System.Drawing.Point(234, 112);
            this.txtCustomerAddress.MaxLength = 200;
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(227, 64);
            this.txtCustomerAddress.TabIndex = 254;
            // 
            // SalesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 557);
            this.Controls.Add(this.txtCustomerAddress);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTermOfPayment);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPaidStatus);
            this.Controls.Add(this.btnBrowseSalesman);
            this.Controls.Add(this.txtSalesmanName);
            this.Controls.Add(this.btnBrowseCustomer);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQtyEnd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSalesmanId);
            this.Controls.Add(this.txtCustomerId);
            this.Controls.Add(this.txtSalesId);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstSales);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.optCredit);
            this.Controls.Add(this.optCash);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SalesUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Penjualan";
            this.Load += new System.EventHandler(this.SalesUI_Load);
            this.Activated += new System.EventHandler(this.SalesUI_Activated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton optCash;
        private System.Windows.Forms.RadioButton optCredit;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ListBox lstSales;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.TextBox txtSalesmanId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQtyEnd;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnBrowseCustomer;
        private System.Windows.Forms.TextBox txtSalesmanName;
        private System.Windows.Forms.Button btnBrowseSalesman;
        private System.Windows.Forms.Label lblPaidStatus;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.ListView lvwSales;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtTermOfPayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCustomerAddress;
    }
}