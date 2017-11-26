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
using BizCare.Report;

namespace BizCare.View
{
    public partial class ExpenseUI : Form
    {
        private MainUI frmMain;
        private FormMode formMode;
        private FormFilter formFilter;

        private IExpenseRepository expenseRepository;
        private IExpenseItemRepository expenseItemRepository;
        private IUserAccessRepository userAccessRepository;

        public ExpenseUI()
        {
            InitializeComponent();
        }

            public ExpenseUI(MainUI frmMain)
        {
            this.frmMain = frmMain;

         
            expenseRepository = ServiceLocator.GetObject<IExpenseRepository>();
            expenseItemRepository = ServiceLocator.GetObject<IExpenseItemRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
            InitializeComponent();
        }


            public string ExpenseCode
            {
                get { return lblCode.Text; }
            }

        private void DisableForm()
        {
            dtpDate.Enabled = false;
            optCash.Enabled = false;
            optBank.Enabled = false;
            optCreditCard.Enabled = false;
            optGiro.Enabled = false;

            txtAccountName.Enabled = false;
            txtAccountName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtAccountNumber.Enabled = false;
            txtAccountNumber.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtNotesHeader.Enabled = false;
            txtNotesHeader.BackColor = System.Drawing.SystemColors.ButtonFace;

            tsbBack.Enabled = true;
            tsbNext.Enabled = true;
            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;
            tsbHistory.Enabled = true;

            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtTotal.Enabled = false;
            txtTotal.BackColor = System.Drawing.SystemColors.ButtonFace;

            btnAdd.Enabled = false;

            txtNotes.Clear();
            txtTotal.Clear();
            

            lvwExpense.Enabled = true;
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            if (lvwExpense.Items.Count == 0)
            {
                tsbBack.Enabled = false;
                tsbNext.Enabled = false;
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbHistory.Enabled = false;              
            }

        }
        
        private void EnableForm()
        {
            dtpDate.Enabled = true;
            optCash.Enabled = true;
            optBank.Enabled = true;
            optCreditCard.Enabled = true;
            optGiro.Enabled = true;

            txtAccountName.Enabled = true;
            txtAccountName.BackColor = Color.White;

            txtAccountNumber.Enabled = true;
            txtAccountNumber.BackColor = Color.White;

            txtNotesHeader.Enabled = true;
            txtNotesHeader.BackColor = Color.White;

            tsbBack.Enabled = false;
            tsbNext.Enabled = false;
            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;
            tsbHistory.Enabled = false;

            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;

            txtTotal.Enabled = true;
            txtTotal.BackColor =  Color.White;


            btnAdd.Enabled = true;
        
            
        }


         private void ClearForm()
        {
            dtpDate.Value = DateTime.Now;
            optCash.Checked = true;
             txtAccountName.Clear();
             txtAccountNumber.Clear();
            txtNotesHeader.Clear();

            txtNotes.Clear();
            txtTotal.Clear();
           
            lvwExpense.Items.Clear();
        }

        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();
            
            optCash.Checked = true;
        }


        private void EnableFormForEdit()
        {
            EnableForm();
        }


        private void ViewExpenseDetail(Expense expense)
        {
            txtID.Text = expense.ID.ToString();
            txtExpenseId.Text = expense.ID.ToString();
            lblCode.Text = expense.Code;
            dtpDate.Text = expense.Date.ToShortDateString();


            if (expense.AccountType == "Cash")
            {
                optCash.Checked = true;
            }
            else if (expense.AccountType == "Bank")
            {
                optBank.Checked = true;
            }
            else if (expense.AccountType == "Kartu Kredit")
            {
                optCreditCard.Checked = true;
            }
            else 
            {
                optGiro.Checked = true;
            }

            txtAccountName.Text = expense.AccountName;
            txtAccountNumber.Text = expense.AccountNumber;
            txtNotesHeader.Text = expense.Notes;

        }

