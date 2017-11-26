namespace BizCare.View
{
    partial class ProductListUI
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
            this.lvwProduct = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwProduct
            // 
            this.lvwProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwProduct.FullRowSelect = true;
            this.lvwProduct.HideSelection = false;
            this.lvwProduct.Location = new System.Drawing.Point(0, 26);
            this.lvwProduct.Name = "lvwProduct";
            this.lvwProduct.Size = new System.Drawing.Size(440, 558);
            this.lvwProduct.TabIndex = 76;
            this.lvwProduct.UseCompatibleStateImageBehavior = false;
            this.lvwProduct.View = System.Windows.Forms.View.Details;
            this.lvwProduct.DoubleClick += new System.EventHandler(this.lvwProduct_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Kode";
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nama Barang";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Satuan";
            this.columnHeader4.Width = 73;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Harga";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 95;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(440, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // ProductListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 597);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvwProduct);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductListUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Barang";
            this.Load += new System.EventHandler(this.ProductListUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProduct;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtSearch;
    }
}