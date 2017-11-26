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
    public partial class CustomerListUI : Form
    {
        private ICustomerRepository customerRepository;
        private SalesUI frmSales;
        private PayableBalanceUI frmPayableBalance;
        private string formActive;       

        public CustomerListUI(SalesUI frmSales)
        {
            InitializeComponent();
            customerRepository = ServiceLocator.GetObject<ICustomerRepository>();

            this.frmSales = frmSales;
            formActive = "Sales";
        }


        public CustomerListUI(PayableBalanceUI frmPayableBalance)
        {
            InitializeComponent();
            customerRepository = ServiceLocator.GetObject<ICustomerRepository>();

            this.frmPayableBalance = frmPayableBalance;
            formActive = "PayableBalance";
        }

        public void SearchSetFocus ()
        {
              txtSearch.Focus();

        }

        private void RenderCustomer(Customer customer)
        {
            var item = new ListViewItem(customer.ID.ToString());
            item.SubItems.Add(customer.Name);
            item.SubItems.Add(customer.TermOfPayment.ToString("N0").Replace(",", "."));
            item.SubItems.Add(customer.Address);

            lvwCustomer.Items.Add(item);

        }

        private void FilterCustomers(string value)
        {
            var customers = customerRepository.Search(value);

            lvwCustomer.Items.Clear();

            foreach (var customer in customers)
            {
                RenderCustomer(customer);
            }

        }


        private void LoadCustomers()
        {
            var customers = customerRepository.GetActiveCustomer();

            lvwCustomer.Items.Clear();

            foreach (var customer in customers)
            {
                RenderCustomer(customer);
            }
        }



        private void CustomerListUI_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            LoadCustomers();
        }




        private void lvwCustomer_DoubleClick(object sender, EventArgs e)
        {
            string id = lvwCustomer.FocusedItem.Text;
            string name = lvwCustomer.FocusedItem.SubItems[1].Text;
            int termOfPayment = int.Parse(lvwCustomer.FocusedItem.SubItems[2].Text);
            string address = lvwCustomer.FocusedItem.SubItems[3].Text;

            if (formActive == "Sales")
            {
                frmSales.PutCustomer(id, name, address, termOfPayment);
            }
            else if (formActive == "PayableBalance")
            {
                frmPayableBalance.PutCustomer(id, name, termOfPayment);
            }


            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterCustomers(txtSearch.Text);
            }
            else
            {
                LoadCustomers();
            }
        }

        
     
    }
}
