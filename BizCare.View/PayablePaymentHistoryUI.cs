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
    public partial class PayablePaymentHistoryUI : Form
    {
        private PayablePaymentUI frmPayablePayment;
        private IPayablePaymentRepository payablePaymentRepository;

        public PayablePaymentHistoryUI()
        {
            InitializeComponent();
        }

        public PayablePaymentHistoryUI(PayablePaymentUI frmPayablePayment)
        {
            payablePaymentRepository = ServiceLocator.GetObject<IPayablePaymentRepository>();
            this.frmPayablePayment = frmPayablePayment;
            InitializeComponent();
        }

        private void PopulatePayablePayment(PayablePayment payablePayment)
        {
            var item = new ListViewItem(payablePayment.ID.ToString());

            item.SubItems.Add(payablePayment.PaymentDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(payablePayment.PaymentCode);
            item.SubItems.Add(payablePayment.GrandTotal.ToString("N0").Replace(",", "."));
            item.SubItems.Add(payablePayment.CreatedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(payablePayment.CreatedBy);
            item.SubItems.Add(payablePayment.ModifiedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(payablePayment.ModifiedBy);

            lvwPayablePayment.Items.Add(item);

        }

        private void LoadPayablePayment()
        {
            var payablePayment = payablePaymentRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

            lvwPayablePayment.Items.Clear();

            foreach (var s in payablePayment)
            {
                PopulatePayablePayment(s);
            }
        }

       

        private void PayablePaymentHistoryUI_Load(object sender, EventArgs e)
        {
            lvwPayablePayment.Columns[4].Width = 0;
            lvwPayablePayment.Columns[5].Width = 0;
            lvwPayablePayment.Columns[6].Width = 0;
            lvwPayablePayment.Columns[7].Width = 0;

            this.Width = 445;

            LoadPayablePayment();
        }

        private void lvwPayablePayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmPayablePayment.GetPayablePaymentHistory(lvwPayablePayment.FocusedItem.SubItems[2].Text);

        }

        private void lvwPayablePayment_DoubleClick(object sender, EventArgs e)
        {
            lvwPayablePayment_SelectedIndexChanged(sender, e);
            this.Close();
        }

        private void FilterPayablePayment(string value)
        {
            var payablePayment1 = payablePaymentRepository.Search(value, Store.ActiveMonth, Store.ActiveYear);

            lvwPayablePayment.Items.Clear();

            foreach (var payablePayment in payablePayment1)
            {
                PopulatePayablePayment(payablePayment);
            }

        }


        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterPayablePayment(txtSearch.Text);
            }
            else
            {
                LoadPayablePayment();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterPayablePayment(txtSearch.Text);
            }
            else
            {
                LoadPayablePayment();
            }
        }

        private void tsmUserLog_Click(object sender, EventArgs e)
        {
            if (tsmUserLog.CheckState == CheckState.Unchecked)
            {
                lvwPayablePayment.Columns[4].Width = 80;
                lvwPayablePayment.Columns[5].Width = 80;
                lvwPayablePayment.Columns[6].Width = 80;
                lvwPayablePayment.Columns[7].Width = 80;

                this.Width = 770;

                tsmUserLog.Checked = true;
            }
            else
            {
                lvwPayablePayment.Columns[4].Width = 0;
                lvwPayablePayment.Columns[5].Width = 0;
                lvwPayablePayment.Columns[6].Width = 0;
                lvwPayablePayment.Columns[7].Width = 0;

                this.Width = 445;

                tsmUserLog.Checked = false;
            }
        }
    }
}
