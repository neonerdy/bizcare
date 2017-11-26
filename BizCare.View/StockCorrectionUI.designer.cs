namespace BizCare.View
{
    partial class StockCorrectionUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockCorrectionUI));
            this.label8 = new System.Windows.Forms.Label();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.txtQtyMinus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQtyPlus = new System.Windows.Forms.TextBox();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.lblCode = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwStockCorrection = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.lstStockCorrection = new System.Windows.Forms.ListBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtStockCorrectionId = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValueMinus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValuePlus = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(337, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 253;
            this.label8.Text = "Qty ( -- )";
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
            // txtQtyMinus
            // 
            this.txtQtyMinus.Enabled = false;
            this.txtQtyMinus.Location = new System.Drawing.Point(340, 147);
            this.txtQtyMinus.Name = "txtQtyMinus";
            this.txtQtyMinus.Size = new System.Drawing.Size(77, 20);
            this.txtQtyMinus.TabIndex = 5;
            this.txtQtyMinus.TextChanged += new System.EventHandler(this.txtQtyMinus_TextChanged);
            this.txtQtyMinus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyMinus_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 252;
            this.label6.Text = "Qty ( + )";
            // 
            // txtQtyPlus
            // 
            this.txtQtyPlus.Enabled = false;
            this.txtQtyPlus.Location = new System.Drawing.Point(250, 148);
            this.txtQtyPlus.Name = "txtQtyPlus";
            this.txtQtyPlus.Size = new System.Drawing.Size(84, 20);
            this.txtQtyPlus.TabIndex = 4;
            this.txtQtyPlus.TextChanged += new System.EventHandler(this.txtQtyPlus_TextChanged);
            this.txtQtyPlus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtyPlus_KeyPress);
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
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(188, 53);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(463, 20);
            this.txtNotes.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 249;
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
            this.toolStrip1.Size = new System.Drawing.Size(726, 25);
            this.toolStrip1.TabIndex = 245;
            this.toolStrip1.Text = "toolStrip1";
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
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblCode.Location = new System.Drawing.Point(520, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(184, 20);
            this.lblCode.TabIndex = 255;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 251;
            this.label4.Text = "Barang";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(-5, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 21);
            this.panel1.TabIndex = 250;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(13, 53);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(169, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 246;
            this.label3.Text = "Tanggal";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(188, 143);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(42, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(657, 142);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-5, 180);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(782, 311);
            this.tabControl1.TabIndex = 259;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwStockCorrection);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(774, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail Pembelian";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwStockCorrection
            // 
            this.lvwStockCorrection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwStockCorrection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwStockCorrection.FullRowSelect = true;
            this.lvwStockCorrection.HideSelection = false;
            this.lvwStockCorrection.Location = new System.Drawing.Point(3, 3);
            this.lvwStockCorrection.Name = "lvwStockCorrection";
            this.lvwStockCorrection.Size = new System.Drawing.Size(768, 279);
            this.lvwStockCorrection.TabIndex = 195;
            this.lvwStockCorrection.UseCompatibleStateImageBehavior = false;
            this.lvwStockCorrection.View = System.Windows.Forms.View.Details;
            this.lvwStockCorrection.DoubleClick += new System.EventHandler(this.lvwStockCorrection_DoubleClick);
            this.lvwStockCorrection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwStockCorrection_KeyDown);
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
            this.columnHeader8.Text = "Qty (+)";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 61;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Qty (-)";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nilai (+)";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nilai (-)";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 87;
            // 
            // lstStockCorrection
            // 
            this.lstStockCorrection.FormattingEnabled = true;
            this.lstStockCorrection.Location = new System.Drawing.Point(2, 516);
            this.lstStockCorrection.Name = "lstStockCorrection";
            this.lstStockCorrection.Size = new System.Drawing.Size(197, 43);
            this.lstStockCorrection.TabIndex = 258;
            this.lstStockCorrection.Visible = false;
            this.lstStockCorrection.SelectedIndexChanged += new System.EventHandler(this.lstStockCorrection_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(750, 53);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(42, 20);
            this.txtID.TabIndex = 257;
            this.txtID.Visible = false;
            // 
            // txtProduct
            // 
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(12, 145);
            this.txtProduct.MaxLength = 200;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(170, 20);
            this.txtProduct.TabIndex = 256;
            // 
            // txtStockCorrectionId
            // 
            this.txtStockCorrectionId.Enabled = false;
            this.txtStockCorrectionId.Location = new System.Drawing.Point(679, 53);
            this.txtStockCorrectionId.Name = "txtStockCorrectionId";
            this.txtStockCorrectionId.Size = new System.Drawing.Size(43, 20);
            this.txtStockCorrectionId.TabIndex = 262;
            this.txtStockCorrectionId.Visible = false;
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(679, 113);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(39, 20);
            this.txtUnit.TabIndex = 261;
            this.txtUnit.Visible = false;
            // 
            // txtProductId
            // 
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(727, 113);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(43, 20);
            this.txtProductId.TabIndex = 260;
            this.txtProductId.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(597, 142);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 268;
            this.label1.Text = "Nilai ( -- )";
            // 
            // txtValueMinus
            // 
            this.txtValueMinus.Enabled = false;
            this.txtValueMinus.Location = new System.Drawing.Point(511, 146);
            this.txtValueMinus.Name = "txtValueMinus";
            this.txtValueMinus.Size = new System.Drawing.Size(77, 20);
            this.txtValueMinus.TabIndex = 7;
            this.txtValueMinus.TextChanged += new System.EventHandler(this.txtValueMinus_TextChanged);
            this.txtValueMinus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueMinus_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 267;
            this.label2.Text = "Nilai ( + )";
            // 
            // txtValuePlus
            // 
            this.txtValuePlus.Enabled = false;
            this.txtValuePlus.Location = new System.Drawing.Point(421, 147);
            this.txtValuePlus.Name = "txtValuePlus";
            this.txtValuePlus.Size = new System.Drawing.Size(84, 20);
            this.txtValuePlus.TabIndex = 6;
            this.txtValuePlus.TextChanged += new System.EventHandler(this.txtValuePlus_TextChanged);
            this.txtValuePlus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValuePlus_KeyPress);
            // 
            // StockCorrectionUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 495);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValueMinus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValuePlus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQtyMinus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQtyPlus);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstStockCorrection);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtStockCorrectionId);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtProductId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StockCorrectionUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Koreksi Stok";
            this.Load += new System.EventHandler(this.StockCorrectionUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.TextBox txtQtyMinus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQtyPlus;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstStockCorrection;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtStockCorrectionId;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValueMinus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValuePlus;
        private System.Windows.Forms.ListView lvwStockCorrection;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}