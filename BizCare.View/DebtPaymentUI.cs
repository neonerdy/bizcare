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
    public partial class DebtPaymentUI : Form
    {

        private MainUI frmMain;
        private FormMode formMode;
        private FormFilter formFilter;

        private IDebtPaymentRepository debtPaymentRepository;
        private IDebtPaymentItemRepository debtPaymentItemRepository;
        private IPurchaseRepository purchaseRepository;
        private IUserAccessRepository userAccessRepository;

        public DebtPaymentUI()
        {
            InitializeComponent();
        }

          public DebtPaymentUI(MainUI frmMain)
        {
            this.frmMain = frmMain;

         
            debtPaymentRepository = ServiceLocator.GetObject<IDebtPaymentRepository>();
            debtPaymentItemRepository = ServiceLocator.GetObject<IDebtPaymentItemRepository>();
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
            InitializeComponent();
        }


        private void EnableForm()
        {
            dtpDate.Enabled = true;
            
            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;

            tsbBack.Enabled = false;
            tsbNext.Enabled = false;
            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;
            tsbHistory.Enabled = false;

            txtPurchase.Enabled = false;
            txtPurchase.BackColor = Color.White;

            txtCash.Enabled = true;
            txtCash.BackColor = Color.White;

            txtBank.Enabled = true;
            txtBank.BackColor = Color.White;

            txtGiro.Enabled = true;
            txtGiro.BackColor = Color.White;

            txtGiroNumber.Enabled = true;
            txtGiroNumber.BackColor = Color.White;

            txtCorrection.Enabled = true;
            txtCorrection.BackColor = Color.White;

            btnBrowse.Enabled = true;
            btnAdd.Enabled = true;


        }

        private void DisableForm()
        {
            dtpDate.Enabled = false;
            
            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;

            tsbBack.Enabled = true;
            tsbNext.Enabled = true;
            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;
            tsbHistory.Enabled = true;

            txtPurchase.Enabled = false;
            txtPurchase.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtCash.Enabled = false;
            txtCash.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtBank.Enabled = false;
            txtBank.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtGiro.Enabled = false;
            txtGiro.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtGiroNumber.Enabled = false;
            txtGiroNumber.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtCorrection.Enabled = false;
            txtCorrection.BackColor = System.Drawing.SystemColors.ButtonFace;

            btnBrowse.Enabled = false;
            btnAdd.Enabled = false;

            txtPurchase.Clear();
            txtCash.Clear();
            txtBank.Clear();
            txtGiro.Clear();
            txtGiroNumber.Clear();
            txtCorrection.Clear();

            lvwDebtPayment.Enabled = true;
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            if (lvwDebtPayment.Items.Count == 0)
            {
                tsbBack.Enabled = false;
                tsbNext.Enabled = false;
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbHistory.Enabled = false;
            }

        }

        private void ClearForm()
        {
            dtpDate.Value = DateTime.Now;
            txtNotes.Clear();

            txtPurchase.Clear();
            txtCash.Clear();
            txtBank.Clear();
            txtGiro.Clear();
            txtGiroNumber.Clear();
            txtCorrection.Clear();

            lvwDebtPayment.Items.Clear();
        }

        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();

        }


        private void EnableFormForEdit()
        {
            EnableForm();
        }

        private void ViewDebtPaymentDetail(DebtPayment debtPayment)
        {
            txtID.Text = debtPayment.ID.ToString();
            txtDebtPaymentId.Text = debtPayment.ID.ToString();
            lblCode.Text = debtPayment.PaymentCode;
            
            dtpDate.Text = debtPayment.PaymentDate.ToShortDateString();

            txtNotes.Text = debtPayment.Notes;

        }

        private void PopulateDebtPaymentItem(DebtPaymentItem debtPaymentItem)
        {
            var item = new ListViewItem(debtPaymentItem.PurchaseId.ToString());

            item.SubItems.Add(debtPaymentItem.Purchase.Code);
            item.SubItems.Add(debtPaymentItem.Cash.ToString("N0").Replace(",", "."));
            item.SubItems.Add(debtPaymentItem.Bank.ToString("N0").Replace(",", "."));
            item.SubItems.Add(debtPaymentItem.Giro.ToString("N0").Replace(",", "."));
            item.SubItems.Add(debtPaymentItem.GiroNumber);
            item.SubItems.Add(debtPaymentItem.Correction.ToString("N0").Replace(",", "."));

            decimal total = debtPaymentItem.Cash + debtPaymentItem.Bank + debtPaymentItem.Giro + debtPaymentItem.Correction;

            item.SubItems.Add(total.ToString("N0").Replace(",", "."));
            item.SubItems.Add(debtPaymentItem.Purchase.GrandTotal.ToString("N0").Replace(",", "."));

            lvwDebtPayment.Items.Add(item);

        }

        private void LoadDebtPaymentItems(Guid id)
        {
            var debtPaymentItems = debtPaymentItemRepository.GetByDebtPaymentId(id);

            lvwDebtPayment.Items.Clear();

            decimal cash = 0;
            decimal bank = 0;
            decimal giro = 0;
            decimal correction = 0;
            decimal total = 0;

            foreach (var debtPaymentItem in debtPaymentItems)
            {
                cash = cash + debtPaymentItem.Cash;
                bank = bank + debtPaymentItem.Bank;
                giro = giro + debtPaymentItem.Giro;
                correction = correction + debtPaymentItem.Correction;

                total = total + (debtPaymentItem.Cash + debtPaymentItem.Bank + debtPaymentItem.Giro + debtPaymentItem.Correction);
                PopulateDebtPaymentItem(debtPaymentItem);
            }

            lblCash.Text = cash.ToString("N0").Replace(",", ".");
            lblBank.Text = bank.ToString("N0").Replace(",", ".");
            lblGiro.Text = giro.ToString("N0").Replace(",", ".");
            lblCorrection.Text = correction.ToString("N0").Replace(",", ".");
            lblTotal.Text = total.ToString("N0").Replace(",", ".");
        }

        public void GetDebtPaymentHistory(string code)
        {
            var debtPayment = debtPaymentRepository.GetByCode(code);

            if (debtPayment != null)
            {
                ViewDebtPaymentDetail(debtPayment);
                LoadDebtPaymentItems(new Guid(txtID.Text));
            }
        }

        private void GetLastDebtPayment()
        {
            var debtPayment = debtPaymentRepository.GetLast(Store.ActiveMonth, Store.ActiveYear);
            if (debtPayment != null)
            {
                ViewDebtPaymentDetail(debtPayment);
                LoadDebtPaymentItems(new Guid(txtID.Text));
            }
        }

        private void FillCode()
        {
            var debtPayment = debtPaymentRepository.GetAllCode(Store.ActiveMonth, Store.ActiveYear);

            lstDebtPayment.Items.Clear();

            foreach (var s in debtPayment)
            {
                lstDebtPayment.Items.Add(s);
            }

            if (lstDebtPayment.Items.Count > 0) lstDebtPayment.SelectedIndex = 0;

        }

        private void DebtPaymentUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.SupplierName;

            FillCode();
            GetLastDebtPayment();

            if (lvwDebtPayment.Items.Count == 0)
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
            var frmHistory = new DebtPaymentHistoryUI(this);
            frmHistory.ShowDialog();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pelunasan Hutang" && u.IsAdd);

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
                    lblCode.Text = debtPaymentRepository.GenerateDebtPaymentCode(Store.ActiveMonth, Store.ActiveYear);
                    lblTotal.Text = "0";

                    this.Text = "Pembayaran Hutang - Tambah";
                }
            }
        }

        public void PutPurchase(string purchaseId, string purchaseCode, decimal purchaseTotal)
        {
            txtPurchaseId.Text = purchaseId;
            txtPurchase.Text = purchaseCode;
            txtPurchaseTotal.Text = purchaseTotal.ToString();


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var frmDebtPaymentPurchaseList = new DebtPaymentPurchaseListUI(this);
            frmDebtPaymentPurchaseList.ShowDialog();
        }
        private bool IsPurchaseExist(string purchaseCode)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwDebtPayment.Items)
            {
                if (purchaseCode == item.SubItems[1].Text)
                {
                    isExist = true;
                }
            }

            return isExist;
        }

        private void ClearPurchaseEntry()
        {
            txtPurchaseId.Clear();
            txtPurchase.Clear();
            txtCash.Clear();
            txtBank.Clear();
            txtGiro.Clear();
            txtGiroNumber.Clear();
            txtCorrection.Clear();
            txtPurchaseTotal.Clear();
        }

        private void GetTotalDebtPayment()
        {
            decimal totalCash = 0;
            decimal totalBank = 0;
            decimal totalGiro = 0;
            decimal totalCorrection = 0;
            decimal totalDebtPayment = 0;

            if (lvwDebtPayment.Items.Count > 0)
            {
                foreach (ListViewItem item in lvwDebtPayment.Items)
                {

                    string cash = item.SubItems[2].Text;
                    string bank = item.SubItems[3].Text;
                    string giro = item.SubItems[4].Text;
                    string correction = item.SubItems[6].Text;
                    string total = item.SubItems[7].Text;

                    totalCash = totalCash + decimal.Parse(cash.Replace(".", ""));
                    totalBank = totalBank + decimal.Parse(bank.Replace(".", ""));
                    totalGiro = totalGiro + decimal.Parse(giro.Replace(".", ""));
                    totalCorrection = totalCorrection + decimal.Parse(correction.Replace(".", ""));
                    totalDebtPayment = totalDebtPayment + decimal.Parse(total.Replace(".", ""));


                    lblCash.Text = totalCash.ToString("N0").Replace(",", ".");
                    lblBank.Text = totalBank.ToString("N0").Replace(",", ".");
                    lblGiro.Text = totalGiro.ToString("N0").Replace(",", ".");
                    lblCorrection.Text = totalCorrection.ToString("N0").Replace(",", ".");
                    lblTotal.Text = totalDebtPayment.ToString("N0").Replace(",", ".");
                }
            }
            else
            {
                lblCash.Text = "0";
                lblBank.Text = "0";
                lblGiro.Text = "0";
                lblCorrection.Text = "0";
                lblTotal.Text = "0";
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal cash1 = decimal.Parse(txtCash.Text == "" ? "0" : txtCash.Text.Replace(".", string.Empty));
            decimal bank1 = decimal.Parse(txtBank.Text == "" ? "0" : txtBank.Text.Replace(".", string.Empty));
            decimal giro1 = decimal.Parse(txtGiro.Text == "" ? "0" : txtGiro.Text.Replace(".", string.Empty));
            decimal correction1 = decimal.Parse(txtCorrection.Text == "" ? "0" : txtCorrection.Text.Replace(".", string.Empty));

            decimal total1 = cash1 + bank1 + giro1 + correction1;

            if (txtPurchase.Text == "")
            {
                MessageBox.Show("Dokumen Pembelian harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPurchase.Focus();
            }
            else if (txtGiro.Text != "" && txtGiroNumber.Text == "")
            {
                MessageBox.Show("No. Giro harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiroNumber.Focus();
            }

            else if (IsPurchaseExist(txtPurchase.Text) && btnAdd.Text == "Tambah")
            {
                MessageBox.Show("Dokumen Pembelian sudah ditambahkan, silahkan pilih yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }
            else if (total1 < decimal.Parse(txtPurchaseTotal.Text.Replace(".", "")) || total1 > decimal.Parse(txtPurchaseTotal.Text.Replace(".", "")))
            {
                MessageBox.Show("Total Pembayaran tidak sama dengan Total Hutang", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }
            else
            {
                if (btnAdd.Text == "Update")
                {
                    lvwDebtPayment.FocusedItem.Remove();
                    lvwDebtPayment.Enabled = true;

                    btnAdd.Text = "Tambah";
                    btnCancel.Visible = false;
                }


                var item = new ListViewItem(txtPurchaseId.Text.ToString());

                decimal cash = decimal.Parse(txtCash.Text == "" ? "0" : txtCash.Text.Replace(".", string.Empty));
                decimal bank = decimal.Parse(txtBank.Text == "" ? "0" : txtBank.Text.Replace(".", string.Empty));
                decimal giro = decimal.Parse(txtGiro.Text == "" ? "0" : txtGiro.Text.Replace(".", string.Empty));
                decimal correction = decimal.Parse(txtCorrection.Text == "" ? "0" : txtCorrection.Text.Replace(".", string.Empty));

                decimal total = cash + bank + giro + correction;

                item.SubItems.Add(txtPurchase.Text);
                item.SubItems.Add(cash.ToString("N0").Replace(",", "."));
                item.SubItems.Add(bank.ToString("N0").Replace(",", "."));
                item.SubItems.Add(giro.ToString("N0").Replace(",", "."));
                item.SubItems.Add(txtGiroNumber.Text);
                item.SubItems.Add(correction.ToString("N0").Replace(",", "."));
                item.SubItems.Add(total.ToString("N0").Replace(",", "."));
                item.SubItems.Add(txtPurchaseTotal.Text.Replace(",", "."));

                lvwDebtPayment.Items.Add(item);

                ClearPurchaseEntry();

                GetTotalDebtPayment();

            }
        }

        private void lvwDebtPayment_DoubleClick(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
            {
                if (lvwDebtPayment.Items.Count > 0)
                {
                    btnAdd.Text = "Update";
                    btnCancel.Visible = true;

                    lvwDebtPayment.Enabled = false;

                    txtPurchaseId.Text = lvwDebtPayment.FocusedItem.SubItems[0].Text;
                    txtPurchase.Text = lvwDebtPayment.FocusedItem.SubItems[1].Text;
                    txtCash.Text = lvwDebtPayment.FocusedItem.SubItems[2].Text;
                    txtBank.Text = lvwDebtPayment.FocusedItem.SubItems[3].Text;
                    txtGiro.Text = lvwDebtPayment.FocusedItem.SubItems[4].Text;
                    txtGiroNumber.Text = lvwDebtPayment.FocusedItem.SubItems[5].Text;
                    txtCorrection.Text = lvwDebtPayment.FocusedItem.SubItems[6].Text;

                    txtPurchaseTotal.Text = lvwDebtPayment.FocusedItem.SubItems[8].Text;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            ClearPurchaseEntry();

            lvwDebtPayment.Enabled = true;
        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBank_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiro_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCorrection_KeyPress(object sender, KeyPressEventArgs e)
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
                && u.ObjectName == "Pelunasan Hutang" && u.IsEdit);

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
                    DebtPayment debtPayment = debtPaymentRepository.GetById(new Guid(txtID.Text));
                    if (debtPayment.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        formMode = FormMode.Edit;
                        this.Text = "Pembayaran Hutang - Edit";

                        EnableFormForEdit();
                    }
                }
            }
        }

        private void SaveDebtPayment()
        {
            if (dtpDate.Value.Month != Store.ActiveMonth || dtpDate.Value.Year != Store.ActiveYear)
            {
                MessageBox.Show("Tanggal diluar periode aktif", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else if (lvwDebtPayment.Items.Count == 0)
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var debtPayment = new DebtPayment();

                debtPayment.PaymentCode = lblCode.Text;
                debtPayment.PaymentDate = dtpDate.Value;
                debtPayment.Notes = txtNotes.Text;
                debtPayment.TotalCash = decimal.Parse(lblCash.Text.Replace(".", ""));
                debtPayment.TotalBank = decimal.Parse(lblBank.Text.Replace(".", ""));
                debtPayment.TotalGiro = decimal.Parse(lblGiro.Text.Replace(".", ""));
                debtPayment.TotalCorrection = decimal.Parse(lblCorrection.Text.Replace(".", ""));
                debtPayment.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));


                var debtPaymentItems = new List<DebtPaymentItem>();

                foreach (ListViewItem item in lvwDebtPayment.Items)
                {
                    string purchaseId = item.SubItems[0].Text;
                    string cash = item.SubItems[2].Text;
                    string bank = item.SubItems[3].Text;
                    string giro = item.SubItems[4].Text;
                    string giroNumber = item.SubItems[5].Text;
                    string correction = item.SubItems[6].Text;
                    string total = item.SubItems[7].Text;

                    DebtPaymentItem si = new DebtPaymentItem();

                    if (si.Purchase == null) si.Purchase = new Purchase();
                    si.Purchase.Code = item.SubItems[1].Text;

                    si.PurchaseId = new Guid(purchaseId);
                    si.Notes = "";
                    si.Cash = int.Parse(cash.Replace(".", ""));
                    si.Bank = decimal.Parse(bank.Replace(".", ""));
                    si.Giro = decimal.Parse(giro.Replace(".", ""));
                    si.GiroNumber = txtGiroNumber.Text;
                    si.Correction = decimal.Parse(correction.Replace(".", ""));
                    si.Total = decimal.Parse(total.Replace(".", ""));

                    debtPaymentItems.Add(si);
                }


                debtPayment.DebtPaymentItems = debtPaymentItems;


                if (formMode == FormMode.Add)
                {
                    debtPaymentRepository.Save(debtPayment);

                    GetLastDebtPayment();
                }
                else if (formMode == FormMode.Edit)
                {
                    debtPayment.ID = new Guid(txtID.Text);

                    debtPayment.TotalCash = decimal.Parse(lblCash.Text.Replace(".", ""));
                    debtPayment.TotalBank = decimal.Parse(lblBank.Text.Replace(".", ""));
                    debtPayment.TotalGiro = decimal.Parse(lblGiro.Text.Replace(".", ""));
                    debtPayment.TotalCorrection = decimal.Parse(lblCorrection.Text.Replace(".", ""));
                    debtPayment.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));


                    debtPaymentRepository.Update(debtPayment);
                }

                LoadDebtPaymentItems(new Guid(txtID.Text));
                DisableForm();
                formMode = FormMode.View;

                FillCode();
                this.Text = "Pembayaran Hutang";
            }

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveDebtPayment();
            
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (formMode == FormMode.Add) debtPaymentRepository.Delete(lblCode.Text);

            GetLastDebtPayment();

            DisableForm();

            formMode = FormMode.View;
            this.Text = "Pembayaran Hutang";
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            if (lstDebtPayment.SelectedIndex < lstDebtPayment.Items.Count - 1)
            {
                lstDebtPayment.SelectedIndex = lstDebtPayment.SelectedIndex + 1;
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (lstDebtPayment.SelectedIndex > 0)
            {
                lstDebtPayment.SelectedIndex = lstDebtPayment.SelectedIndex - 1;
            }
            
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (txtCash.Text != string.Empty)
            {
                string textBoxData = txtCash.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtCash.Text = StringBldr.ToString();
                txtCash.SelectionStart = txtCash.Text.Length;
            }
        }

        private void txtBank_TextChanged(object sender, EventArgs e)
        {
            if (txtBank.Text != string.Empty)
            {
                string textBoxData = txtBank.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtBank.Text = StringBldr.ToString();
                txtBank.SelectionStart = txtBank.Text.Length;
            }
        }

        private void txtGiro_TextChanged(object sender, EventArgs e)
        {
            if (txtGiro.Text != string.Empty)
            {
                string textBoxData = txtGiro.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtGiro.Text = StringBldr.ToString();
                txtGiro.SelectionStart = txtGiro.Text.Length;
            }
        }

        private void txtCorrection_TextChanged(object sender, EventArgs e)
        {
            if (txtCorrection.Text != string.Empty)
            {
                string textBoxData = txtCorrection.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtCorrection.Text = StringBldr.ToString();
                txtCorrection.SelectionStart = txtCorrection.Text.Length;
            }
        }

        private void lvwDebtPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwDebtPayment.Items.Count > 0)
            {
                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwDebtPayment.FocusedItem.Remove();
                    }

                    GetTotalDebtPayment();

                }
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pelunasan Piutang" && u.IsDelete);

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
                    DebtPayment debtPayment = debtPaymentRepository.GetById(new Guid(txtID.Text));
                    if (debtPayment.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + lblCode.Text + "'", "Perhatian",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var debtPayment1 = new DebtPayment();
                            debtPayment1.ID = new Guid(txtID.Text);
                            debtPayment1.Notes = txtNotes.Text;

                            debtPaymentRepository.Delete(debtPayment1);
                            GetLastDebtPayment();

                        }

                        if (lvwDebtPayment.Items.Count == 0)
                        {
                            tsbEdit.Enabled = false;
                            tsbDelete.Enabled = false;


                        }
                    }
                }
            }
        }

        private void txtPurchaseTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchaseTotal.Text != string.Empty)
            {
                string textBoxData = txtPurchaseTotal.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtPurchaseTotal.Text = StringBldr.ToString();
                txtPurchaseTotal.SelectionStart = txtPurchaseTotal.Text.Length;
            }
        }

        private void lstDebtPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var debtPayment = debtPaymentRepository.GetByCode(lstDebtPayment.Text);
            if (debtPayment != null)
            {
                ViewDebtPaymentDetail(debtPayment);
                LoadDebtPaymentItems(new Guid(txtID.Text));
            }
        }











    }
}
