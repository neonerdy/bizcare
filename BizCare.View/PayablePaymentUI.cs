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
    public partial class PayablePaymentUI : Form
    {
        private MainUI frmMain;
        private FormMode formMode;
        private FormFilter formFilter;

        private IPayablePaymentRepository payablePaymentRepository;
        private IPayablePaymentItemRepository payablePaymentItemRepository;
        private ISalesRepository salesRepository;
        private IUserAccessRepository userAccessRepository;

        public PayablePaymentUI()
        {
            InitializeComponent();
        }

        public string PayablePaymentCode
        {
            get { return lblCode.Text; }
        }

        public PayablePaymentUI(MainUI frmMain)
        {
            this.frmMain = frmMain;

         
            payablePaymentRepository = ServiceLocator.GetObject<IPayablePaymentRepository>();
            payablePaymentItemRepository = ServiceLocator.GetObject<IPayablePaymentItemRepository>();
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
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

            txtSales.Enabled = false;
            txtSales.BackColor = Color.White;

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

            txtSales.Enabled = false;
            txtSales.BackColor = System.Drawing.SystemColors.ButtonFace;

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

            txtSales.Clear();
            txtCash.Clear();
            txtBank.Clear();
            txtGiro.Clear();
            txtGiroNumber.Clear();
            txtCorrection.Clear();

            lvwPayablePayment.Enabled = true;
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            if (lvwPayablePayment.Items.Count == 0)
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

            txtSales.Clear();
            txtCash.Clear();
            txtBank.Clear();
            txtGiro.Clear();
            txtGiroNumber.Clear();
            txtCorrection.Clear();

            lvwPayablePayment.Items.Clear();
            
            lblCash.Text = "0";
            lblBank.Text = "0";
            lblGiro.Text = "0";
            lblCorrection.Text = "0";
            lblTotal.Text = "0";

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

        private void ViewPayablePaymentDetail(PayablePayment payablePayment)
        {
            txtID.Text = payablePayment.ID.ToString();
            txtPayablePaymentId.Text = payablePayment.ID.ToString();
            lblCode.Text = payablePayment.PaymentCode;
            
            dtpDate.Text = payablePayment.PaymentDate.ToShortDateString();

            txtNotes.Text = payablePayment.Notes;

        }

        private void PopulatePayablePaymentItem(PayablePaymentItem payablePaymentItem)
        {
            var item = new ListViewItem(payablePaymentItem.SalesId.ToString());

            item.SubItems.Add(payablePaymentItem.Sales.Code);
            item.SubItems.Add(payablePaymentItem.Cash.ToString("N0").Replace(",", "."));
            item.SubItems.Add(payablePaymentItem.Bank.ToString("N0").Replace(",", "."));
            item.SubItems.Add(payablePaymentItem.Giro.ToString("N0").Replace(",", "."));
            item.SubItems.Add(payablePaymentItem.GiroNumber);
            item.SubItems.Add(payablePaymentItem.Correction.ToString("N0").Replace(",", "."));

            decimal total = payablePaymentItem.Cash + payablePaymentItem.Bank + payablePaymentItem.Giro + payablePaymentItem.Correction;

            item.SubItems.Add(total.ToString("N0").Replace(",", "."));
            item.SubItems.Add(payablePaymentItem.Sales.GrandTotal.ToString("N0").Replace(",", "."));

            lvwPayablePayment.Items.Add(item);

        }

        private void LoadPayablePaymentItems(Guid id)
        {
            var payablePaymentItems = payablePaymentItemRepository.GetByPayablePaymentId(id);

            lvwPayablePayment.Items.Clear();

            decimal cash = 0;
            decimal bank = 0;
            decimal giro = 0;
            decimal correction = 0;
            decimal total = 0;

            foreach (var payablePaymentItem in payablePaymentItems)
            {
                cash = cash + payablePaymentItem.Cash;
                bank = bank + payablePaymentItem.Bank;
                giro = giro + payablePaymentItem.Giro;
                correction = correction + payablePaymentItem.Correction;

                total = total + (payablePaymentItem.Cash + payablePaymentItem.Bank + payablePaymentItem.Giro + payablePaymentItem.Correction);
                PopulatePayablePaymentItem(payablePaymentItem);
            }

            lblCash.Text = cash.ToString("N0").Replace(",", ".");
            lblBank.Text = bank.ToString("N0").Replace(",", ".");
            lblGiro.Text = giro.ToString("N0").Replace(",", ".");
            lblCorrection.Text = correction.ToString("N0").Replace(",", ".");
            lblTotal.Text = total.ToString("N0").Replace(",", ".");
        }

        public void GetPayablePaymentHistory(string code)
        {
            var payablePayment = payablePaymentRepository.GetByCode(code);

            if (payablePayment != null)
            {
                ViewPayablePaymentDetail(payablePayment);
                LoadPayablePaymentItems(new Guid(txtID.Text));
            }
        }

        private void GetLastPayablePayment()
        {
            var payablePayment = payablePaymentRepository.GetLast(Store.ActiveMonth, Store.ActiveYear);
            if (payablePayment != null)
            {
                ViewPayablePaymentDetail(payablePayment);
                LoadPayablePaymentItems(new Guid(txtID.Text));
            }
        }

        private void PayablePaymentUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.SupplierName;

            FillCode();
            GetLastPayablePayment();

            if (lvwPayablePayment.Items.Count == 0)
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
            var frmHistory = new PayablePaymentHistoryUI(this);
            frmHistory.ShowDialog();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pelunasan Piutang" && u.IsAdd);

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
                    lblCode.Text = payablePaymentRepository.GeneratePayablePaymentCode(Store.ActiveMonth, Store.ActiveYear);
                    lblTotal.Text = "0";

                    this.Text = "Pelunasan Piutang - Tambah";

                }
            }
        }

        public void PutSales(string salesId, string salesCode, decimal salesTotal)
        {
            txtSalesId.Text = salesId;
            txtSales.Text = salesCode;
            txtSalesTotal.Text = salesTotal.ToString();
            

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var frmPayablePaymentSalesList = new PayablePaymentSalesListUI(this);
            frmPayablePaymentSalesList.ShowDialog();
        }

        private bool IsSalesExist(string salesCode)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwPayablePayment.Items)
            {
                if (salesCode == item.SubItems[1].Text)
                {
                    isExist = true;
                }
            }

            return isExist;
        }

        private void ClearSalesEntry()
        {
            txtSalesId.Clear();
            txtSales.Clear();
            txtCash.Clear();
            txtBank.Clear();
            txtGiro.Clear();
            txtGiroNumber.Clear();
            txtCorrection.Clear();
            txtSalesTotal.Clear();
        }

        private void GetTotalPayablePayment()
        {
            decimal totalCash = 0;
            decimal totalBank = 0;
            decimal totalGiro = 0;
            decimal totalCorrection = 0;
            decimal totalPayablePayment = 0;

            if (lvwPayablePayment.Items.Count > 0)
            {
                foreach (ListViewItem item in lvwPayablePayment.Items)
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
                    totalPayablePayment = totalPayablePayment + decimal.Parse(total.Replace(".", ""));


                    lblCash.Text = totalCash.ToString("N0").Replace(",", ".");
                    lblBank.Text = totalBank.ToString("N0").Replace(",", ".");
                    lblGiro.Text = totalGiro.ToString("N0").Replace(",", ".");
                    lblCorrection.Text = totalCorrection.ToString("N0").Replace(",", ".");
                    lblTotal.Text = totalPayablePayment.ToString("N0").Replace(",", ".");
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

            if (txtSales.Text == "")
            {
                MessageBox.Show("Dokumen penjualan harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSales.Focus();
            }
            else if (txtGiro.Text != "" && txtGiroNumber.Text == "")
            {
                MessageBox.Show("No. Giro harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiroNumber.Focus();
            }
            
            else if (IsSalesExist(txtSales.Text) && btnAdd.Text == "Tambah")
            {
                MessageBox.Show("Dokumen Penjualan sudah ditambahkan, silahkan pilih yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }
            else if (total1 < decimal.Parse(txtSalesTotal.Text.Replace(".", "")) || total1 > decimal.Parse(txtSalesTotal.Text.Replace(".", "")))
            {
                MessageBox.Show("Total Pelunasan tidak sama dengan Total Piutang", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }
            else
            {
                if (btnAdd.Text == "Update")
                {
                    lvwPayablePayment.FocusedItem.Remove();
                    lvwPayablePayment.Enabled = true;

                    btnAdd.Text = "Tambah";
                    btnCancel.Visible = false;
                }


                var item = new ListViewItem(txtSalesId.Text.ToString());

                decimal cash = decimal.Parse(txtCash.Text == "" ? "0" : txtCash.Text.Replace(".", string.Empty));
                decimal bank = decimal.Parse(txtBank.Text == "" ? "0" : txtBank.Text.Replace(".", string.Empty));
                decimal giro = decimal.Parse(txtGiro.Text == "" ? "0" : txtGiro.Text.Replace(".", string.Empty));
                decimal correction = decimal.Parse(txtCorrection.Text == "" ? "0" : txtCorrection.Text.Replace(".", string.Empty));
                
                decimal total = cash + bank + giro + correction;
                
                item.SubItems.Add(txtSales.Text);
                item.SubItems.Add(cash.ToString("N0").Replace(",", "."));
                item.SubItems.Add(bank.ToString("N0").Replace(",", "."));
                item.SubItems.Add(giro.ToString("N0").Replace(",", "."));
                item.SubItems.Add(txtGiroNumber.Text);
                item.SubItems.Add(correction.ToString("N0").Replace(",", "."));
                item.SubItems.Add(total.ToString("N0").Replace(",", "."));
                item.SubItems.Add(txtSalesTotal.Text.Replace(",", "."));

                lvwPayablePayment.Items.Add(item);

                ClearSalesEntry();

                GetTotalPayablePayment();

            }
        }

        private void lvwPayablePayment_DoubleClick(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
            {
                if (lvwPayablePayment.Items.Count > 0)
                {
                    btnAdd.Text = "Update";
                    btnCancel.Visible = true;

                    lvwPayablePayment.Enabled = false;

                    txtSalesId.Text = lvwPayablePayment.FocusedItem.SubItems[0].Text;
                    txtSales.Text = lvwPayablePayment.FocusedItem.SubItems[1].Text;
                    txtCash.Text = lvwPayablePayment.FocusedItem.SubItems[2].Text;
                    txtBank.Text = lvwPayablePayment.FocusedItem.SubItems[3].Text;
                    txtGiro.Text = lvwPayablePayment.FocusedItem.SubItems[4].Text;
                    txtGiroNumber.Text = lvwPayablePayment.FocusedItem.SubItems[5].Text;
                    txtCorrection.Text = lvwPayablePayment.FocusedItem.SubItems[6].Text;

                    txtSalesTotal.Text = lvwPayablePayment.FocusedItem.SubItems[8].Text;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            ClearSalesEntry();

            lvwPayablePayment.Enabled = true;
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
                && u.ObjectName == "Pelunasan Piutang" && u.IsEdit);

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
                    PayablePayment payablePayment = payablePaymentRepository.GetById(new Guid(txtID.Text));
                    if (payablePayment.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        formMode = FormMode.Edit;
                        this.Text = "Pelunasan Piutang - Edit";

                        EnableFormForEdit();
                    }
                }
            }
        }

        private void FillCode()
        {
            var payablePayment = payablePaymentRepository.GetAllCode(Store.ActiveMonth, Store.ActiveYear);

            lstPayablePayment.Items.Clear();

            foreach (var s in payablePayment)
            {
                lstPayablePayment.Items.Add(s);
            }

            if (lstPayablePayment.Items.Count > 0) lstPayablePayment.SelectedIndex = 0;

        }

        private void ShowPayablePaymentReport()
        {
            //Store.ActiveReport = "PayablePayment";

            //var frmReportPrint = new ReportPrintUI(this);
            //frmReportPrint.Show();

        }

        private void SavePayablePayment()
        {
            if (dtpDate.Value.Month != Store.ActiveMonth || dtpDate.Value.Year != Store.ActiveYear)
            {
                MessageBox.Show("Tanggal diluar periode aktif", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else if (lvwPayablePayment.Items.Count == 0)
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var payablePayment = new PayablePayment();

                payablePayment.PaymentCode = lblCode.Text;
                payablePayment.PaymentDate = dtpDate.Value;
                payablePayment.Notes = txtNotes.Text;
                payablePayment.TotalCash = decimal.Parse(lblCash.Text.Replace(".", ""));
                payablePayment.TotalBank = decimal.Parse(lblBank.Text.Replace(".", ""));
                payablePayment.TotalGiro = decimal.Parse(lblGiro.Text.Replace(".", ""));
                payablePayment.TotalCorrection = decimal.Parse(lblCorrection.Text.Replace(".", ""));
                payablePayment.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));


                var payablePaymentItems = new List<PayablePaymentItem>();

                foreach (ListViewItem item in lvwPayablePayment.Items)
                {
                    string salesId = item.SubItems[0].Text;
                    string cash = item.SubItems[2].Text;
                    string bank = item.SubItems[3].Text;
                    string giro = item.SubItems[4].Text;
                    string giroNumber = item.SubItems[5].Text;
                    string correction = item.SubItems[6].Text;
                    string total = item.SubItems[7].Text;

                    PayablePaymentItem si = new PayablePaymentItem();

                    
                    if (si.Sales == null) si.Sales = new Sales();
                    si.Sales.Code = item.SubItems[1].Text;

                    si.SalesId = new Guid(salesId);
                    si.Notes = "";
                    si.Cash = int.Parse(cash.Replace(".", ""));
                    si.Bank = decimal.Parse(bank.Replace(".", ""));
                    si.Giro = decimal.Parse(giro.Replace(".", ""));
                    si.GiroNumber = txtGiroNumber.Text;
                    si.Correction = decimal.Parse(correction.Replace(".", ""));
                    si.Total = decimal.Parse(total.Replace(".", ""));

                    payablePaymentItems.Add(si);
                }


                payablePayment.PayablePaymentItems = payablePaymentItems;


                if (formMode == FormMode.Add)
                {
                    payablePaymentRepository.Save(payablePayment);
                    ShowPayablePaymentReport();
                    GetLastPayablePayment();
                }
                else if (formMode == FormMode.Edit)
                {
                    payablePayment.ID = new Guid(txtID.Text);

                    payablePayment.TotalCash = decimal.Parse(lblCash.Text.Replace(".", ""));
                    payablePayment.TotalBank = decimal.Parse(lblBank.Text.Replace(".", ""));
                    payablePayment.TotalGiro = decimal.Parse(lblGiro.Text.Replace(".", ""));
                    payablePayment.TotalCorrection = decimal.Parse(lblCorrection.Text.Replace(".", ""));
                    payablePayment.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));


                    payablePaymentRepository.Update(payablePayment);

                    ShowPayablePaymentReport();
                }

                LoadPayablePaymentItems(new Guid(txtID.Text));
                DisableForm();
                formMode = FormMode.View;

                FillCode();
                this.Text = "Pelunasan Piutang";

            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SavePayablePayment();
            
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (formMode == FormMode.Add) payablePaymentRepository.Delete(lblCode.Text);

            GetLastPayablePayment();

            DisableForm();

            formMode = FormMode.View;
            this.Text = "Pelunasan Piutang";
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            if (lstPayablePayment.SelectedIndex < lstPayablePayment.Items.Count - 1)
            {
                lstPayablePayment.SelectedIndex = lstPayablePayment.SelectedIndex + 1;
            }
            
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (lstPayablePayment.SelectedIndex > 0)
            {
                lstPayablePayment.SelectedIndex = lstPayablePayment.SelectedIndex - 1;
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

        private void lvwPayablePayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwPayablePayment.Items.Count > 0)
            {
                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwPayablePayment.FocusedItem.Remove();
                    }

                    GetTotalPayablePayment();

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
                    PayablePayment payablePayment = payablePaymentRepository.GetById(new Guid(txtID.Text));
                    if (payablePayment.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + lblCode.Text + "'", "Perhatian",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var payablePayment1 = new PayablePayment();
                            payablePayment1.ID = new Guid(txtID.Text);
                            payablePayment1.Notes = txtNotes.Text;

                            payablePaymentRepository.Delete(payablePayment1);
                            GetLastPayablePayment();

                        }

                        if (lvwPayablePayment.Items.Count == 0)
                        {
                            tsbEdit.Enabled = false;
                            tsbDelete.Enabled = false;


                        }
                    }
                }
            }
        }

        private void txtSalesTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtSalesTotal.Text != string.Empty)
            {
                string textBoxData = txtSalesTotal.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtSalesTotal.Text = StringBldr.ToString();
                txtSalesTotal.SelectionStart = txtSalesTotal.Text.Length;
            }
        }

        private void lstPayablePayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var payablePayment = payablePaymentRepository.GetByCode(lstPayablePayment.Text);
            if (payablePayment != null)
            {
                ViewPayablePaymentDetail(payablePayment);
                LoadPayablePaymentItems(new Guid(txtID.Text));
            }
        }










    }
}
