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
    public partial class PurchaseHistoryUI : Form
    {

        private PurchaseUI frmPurchase;
        private IPurchaseRepository purchaseRepository;

        public PurchaseHistoryUI()
        {
            InitializeComponent();
        }


         public PurchaseHistoryUI(PurchaseUI frmPurchase)
        {
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();
            this.frmPurchase = frmPurchase;
            InitializeComponent();
        }

         private void PopulatePurchase(Purchase purchase)
         {
             var item = new ListViewItem(purchase.ID.ToString());

             item.SubItems.Add(purchase.Date.ToString("dd/MM/yyyy"));
             item.SubItems.Add(purchase.Code);
             item.SubItems.Add(purchase.Supplier.Name);
             item.SubItems.Add(purchase.GrandTotal.ToString("N0").Replace(",", "."));
             item.SubItems.Add(purchase.CreatedDate.ToString("dd/MM/yyyy"));
             item.SubItems.Add(purchase.CreatedBy);
             item.SubItems.Add(purchase.ModifiedDate.ToString("dd/MM/yyyy"));
             item.SubItems.Add(purchase.ModifiedBy);

             lvwPurchase.Items.Add(item);

         }

         private void LoadPurchase()
         {
             var purchase = purchaseRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

             lvwPurchase.Items.Clear();

             foreach (var s in purchase)
             {
                 PopulatePurchase(s);
             }
         }

        private void PurchaseHistoryUI_Load(object sender, EventArgs e)
        {
            lvwPurchase.Columns[5].Width = 0;
            lvwPurchase.Columns[6].Width = 0;
            lvwPurchase.Columns[7].Width = 0;
            lvwPurchase.Columns[8].Width = 0;

            this.Width = 480;

            LoadPurchase();
        }

        private void lvwPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmPurchase.GetPurchaseHistory(lvwPurchase.FocusedItem.SubItems[2].Text);

        }

        private void lvwPurchase_DoubleClick(object sender, EventArgs e)
        {
            lvwPurchase_SelectedIndexChanged(sender, e);
            this.Close();
        }

        private void FilterPurchase(string value)
        {
            var purchase1 = purchaseRepository.Search(value, Store.ActiveMonth, Store.ActiveYear);

            lvwPurchase.Items.Clear();

            foreach (var purchase in purchase1)
            {
                PopulatePurchase(purchase);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
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

        private void tsmUserLog_Click(object sender, EventArgs e)
        {
          
        }

        private void tsbUserLog_Click(object sender, EventArgs e)
        {
            if (tsbUserLog.CheckState == CheckState.Unchecked)
            {
                lvwPurchase.Columns[5].Width = 80;
                lvwPurchase.Columns[6].Width = 80;
                lvwPurchase.Columns[7].Width = 80;
                lvwPurchase.Columns[8].Width = 80;

                this.Width = 790;

                tsbUserLog.Checked = true;
            }
            else
            {
                lvwPurchase.Columns[5].Width = 0;
                lvwPurchase.Columns[6].Width = 0;
                lvwPurchase.Columns[7].Width = 0;
                lvwPurchase.Columns[8].Width = 0;

                this.Width = 480;

                tsbUserLog.Checked = false;
            }
        }
    }
}
