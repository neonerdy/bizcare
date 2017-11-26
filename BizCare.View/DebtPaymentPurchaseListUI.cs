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
    public partial class DebtPaymentPurchaseListUI : Form
    {
        private DebtPaymentUI frmDebtPayment;
        private IPurchaseRepository purchaseRepository;

        public DebtPaymentPurchaseListUI()
        {
            InitializeComponent();
        }

         public DebtPaymentPurchaseListUI(DebtPaymentUI frmDebtPayment)
        {
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();

            this.frmDebtPayment = frmDebtPayment;
            InitializeComponent();
        }

        private void PopulatePurchase(Purchase purchase)
        {
            var item = new ListViewItem(purchase.ID.ToString());

            item.SubItems.Add(purchase.Date.ToString("dd/MM/yyyy"));
            item.SubItems.Add(purchase.Code);
            item.SubItems.Add(purchase.Supplier.Name);
            item.SubItems.Add(purchase.GrandTotal.ToString("N0").Replace(",", "."));

            lvwPurchase.Items.Add(item);

        }

        private void LoadPurchase()
        {
            var purchase = purchaseRepository.GetByStatusFalse();

            lvwPurchase.Items.Clear();

            foreach (var s in purchase)
            {
                PopulatePurchase(s);
            }
        }


        private void DebtPaymentPurchaseListUI_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            LoadPurchase();
        }

        private void lvwPurchase_DoubleClick(object sender, EventArgs e)
        {
            string purchaseId = lvwPurchase.FocusedItem.Text;
            string purchaseCode = lvwPurchase.FocusedItem.SubItems[2].Text;
            decimal purchaseTotal = decimal.Parse(lvwPurchase.FocusedItem.SubItems[4].Text.Replace(".",""));

            frmDebtPayment.PutPurchase(purchaseId, purchaseCode, purchaseTotal);

            this.Close();
        }


        private void FilterPurchase(string value)
        {
            var purchase = purchaseRepository.SearchStatusFalse(value);

            lvwPurchase.Items.Clear();

            foreach (var s in purchase)
            {
                PopulatePurchase(s);
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterPurchase(txtSearch.Text);
            }
            else
            {
                LoadPurchase();
            }
        }

     
    }
}
