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
    public partial class SalesmanListUI : Form
    {
        private ISalesmanRepository salesmanRepository;
        private SalesUI frmSales;        
        private PayableBalanceUI frmPayableBalance;
        private BillReceiptUI frmBillReceipt;
        
        private string formActive;


        public SalesmanListUI(SalesUI frmSales)
        {
            InitializeComponent();
            this.frmSales = frmSales;
            formActive = "Sales";

            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
        }


        public SalesmanListUI(PayableBalanceUI frmPayableBalance)
        {
            InitializeComponent();
            this.frmPayableBalance = frmPayableBalance;
            formActive = "PayableBalance";
            
            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
        }


        public SalesmanListUI(BillReceiptUI frmBillReceipt)
        {
            InitializeComponent();
            this.frmBillReceipt = frmBillReceipt;
            formActive = "BillReceipt";

            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
        }




        private void RenderSalesman(Salesman salesman)
        {
            var item = new ListViewItem(salesman.ID.ToString());
            item.SubItems.Add(salesman.Name);

            lvwSalesman.Items.Add(item);

        }

        private void FilterSalesman(string value)
        {
            var salesman = salesmanRepository.Search(value);

            lvwSalesman.Items.Clear();

            foreach (var s in salesman)
            {
                RenderSalesman(s);
            }
        }


        private void LoadSalesman()
        {
            var salesman = salesmanRepository.GetActiveSalesman();

            lvwSalesman.Items.Clear();

            foreach (var s in salesman)
            {
                RenderSalesman(s);
            }
        }


        private void SalesmanListUI_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            LoadSalesman();
        }


        private void lvwSalesman_DoubleClick(object sender, EventArgs e)
        {
            string id = lvwSalesman.FocusedItem.Text;
            string name = lvwSalesman.FocusedItem.SubItems[1].Text;

            if (formActive == "Sales")
            {
                frmSales.PutSalesman(id, name);
            }
            else if (formActive == "PayableBalance")
            {
                frmPayableBalance.PutSalesman(id, name);
            }
            else if (formActive == "BillReceipt")
            {
                frmBillReceipt.PutSalesman(id, name);
            }

            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterSalesman(txtSearch.Text);
            }
            else
            {
                LoadSalesman();
            }
        }




       

    }
}