        private void PopulateExpenseItem(ExpenseItem expenseItem)
        {
            var item = new ListViewItem(expenseItem.Notes);

            item.SubItems.Add(expenseItem.Total.ToString("N0").Replace(",", "."));
            
            lvwExpense.Items.Add(item);

        }


        private void LoadExpenseItems(Guid id)
        {
            var expenseItems = expenseItemRepository.GetByExpenseId(id);

            lvwExpense.Items.Clear();

            decimal total = 0;

            foreach (var expenseItem in expenseItems)
            {
                total = total + (expenseItem.Total);
                PopulateExpenseItem(expenseItem);
            }

            lblTotal.Text = total.ToString("N0").Replace(",", ".");
        }


        public void GetExpenseHistory(string code)
        {
            var expense = expenseRepository.GetByCode(code);

            if (expense != null)
            {
                ViewExpenseDetail(expense);
                LoadExpenseItems(new Guid(txtID.Text));
            }
        }


        private void GetLastExpense()
        {
            var expense = expenseRepository.GetLast(Store.ActiveMonth, Store.ActiveYear);
            if (expense != null)
            {
                ViewExpenseDetail(expense);
                LoadExpenseItems(new Guid(txtID.Text));
            }
        }

        private void FillCode()
        {
            var expense = expenseRepository.GetAllCode(Store.ActiveMonth, Store.ActiveYear);

            lstExpense.Items.Clear();

            foreach (var s in expense)
            {
                lstExpense.Items.Add(s);
            }

            if (lstExpense.Items.Count > 0) lstExpense.SelectedIndex = 0;

        }

        private void ExpenseUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.SupplierName;

            FillCode();
            GetLastExpense();

