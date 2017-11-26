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
    public partial class PayablePaymentSalesListUI : Form
    {
        private PayablePaymentUI frmPayablePayment;
        private ISalesRepository salesRepository;

        public PayablePaymentSalesListUI()
        {
            InitializeComponent();
        }

        public PayablePaymentSalesListUI(PayablePaymentUI frmPayablePayment)
        {
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();

            this.frmPayablePayment = frmPayablePayment;
            InitializeComponent();
        }

        private void PopulateSales(Sales sales)
        {
            var item = new ListViewItem(sales.ID.ToString());

            item.SubItems.Add(sales.Date.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sales.Code);
            item.SubItems.Add(sales.Customer.Name);
            item.SubItems.Add(sales.GrandTotal.ToString("N0").Replace(",", "."));

            lvwSales.Items.Add(item);

        }

        private void LoadSales()
        {
            var sales = salesRepository.GetByStatusFalse();

            lvwSales.Items.Clear();

            foreach (var s in sales)
            {
                PopulateSales(s);
            }
        }

        private void PayablePaymentSalesListUI_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            LoadSales();
        }

        private void lvwSales_DoubleClick(object sender, EventArgs e)
        {
            string salesId = lvwSales.FocusedItem.Text;
            string salesCode = lvwSales.FocusedItem.SubItems[2].Text;
            decimal salesTotal = decimal.Parse(lvwSales.FocusedItem.SubItems[4].Text.Replace(".",""));

            frmPayablePayment.PutSales(salesId, salesCode, salesTotal);

            this.Close();
        }


        private void FilterSales(string value)
        {
            var sales = salesRepository.SearchStatusFalse(value);

            lvwSales.Items.Clear();

            foreach (var s in sales)
            {
                PopulateSales(s);
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



    }
}
