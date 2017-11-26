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
    public partial class BillReceiptHistoryUI : Form
    {
        private BillReceiptUI frmBillReceipt;
        private IBillReceiptRepository billReceiptRepository;

        public BillReceiptHistoryUI()
        {
            InitializeComponent();
        }

         public BillReceiptHistoryUI(BillReceiptUI frmBillReceipt)
        {
            billReceiptRepository = ServiceLocator.GetObject<IBillReceiptRepository>();
            this.frmBillReceipt = frmBillReceipt;
            InitializeComponent();
        }

         private void PopulateBillReceipt(BillReceipt billReceipt)
        {
            var item = new ListViewItem(billReceipt.ID.ToString());

            item.SubItems.Add(billReceipt.BillReceiptDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(billReceipt.Code);
            item.SubItems.Add(billReceipt.Salesman.Name);
            item.SubItems.Add(billReceipt.GrandTotal.ToString("N0").Replace(",", "."));
            item.SubItems.Add(billReceipt.CreatedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(billReceipt.CreatedBy);
            item.SubItems.Add(billReceipt.ModifiedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(billReceipt.ModifiedBy);

            lvwBillReceipt.Items.Add(item);

        }

        private void LoadBillReceipt()
        {
            var billReceipt = billReceiptRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

            lvwBillReceipt.Items.Clear();

            foreach (var s in billReceipt)
            {
                PopulateBillReceipt(s);
            }
        }

        private void BillReceiptHistoryUI_Load(object sender, EventArgs e)
        {
            lvwBillReceipt.Columns[5].Width = 0;
            lvwBillReceipt.Columns[6].Width = 0;
            lvwBillReceipt.Columns[7].Width = 0;
            lvwBillReceipt.Columns[8].Width = 0;

            this.Width = 465;

            LoadBillReceipt();
        }

        private void lvwBillReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmBillReceipt.GetBillReceiptHistory(lvwBillReceipt.FocusedItem.SubItems[2].Text);
        }

        private void lvwBillReceipt_DoubleClick(object sender, EventArgs e)
        {
            lvwBillReceipt_SelectedIndexChanged(sender, e);
            this.Close();
        }

        private void FilterBillReceipt(string value)
        {
            var billReceipt1 = billReceiptRepository.Search(value, Store.ActiveMonth, Store.ActiveYear);

            lvwBillReceipt.Items.Clear();

            foreach (var billReceipt in billReceipt1)
            {
                PopulateBillReceipt(billReceipt);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterBillReceipt(txtSearch.Text);
            }
            else
            {
                LoadBillReceipt();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterBillReceipt(txtSearch.Text);
            }
            else
            {
                LoadBillReceipt();
            }
        }

        private void tsmUserLog_Click(object sender, EventArgs e)
        {
        }

        private void tsbUserLog_Click(object sender, EventArgs e)
        {

            if (tsbUserLog.CheckState == CheckState.Unchecked)
            {
                lvwBillReceipt.Columns[5].Width = 80;
                lvwBillReceipt.Columns[6].Width = 80;
                lvwBillReceipt.Columns[7].Width = 80;
                lvwBillReceipt.Columns[8].Width = 80;

                this.Width = 780;

                tsbUserLog.Checked = true;
            }
            else
            {
                lvwBillReceipt.Columns[5].Width = 0;
                lvwBillReceipt.Columns[6].Width = 0;
                lvwBillReceipt.Columns[7].Width = 0;
                lvwBillReceipt.Columns[8].Width = 0;

                this.Width = 465;

                tsbUserLog.Checked = false;
            }
        }
    }
}
