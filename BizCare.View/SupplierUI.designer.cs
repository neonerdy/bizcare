namespace BizCare.View
{
    partial class SupplierUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierUI));
            this.txtID = new System.Windows.Forms.TextBox();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtPlafon = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.tsbMenuFilter = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lvwSupplier = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.txtTermOfPayment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(781, 177);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 59;
            this.txtID.Visible = false;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Enabled = false;
            this.chkIsActive.Location = new System.Drawing.Point(244, 177);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(47, 17);
            this.chkIsActive.TabIndex = 7;
            this.chkIsActive.Text = "Aktif";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtPlafon
            // 
            this.txtPlafon.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPlafon.Enabled = false;
            this.txtPlafon.Location = new System.Drawing.Point(244, 130);
            this.txtPlafon.Name = "txtPlafon";
            this.txtPlafon.Size = new System.Drawing.Size(90, 20);
            this.txtPlafon.TabIndex = 5;
            this.txtPlafon.TextChanged += new System.EventHandler(this.txtPlafon_TextChanged);
            this.txtPlafon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlafon_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(241, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Plafon";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(18, 131);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(210, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "E-Mail";
            // 
            // txtContact
            // 
            this.txtContact.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtContact.Enabled = false;
            this.txtContact.Location = new System.Drawing.Point(19, 177);
            this.txtContact.MaxLength = 200;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(209, 20);
            this.txtContact.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Contact Person";
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtFax.Enabled = false;
            this.txtFax.Location = new System.Drawing.Point(340, 79);
            this.txtFax.MaxLength = 200;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(88, 20);
            this.txtFax.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Fax";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Telepon";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(244, 79);
            this.txtPhone.MaxLength = 200;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(90, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(645, 79);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(186, 72);
            this.txtNotes.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Keterangan";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(448, 78);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(186, 72);
            this.txtAddress.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Alamat";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(15, 79);
            this.txtName.MaxLength = 200;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 20);
            this.txtName.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Nama";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // tsbMenuFilter
            // 
            this.tsbMenuFilter.AutoToolTip = false;
            this.tsbMenuFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbMenuFilter.Image")));
            this.tsbMenuFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMenuFilter.Name = "tsbMenuFilter";
            this.tsbMenuFilter.Size = new System.Drawing.Size(65, 22);
            this.tsbMenuFilter.Text = " Filter";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // txtSearch
            // 
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.toolStrip1.Size = new System.Drawing.Size(849, 25);
            this.toolStrip1.TabIndex = 40;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lvwSupplier
            // 
            this.lvwSupplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwSupplier.FullRowSelect = true;
            this.lvwSupplier.HideSelection = false;
            this.lvwSupplier.Location = new System.Drawing.Point(2, 216);
            this.lvwSupplier.Name = "lvwSupplier";
            this.lvwSupplier.Size = new System.Drawing.Size(847, 314);
            this.lvwSupplier.TabIndex = 61;
            this.lvwSupplier.UseCompatibleStateImageBehavior = false;
            this.lvwSupplier.View = System.Windows.Forms.View.Details;
            this.lvwSupplier.SelectedIndexChanged += new System.EventHandler(this.lvwSupplier_SelectedIndexChanged);
            this.lvwSupplier.DoubleClick += new System.EventHandler(this.lvwSupplier_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nama";
            this.columnHeader2.Width = 225;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Alamat";
            this.columnHeader3.Width = 243;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Telepon";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Contact Person";
            this.columnHeader5.Width = 195;
            // 
            // txtTermOfPayment
            // 
            this.txtTermOfPayment.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTermOfPayment.Enabled = false;
            this.txtTermOfPayment.Location = new System.Drawing.Point(340, 130);
            this.txtTermOfPayment.MaxLength = 3;
            this.txtTermOfPayment.Name = "txtTermOfPayment";
            this.txtTermOfPayment.Size = new System.Drawing.Size(90, 20);
            this.txtTermOfPayment.TabIndex = 6;
            this.txtTermOfPayment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTermOfPayment_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 63;
            this.label10.Text = "TOP ( hari )";
            // 
            // SupplierUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 538);
            this.Controls.Add(this.txtTermOfPayment);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lvwSupplier);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtPlafon);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SupplierUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Supplier";
            this.Load += new System.EventHandler(this.SupplierUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtPlafon;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.ToolStripDropDownButton tsbMenuFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView lvwSupplier;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtTermOfPayment;
        private System.Windows.Forms.Label label10;
    }
}