            if (lvwExpense.Items.Count == 0)
            {
                tsbBack.Enabled = false;
                tsbNext.Enabled = false;
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbHistory.Enabled = false;
            }

        }

        private void tsbHistory_Click(object sender, EventArgs e)
        {
            var frmHistory = new ExpenseHistoryUI(this);
            frmHistory.ShowDialog();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Biaya" && u.IsAdd);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menambah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (Store.IsPeriodClosed)
                {
                    MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    formMode = FormMode.Add;

                    EnableFormForAdd();
                    lblCode.Text = expenseRepository.GenerateExpenseCode(Store.ActiveMonth, Store.ActiveYear);
                    lblTotal.Text = "0";

                    this.Text = "Biaya - Tambah";
                }
            }
        }

        private bool IsDetailExist(string notes)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwExpense.Items)
            {
                if (notes == item.SubItems[0].Text)
                {
                    isExist = true;
                }
            }

            return isExist;
        }

        private void ClearDetailEntry()
        {
            txtNotes.Clear();
            txtTotal.Clear();
           

        }

        private decimal GetTotalExpense()
        {
            decimal totalExpense = 0;

            foreach (ListViewItem item in lvwExpense.Items)
            {
                string total = item.SubItems[1].Text;
                totalExpense = totalExpense + decimal.Parse(total.Replace(".", ""));

            }

            return totalExpense;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNotes.Text == "")
            {
                MessageBox.Show("Keterangan harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNotes.Focus();
            }
            else if (txtTotal.Text == "" || int.Parse(txtTotal.Text.Replace(".", "")) == 0)
            {
                MessageBox.Show("Jumlah harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTotal.Focus();
            }
            else if (IsDetailExist(txtNotes.Text) && btnAdd.Text == "Tambah")
            {
                MessageBox.Show("Detail sudah ditambahkan, silahkan isi yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }

            else
            {
                if (btnAdd.Text == "Update")
                {
                    lvwExpense.FocusedItem.Remove();
                    lvwExpense.Enabled = true;

                    btnAdd.Text = "Tambah";
                    btnCancel.Visible = false;
                }


                var item = new ListViewItem(txtNotes.Text);

                decimal total = decimal.Parse(txtTotal.Text.Replace(".", ""));
                
                item.SubItems.Add(total.ToString("N0").Replace(",", "."));
                
                lvwExpense.Items.Add(item);

                ClearDetailEntry();

                lblTotal.Text = GetTotalExpense().ToString("N0").Replace(",", ".");

            }
        }

        private void lvwExpense_DoubleClick(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
            {
                if (lvwExpense.Items.Count > 0)
                {
                    btnAdd.Text = "Update";
                    btnCancel.Visible = true;

                    lvwExpense.Enabled = false;

                    txtNotes.Text = lvwExpense.FocusedItem.SubItems[0].Text;
                    txtTotal.Text = lvwExpense.FocusedItem.SubItems[1].Text;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            ClearDetailEntry();

            lvwExpense.Enabled = true;
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                             && e.KeyChar != '.')
            {
                e.Handled = true;
            }


            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
                        var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Biaya" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (Store.IsPeriodClosed)
                {
                    MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Expense expense = expenseRepository.GetById(new Guid(txtID.Text));

                    if (expense.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        formMode = FormMode.Edit;
                        this.Text = "Biaya - Edit";

                        EnableFormForEdit();
                    }
                }
            }
        }


        private void ShowExpenseReport()
        {
            Store.ActiveReport = "Expense";

            var frmReportPrint = new ReportPrintUI(this);
            frmReportPrint.Show();

        }

        private void SaveExpense()
        {
            if (dtpDate.Value.Month != Store.ActiveMonth || dtpDate.Value.Year != Store.ActiveYear)
            {
                MessageBox.Show("Tanggal diluar periode aktif", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lvwExpense.Items.Count == 0)
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (optCash.Checked == true && txtAccountName.Text =="") 
            {
                MessageBox.Show("Nama Kas tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountName.Focus();
            }
            else if (optBank.Checked == true && txtAccountName.Text == "")
            {
                MessageBox.Show("Nama Bank tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountName.Focus();
            }
            else if (optBank.Checked == true && txtAccountNumber.Text == "")
            {
                MessageBox.Show("No. Rekening tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountNumber.Focus();
            }
            else if (optCreditCard.Checked == true && txtAccountName.Text == "")
            {
                MessageBox.Show("Nama Bank tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountName.Focus();
            }
            else if (optCreditCard.Checked == true && txtAccountNumber.Text == "")
            {
                MessageBox.Show("No. Kartu Kredit tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountNumber.Focus();
            }
            else if (optGiro.Checked == true && txtAccountName.Text == "")
            {
                MessageBox.Show("Nama Bank tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountName.Focus();
            }
            else if (optGiro.Checked == true && txtAccountNumber.Text == "")
            {
                MessageBox.Show("No. Giro tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAccountNumber.Focus();
            }
            else
            {
                var expense = new Expense();

                expense.Code = lblCode.Text;
                expense.Date = dtpDate.Value;

                if (optCash.Checked == true)
                {
                    expense.AccountType = "Cash";
                }
                else if (optBank.Checked == true)
                {
                    expense.AccountType = "Bank";
                }
                else if (optCreditCard.Checked == true)
                {
                    expense.AccountType = "Kartu Kredit";
                }
                else
                {
                    expense.AccountType = "Giro";
                }

                expense.AccountName = txtAccountName.Text;
                expense.AccountNumber = txtAccountNumber.Text;
                expense.Notes = txtNotes.Text;
                expense.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));

                string amountInWords = Store.GetAmounInWords(Convert.ToInt32(expense.GrandTotal));
                string firstLetter = amountInWords.Substring(0, 2).Trim().ToUpper();
                string theRest = amountInWords.Substring(2, amountInWords.Length - 2);

                expense.AmountInWords = firstLetter + theRest + " rupiah";
                

                var expenseItems = new List<ExpenseItem>();

                foreach (ListViewItem item in lvwExpense.Items)
                {
                    string notes = item.SubItems[0].Text;
                    string total = item.SubItems[1].Text;

                    ExpenseItem si = new ExpenseItem();

                    si.Notes = notes;
                    si.Total = int.Parse(total.Replace(".", ""));

                    expenseItems.Add(si);
                }


                expense.ExpenseItems = expenseItems;


                if (formMode == FormMode.Add)
                {
                    expenseRepository.Save(expense);
                    ShowExpenseReport();
                    GetLastExpense();
                }
                else if (formMode == FormMode.Edit)
                {
                    expense.ID = new Guid(txtID.Text);
                    expense.ModifiedBy = Store.ActiveUser;
                    expense.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));

                    expenseRepository.Update(expense);
                    ShowExpenseReport();
                }

                LoadExpenseItems(new Guid(txtID.Text));
                DisableForm();
                formMode = FormMode.View;
                FillCode();
                this.Text = "Biaya";
            }

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveExpense();
            
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (formMode == FormMode.Add) expenseRepository.Delete(lblCode.Text);

            GetLastExpense();

            DisableForm();

            formMode = FormMode.View;
            this.Text = "Biaya";
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
                        var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Biaya" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (Store.IsPeriodClosed)
                {
                    MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Expense expense = expenseRepository.GetById(new Guid(txtID.Text));
                    if (expense.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + lblCode.Text + "'", "Perhatian",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var expense1 = new Expense();
                            expense1.ID = new Guid(txtID.Text);
                            expense1.Notes = txtNotes.Text;

                            expenseRepository.Delete(expense1);
                            GetLastExpense();

                        }

                        if (lvwExpense.Items.Count == 0)
                        {
                            tsbEdit.Enabled = false;
                            tsbDelete.Enabled = false;


                        }
                    }
                }
            }
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            if (lstExpense.SelectedIndex < lstExpense.Items.Count - 1)
            {
                lstExpense.SelectedIndex = lstExpense.SelectedIndex + 1;
            }
            
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (lstExpense.SelectedIndex > 0)
            {
                lstExpense.SelectedIndex = lstExpense.SelectedIndex - 1;
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text != string.Empty)
            {
                string textBoxData = txtTotal.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtTotal.Text = StringBldr.ToString();
                txtTotal.SelectionStart = txtTotal.Text.Length;
            }
        }

        private void lvwExpense_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwExpense.Items.Count > 0)
            {
                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwExpense.FocusedItem.Remove();
                    }

                    lblTotal.Text = GetTotalExpense().ToString("N0").Replace(",", ".");

                }
            }
        }

        private void lstExpense_SelectedIndexChanged(object sender, EventArgs e)
        {
            var expense = expenseRepository.GetByCode(lstExpense.Text);
            if (expense != null)
            {
                ViewExpenseDetail(expense);
                LoadExpenseItems(new Guid(txtID.Text));
            }
        }

        private void optCash_CheckedChanged(object sender, EventArgs e)
        {
           
            lblAccountName.Text = "Nama Kas";
            lblAccountNumber.Text = "No. Rekening";

            if (formMode != FormMode.View)
            {
                txtAccountNumber.Enabled = false;
                txtAccountNumber.BackColor = System.Drawing.SystemColors.ButtonFace;
            }
        }

        private void optBank_CheckedChanged(object sender, EventArgs e)
        {
           
            lblAccountName.Text = "Nama Bank";
            lblAccountNumber.Text = "No. Rekening";
           
            if (formMode != FormMode.View)
            {
                txtAccountNumber.Enabled = true;
                txtAccountNumber.BackColor = Color.White;
            }
        }


        private void optCreditCard_CheckedChanged(object sender, EventArgs e)
        {
        
            lblAccountName.Text = "Nama Bank";
            lblAccountNumber.Text = "No. Kartu Kredit";
            
            if (formMode != FormMode.View)
            {
                txtAccountNumber.Enabled = true;
                txtAccountNumber.BackColor = Color.White;
            }
        }

        private void optGiro_CheckedChanged(object sender, EventArgs e)
        {
         
            lblAccountName.Text = "Nama Bank";
            lblAccountNumber.Text = "No. Giro";

            if (formMode != FormMode.View)
            {
                txtAccountNumber.Enabled = true;
                txtAccountNumber.BackColor = Color.White;
            }
        }





















    }
}
