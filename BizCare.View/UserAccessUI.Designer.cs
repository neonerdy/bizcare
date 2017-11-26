namespace BizCare.View
{
    partial class UserAccessUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccessUI));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbForm = new System.Windows.Forms.RadioButton();
            this.rbReport = new System.Windows.Forms.RadioButton();
            this.cboFormReport = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkEdit = new System.Windows.Forms.CheckBox();
            this.chkAdd = new System.Windows.Forms.CheckBox();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.lvwUserAccess = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.cboFilter = new System.Windows.Forms.ComboBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbSave,
            this.tsbCancel,
            this.tsbDelete,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(647, 25);
            this.toolStrip1.TabIndex = 1;
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
            // cboUser
            // 
            this.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUser.Enabled = false;
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(21, 64);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(136, 21);
            this.cboUser.TabIndex = 0;
            this.cboUser.SelectedIndexChanged += new System.EventHandler(this.cboUser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "User";
            // 
            // rbForm
            // 
            this.rbForm.AutoSize = true;
            this.rbForm.Checked = true;
            this.rbForm.Enabled = false;
            this.rbForm.Location = new System.Drawing.Point(183, 41);
            this.rbForm.Name = "rbForm";
            this.rbForm.Size = new System.Drawing.Size(48, 17);
            this.rbForm.TabIndex = 1;
            this.rbForm.TabStop = true;
            this.rbForm.Text = "Form";
            this.rbForm.UseVisualStyleBackColor = true;
            this.rbForm.CheckedChanged += new System.EventHandler(this.rbForm_CheckedChanged);
            // 
            // rbReport
            // 
            this.rbReport.AutoSize = true;
            this.rbReport.Enabled = false;
            this.rbReport.Location = new System.Drawing.Point(237, 41);
            this.rbReport.Name = "rbReport";
            this.rbReport.Size = new System.Drawing.Size(57, 17);
            this.rbReport.TabIndex = 2;
            this.rbReport.Text = "Report";
            this.rbReport.UseVisualStyleBackColor = true;
            this.rbReport.CheckedChanged += new System.EventHandler(this.rbReport_CheckedChanged);
            // 
            // cboFormReport
            // 
            this.cboFormReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormReport.Enabled = false;
            this.cboFormReport.FormattingEnabled = true;
            this.cboFormReport.Location = new System.Drawing.Point(183, 64);
            this.cboFormReport.Name = "cboFormReport";
            this.cboFormReport.Size = new System.Drawing.Size(427, 21);
            this.cboFormReport.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkDelete);
            this.groupBox1.Controls.Add(this.chkEdit);
            this.groupBox1.Controls.Add(this.chkAdd);
            this.groupBox1.Controls.Add(this.chkOpen);
            this.groupBox1.Location = new System.Drawing.Point(21, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 67);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hak Akses";
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Enabled = false;
            this.chkDelete.Location = new System.Drawing.Point(194, 29);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 7;
            this.chkDelete.Text = "Hapus";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkEdit
            // 
            this.chkEdit.AutoSize = true;
            this.chkEdit.Enabled = false;
            this.chkEdit.Location = new System.Drawing.Point(144, 29);
            this.chkEdit.Name = "chkEdit";
            this.chkEdit.Size = new System.Drawing.Size(44, 17);
            this.chkEdit.TabIndex = 6;
            this.chkEdit.Text = "Edit";
            this.chkEdit.UseVisualStyleBackColor = true;
            // 
            // chkAdd
            // 
            this.chkAdd.AutoSize = true;
            this.chkAdd.Enabled = false;
            this.chkAdd.Location = new System.Drawing.Point(73, 29);
            this.chkAdd.Name = "chkAdd";
            this.chkAdd.Size = new System.Drawing.Size(65, 17);
            this.chkAdd.TabIndex = 5;
            this.chkAdd.Text = "Tambah";
            this.chkAdd.UseVisualStyleBackColor = true;
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Enabled = false;
            this.chkOpen.Location = new System.Drawing.Point(16, 29);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(51, 17);
            this.chkOpen.TabIndex = 4;
            this.chkOpen.Text = "Buka";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // lvwUserAccess
            // 
            this.lvwUserAccess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.lvwUserAccess.FullRowSelect = true;
            this.lvwUserAccess.HideSelection = false;
            this.lvwUserAccess.Location = new System.Drawing.Point(0, 186);
            this.lvwUserAccess.Name = "lvwUserAccess";
            this.lvwUserAccess.Size = new System.Drawing.Size(647, 247);
            this.lvwUserAccess.TabIndex = 48;
            this.lvwUserAccess.UseCompatibleStateImageBehavior = false;
            this.lvwUserAccess.View = System.Windows.Forms.View.Details;
            this.lvwUserAccess.SelectedIndexChanged += new System.EventHandler(this.lvwUserAccess_SelectedIndexChanged);
            this.lvwUserAccess.DoubleClick += new System.EventHandler(this.lvwUserAccess_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // cboFilter
            // 
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FormattingEnabled = true;
            this.cboFilter.Location = new System.Drawing.Point(474, 0);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.Size = new System.Drawing.Size(136, 21);
            this.cboFilter.TabIndex = 49;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(21, 160);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(45, 20);
            this.txtUserId.TabIndex = 50;
            this.txtUserId.Visible = false;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(72, 160);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(45, 20);
            this.txtID.TabIndex = 51;
            this.txtID.Visible = false;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nama Lengkap";
            this.columnHeader8.Width = 106;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tipe";
            this.columnHeader9.Width = 61;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Nama Form/Report";
            this.columnHeader10.Width = 233;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Buka";
            this.columnHeader11.Width = 56;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tambah";
            this.columnHeader12.Width = 56;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Edit";
            this.columnHeader13.Width = 47;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Hapus";
            this.columnHeader14.Width = 45;
            // 
            // UserAccessUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 448);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.cboFilter);
            this.Controls.Add(this.lvwUserAccess);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboFormReport);
            this.Controls.Add(this.rbReport);
            this.Controls.Add(this.rbForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserAccessUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hak Akses";
            this.Load += new System.EventHandler(this.UserAccessUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbForm;
        private System.Windows.Forms.RadioButton rbReport;
        private System.Windows.Forms.ComboBox cboFormReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEdit;
        private System.Windows.Forms.CheckBox chkAdd;
        private System.Windows.Forms.CheckBox chkOpen;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.ListView lvwUserAccess;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox cboFilter;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
    }
}