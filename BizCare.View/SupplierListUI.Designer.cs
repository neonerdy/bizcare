namespace BizCare.View
{
    partial class SupplierListUI
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
            this.lvwSupplier = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwSupplier
            // 
            this.lvwSupplier.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwSupplier.FullRowSelect = true;
            this.lvwSupplier.HideSelection = false;
            this.lvwSupplier.Location = new System.Drawing.Point(0, 26);
            this.lvwSupplier.Name = "lvwSupplier";
            this.lvwSupplier.Size = new System.Drawing.Size(420, 504);
            this.lvwSupplier.TabIndex = 78;
            this.lvwSupplier.UseCompatibleStateImageBehavior = false;
            this.lvwSupplier.View = System.Windows.Forms.View.Details;
            this.lvwSupplier.DoubleClick += new System.EventHandler(this.lvwSupplier_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nama Supplier";
            this.columnHeader2.Width = 384;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TermOfPayment";
            this.columnHeader3.Width = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(420, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // SupplierListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 542);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvwSupplier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierListUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Supplier";
            this.Load += new System.EventHandler(this.SupplierListUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSupplier;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtSearch;
    }
}