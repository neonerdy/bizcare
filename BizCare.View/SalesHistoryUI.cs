using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizCare.Repository;
using EntityMap;
using BizCare.Model;
using Corbis.Repository;

namespace BizCare.View
{
    public partial class SalesHistoryUI : Form
    {
        private SalesUI frmSales;
        private ISalesRepository salesRepository;
        private string formActive; 

        public SalesHistoryUI()
        {
            InitializeComponent();
        }


        public SalesHistoryUI(SalesUI frmSales)
        {
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
            this.frmSales = frmSales;

            formActive = "SalesUI";

            InitializeComponent();
        }


     

        private void PopulateSales(Sales sales)
        {
            var item = new ListViewItem(sales.ID.ToString());

            item.SubItems.Add(sales.Date.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sales.Code);
            item.SubItems.Add(sales.Customer.Name);
            item.SubItems.Add(sales.Salesman.Name);
            item.SubItems.Add(sales.GrandTotal.ToString("N0").Replace(",", "."));
            item.SubItems.Add(sales.CreatedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sales.CreatedBy);
            item.SubItems.Add(sales.ModifiedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sales.ModifiedBy);

            lvwSales.Items.Add(item);

        }


        private void LoadSales()
        {
            var sales = salesRepository.GetAll(Store.ActiveMonth,Store.ActiveYear);

            lvwSales.Items.Clear();

            foreach (var s in sales)
            {
                PopulateSales(s);
            }
        }

        private void SalesHistoryUI_Load(object sender, EventArgs e)
        {
            
            lvwSales.Columns[6].Width = 0;
            lvwSales.Columns[7].Width = 0;
            lvwSales.Columns[8].Width = 0;
            lvwSales.Columns[9].Width = 0;

            this.Width = 480;

            LoadSales();
        }

        private void lvwSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmSales.GetSalesHistory(lvwSales.FocusedItem.SubItems[2].Text);
        }

        private void mAretToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lvwSales_DoubleClick(object sender, EventArgs e)
        {
            lvwSales_SelectedIndexChanged(sender, e);
            this.Close();

        }

        private void FilterSales(string value)
        {
            var sales1 = salesRepository.Search(value, Store.ActiveMonth, Store.ActiveYear);

            lvwSales.Items.Clear();

            foreach (var sales in sales1)
            {
                PopulateSales(sales);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterSales(txtSearch.Text);
            }
            else
            {
                LoadSales();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterSales(txtSearch.Text);
            }
            else
            {
                LoadSales();
            }
        }

        private void tsmUserLog_Click(object sender, EventArgs e)
        {
            
        }

        private void tsbUserLog_Click(object sender, EventArgs e)
        {
            if (tsbUserLog.CheckState == CheckState.Unchecked)
            {
                lvwSales.Columns[6].Width = 80;
                lvwSales.Columns[7].Width = 80;
                lvwSales.Columns[8].Width = 80;
                lvwSales.Columns[9].Width = 80;

                this.Width = 790;

                tsbUserLog.Checked = true;
            }
            else
            {
                lvwSales.Columns[6].Width = 0;
                lvwSales.Columns[7].Width = 0;
                lvwSales.Columns[8].Width = 0;
                lvwSales.Columns[9].Width = 0;

                this.Width = 480;

                tsbUserLog.Checked = false;
            }
        }

       
    }
}
