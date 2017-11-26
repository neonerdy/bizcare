namespace BizCare.View
{
    partial class CategoryUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryUI));
            this.lvwCategory = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwCategory
            // 
            this.lvwCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader10,
            this.columnHeader14});
            this.lvwCategory.FullRowSelect = true;
            this.lvwCategory.HideSelection = false;
            this.lvwCategory.Location = new System.Drawing.Point(0, 92);
            this.lvwCategory.Name = "lvwCategory";
            this.lvwCategory.Size = new System.Drawing.Size(420, 237);
            this.lvwCategory.TabIndex = 101;
            this.lvwCategory.UseCompatibleStateImageBehavior = false;
            this.lvwCategory.View = System.Windows.Forms.View.Details;
            this.lvwCategory.SelectedIndexChanged += new System.EventHandler(this.lvwCategory_SelectedIndexChanged);
            this.lvwCategory.DoubleClick += new System.EventHandler(this.lvwCategory_DoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Nama";
            this.columnHeader10.Width = 175;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Keterangan";
            this.columnHeader14.Width = 220;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(353, 31);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(50, 20);
            this.txtID.TabIndex = 100;
            this.txtID.Visible = false;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCategoryName.Enabled = false;
            this.txtCategoryName.Location = new System.Drawing.Point(12, 57);
            this.txtCategoryName.MaxLength = 200;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(199, 20);
            this.txtCategoryName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Nama";
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
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.Enabled = false;
            this.txtNotes.Location = new System.Drawing.Point(233, 57);
            this.txtNotes.MaxLength = 200;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(170, 20);
            this.txtNotes.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 95;
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
            this.toolStrip1.Size = new System.Drawing.Size(421, 25);
            this.toolStrip1.TabIndex = 92;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CategoryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 330);
            this.Controls.Add(this.lvwCategory);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CategoryUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Kategori";
            this.Load += new System.EventHandler(this.CategoryUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCategory;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}