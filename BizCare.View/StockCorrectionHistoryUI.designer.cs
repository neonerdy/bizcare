﻿namespace BizCare.View
{
    partial class StockCorrectionHistoryUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockCorrectionHistoryUI));
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUserLog = new System.Windows.Forms.ToolStripButton();
            this.lvwStockCorrection = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.tsbMenuFilter = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.tsbUserLog});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(734, 25);
            this.toolStrip1.TabIndex = 84;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // txtSearch
            // 
            this.txtSearch.MaxLength = 200;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUserLog
            // 
            this.tsbUserLog.AutoSize = false;
            this.tsbUserLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUserLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbUserLog.Image")));
            this.tsbUserLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUserLog.Name = "tsbUserLog";
            this.tsbUserLog.Size = new System.Drawing.Size(23, 22);
            this.tsbUserLog.ToolTipText = "User Log";
            this.tsbUserLog.Click += new System.EventHandler(this.tsbUserLog_Click);
            // 
            // lvwStockCorrection
            // 
            this.lvwStockCorrection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvwStockCorrection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwStockCorrection.FullRowSelect = true;
            this.lvwStockCorrection.HideSelection = false;
            this.lvwStockCorrection.Location = new System.Drawing.Point(0, 25);
            this.lvwStockCorrection.Name = "lvwStockCorrection";
            this.lvwStockCorrection.Size = new System.Drawing.Size(734, 531);
            this.lvwStockCorrection.TabIndex = 88;
            this.lvwStockCorrection.UseCompatibleStateImageBehavior = false;
            this.lvwStockCorrection.View = System.Windows.Forms.View.Details;
            this.lvwStockCorrection.SelectedIndexChanged += new System.EventHandler(this.lvwStockCorrection_SelectedIndexChanged);
            this.lvwStockCorrection.DoubleClick += new System.EventHandler(this.lvwStockCorrection_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tanggal";
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dokumen";
            this.columnHeader3.Width = 259;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tgl Input";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Input Oleh";
            this.columnHeader5.Width = 87;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tgl Update";
            this.columnHeader6.Width = 79;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Update Oleh";
            this.columnHeader7.Width = 98;
            // 
            // tsbMenuFilter
            // 
            this.tsbMenuFilter.Image = ((System.Drawing.Image)(resources.GetObject("tsbMenuFilter.Image")));
            this.tsbMenuFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMenuFilter.Name = "tsbMenuFilter";
            this.tsbMenuFilter.Size = new System.Drawing.Size(52, 22);
            this.tsbMenuFilter.Text = " Filter";
            // 
            // StockCorrectionHistoryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 556);
            this.Controls.Add(this.lvwStockCorrection);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StockCorrectionHistoryUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Koreksi Stok";
            this.Load += new System.EventHandler(this.StockCorrectionHistoryUI_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbUserLog;
        private System.Windows.Forms.ListView lvwStockCorrection;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStripLabel tsbMenuFilter;
    }
}