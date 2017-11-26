using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityMap;
using BizCare.Model;
using BizCare.Repository;
using Corbis.Repository;

namespace BizCare.View
{
    public partial class StockCorrectionHistoryUI : Form
    {
        private StockCorrectionUI frmStockCorrection;
        private IStockCorrectionRepository stockCorrectionRepository;


        public StockCorrectionHistoryUI()
        {
            InitializeComponent();
        }

          public StockCorrectionHistoryUI(StockCorrectionUI frmStockCorrection)
        {
            stockCorrectionRepository = ServiceLocator.GetObject<IStockCorrectionRepository>();
            this.frmStockCorrection = frmStockCorrection;
            InitializeComponent();
        }

        private void PopulateStockCorrection(StockCorrection stockCorrection)
        {
            var item = new ListViewItem(stockCorrection.ID.ToString());

            item.SubItems.Add(stockCorrection.Date.ToString("dd/MM/yyyy"));
            item.SubItems.Add(stockCorrection.Code);
            item.SubItems.Add(stockCorrection.CreatedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(stockCorrection.CreatedBy);
            item.SubItems.Add(stockCorrection.ModifiedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(stockCorrection.ModifiedBy);
            lvwStockCorrection.Items.Add(item);

        }

        private void LoadStockCorrection()
        {
            var stockCorrection = stockCorrectionRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

            lvwStockCorrection.Items.Clear();

            foreach (var s in stockCorrection)
            {
                PopulateStockCorrection(s);
            }
        }

        private void StockCorrectionHistoryUI_Load(object sender, EventArgs e)
        {
            lvwStockCorrection.Columns[3].Width = 0;
            lvwStockCorrection.Columns[4].Width = 0;
            lvwStockCorrection.Columns[5].Width = 0;
            lvwStockCorrection.Columns[6].Width = 0;

            this.Width = 415;


            LoadStockCorrection();
        }

        private void lvwStockCorrection_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmStockCorrection.GetStockCorrectionHistory(lvwStockCorrection.FocusedItem.SubItems[2].Text);
        }

        private void lvwStockCorrection_DoubleClick(object sender, EventArgs e)
        {
            lvwStockCorrection_SelectedIndexChanged(sender, e);
            this.Close();
        }

          private void FilterStockCorrection(string value)
        {
            var stockCorrection1 = stockCorrectionRepository.Search(value, Store.ActiveMonth, Store.ActiveYear);

            lvwStockCorrection.Items.Clear();

            foreach (var stockCorrection in stockCorrection1)
            {
                PopulateStockCorrection(stockCorrection);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterStockCorrection(txtSearch.Text);
            }
            else
            {
                LoadStockCorrection();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
             if (txtSearch.Text.Length > 0)
            {
                FilterStockCorrection(txtSearch.Text);
            }
            else
            {
                LoadStockCorrection();
            }
        }

        private void tsbUserLog_Click(object sender, EventArgs e)
        {
            if (tsbUserLog.CheckState == CheckState.Unchecked)
            {
                lvwStockCorrection.Columns[3].Width = 80;
                lvwStockCorrection.Columns[4].Width = 80;
                lvwStockCorrection.Columns[5].Width = 80;
                lvwStockCorrection.Columns[6].Width = 80;

                this.Width = 740;

                tsbUserLog.Checked = true;
            }
            else
            {
                lvwStockCorrection.Columns[3].Width = 0;
                lvwStockCorrection.Columns[4].Width = 0;
                lvwStockCorrection.Columns[5].Width = 0;
                lvwStockCorrection.Columns[6].Width = 0;

                this.Width = 415;

                tsbUserLog.Checked = false;
            }
        }














    }
}
