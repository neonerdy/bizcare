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
    public partial class RecordCounterUI : Form
    {
        private MainUI frmMain;
        private IRecordCounterRepository recordCounterRepository;
        private FormMode formMode;
        private FormFilter formFilter;
        private IUserAccessRepository userAccessRepository;

        public RecordCounterUI()
        {
            InitializeComponent();
        }

        public RecordCounterUI(MainUI frmMain)
        {
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();

            this.frmMain = frmMain;
            InitializeComponent();
        }


        private void FillMonth()
        {
            
           cboMonth.Items.Add("Januari");
           cboMonth.Items.Add("Februari");
           cboMonth.Items.Add("Maret");
           cboMonth.Items.Add("April");
           cboMonth.Items.Add("Mei");
           cboMonth.Items.Add("Juni");
           cboMonth.Items.Add("Juli");
           cboMonth.Items.Add("Agustus");
           cboMonth.Items.Add("September");
           cboMonth.Items.Add("Oktober");
           cboMonth.Items.Add("November");
           cboMonth.Items.Add("Desember");


        }

        private void ViewRecordCounterDetail(RecordCounter recordCounter)
        {
            txtID.Text = recordCounter.ID.ToString();
            txtYear.Text = recordCounter.ActiveYear.ToString();
            cboMonth.Text = GetMonthName(recordCounter.ActiveMonth);           
            txtSalesCounter.Text = recordCounter.SalesCounter.ToString();
            txtPurchaseCounter.Text = recordCounter.PurchaseCounter.ToString();
            txtExpenseCounter.Text = recordCounter.ExpenseCounter.ToString();
            txtPayablePaymentCounter.Text = recordCounter.PayablePaymentCounter.ToString();
            txtDebtPaymentCounter .Text = recordCounter.DebtPaymentCounter.ToString();
            txtBillReceiptCounter.Text = recordCounter.BillReceiptCounter.ToString();
            txtStockCorrectionCounter.Text = recordCounter.StockCorrectionCounter.ToString();
            chkClosingStatus.Checked = recordCounter.ClosingStatus;
        }

        private void GetLastRecordCounter()
        {
            RecordCounter recordCounter = recordCounterRepository.GetLast();
            if (recordCounter != null) ViewRecordCounterDetail(recordCounter);
        }


        private void RenderRecordCounter(RecordCounter recordCounter)
        {
            var item = new ListViewItem(recordCounter.ID.ToString());

            
            item.SubItems.Add(recordCounter.ActiveYear.ToString());
            item.SubItems.Add(GetMonthName(recordCounter.ActiveMonth));
            item.SubItems.Add(recordCounter.SalesCounter.ToString());
            item.SubItems.Add(recordCounter.PurchaseCounter.ToString());
            item.SubItems.Add(recordCounter.ExpenseCounter.ToString());
            item.SubItems.Add(recordCounter.PayablePaymentCounter.ToString());
            item.SubItems.Add(recordCounter.DebtPaymentCounter.ToString());
            item.SubItems.Add(recordCounter.BillReceiptCounter.ToString());
            item.SubItems.Add(recordCounter.StockCorrectionCounter.ToString());
           
            if (recordCounter.ClosingStatus == true)
            {
                item.SubItems.Add("YA");
            }
            else
            {
                item.SubItems.Add("TIDAK");
            }


            lvwRecordCounter.Items.Add(item);

        }

        private void LoadRecordCounter()
        {
            var recordCounters = recordCounterRepository.GetAll();

            lvwRecordCounter.Items.Clear();

            foreach (var recordCounter in recordCounters)
            {
                RenderRecordCounter(recordCounter);
            }
        }

        private void RecordCounterUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;

            FillMonth();
            GetLastRecordCounter();
            LoadRecordCounter();

            if (lvwRecordCounter.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbMenuFilter.Enabled = false;
                txtSearch.Enabled = false;
                tsbFilter.Enabled = false;
            }
        }

        private void lvwRecordCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwRecordCounter.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    RecordCounter recordCounter = recordCounterRepository.GetById(new Guid(lvwRecordCounter.FocusedItem.Text));
                    ViewRecordCounterDetail(recordCounter);
                }
            }
        }

        private void ClearForm()
        {
            cboMonth.SelectedIndex = -1;
            txtYear.Clear();
            txtSalesCounter.Clear();
            txtPurchaseCounter.Clear();
            txtExpenseCounter.Clear();
            txtPayablePaymentCounter.Clear();
            txtDebtPaymentCounter.Clear();
            txtBillReceiptCounter.Clear();
            txtStockCorrectionCounter.Clear();
            chkClosingStatus.Checked = false;

        }

        private void EnableForm()
        {
            cboMonth.Enabled = true;
            cboMonth.BackColor = Color.White;

            txtYear.Enabled = true;
            txtYear.BackColor = Color.White;

            txtSalesCounter.Enabled = true;
            txtSalesCounter.BackColor = Color.White;

            txtPurchaseCounter.Enabled = true;
            txtPurchaseCounter.BackColor = Color.White;

            txtExpenseCounter.Enabled = true;
            txtExpenseCounter.BackColor = Color.White;

            txtPayablePaymentCounter.Enabled = true;
            txtPayablePaymentCounter.BackColor = Color.White;

            txtDebtPaymentCounter.Enabled = true;
            txtDebtPaymentCounter.BackColor = Color.White;

            txtBillReceiptCounter.Enabled = true;
            txtBillReceiptCounter.BackColor = Color.White;

            txtStockCorrectionCounter.Enabled = true;
            txtStockCorrectionCounter.BackColor = Color.White;

            chkClosingStatus.Enabled = true;

            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;

        }

        private void EnableFormForEdit()
        {
            EnableForm();

            cboMonth.Enabled = false;
            cboMonth.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtYear.Enabled = false;
            txtYear.BackColor = System.Drawing.SystemColors.ButtonFace;


            txtSalesCounter.SelectionStart = 0;
            txtSalesCounter.Focus();
        }

        private void EnableFormForAdd()
        {

            EnableForm();
            ClearForm();
            cboMonth.Focus();

        }

        private void DisableForm()
        {
            cboMonth.Enabled = false;
            cboMonth.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtYear.Enabled = false;
            txtYear.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtSalesCounter.Enabled = false;
            txtSalesCounter.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPurchaseCounter.Enabled = false;
            txtPurchaseCounter.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtExpenseCounter.Enabled = false;
            txtExpenseCounter.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPayablePaymentCounter.Enabled = false;
            txtPayablePaymentCounter.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtDebtPaymentCounter.Enabled = false;
            txtDebtPaymentCounter.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtBillReceiptCounter.Enabled = false;
            txtBillReceiptCounter.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtStockCorrectionCounter.Enabled = false;
            txtStockCorrectionCounter.BackColor = System.Drawing.SystemColors.ButtonFace;

            chkClosingStatus.Enabled = false;

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

            if (lvwRecordCounter.Items.Count == 0)
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
                && u.ObjectName == "Dokumen" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Edit;
                this.Text = "Dokumen - Edit";
                EnableFormForEdit();
            }

        }

        private void lvwRecordCounter_DoubleClick(object sender, EventArgs e)
        {
            if (lvwRecordCounter.Items.Count > 0)
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
                && u.ObjectName == "Dokumen" && u.IsAdd);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menambah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Add;
                this.Text = "Dokumen - Tambah";
                EnableFormForAdd();
            }
        }

        private void SaveRecordCounter()
        {
            if (cboMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Bulan harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMonth.Focus();
            }
            else if (txtYear.Text.Equals("") || txtYear.TextLength < 4)
            {
                MessageBox.Show("Tahun harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtYear.Focus();
            }
            else if (formMode == FormMode.Add && recordCounterRepository.IsRecordCounterExisted(int.Parse(GetMonthCode(cboMonth.Text).ToString()), int.Parse(txtYear.Text)))
            {
                MessageBox.Show("Periode : " + cboMonth.Text + " - " + txtYear.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else
            {

                RecordCounter recordCounter = new RecordCounter();

                recordCounter.ActiveMonth = GetMonthCode(cboMonth.Text);
                recordCounter.ActiveYear = int.Parse(txtYear.Text);
                recordCounter.SalesCounter = int.Parse(txtSalesCounter.Text=="" ? "0" : txtSalesCounter.Text);
                recordCounter.PurchaseCounter = int.Parse(txtPurchaseCounter.Text=="" ? "0" :txtPurchaseCounter.Text );
                recordCounter.ExpenseCounter = int.Parse(txtExpenseCounter.Text=="" ? "0" : txtExpenseCounter.Text);
                recordCounter.DebtPaymentCounter = int.Parse(txtDebtPaymentCounter.Text=="" ? "0" : txtDebtPaymentCounter.Text);
                recordCounter.PayablePaymentCounter = int.Parse(txtPayablePaymentCounter.Text == "" ? "0" : txtPayablePaymentCounter.Text);
                recordCounter.BillReceiptCounter = int.Parse(txtBillReceiptCounter.Text == "" ? "0" : txtBillReceiptCounter.Text);
                recordCounter.StockCorrectionCounter = int.Parse(txtStockCorrectionCounter.Text == "" ? "0" : txtStockCorrectionCounter.Text);
                recordCounter.ClosingStatus = chkClosingStatus.Checked;

                if (formMode == FormMode.Add)
                {
                    recordCounterRepository.Save(recordCounter);

                    GetLastRecordCounter();
                }
                else if (formMode == FormMode.Edit)
                {
                    recordCounter.ID = new Guid(txtID.Text);
                    recordCounterRepository.Update(recordCounter);
                }

                if (recordCounter.ClosingStatus == true && recordCounter.ActiveMonth == Store.ActiveMonth && recordCounter.ActiveYear == Store.ActiveYear)
                {
                    Store.IsPeriodClosed = true;
                }
                else
                {
                    Store.IsPeriodClosed = false;
                }

                LoadRecordCounter();
                DisableForm();

                formMode = FormMode.View;
                this.Text = "Dokumen";               
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveRecordCounter();            
        }



        private void GetRecordCounterById(Guid id)
        {
            RecordCounter recordCounter = recordCounterRepository.GetById(id);
            ViewRecordCounterDetail(recordCounter);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwRecordCounter.Items.Count > 0)
            {
                GetRecordCounterById(new Guid(txtID.Text));
            }

            DisableForm();

            lvwRecordCounter.Enabled = true;

            formMode = FormMode.View;
            this.Text = "Dokumen";
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Dokumen" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Anda yakin ingin menghapus '" + cboMonth.Text + " " + txtYear.Text + "'", "Perhatian",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    recordCounterRepository.Delete(new Guid(txtID.Text));
                    GetLastRecordCounter();
                    LoadRecordCounter();

                }

                if (lvwRecordCounter.Items.Count == 0)
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

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadRecordCounter();
        }


        private void FilterRecordCounter(string field, string value)
        {

            var recordCounters = recordCounterRepository.Search(value);

            lvwRecordCounter.Items.Clear();

            foreach (var recordCounter in recordCounters)
            {
                RenderRecordCounter(recordCounter);
            }

        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterRecordCounter(formFilter.ToString(), txtSearch.Text);
            }
            else
            {
                LoadRecordCounter();
            }
        }

    
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterRecordCounter(formFilter.ToString(), txtSearch.Text);
            }
            else
            {
                LoadRecordCounter();
            }
        }

       

        private void txtSalesCounter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPurchaseCounter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtExpenseCounter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPayablePaymentCounter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDebtPaymentCounter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBillReceiptCounter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
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



        private string GetMonthName(int monthCode)
        {
            string monthName = "";

            if (monthCode == 1)
            {
                monthName = "Januari";
            }
            else if (monthCode == 2)
            {
                monthName = "Februari";
            }
            else if (monthCode == 3)
            {
                monthName = "Maret";
            }
            else if (monthCode == 4)
            {
                monthName = "April";
            }
            else if (monthCode == 5)
            {
                monthName = "Mei";
            }
            else if (monthCode == 6)
            {
                monthName = "Juni";
            }
            else if (monthCode == 7)
            {
                monthName = "Juli";
            }
            else if (monthCode == 8)
            {
                monthName = "Agustus";
            }
            else if (monthCode == 9)
            {
                monthName = "September";
            }
            else if (monthCode == 10)
            {
                monthName = "Oktober";
            }
            else if (monthCode == 11)
            {
                monthName = "November";
            }
            else
            {
                monthName = "Desember";
            }


            return monthName;

        }


        private int GetMonthCode(string monthName)
        {
            int monthCode = 0;

            if (monthName == "Januari")
            {
                monthCode = 1;
            }
            else if (monthName == "Februari")
            {
                monthCode = 2;
            }
            else if (monthName == "Maret")
            {
                monthCode = 3;
            }
            else if (monthName == "April")
            {
                monthCode = 4;
            }
            else if (monthName == "Mei")
            {
                monthCode = 5;
            }
            else if (monthName == "Juni")
            {
                monthCode = 6;
            }
            else if (monthName == "Juli")
            {
                monthCode = 7;
            }
            else if (monthName == "Agustus")
            {
                monthCode = 8;
            }
            else if (monthName == "September")
            {
                monthCode = 9;
            }
            else if (monthName == "Oktober")
            {
                monthCode = 10;
            }
            else if (monthName == "November")
            {
                monthCode = 11;
            }
            else
            {
                monthCode = 12;
            }


            return monthCode;

        }

        private void txtStockCorrectionCounter_KeyPress(object sender, KeyPressEventArgs e)
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


    }
}
