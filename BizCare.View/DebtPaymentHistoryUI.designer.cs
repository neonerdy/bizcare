namespace BizCare.View
{
    partial class DebtPaymentHistoryUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebtPaymentHistoryUI));
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lvwDebtPayment = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbMenuFilter = new System.Windows.Forms.ToolStripLabel();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmUserLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lvwDebtPayment
            // 
            this.lvwDebtPayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8});
            this.lvwDebtPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwDebtPayment.FullRowSelect = true;
            this.lvwDebtPayment.HideSelection = false;
            this.lvwDebtPayment.Location = new System.Drawing.Point(0, 25);
            this.lvwDebtPayment.Name = "lvwDebtPayment";
            this.lvwDebtPayment.Size = new System.Drawing.Size(429, 541);
            this.lvwDebtPayment.TabIndex = 78;
            this.lvwDebtPayment.UseCompatibleStateImageBehavior = false;
            this.lvwDebtPayment.View = System.Windows.Forms.View.Details;
            this.lvwDebtPayment.SelectedIndexChanged += new System.EventHandler(this.lvwDebtPayment_SelectedIndexChanged);
            this.lvwDebtPayment.DoubleClick += new System.EventHandler(this.lvwDebtPayment_DoubleClick);
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
            // columnHeader6
            // 
            this.columnHeader6.Text = "Total";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 229;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // txtSearch
            // 
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMenuFilter,
            this.toolStripSeparator2,
            this.txtSearch,
            this.toolStripSeparator3,
            this.tsbFilter,
            this.toolStripSeparator4,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(429, 25);
            this.toolStrip1.TabIndex = 77;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbMenuFilter
            // 
            this.tsbMenuFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbMenuFilter.Image")));
            this.tsbMenuFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMenuFilter.Name = "tsbMenuFilter";
            this.tsbMenuFilter.Size = new System.Drawing.Size(52, 22);
            this.tsbMenuFilter.Text = " Filter";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tgl Input";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Input Oleh";
            this.columnHeader5.Width = 82;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tgl Update";
            this.columnHeader7.Width = 87;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Update Oleh";
            this.columnHeader8.Width = 89;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUserLog});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // tsmUserLog
            // 
            this.tsmUserLog.Name = "tsmUserLog";
            this.tsmUserLog.Size = new System.Drawing.Size(179, 22);
            this.tsmUserLog.Text = "Tampilkan User Log";
            this.tsmUserLog.Click += new System.EventHandler(this.tsmUserLog_Click);
            // 
            // DebtPaymentHistoryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 566);
            this.Controls.Add(this.lvwDebtPayment);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DebtPaymentHistoryUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Pembayaran Hutang";
            this.Load += new System.EventHandler(this.DebtPaymentHistoryUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ListView lvwDebtPayment;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsbMenuFilter;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem tsmUserLog;
    }
}