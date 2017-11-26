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
    public partial class DebtPaymentHistoryUI : Form
    {

        private DebtPaymentUI frmDebtPayment;
        private IDebtPaymentRepository debtPaymentRepository;

        public DebtPaymentHistoryUI()
        {
            InitializeComponent();
        }

        public DebtPaymentHistoryUI(DebtPaymentUI frmDebtPayment)
        {
            debtPaymentRepository = ServiceLocator.GetObject<IDebtPaymentRepository>();
            this.frmDebtPayment = frmDebtPayment;
            InitializeComponent();
        }

        private void PopulateDebtPayment(DebtPayment debtPayment)
        {
            var item = new ListViewItem(debtPayment.ID.ToString());

            item.SubItems.Add(debtPayment.PaymentDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(debtPayment.PaymentCode);
            item.SubItems.Add(debtPayment.GrandTotal.ToString("N0").Replace(",", "."));
            item.SubItems.Add(debtPayment.CreatedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(debtPayment.CreatedBy);
            item.SubItems.Add(debtPayment.ModifiedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(debtPayment.ModifiedBy);

            lvwDebtPayment.Items.Add(item);

        }

        private void LoadDebtPayment()
        {
            var debtPayment = debtPaymentRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

            lvwDebtPayment.Items.Clear();

            foreach (var s in debtPayment)
            {
                PopulateDebtPayment(s);
            }
        }

        private void DebtPaymentHistoryUI_Load(object sender, EventArgs e)
        {
            lvwDebtPayment.Columns[4].Width = 0;
            lvwDebtPayment.Columns[5].Width = 0;
            lvwDebtPayment.Columns[6].Width = 0;
            lvwDebtPayment.Columns[7].Width = 0;

            this.Width = 435;

            LoadDebtPayment();
        }

        private void lvwDebtPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmDebtPayment.GetDebtPaymentHistory(lvwDebtPayment.FocusedItem.SubItems[2].Text);

        }

        private void lvwDebtPayment_DoubleClick(object sender, EventArgs e)
        {
            lvwDebtPayment_SelectedIndexChanged(sender, e);
            this.Close();
        }

        private void FilterDebtPayment(string value)
        {
            var debtPayment1 = debtPaymentRepository.Search(value, Store.ActiveMonth, Store.ActiveYear);

            lvwDebtPayment.Items.Clear();

            foreach (var debtPayment in debtPayment1)
            {
                PopulateDebtPayment(debtPayment);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterDebtPayment(txtSearch.Text);
            }
            else
            {
                LoadDebtPayment();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterDebtPayment(txtSearch.Text);
            }
            else
            {
                LoadDebtPayment();
            }
        }

        private void tsmUserLog_Click(object sender, EventArgs e)
        {
            if (tsmUserLog.CheckState == CheckState.Unchecked)
            {
                lvwDebtPayment.Columns[4].Width = 80;
                lvwDebtPayment.Columns[5].Width = 80;
                lvwDebtPayment.Columns[6].Width = 80;
                lvwDebtPayment.Columns[7].Width = 80;

                this.Width = 770;

                tsmUserLog.Checked = true;
            }
            else
            {
                lvwDebtPayment.Columns[4].Width = 0;
                lvwDebtPayment.Columns[5].Width = 0;
                lvwDebtPayment.Columns[6].Width = 0;
                lvwDebtPayment.Columns[7].Width = 0;

                this.Width = 435;

                tsmUserLog.Checked = false;
            }
        }
    }
}
