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
    public partial class DebtBalanceUI : Form
    {

        private MainUI frmMain;
        private IDebtBalanceRepository debtBalanceRepository;
        private ISupplierRepository supplierRepository;
        private FormMode formMode;
        private FormFilter formFilter;
        private IUserAccessRepository userAccessRepository;

        public DebtBalanceUI()
        {
            InitializeComponent();
        }

        public DebtBalanceUI(MainUI frmMain)
        {
            debtBalanceRepository = ServiceLocator.GetObject<IDebtBalanceRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
            this.frmMain = frmMain;
            InitializeComponent();

            supplierRepository = ServiceLocator.GetObject<ISupplierRepository>();
          
        }

        public void PutSupplier(string id, string name, int termOfPayment)
        {
            txtSupplierId.Text = id;
            txtSupplierName.Text = name;
            txtTermOfPayment.Text = termOfPayment.ToString();
        }


        private void ViewDebtBalanceDetail(DebtBalance debtBalance)
        {
            txtID.Text = debtBalance.ID.ToString();
            txtPurchaseCode.Text = debtBalance.PurchaseCode;
            dtpDate.Text = debtBalance.PurchaseDate.ToShortDateString();
            dtpDueDate.Text = debtBalance.DueDate.ToShortDateString();
            txtTermOfPayment.Text = debtBalance.TermOfPayment.ToString();

            txtSupplierId.Text = debtBalance.SupplierId.ToString();
            txtSupplierName.Text = debtBalance.Supplier.Name;
                        
            if (debtBalance.PaymentMethod == 1)
            {
                optCash.Checked = true;
            }
            else if (debtBalance.PaymentMethod == 2)
            {
                optCredit.Checked = true;
            }
            txtGrandTotal.Text = debtBalance.GrandTotal.ToString();
            txtNotes.Text = debtBalance.Notes;
            chkIsStatus.Checked = debtBalance.IsStatus;
        }


        private void GetLastDebtBalance()
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
            
            DebtBalance debtBalance = debtBalanceRepository.GetLast(month, year);
            if (debtBalance != null) ViewDebtBalanceDetail(debtBalance);
        }

        private void RenderDebtBalance(DebtBalance debtBalance)
        {
            var item = new ListViewItem(debtBalance.ID.ToString());

            item.SubItems.Add(debtBalance.PurchaseCode);
            item.SubItems.Add(debtBalance.PurchaseDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(debtBalance.Supplier.Name);
            item.SubItems.Add(debtBalance.DueDate.ToString("dd/MM/yyyy"));
            item.SubItems.Add(debtBalance.GrandTotal.ToString("N0").Replace(",", "."));

            if (debtBalance.IsStatus == true)
            {
                item.SubItems.Add("LUNAS");
            }
            else
            {
                item.SubItems.Add("BELUM LUNAS");
            }


            lvwDebtBalance.Items.Add(item);

        }

        private void LoadDebtBalance()
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
                month = Store.ActiveMonth-1;
                year = Store.ActiveYear;
            }
            
            var debtBalances = debtBalanceRepository.GetAll(month, year);

            lvwDebtBalance.Items.Clear();

            foreach (var debtBalance in debtBalances)
            {
                RenderDebtBalance(debtBalance);
            }
        }

        private void DebtBalanceUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;

            GetLastDebtBalance();
            LoadDebtBalance();

            if (lvwDebtBalance.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbMenuFilter.Enabled = false;
                txtSearch.Enabled = false;
                tsbFilter.Enabled = false;
            }

        }

        private void lvwDebtBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDebtBalance.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    DebtBalance debtBalance = debtBalanceRepository.GetById(new Guid(lvwDebtBalance.FocusedItem.Text));
                    ViewDebtBalanceDetail(debtBalance);
                }
            }
        }

        private void ClearForm()
        {
            txtSupplierId.Clear();
            txtSupplierName.Clear();

            txtPurchaseCode.Clear();
            dtpDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
            optCash.Checked = true;
            txtGrandTotal.Clear();
            txtNotes.Clear();
            chkIsStatus.Checked = false;
            txtTermOfPayment.Clear();
        }



        private void EnableForm()
        {
            txtPurchaseCode.Enabled = true;
            txtPurchaseCode.BackColor = Color.White;

            dtpDate.Enabled = true;
            //dtpDueDate.Enabled = true;
            optCash.Enabled = true;
            optCredit.Enabled = true;

            txtSupplierName.BackColor = Color.White;
            btnBrowseSupplier.Enabled = true;

            txtGrandTotal.Enabled = true;
            txtGrandTotal.BackColor = Color.White;

            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;

            txtTermOfPayment.BackColor = Color.White;

            chkIsStatus.Enabled = false;

            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;
            
            tsbRefresh.Enabled = false;
            txtSearch.Enabled = false;
            txtSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            tsbMenuFilter.Enabled = false;
            tsbFilter.Enabled = false;


        }

        private void EnableFormForEdit()
        {
            EnableForm();

            txtPurchaseCode.Enabled = false;
            txtPurchaseCode.BackColor = System.Drawing.SystemColors.ButtonFace;

            dtpDate.Focus();
        }

        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();
            optCredit.Checked = true;

            txtPurchaseCode.Focus();

        }

        private void DisableForm()
        {
            txtPurchaseCode.Enabled = false;
            txtPurchaseCode.BackColor = System.Drawing.SystemColors.ButtonFace;

            dtpDate.Enabled = false;
            dtpDueDate.Enabled = false;
            optCash.Enabled = false;
            optCredit.Enabled = false;

            txtSupplierName.Enabled = false;
            txtGrandTotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnBrowseSupplier.Enabled = false;

            txtGrandTotal.Enabled = false;
            txtGrandTotal.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtTermOfPayment.BackColor = System.Drawing.SystemColors.ButtonFace;

            chkIsStatus.Enabled = false;

            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;

            tsbRefresh.Enabled = true;
            txtSearch.Enabled = true;
            txtSearch.BackColor = Color.White;
            tsbMenuFilter.Enabled = true;
            tsbFilter.Enabled = true;
                        
            if (lvwDebtBalance.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbMenuFilter.Enabled = false;
                txtSearch.Enabled = false;
                tsbFilter.Enabled = false;
                txtSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            }


        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Hutang" && u.IsEdit);

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
                    DebtBalance debtBalance = debtBalanceRepository.GetById(new Guid(txtID.Text));
                    if (Store.ActiveMonth != Store.StartDate.Month || Store.ActiveYear != Store.StartDate.Year)
                    {
                        MessageBox.Show("Tanggal harus sesuai periode awal pemakaian" + "\n" + Store.GetMonthName(Store.StartDate.Month) + " " + Store.StartDate.Year, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else if (debtBalance.IsStatus == true)
                    {
                        MessageBox.Show("Tidak bisa diubah " + "\n\n" + "Dokumen : " + txtPurchaseCode.Text + "\n\n" + "dipakai di Pembayaran Hutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        formMode = FormMode.Edit;
                        this.Text = "Saldo Awal Hutang - Edit";

                        EnableFormForEdit();

                    }
                }
            }
        }

        private void lvwDebtBalance_DoubleClick(object sender, EventArgs e)
        {
            if (lvwDebtBalance.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    tsbEdit_Click(sender, e);

                }

            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Hutang" && u.IsAdd);

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
                    this.Text = "Saldo Awal Hutang - Tambah";
                    EnableFormForAdd();
                }
            }
        }

        
        private void SaveDebtBalance()
        {
            if (dtpDate.Value.Month >= Store.StartDate.Month && dtpDate.Value.Year >= Store.StartDate.Year)
            {
                MessageBox.Show("Tanggal harus sebelum periode awal pemakaian" + "\n" + Store.GetMonthName(Store.StartDate.Month) + " " + Store.StartDate.Year, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (formMode == FormMode.Add && debtBalanceRepository.IsPurchaseCodeExisted(txtPurchaseCode.Text))
            {
                MessageBox.Show("Dokumen : \n\n" + txtPurchaseCode.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtPurchaseCode.Text == "")
            {
                MessageBox.Show("Dokumen harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPurchaseCode.Focus();
            }
            else if (txtSupplierName.Text=="")
            {
                MessageBox.Show("Supplier harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowseSupplier.Focus();
            }
            else if (dtpDate.Value > dtpDueDate.Value)
            {
                MessageBox.Show("Tanggal jatuh tempo harus lebih besar dari tanggal transaksi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtGrandTotal.Text == "" || txtGrandTotal.Text == "0")
            {
                MessageBox.Show("Nilai harus lebih dari Nol", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGrandTotal.Focus();
            }
            else
            {

                DebtBalance debtBalance = new DebtBalance();

                debtBalance.BalanceYear = Store.StartDate.Year;
                debtBalance.BalanceMonth = Store.StartDate.Month - 1;               
                debtBalance.PurchaseCode = txtPurchaseCode.Text;
                debtBalance.PurchaseDate = dtpDate.Value;
                debtBalance.DueDate = dtpDueDate.Value;
                debtBalance.SupplierId = new Guid(txtSupplierId.Text);

                debtBalance.PaymentMethod = 2;

                debtBalance.GrandTotal = decimal.Parse(txtGrandTotal.Text.Replace(".", ""));
                debtBalance.Notes = txtNotes.Text;
                
                string amountInWords = Store.GetAmounInWords(Convert.ToInt32(debtBalance.GrandTotal));
                string firstLetter = amountInWords.Substring(0, 2).Trim().ToUpper();
                string theRest = amountInWords.Substring(2, amountInWords.Length - 2);

                debtBalance.AmountInWords = firstLetter + theRest + " rupiah";
                debtBalance.IsStatus = chkIsStatus.Checked;
                debtBalance.TermOfPayment = int.Parse(txtTermOfPayment.Text);

                if (formMode == FormMode.Add)
                {
                    debtBalanceRepository.Save(debtBalance);
                    GetLastDebtBalance();
                }
                else if (formMode == FormMode.Edit)
                {
                    debtBalance.ID = new Guid(txtID.Text);
                    debtBalanceRepository.Update(debtBalance);
                }

                LoadDebtBalance();
                DisableForm();

                formMode = FormMode.View;

            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveDebtBalance();
            this.Text = "Saldo Awal Hutang";

        }

        private void GetDebtBalanceById(Guid id)
        {
            DebtBalance debtBalance = debtBalanceRepository.GetById(id);
            ViewDebtBalanceDetail(debtBalance);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwDebtBalance.Items.Count > 0)
            {
                GetDebtBalanceById(new Guid(txtID.Text));
            }

            DisableForm();

            lvwDebtBalance.Enabled = true;

            formMode = FormMode.View;
            this.Text = "Saldo Awal Hutang";
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Hutang" && u.IsDelete);

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
                    DebtBalance debtBalance = debtBalanceRepository.GetById(new Guid(txtID.Text));
                    if (debtBalance.IsStatus == true)
                    {
                        MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Dokumen : " + txtPurchaseCode.Text + "\n\n" + "dipakai di Pembayaran Hutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + txtPurchaseCode.Text + "'", "Perhatian",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            debtBalanceRepository.Delete(new Guid(txtID.Text), txtPurchaseCode.Text);
                            GetLastDebtBalance();
                            LoadDebtBalance();

                        }

                        if (lvwDebtBalance.Items.Count == 0)
                        {
                            tsbEdit.Enabled = false;
                            tsbDelete.Enabled = false;
                            tsbRefresh.Enabled = false;
                            tsbMenuFilter.Enabled = false;
                            txtSearch.Enabled = false;
                            tsbFilter.Enabled = false;

                            ClearForm();
                        }
                    }
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadDebtBalance();

        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtGrandTotal.Text != string.Empty)
            {
                string textBoxData = txtGrandTotal.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtGrandTotal.Text = StringBldr.ToString();

                txtGrandTotal.SelectionStart = txtGrandTotal.Text.Length;
            }

        }

        private void txtGrandTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FilterDebtBalance(string value)
        {
            var debtBalances = debtBalanceRepository.Search(Store.ActiveMonth-1,Store.ActiveYear,value);

            lvwDebtBalance.Items.Clear();

            foreach (var debtBalance in debtBalances)
            {
                RenderDebtBalance(debtBalance);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterDebtBalance(txtSearch.Text);
            }
            else
            {
                LoadDebtBalance();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterDebtBalance(txtSearch.Text);
            }
            else
            {
                LoadDebtBalance();
            }
        }

        private void btnBrowseSupplier_Click(object sender, EventArgs e)
        {
            var frmSupplierList = new SupplierListUI(this);
            frmSupplierList.ShowDialog();
        }

        private void txtTermOfPayment_TextChanged(object sender, EventArgs e)
        {
            if (txtTermOfPayment.Text != "" && int.Parse(txtTermOfPayment.Text) > 0)
            {
                dtpDueDate.Value = dtpDate.Value.AddDays(double.Parse(txtTermOfPayment.Text));
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            txtTermOfPayment_TextChanged(sender, e);
        }




    }
}
