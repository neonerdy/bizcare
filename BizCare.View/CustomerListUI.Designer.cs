namespace BizCare.View
{
    partial class CustomerListUI
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
            this.lvwCustomer = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwCustomer
            // 
            this.lvwCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwCustomer.FullRowSelect = true;
            this.lvwCustomer.HideSelection = false;
            this.lvwCustomer.Location = new System.Drawing.Point(0, 26);
            this.lvwCustomer.Name = "lvwCustomer";
            this.lvwCustomer.Size = new System.Drawing.Size(418, 492);
            this.lvwCustomer.TabIndex = 1;
            this.lvwCustomer.UseCompatibleStateImageBehavior = false;
            this.lvwCustomer.View = System.Windows.Forms.View.Details;
            this.lvwCustomer.DoubleClick += new System.EventHandler(this.lvwCustomer_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nama Customer";
            this.columnHeader2.Width = 384;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TermOfPayment";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Address";
            this.columnHeader4.Width = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(418, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // CustomerListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 530);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvwCustomer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerListUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Customer";
            this.Load += new System.EventHandler(this.CustomerListUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCustomer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtSearch;
    }
}