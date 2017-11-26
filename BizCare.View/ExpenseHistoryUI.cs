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
    public partial class ExpenseHistoryUI : Form
    {
        private ExpenseUI frmExpense;
        private IExpenseRepository expenseRepository;

        public ExpenseHistoryUI()
        {
            InitializeComponent();
        }

           public ExpenseHistoryUI(ExpenseUI frmExpense)
        {
            expenseRepository = ServiceLocator.GetObject<IExpenseRepository>();
            this.frmExpense = frmExpense;
            InitializeComponent();
        }

            private void PopulateExpense(Expense expense)
        {
            var item = new ListViewItem(expense.ID.ToString());

            item.SubItems.Add(expense.Date.ToString("dd/MM/yyyy"));
            item.SubItems.Add(expense.Code);
            item.SubItems.Add(expense.AccountType);
            item.SubItems.Add(expense.GrandTotal.ToString("N0").Replace(",", "."));
            item.SubItems.Add(expense.CreatedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(expense.CreatedBy);
            item.SubItems.Add(expense.ModifiedDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(expense.ModifiedBy);
            lvwExpense.Items.Add(item);

        }

         private void LoadExpense()
        {
            var expense = expenseRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

            lvwExpense.Items.Clear();

            foreach (var s in expense)
            {
                PopulateExpense(s);
            }
        }

        private void ExpenseHistoryUI_Load(object sender, EventArgs e)
        {
            lvwExpense.Columns[5].Width = 0;
            lvwExpense.Columns[6].Width = 0;
            lvwExpense.Columns[7].Width = 0;
            lvwExpense.Columns[8].Width = 0;

            this.Width = 480;

            LoadExpense();
        }

        private void lvwExpense_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmExpense.GetExpenseHistory(lvwExpense.FocusedItem.SubItems[2].Text);
        }

        private void lvwExpense_DoubleClick(object sender, EventArgs e)
        {
            lvwExpense_SelectedIndexChanged(sender, e);
            this.Close();
        }

        private void FilterExpense(string value)
        {
            var expense1 = expenseRepository.Search(value, Store.ActiveMonth, Store.ActiveYear);

            lvwExpense.Items.Clear();

            foreach (var expense in expense1)
            {
                PopulateExpense(expense);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
         if (txtSearch.Text.Length > 0)
            {
                FilterExpense(txtSearch.Text);
            }
            else
            {
                LoadExpense();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
             if (txtSearch.Text.Length > 0)
            {
                FilterExpense(txtSearch.Text);
            }
            else
            {
                LoadExpense();
            }
        }


        private void tsbUserLog_Click(object sender, EventArgs e)
        {
            if (tsbUserLog.CheckState == CheckState.Unchecked)
            {
                lvwExpense.Columns[5].Width = 80;
                lvwExpense.Columns[6].Width = 80;
                lvwExpense.Columns[7].Width = 80;
                lvwExpense.Columns[8].Width = 80;

                this.Width = 790;

                tsbUserLog.Checked = true;
            }
            else
            {
                lvwExpense.Columns[5].Width = 0;
                lvwExpense.Columns[6].Width = 0;
                lvwExpense.Columns[7].Width = 0;
                lvwExpense.Columns[8].Width = 0;

                this.Width = 480;

                tsbUserLog.Checked = false;
            }
        }











    }
}
