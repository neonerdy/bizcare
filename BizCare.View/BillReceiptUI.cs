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
    public partial class BillReceiptUI : Form
    {

        private MainUI frmMain;
        private FormMode formMode;
      
        private IBillReceiptRepository billReceiptRepository;
        private IBillReceiptItemRepository billReceiptItemRepository;
        private ISalesRepository salesRepository;
        private ISalesmanRepository salesmanRepository;
        private IUserAccessRepository userAccessRepository;

        public BillReceiptUI()
        {
            InitializeComponent();
        }

        public BillReceiptUI(MainUI frmMain)
        {
            this.frmMain = frmMain;

         
            billReceiptRepository = ServiceLocator.GetObject<IBillReceiptRepository>();
            billReceiptItemRepository = ServiceLocator.GetObject<IBillReceiptItemRepository>();
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
            InitializeComponent();
        }


        public void PutSalesman(string id, string name)
        {
            txtSalesmanId.Text = id;
            txtSalesmanName.Text = name;
        }

        public string BillReceiptCode
        {
            get { return lblCode.Text; }
        }

        private void EnableForm()
        {
            dtpDate.Enabled = true;

            txtSalesmanName.BackColor = Color.White;
            btnBrowseSalesman.Enabled = true;
            
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

            btnBrowse.Enabled = true;
            


        }

        private void DisableForm()
        {
            dtpDate.Enabled = false;

            txtSalesmanName.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnBrowseSalesman.Enabled = false;
           
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

            
            btnBrowse.Enabled = false;
            lvwBillReceipt.Enabled = true;
            btnBrowse.Text = "Tambah";
            
            if (lvwBillReceipt.Items.Count == 0)
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
            txtSalesmanId.Clear();
            txtSalesmanName.Clear();
            txtNotes.Clear();
            txtSalesmanId.Clear();
            lvwBillReceipt.Items.Clear();
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

     
        private void ViewBillReceiptDetail(BillReceipt billReceipt)
        {
            txtID.Text = billReceipt.ID.ToString();
            txtBillReceiptId.Text = billReceipt.ID.ToString();
            lblCode.Text = billReceipt.Code;
            dtpDate.Text = billReceipt.BillReceiptDate.ToShortDateString();

            txtSalesmanId.Text = billReceipt.SalesmanId.ToString();
            txtSalesmanName.Text = billReceipt.Salesman.Name;
      
            txtNotes.Text = billReceipt.Notes;

        }

        private void PopulateBillReceiptItem(BillReceiptItem billReceiptItem)
        {
            var item = new ListViewItem(billReceiptItem.SalesId.ToString());

            item.SubItems.Add(billReceiptItem.Sales.Date.ToString("dd/MM/yyyy"));
            item.SubItems.Add(billReceiptItem.Sales.Code);
            item.SubItems.Add(billReceiptItem.Sales.Customer.Name);
            item.SubItems.Add(billReceiptItem.Sales.Salesman.Name);
            item.SubItems.Add(billReceiptItem.Total.ToString("N0").Replace(",", "."));
            
            lvwBillReceipt.Items.Add(item);

        }

        private void LoadBillReceiptItems(Guid id)
        {
            var billReceiptItems = billReceiptItemRepository.GetByBillReceiptId(id);

            lvwBillReceipt.Items.Clear();

            decimal total = 0;

            foreach (var billReceiptItem in billReceiptItems)
            {
                total = total + billReceiptItem.Total;

                PopulateBillReceiptItem(billReceiptItem);
            }

            lblTotal.Text = total.ToString("N0").Replace(",", ".");
        }

        public void GetBillReceiptHistory(string code)
        {
            var billReceipt = billReceiptRepository.GetByCode(code);

            if (billReceipt != null)
            {
                ViewBillReceiptDetail(billReceipt);
                LoadBillReceiptItems(new Guid(txtID.Text));
            }
        }


        private void GetLastBillReceipt()
        {
            var billReceipt = billReceiptRepository.GetLast(Store.ActiveMonth, Store.ActiveYear);
            if (billReceipt != null)
            {
                ViewBillReceiptDetail(billReceipt);
                LoadBillReceiptItems(new Guid(txtID.Text));
            }
        }

        private void FillCode()
        {
            var billReceipt = billReceiptRepository.GetAllCode(Store.ActiveMonth, Store.ActiveYear);

            lstBillReceipt.Items.Clear();

            foreach (var s in billReceipt)
            {
                lstBillReceipt.Items.Add(s);
            }

            if (lstBillReceipt.Items.Count > 0) lstBillReceipt.SelectedIndex = 0;

        }

        private void BillReceiptUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
         
            FillCode();
            GetLastBillReceipt();

            if (lvwBillReceipt.Items.Count == 0)
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
            var frmHistory = new BillReceiptHistoryUI(this);
            frmHistory.ShowDialog();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "TTNT" && u.IsAdd);

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
                    lblCode.Text = billReceiptRepository.GenerateBillReceiptCode(Store.ActiveMonth, Store.ActiveYear);
                    lblTotal.Text = "0";

                    this.Text = "TTNT - Tambah";
                }
            }
        }

        

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var frmBillReceiptSalesList = new BillReceiptSalesListUI(this);
            frmBillReceiptSalesList.ShowDialog();
        }

        private bool IsSalesExist(string salesCode)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwBillReceipt.Items)
            {
                if (salesCode == item.SubItems[2].Text)
                {
                    isExist = true;
                }
            }

            return isExist;
        }

        private void GetTotalBillReceipt()
        {
            decimal totalBillReceipt = 0;

            if (lvwBillReceipt.Items.Count > 0)
            {
                foreach (ListViewItem item in lvwBillReceipt.Items)
                {

                    string total = item.SubItems[5].Text;

                    totalBillReceipt = totalBillReceipt + decimal.Parse(total.Replace(".", ""));

                    lblTotal.Text = totalBillReceipt.ToString("N0").Replace(",", ".");
                }
            }
            else
            {
                lblTotal.Text = "0";
            }

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "TTNT" && u.IsEdit);

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
                    BillReceipt billReceipt = billReceiptRepository.GetById(new Guid(txtID.Text));
                    if (billReceipt.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        formMode = FormMode.Edit;
                        this.Text = "TTNT - Edit";

                        EnableFormForEdit();
                    }
                }
            }
        }


        private void ShowBillReceiptReport()
        {
            Store.ActiveReport = "BillReceipt";

            var frmReportPrint = new ReportPrintUI(this);
            frmReportPrint.Show();

        }

        private void SaveBillReceipt()
        {
            if (dtpDate.Value.Month != Store.ActiveMonth || dtpDate.Value.Year != Store.ActiveYear)
            {
                MessageBox.Show("Tanggal diluar periode aktif", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            else if (txtSalesmanName.Text == "")
            {
                MessageBox.Show("Salesman tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowseSalesman.Focus();
            }
            else if (lvwBillReceipt.Items.Count == 0)
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var billReceipt = new BillReceipt();

                billReceipt.Code = lblCode.Text;
                billReceipt.BillReceiptDate = dtpDate.Value;
                billReceipt.Notes = txtNotes.Text;
                billReceipt.SalesmanId = new Guid(txtSalesmanId.Text);
                billReceipt.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));


                var billReceiptItems = new List<BillReceiptItem>();

                foreach (ListViewItem item in lvwBillReceipt.Items)
                {
                    string salesId = item.SubItems[0].Text;
                    string total = item.SubItems[5].Text;

                    BillReceiptItem si = new BillReceiptItem();

                    if (si.Sales == null) si.Sales = new Sales();
                    si.Sales.Code = item.SubItems[2].Text;

                    si.SalesId = new Guid(salesId);
                    si.Notes = "";
                    si.Total = decimal.Parse(total.Replace(".", ""));

                    billReceiptItems.Add(si);
                }


                billReceipt.BillReceiptItems = billReceiptItems;


                if (formMode == FormMode.Add)
                {
                    billReceiptRepository.Save(billReceipt);
                    ShowBillReceiptReport();
                    GetLastBillReceipt();
                }
                else if (formMode == FormMode.Edit)
                {
                    billReceipt.ID = new Guid(txtID.Text);
                    billReceipt.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));
                    billReceiptRepository.Update(billReceipt);
                    ShowBillReceiptReport();
                }

                LoadBillReceiptItems(new Guid(txtID.Text));
                DisableForm();
                formMode = FormMode.View;

                FillCode();
                this.Text = "TTNT";
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveBillReceipt();
            
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (formMode == FormMode.Add) billReceiptRepository.Delete(lblCode.Text);

            GetLastBillReceipt();

            DisableForm();

            formMode = FormMode.View;
            this.Text = "TTNT";
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            if (lstBillReceipt.SelectedIndex < lstBillReceipt.Items.Count - 1)
            {
                lstBillReceipt.SelectedIndex = lstBillReceipt.SelectedIndex + 1;
            }
            
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (lstBillReceipt.SelectedIndex > 0)
            {
                lstBillReceipt.SelectedIndex = lstBillReceipt.SelectedIndex - 1;
            }
        }

        private void lvwBillReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwBillReceipt.Items.Count > 0)
            {
                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwBillReceipt.FocusedItem.Remove();
                    }

                    GetTotalBillReceipt();
                }
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "TTNT" && u.IsDelete);

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
                    BillReceipt billReceipt = billReceiptRepository.GetById(new Guid(txtID.Text));
                    if (billReceipt.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + lblCode.Text + "'", "Perhatian",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var billReceipt1 = new BillReceipt();
                            billReceipt1.ID = new Guid(txtID.Text);
                            billReceipt1.Notes = txtNotes.Text;

                            billReceiptRepository.Delete(billReceipt1);
                            GetLastBillReceipt();

                        }

                        if (lvwBillReceipt.Items.Count == 0)
                        {
                            tsbEdit.Enabled = false;
                            tsbDelete.Enabled = false;


                        }
                    }
                }
            }
        }

        private void lvwBillReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        
        private void PopulateSales(Sales sales)
        {
            var item = new ListViewItem(sales.ID.ToString());

            item.SubItems.Add(sales.Date.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sales.Code);
            item.SubItems.Add(sales.Customer.Name);
            item.SubItems.Add(sales.Salesman.Name);
            item.SubItems.Add(sales.GrandTotal.ToString("N0").Replace(",", "."));

            lvwBillReceipt.Items.Add(item);

        }

        public void PutSales(string code)
        {
            var sales = salesRepository.GetByCode(code);

            if (sales != null)
            {
                if (IsSalesExist(code))
                {
                    MessageBox.Show("Dokumen Penjualan sudah ditambahkan, silahkan pilih yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    PopulateSales(sales);
                    GetTotalBillReceipt();
                }
            }
        }

        private void lstBillReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            var billReceipt = billReceiptRepository.GetByCode(lstBillReceipt.Text);
            if (billReceipt != null)
            {
                ViewBillReceiptDetail(billReceipt);
                LoadBillReceiptItems(new Guid(txtID.Text));
            }
        }

        private void btnBrowseSalesman_Click(object sender, EventArgs e)
        {
            var frmSalesmanList = new SalesmanListUI(this);
            frmSalesmanList.ShowDialog();
        }











    }
}
