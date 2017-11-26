namespace BizCare.View
{
    partial class BillReceiptUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillReceiptUI));
            this.txtBillReceiptTotal = new System.Windows.Forms.TextBox();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwBillReceipt = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.lstBillReceipt = new System.Windows.Forms.ListBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtBillReceiptId = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtSalesId = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSalesmanId = new System.Windows.Forms.TextBox();
            this.btnBrowseSalesman = new System.Windows.Forms.Button();
            this.txtSalesmanName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBillReceiptTotal
            // 
            this.txtBillReceiptTotal.Enabled = false;
            this.txtBillReceiptTotal.Location = new System.Drawing.Point(236, 469);
            this.txtBillReceiptTotal.Name = "txtBillReceiptTotal";
            this.txtBillReceiptTotal.Size = new System.Drawing.Size(56, 20);
            this.txtBillReceiptTotal.TabIndex = 319;
            this.txtBillReceiptTotal.Visible = false;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-5, 210);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 245);
            this.tabControl1.TabIndex = 303;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwBillReceipt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 219);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail TTNT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwBillReceipt
            // 
            this.lvwBillReceipt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lvwBillReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwBillReceipt.FullRowSelect = true;
            this.lvwBillReceipt.HideSelection = false;
            this.lvwBillReceipt.Location = new System.Drawing.Point(3, 3);
            this.lvwBillReceipt.Name = "lvwBillReceipt";
            this.lvwBillReceipt.Size = new System.Drawing.Size(564, 213);
            this.lvwBillReceipt.TabIndex = 201;
            this.lvwBillReceipt.UseCompatibleStateImageBehavior = false;
            this.lvwBillReceipt.View = System.Windows.Forms.View.Details;
            this.lvwBillReceipt.SelectedIndexChanged += new System.EventHandler(this.lvwBillReceipt_SelectedIndexChanged);
            this.lvwBillReceipt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwBillReceipt_KeyDown);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SalesID";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tanggal";
            this.columnHeader3.Width = 89;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Dokumen";
            this.columnHeader8.Width = 121;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Customer";
            this.columnHeader9.Width = 126;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Salesman";
            this.columnHeader10.Width = 88;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Total";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 98;
            // 
            // lstBillReceipt
            // 
            this.lstBillReceipt.FormattingEnabled = true;
            this.lstBillReceipt.Location = new System.Drawing.Point(2, 457);
            this.lstBillReceipt.Name = "lstBillReceipt";
            this.lstBillReceipt.Size = new System.Drawing.Size(197, 43);
            this.lstBillReceipt.TabIndex = 302;
            this.lstBillReceipt.Visible = false;
            this.lstBillReceipt.SelectedIndexChanged += new System.EventHandler(this.lstBillReceipt_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(515, 139);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(42, 20);
            this.txtID.TabIndex = 301;
            this.txtID.Visible = false;
            // 
            // txtBillReceiptId
            // 
            this.txtBillReceiptId.Enabled = false;
            this.txtBillReceiptId.Location = new System.Drawing.Point(466, 139);
            this.txtBillReceiptId.Name = "txtBillReceiptId";
            this.txtBillReceiptId.Size = new System.Drawing.Size(43, 20);
            this.txtBillReceiptId.TabIndex = 306;
            this.txtBillReceiptId.Visible = false;
            // 
            // txtUnit
            // 
            this.txtUnit.Enabled = false;
            this.txtUnit.Location = new System.Drawing.Point(298, 468);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(39, 20);
            this.txtUnit.TabIndex = 305;
            this.txtUnit.Visible = false;
            // 
            // txtSalesId
            // 
            this.txtSalesId.Enabled = false;
            this.txtSalesId.Location = new System.Drawing.Point(343, 468);
            this.txtSalesId.Name = "txtSalesId";
            this.txtSalesId.Size = new System.Drawing.Size(43, 20);
            this.txtSalesId.TabIndex = 304;
            this.txtSalesId.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(430, 464);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 24);
            this.lblTotal.TabIndex = 297;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(490, 185);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(54, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Tambah";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblCode.Location = new System.Drawing.Point(385, 1);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(184, 20);
            this.lblCode.TabIndex = 298;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.label7.Location = new System.Drawing.Point(241, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 289;
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
            this.toolStrip1.Size = new System.Drawing.Size(574, 25);
            this.toolStrip1.TabIndex = 285;
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
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(244, 65);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(300, 71);
            this.txtNotes.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(-5, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 21);
            this.panel1.TabIndex = 290;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(18, 65);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(199, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 286;
            this.label3.Text = "Tanggal";
            // 
            // txtSalesmanId
            // 
            this.txtSalesmanId.Enabled = false;
            this.txtSalesmanId.Location = new System.Drawing.Point(417, 139);
            this.txtSalesmanId.Name = "txtSalesmanId";
            this.txtSalesmanId.Size = new System.Drawing.Size(43, 20);
            this.txtSalesmanId.TabIndex = 323;
            this.txtSalesmanId.Visible = false;
            // 
            // btnBrowseSalesman
            // 
            this.btnBrowseSalesman.Enabled = false;
            this.btnBrowseSalesman.Location = new System.Drawing.Point(189, 114);
            this.btnBrowseSalesman.Name = "btnBrowseSalesman";
            this.btnBrowseSalesman.Size = new System.Drawing.Size(28, 23);
            this.btnBrowseSalesman.TabIndex = 1;
            this.btnBrowseSalesman.Text = "...";
            this.btnBrowseSalesman.UseVisualStyleBackColor = true;
            this.btnBrowseSalesman.Click += new System.EventHandler(this.btnBrowseSalesman_Click);
            // 
            // txtSalesmanName
            // 
            this.txtSalesmanName.Enabled = false;
            this.txtSalesmanName.Location = new System.Drawing.Point(18, 116);
            this.txtSalesmanName.Name = "txtSalesmanName";
            this.txtSalesmanName.Size = new System.Drawing.Size(169, 20);
            this.txtSalesmanName.TabIndex = 325;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 324;
            this.label2.Text = "Salesman";
            // 
            // BillReceiptUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 502);
            this.Controls.Add(this.btnBrowseSalesman);
            this.Controls.Add(this.txtSalesmanName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSalesmanId);
            this.Controls.Add(this.txtBillReceiptTotal);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstBillReceipt);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtBillReceiptId);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtSalesId);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BillReceiptUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TTNT";
            this.Load += new System.EventHandler(this.BillReceiptUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBillReceiptTotal;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstBillReceipt;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtBillReceiptId;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtSalesId;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSalesmanId;
        private System.Windows.Forms.ListView lvwBillReceipt;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnBrowseSalesman;
        private System.Windows.Forms.TextBox txtSalesmanName;
        private System.Windows.Forms.Label label2;
    }
}