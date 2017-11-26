namespace BizCare.View
{
    partial class ExpenseUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseUI));
            this.txtExpenseTotal = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwExpense = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lstExpense = new System.Windows.Forms.ListBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtExpenseId = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.optGiro = new System.Windows.Forms.RadioButton();
            this.optCreditCard = new System.Windows.Forms.RadioButton();
            this.optBank = new System.Windows.Forms.RadioButton();
            this.optCash = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.txtNotesHeader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExpenseTotal
            // 
            this.txtExpenseTotal.Enabled = false;
            this.txtExpenseTotal.Location = new System.Drawing.Point(208, 473);
            this.txtExpenseTotal.Name = "txtExpenseTotal";
            this.txtExpenseTotal.Size = new System.Drawing.Size(56, 20);
            this.txtExpenseTotal.TabIndex = 340;
            this.txtExpenseTotal.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-2, 223);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(632, 245);
            this.tabControl1.TabIndex = 336;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwExpense);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(624, 219);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail Biaya";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwExpense
            // 
            this.lvwExpense.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader11});
            this.lvwExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwExpense.FullRowSelect = true;
            this.lvwExpense.HideSelection = false;
            this.lvwExpense.Location = new System.Drawing.Point(3, 3);
            this.lvwExpense.Name = "lvwExpense";
            this.lvwExpense.Size = new System.Drawing.Size(618, 213);
            this.lvwExpense.TabIndex = 202;
            this.lvwExpense.UseCompatibleStateImageBehavior = false;
            this.lvwExpense.View = System.Windows.Forms.View.Details;
            this.lvwExpense.DoubleClick += new System.EventHandler(this.lvwExpense_DoubleClick);
            this.lvwExpense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwExpense_KeyDown);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Keterangan";
            this.columnHeader9.Width = 469;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Total";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 116;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(485, 473);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(114, 24);
            this.lblTotal.TabIndex = 332;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblCode.Location = new System.Drawing.Point(442, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(184, 20);
            this.lblCode.TabIndex = 333;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 330;
            this.label7.Text = "Keterangan";
            // 
            // lstExpense
            // 
            this.lstExpense.FormattingEnabled = true;
            this.lstExpense.Location = new System.Drawing.Point(5, 473);
            this.lstExpense.Name = "lstExpense";
            this.lstExpense.Size = new System.Drawing.Size(197, 43);
            this.lstExpense.TabIndex = 335;
            this.lstExpense.Visible = false;
            this.lstExpense.SelectedIndexChanged += new System.EventHandler(this.lstExpense_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(575, 109);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(42, 20);
            this.txtID.TabIndex = 334;
            this.txtID.Visible = false;
            // 
            // txtExpenseId
            // 
            this.txtExpenseId.Enabled = false;
            this.txtExpenseId.Location = new System.Drawing.Point(526, 109);
            this.txtExpenseId.Name = "txtExpenseId";
            this.txtExpenseId.Size = new System.Drawing.Size(43, 20);
            this.txtExpenseId.TabIndex = 339;
            this.txtExpenseId.Visible = false;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(19, 189);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(215, 20);
            this.txtNotes.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Location = new System.Drawing.Point(-2, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 21);
            this.panel1.TabIndex = 331;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 329;
            this.label3.Text = "Tanggal";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(21, 46);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(213, 20);
            this.dtpDate.TabIndex = 0;
            // 
            // optGiro
            // 
            this.optGiro.AutoSize = true;
            this.optGiro.Enabled = false;
            this.optGiro.Location = new System.Drawing.Point(190, 99);
            this.optGiro.Name = "optGiro";
            this.optGiro.Size = new System.Drawing.Size(44, 17);
            this.optGiro.TabIndex = 4;
            this.optGiro.Text = "Giro";
            this.optGiro.UseVisualStyleBackColor = true;
            this.optGiro.CheckedChanged += new System.EventHandler(this.optGiro_CheckedChanged);
            // 
            // optCreditCard
            // 
            this.optCreditCard.AutoSize = true;
            this.optCreditCard.Enabled = false;
            this.optCreditCard.Location = new System.Drawing.Point(108, 99);
            this.optCreditCard.Name = "optCreditCard";
            this.optCreditCard.Size = new System.Drawing.Size(80, 17);
            this.optCreditCard.TabIndex = 3;
            this.optCreditCard.Text = "Kartu Kredit";
            this.optCreditCard.UseVisualStyleBackColor = true;
            this.optCreditCard.CheckedChanged += new System.EventHandler(this.optCreditCard_CheckedChanged);
            // 
            // optBank
            // 
            this.optBank.AutoSize = true;
            this.optBank.Enabled = false;
            this.optBank.Location = new System.Drawing.Point(59, 99);
            this.optBank.Name = "optBank";
            this.optBank.Size = new System.Drawing.Size(50, 17);
            this.optBank.TabIndex = 2;
            this.optBank.Text = "Bank";
            this.optBank.UseVisualStyleBackColor = true;
            this.optBank.CheckedChanged += new System.EventHandler(this.optBank_CheckedChanged);
            // 
            // optCash
            // 
            this.optCash.AutoSize = true;
            this.optCash.Checked = true;
            this.optCash.Enabled = false;
            this.optCash.Location = new System.Drawing.Point(18, 99);
            this.optCash.Name = "optCash";
            this.optCash.Size = new System.Drawing.Size(43, 17);
            this.optCash.TabIndex = 1;
            this.optCash.TabStop = true;
            this.optCash.Text = "Kas";
            this.optCash.UseVisualStyleBackColor = true;
            this.optCash.CheckedChanged += new System.EventHandler(this.optCash_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 345;
            this.label5.Text = "Sumber Dana";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(251, 30);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(84, 13);
            this.lblAccountName.TabIndex = 351;
            this.lblAccountName.Text = "Nama Rekening";
            // 
            // txtAccountName
            // 
            this.txtAccountName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAccountName.Enabled = false;
            this.txtAccountName.Location = new System.Drawing.Point(254, 46);
            this.txtAccountName.MaxLength = 200;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(151, 20);
            this.txtAccountName.TabIndex = 5;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(255, 190);
            this.txtTotal.MaxLength = 13;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(150, 20);
            this.txtTotal.TabIndex = 10;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 350;
            this.label9.Text = "Jumlah";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAccountNumber.Enabled = false;
            this.txtAccountNumber.Location = new System.Drawing.Point(254, 99);
            this.txtAccountNumber.MaxLength = 200;
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(151, 20);
            this.txtAccountNumber.TabIndex = 6;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Location = new System.Drawing.Point(251, 80);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(154, 13);
            this.lblAccountNumber.TabIndex = 349;
            this.lblAccountNumber.Text = "No Rekening/Kartu Kredit/Giro";
            // 
            // txtNotesHeader
            // 
            this.txtNotesHeader.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotesHeader.Enabled = false;
            this.txtNotesHeader.Location = new System.Drawing.Point(417, 47);
            this.txtNotesHeader.MaxLength = 200;
            this.txtNotesHeader.Multiline = true;
            this.txtNotesHeader.Name = "txtNotesHeader";
            this.txtNotesHeader.Size = new System.Drawing.Size(210, 72);
            this.txtNotesHeader.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 353;
            this.label2.Text = "Keterangan";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(480, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(47, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Batal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(422, 187);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(54, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 357;
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
            // ExpenseUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 517);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNotesHeader);
            this.Controls.Add(this.lblAccountName);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.lblAccountNumber);
            this.Controls.Add(this.optGiro);
            this.Controls.Add(this.optCreditCard);
            this.Controls.Add(this.optBank);
            this.Controls.Add(this.optCash);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtExpenseTotal);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lstExpense);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtExpenseId);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExpenseUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Biaya";
            this.Load += new System.EventHandler(this.ExpenseUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExpenseTotal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstExpense;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtExpenseId;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.RadioButton optGiro;
        private System.Windows.Forms.RadioButton optCreditCard;
        private System.Windows.Forms.RadioButton optBank;
        private System.Windows.Forms.RadioButton optCash;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.TextBox txtNotesHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwExpense;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbHistory;
    }
}