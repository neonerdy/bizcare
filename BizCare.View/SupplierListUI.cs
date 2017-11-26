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

namespace BizCare.View
{
    public partial class SupplierListUI : Form
    {
        private ISupplierRepository supplierRepository;
        private PurchaseUI frmPurchase;
        private DebtBalanceUI frmDebtBalance;
        private string formActive;

        public SupplierListUI(DebtBalanceUI frmDebtBalance)
        {
            InitializeComponent();
            this.frmDebtBalance = frmDebtBalance;

            supplierRepository = ServiceLocator.GetObject<ISupplierRepository>();
            formActive = "DebtBalance";        
        }


        public SupplierListUI(PurchaseUI frmPurchase)
        {
            InitializeComponent();
            this.frmPurchase = frmPurchase;

            supplierRepository = ServiceLocator.GetObject<ISupplierRepository>();
            formActive = "Purchase";
        }


        private void RenderSupplier(Supplier supplier)
        {
            var item = new ListViewItem(supplier.ID.ToString());
            item.SubItems.Add(supplier.Name);
            item.SubItems.Add(supplier.TermOfPayment.ToString("N0").Replace(",", "."));

            lvwSupplier.Items.Add(item);

        }

        private void FilterSuppliers(string value)
        {
            var suppliers = supplierRepository.Search(value);

            lvwSupplier.Items.Clear();

            foreach (var supplier in suppliers)
            {
                RenderSupplier(supplier);
            }

        }


        private void LoadSuppliers()
        {
            var suppliers = supplierRepository.GetActiveSupplier();

            lvwSupplier.Items.Clear();

            foreach (var supplier in suppliers)
            {
                RenderSupplier(supplier);
            }
        }




        private void SupplierListUI_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            LoadSuppliers();
        }


        private void lvwSupplier_DoubleClick(object sender, EventArgs e)
        {
            string id = lvwSupplier.FocusedItem.Text;
            string name = lvwSupplier.FocusedItem.SubItems[1].Text;
            int termOfPayment = int.Parse(lvwSupplier.FocusedItem.SubItems[2].Text);

            if (formActive == "Purchase")
            {
                frmPurchase.PutSupplier(id, name, termOfPayment);

            }
            else if (formActive == "DebtBalance")
            {
                frmDebtBalance.PutSupplier(id, name, termOfPayment);
            }

            this.Close();


        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterSuppliers(txtSearch.Text);
            }
            else
            {
                LoadSuppliers();
            }
        }

       
        



    }
}
