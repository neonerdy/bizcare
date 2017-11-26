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
    public partial class PayableBalanceHistoryUI : Form
    {
        private IPayableBalanceRepository payableBalanceRepository;
        private PayableBalanceUI frmPayableBalance;

        public PayableBalanceHistoryUI()
        {
            InitializeComponent();
        }

        public PayableBalanceHistoryUI(PayableBalanceUI frmPayableBalance)
        {
            this.frmPayableBalance = frmPayableBalance;
            payableBalanceRepository = ServiceLocator.GetObject<IPayableBalanceRepository>();
            InitializeComponent();
        }

        private void PopulatePayableBalance(PayableBalance payableBalance)
        {
            var item = new ListViewItem(payableBalance.ID.ToString());

            item.SubItems.Add(payableBalance.SalesDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(payableBalance.SalesCode);
            item.SubItems.Add(payableBalance.Customer.Name);
            item.SubItems.Add(payableBalance.Salesman.Name);
            item.SubItems.Add(payableBalance.GrandTotal.ToString("N0").Replace(",", "."));

            lvwPayableBalance.Items.Add(item);

        }


        private void LoadPayableBalance()
        {
            int month = 0;
            int year = 0;

            if (Store.ActiveMonth == 1)
            {
                month = 12;
                year = Store.ActiveYear - 1;
            }
            else
            {
                month = Store.ActiveMonth - 1;
                year = Store.ActiveYear;
            }

            var payableBalance = payableBalanceRepository.GetAll(month, year);

            lvwPayableBalance.Items.Clear();

            foreach (var s in payableBalance)
            {
                PopulatePayableBalance(s);
            }
        }


        private void FilterPayableBalance(string value)
        {
            int month = 0;
            int year = 0;

            if (Store.ActiveMonth == 1)
            {
                month = 12;
                year = Store.ActiveYear - 1;
            }
            else
            {
                month = Store.ActiveMonth - 1;
                year = Store.ActiveYear;
            }

            var payableBalance = payableBalanceRepository.Search(month,year,value);

            lvwPayableBalance.Items.Clear();

            foreach (var pb in payableBalance)
            {
                PopulatePayableBalance(pb);
            }

        }




        private void PayableBalanceHistoryUI_Load(object sender, EventArgs e)
        {
            LoadPayableBalance();
        }

        private void lvwPayableBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmPayableBalance.GetPayableBalanceHistory(lvwPayableBalance.FocusedItem.SubItems[2].Text);
        }

        private void lvwPayableBalance_DoubleClick(object sender, EventArgs e)
        {
            lvwPayableBalance_SelectedIndexChanged(sender, e);
            this.Close();
        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterPayableBalance(txtSearch.Text);
            }
            else
            {
                LoadPayableBalance();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterPayableBalance(txtSearch.Text);
            }
            else
            {
                LoadPayableBalance();
            }
        }


    }
}
