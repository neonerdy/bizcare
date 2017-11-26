namespace BizCare.View
{
    partial class UserUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserUI));
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.lvwUser = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.dtpFilter = new System.Windows.Forms.DateTimePicker();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIsAdmin = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(521, 135);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 101;
            this.txtID.Visible = false;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtUserName.Enabled = false;
            this.txtUserName.Location = new System.Drawing.Point(19, 58);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(137, 20);
            this.txtUserName.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 100;
            this.label9.Text = "Nama User";
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtFullName.Enabled = false;
            this.txtFullName.Location = new System.Drawing.Point(19, 114);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(137, 20);
            this.txtFullName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 99;
            this.label8.Text = "Nama Lengkap";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(340, 58);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(231, 76);
            this.txtNotes.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(337, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Keterangan";
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbSave,
            this.tsbCancel,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 25);
            this.toolStrip1.TabIndex = 93;
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
            // lvwUser
            // 
            this.lvwUser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwUser.FullRowSelect = true;
            this.lvwUser.HideSelection = false;
            this.lvwUser.Location = new System.Drawing.Point(0, 161);
            this.lvwUser.Name = "lvwUser";
            this.lvwUser.Size = new System.Drawing.Size(582, 284);
            this.lvwUser.TabIndex = 102;
            this.lvwUser.UseCompatibleStateImageBehavior = false;
            this.lvwUser.View = System.Windows.Forms.View.Details;
            this.lvwUser.SelectedIndexChanged += new System.EventHandler(this.lvwUser_SelectedIndexChanged);
            this.lvwUser.DoubleClick += new System.EventHandler(this.lvwUser_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nama User";
            this.columnHeader2.Width = 116;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Password";
            this.columnHeader3.Width = 109;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nama Lengkap";
            this.columnHeader4.Width = 144;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Login Terakhir";
            this.columnHeader5.Width = 178;
            // 
            // dtpFilter
            // 
            this.dtpFilter.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilter.Location = new System.Drawing.Point(223, 4);
            this.dtpFilter.Name = "dtpFilter";
            this.dtpFilter.Size = new System.Drawing.Size(382, 20);
            this.dtpFilter.TabIndex = 112;
            this.dtpFilter.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(176, 58);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(137, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Password";
            // 
            // chkIsAdmin
            // 
            this.chkIsAdmin.AutoSize = true;
            this.chkIsAdmin.Enabled = false;
            this.chkIsAdmin.Location = new System.Drawing.Point(176, 114);
            this.chkIsAdmin.Name = "chkIsAdmin";
            this.chkIsAdmin.Size = new System.Drawing.Size(86, 17);
            this.chkIsAdmin.TabIndex = 3;
            this.chkIsAdmin.Text = "Administrator";
            this.chkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // UserUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.chkIsAdmin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lvwUser);
            this.Controls.Add(this.dtpFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "User";
            this.Load += new System.EventHandler(this.UserUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ListView lvwUser;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.DateTimePicker dtpFilter;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIsAdmin;
    }
}