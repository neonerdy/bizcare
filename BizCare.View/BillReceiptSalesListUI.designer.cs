namespace BizCare.View
{
    partial class BillReceiptSalesListUI
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
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.lvwSales = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Total";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 114;
            // 
            // lvwSales
            // 
            this.lvwSales.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.lvwSales.FullRowSelect = true;
            this.lvwSales.HideSelection = false;
            this.lvwSales.Location = new System.Drawing.Point(0, 60);
            this.lvwSales.Name = "lvwSales";
            this.lvwSales.Size = new System.Drawing.Size(449, 503);
            this.lvwSales.TabIndex = 74;
            this.lvwSales.UseCompatibleStateImageBehavior = false;
            this.lvwSales.View = System.Windows.Forms.View.Details;
            this.lvwSales.DoubleClick += new System.EventHandler(this.lvwSales_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tanggal";
            this.columnHeader2.Width = 79;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Kode";
            this.columnHeader3.Width = 78;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Customer";
            this.columnHeader4.Width = 154;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.Location = new System.Drawing.Point(12, 28);
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(374, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 77;
            this.label1.Text = "Kriteria";
            // 
            // BillReceiptSalesListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 566);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwSales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BillReceiptSalesListUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Penjualan";
            this.Load += new System.EventHandler(this.BillReceiptSalesListUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvwSales;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}