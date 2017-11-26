namespace BizCare.View
{
    partial class PayablePaymentUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayablePaymentUI));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwPayablePayment = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lstPayablePayment = new System.Windows.Forms.ListBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.txtPayablePaymentId = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.lblCode = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiroNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCorrection = new System.Windows.Forms.TextBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.lblBank = new System.Windows.Forms.Label();
            this.lblGiro = new System.Windows.Forms.Label();
            this.lblCorrection = new System.Windows.Forms.Label();
            this.txtSalesTotal = new System.Windows.Forms.TextBox();
            this.txtPaymentTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwPayablePayment);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 219);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail Pelunasan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwPayablePayment
            // 
            this.lvwPayablePayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader9});
            this.lvwPayablePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPayablePayment.FullRowSelect = true;
            this.lvwPayablePayment.HideSelection = false;
            this.lvwPayablePayment.Location = new System.Drawing.Point(3, 3);
            this.lvwPayablePayment.Name = "lvwPayablePayment";
            this.lvwPayablePayment.Size = new System.Drawing.Size(768, 213);
            this.lvwPayablePayment.TabIndex = 199;
            this.lvwPayablePayment.UseCompatibleStateImageBehavior = false;
            this.lvwPayablePayment.View = System.Windows.Forms.View.Details;
            this.lvwPayablePayment.DoubleClick += new System.EventHandler(this.lvwPayablePayment_DoubleClick);
            this.lvwPayablePayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwPayablePayment_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ProductID";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Dokumen";
            this.columnHeader5.Width = 106;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Cash";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 87;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Bank";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 105;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Giro";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "No Giro";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Koreksi";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 83;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Total";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 95;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "SalesTotal";
            this.columnHeader9.Width = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(711, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-5, 212);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 245);
            this.tabControl1.TabIndex = 229;
            // 
            // lstPayablePayment
            // 
            this.lstPayablePayment.FormattingEnabled = true;
            this.lstPayablePayment.Location = new System.Drawing.Point(2, 463);
            this.lstPayablePayment.Name = "lstPayablePayment";
            this.lstPayablePayment.Size = new System.Drawing.Size(197, 43);
            this.lstPayablePayment.TabIndex = 228;
            this.lstPayablePayment.Visible = false;
            this.lstPayablePayment.SelectedIndexChanged += new System.EventHandler(this.lstPayablePayment_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(688, 86);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(42, 20);
            this.txtID.TabIndex = 227;
            this.txtID.Visible = false;
            // 
            // txtSales
            // 
            this.txtSales.Enabled = false;
            this.txtSales.Location = new System.Drawing.Point(10, 169);
            this.txtSales.MaxLength = 200;
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(78, 20);
            this.txtSales.TabIndex = 223;
            // 
            // txtPayablePaymentId
            // 
            this.txtPayablePaymentId.Enabled = false;
            this.txtPayablePaymentId.Location = new System.Drawing.Point(639, 86);
            this.txtPayablePaymentId.Name = "txtPayablePaymentId";
            this.txtPayablePaymentId.Size = new System.Drawing.Size(43, 20);
            this.txtPayablePaymentId.TabIndex = 232;
            this.txtPayablePaymentId.Visible = false;
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(664, 208);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(39, 20);
            this.txtUnit.TabIndex = 231;
            this.txtUnit.Visible = false;
            // 
            // txtSalesId
            // 
            this.txtSalesId.Enabled = false;
            this.txtSalesId.Location = new System.Drawing.Point(709, 208);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(43, 20);
            this.txtSalesId.TabIndex = 230;
            this.txtSalesId.Visible = false;
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
            this.lblTotal.Location = new System.Drawing.Point(616, 472);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 24);
            this.lblTotal.TabIndex = 221;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(652, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 2;
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
            this.lblCode.Location = new System.Drawing.Point(568, 4);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(184, 20);
            this.lblCode.TabIndex = 222;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 219;
            this.label8.Text = "Bank";
            // 
            // txtBank
            // 
            this.txtBank.Enabled = false;
            this.txtBank.Location = new System.Drawing.Point(306, 169);
            this.txtBank.MaxLength = 13;
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(77, 20);
            this.txtBank.TabIndex = 5;
            this.txtBank.TextChanged += new System.EventHandler(this.txtBank_TextChanged);
            this.txtBank.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBank_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 217;
            this.label6.Text = "Cash";
            // 
            // txtCash
            // 
            this.txtCash.Enabled = false;
            this.txtCash.Location = new System.Drawing.Point(216, 169);
            this.txtCash.MaxLength = 13;
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(84, 20);
            this.txtCash.TabIndex = 4;
            this.txtCash.TextChanged += new System.EventHandler(this.txtCash_TextChanged);
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(208, 60);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(498, 20);
            this.txtNotes.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 44);
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
            this.label4.Location = new System.Drawing.Point(9, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 215;
            this.label4.Text = "Dokumen";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(-5, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 21);
            this.panel1.TabIndex = 214;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(18, 60);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(169, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 208;
            this.label3.Text = "Tanggal";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(91, 167);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 237;
            this.label1.Text = "Giro";
            // 
            // txtGiro
            // 
            this.txtGiro.Enabled = false;
            this.txtGiro.Location = new System.Drawing.Point(389, 169);
            this.txtGiro.MaxLength = 13;
            this.txtGiro.Name = "txtGiro";
            this.txtGiro.Size = new System.Drawing.Size(77, 20);
            this.txtGiro.TabIndex = 6;
            this.txtGiro.TextChanged += new System.EventHandler(this.txtGiro_TextChanged);
            this.txtGiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiro_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 239;
            this.label2.Text = "No Giro";
            // 
            // txtGiroNumber
            // 
            this.txtGiroNumber.Enabled = false;
            this.txtGiroNumber.Location = new System.Drawing.Point(472, 169);
            this.txtGiroNumber.MaxLength = 200;
            this.txtGiroNumber.Name = "txtGiroNumber";
            this.txtGiroNumber.Size = new System.Drawing.Size(77, 20);
            this.txtGiroNumber.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(552, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 241;
            this.label5.Text = "Koreksi";
            // 
            // txtCorrection
            // 
            this.txtCorrection.Enabled = false;
            this.txtCorrection.Location = new System.Drawing.Point(555, 168);
            this.txtCorrection.MaxLength = 13;
            this.txtCorrection.Name = "txtCorrection";
            this.txtCorrection.Size = new System.Drawing.Size(77, 20);
            this.txtCorrection.TabIndex = 8;
            this.txtCorrection.TextChanged += new System.EventHandler(this.txtCorrection_TextChanged);
            this.txtCorrection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCorrection_KeyPress);
            // 
            // lblCash
            // 
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.ForeColor = System.Drawing.Color.Black;
            this.lblCash.Location = new System.Drawing.Point(112, 472);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(83, 24);
            this.lblCash.TabIndex = 242;
            this.lblCash.Text = "0";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBank
            // 
            this.lblBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.ForeColor = System.Drawing.Color.Black;
            this.lblBank.Location = new System.Drawing.Point(219, 472);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(83, 24);
            this.lblBank.TabIndex = 243;
            this.lblBank.Text = "0";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGiro
            // 
            this.lblGiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiro.ForeColor = System.Drawing.Color.Black;
            this.lblGiro.Location = new System.Drawing.Point(330, 472);
            this.lblGiro.Name = "lblGiro";
            this.lblGiro.Size = new System.Drawing.Size(83, 24);
            this.lblGiro.TabIndex = 244;
            this.lblGiro.Text = "0";
            this.lblGiro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCorrection
            // 
            this.lblCorrection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrection.ForeColor = System.Drawing.Color.Black;
            this.lblCorrection.Location = new System.Drawing.Point(527, 472);
            this.lblCorrection.Name = "lblCorrection";
            this.lblCorrection.Size = new System.Drawing.Size(83, 24);
            this.lblCorrection.TabIndex = 245;
            this.lblCorrection.Text = "0";
            this.lblCorrection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSalesTotal
            // 
            this.txtSalesTotal.Enabled = false;
            this.txtSalesTotal.Location = new System.Drawing.Point(125, 169);
            this.txtSalesTotal.MaxLength = 13;
            this.txtSalesTotal.Name = "txtSalesTotal";
            this.txtSalesTotal.Size = new System.Drawing.Size(80, 20);
            this.txtSalesTotal.TabIndex = 246;
            this.txtSalesTotal.TextChanged += new System.EventHandler(this.txtSalesTotal_TextChanged);
            // 
            // txtPaymentTotal
            // 
            this.txtPaymentTotal.Enabled = false;
            this.txtPaymentTotal.Location = new System.Drawing.Point(602, 209);
            this.txtPaymentTotal.Name = "txtPaymentTotal";
            this.txtPaymentTotal.Size = new System.Drawing.Size(56, 20);
            this.txtPaymentTotal.TabIndex = 247;
            this.txtPaymentTotal.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(122, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 248;
            this.label9.Text = "Nilai Piutang";
            // 
            // PayablePaymentUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 512);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPaymentTotal);
            this.Controls.Add(this.txtSalesTotal);
            this.Controls.Add(this.lblCorrection);
            this.Controls.Add(this.lblGiro);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCorrection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGiroNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGiro);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstPayablePayment);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.txtPayablePaymentId);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtSalesId);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PayablePaymentUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pelunasan Piutang";
            this.Load += new System.EventHandler(this.PayablePaymentUI_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox lstPayablePayment;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.TextBox txtPayablePaymentId;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCash;
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
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiroNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCorrection;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.Label lblGiro;
        private System.Windows.Forms.Label lblCorrection;
        private System.Windows.Forms.TextBox txtSalesTotal;
        private System.Windows.Forms.TextBox txtPaymentTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView lvwPayablePayment;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}