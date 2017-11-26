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
    public partial class PayableBalanceUI : Form
    {

        private MainUI frmMain;
        private IPayableBalanceRepository payableBalanceRepository;
        private IPayableBalanceItemRepository payableBalanceItemRepository;

        private ICustomerRepository customerRepository;
        private ISalesmanRepository salesmanRepository;
        private ISalesRepository salesRepository;
        private FormMode formMode;
        private IUserAccessRepository userAccessRepository;

        public PayableBalanceUI()
        {
            InitializeComponent();
        }

        public PayableBalanceUI(MainUI frmMain)
        {

            customerRepository = ServiceLocator.GetObject<ICustomerRepository>();
            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
            payableBalanceRepository = ServiceLocator.GetObject<IPayableBalanceRepository>();
            payableBalanceItemRepository = ServiceLocator.GetObject<IPayableBalanceItemRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();

            this.frmMain = frmMain;
            InitializeComponent();

        }


        public void GetPayableBalanceHistory(string code)
        {
            var payableBalance = payableBalanceRepository.GetByCode(code);

            if (payableBalance != null)
            {
                ViewPayableBalanceDetail(payableBalance);
                LoadPayableItems(new Guid(txtID.Text));
            }
        }



        public void PutCustomer(string id, string name, int termOfPayment)
        {
            txtCustomerId.Text = id;
            txtCustomerName.Text = name;
            txtTermOfPayment.Text = termOfPayment.ToString();
        }

        public void PutSalesman(string id, string name)
        {
            txtSalesmanId.Text = id;
            txtSalesmanName.Text = name;
        }

        public void PutProductName(string productId, string productName, string unit, string price)
        {
            txtProductId.Text = productId;
            txtProduct.Text = productName;
            txtUnit.Text = unit;
            txtPrice.Text = price;

            txtPrice.Enabled = true;
            txtQty.Enabled = true;
        }

         private void ViewPayableBalanceDetail(PayableBalance payableBalance)
         {
              txtID.Text = payableBalance.ID.ToString();
              txtSalesCode.Text = payableBalance.SalesCode;
              dtpDate.Text = payableBalance.SalesDate.ToShortDateString();
              dtpDueDate.Text = payableBalance.DueDate.ToShortDateString();

              txtTermOfPayment.Text = payableBalance.TermOfPayment.ToString();

              txtCustomerId.Text = payableBalance.CustomerId.ToString();
              txtCustomerName.Text = payableBalance.Customer.Name;

              txtSalesmanId.Text = payableBalance.SalesmanId.ToString();
              txtSalesmanName.Text = payableBalance.Salesman.Name;

              if (payableBalance.PaymentMethod == 1)
              {
                  optCash.Checked = true;
              }
              else if (payableBalance.PaymentMethod == 2)
              {
                  optCredit.Checked = true;
              }

              if (payableBalance.IsStatus == true)
              {
                  lblPaidStatus.Visible = true;
              }
              else
              {
                  lblPaidStatus.Visible = false;
              }


              lblTotal.Text = payableBalance.GrandTotal.ToString();
              txtNotes.Text = payableBalance.Notes;
          }




         private void PopulatePayableBalanceItem(PayableBalanceItem payableBalanceItem)
         {
             var item = new ListViewItem(payableBalanceItem.ProductId.ToString());

             item.SubItems.Add(payableBalanceItem.Product.Name);
             item.SubItems.Add(payableBalanceItem.Product.Unit);
             item.SubItems.Add(payableBalanceItem.Price.ToString("N0").Replace(",", "."));
             item.SubItems.Add(payableBalanceItem.Qty.ToString("N0").Replace(",", "."));

             decimal total = payableBalanceItem.Qty * payableBalanceItem.Price;
             item.SubItems.Add(total.ToString("N0").Replace(",", "."));

             lvwPayableBalance.Items.Add(item);

         }



         private void LoadPayableItems(Guid id)
         {
             var payableBalanceItems = payableBalanceItemRepository.GetByPayableBalanceId(id);

             lvwPayableBalance.Items.Clear();

             decimal total = 0;

             foreach (var payableBalanceItem in payableBalanceItems)
             {
                 total = total + (payableBalanceItem.Qty * payableBalanceItem.Price);
                 PopulatePayableBalanceItem(payableBalanceItem);
             }

             lblTotal.Text = total.ToString("N0").Replace(",", ".");
         }




         private void GetLastPayableBalance()
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

             PayableBalance payableBalance = payableBalanceRepository.GetLast(month,year);
             if (payableBalance != null)
             {
                 ViewPayableBalanceDetail(payableBalance);
                 LoadPayableItems(new Guid(txtID.Text));   
             }
         }



          private void FillCode()
          {
              int month = 0;
              int year = 0;

              if (Store.ActiveMonth == 1)
              {
                  month = Store.ActiveMonth = 12;
                  year = Store.ActiveYear - 1;
              }
              else
              {
                  month = Store.ActiveMonth-1;
                  year = Store.ActiveYear;
              }
              
              var payableBalance = payableBalanceRepository.GetAllCode(month, year);

              lstDocument.Items.Clear();

              foreach (var s in payableBalance)
              {
                  lstDocument.Items.Add(s);
              }

              if (lstDocument.Items.Count > 0) lstDocument.SelectedIndex = 0;

          }

        

        private void PayableBalanceUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            FillCode();

            GetLastPayableBalance();

            if (lvwPayableBalance.Items.Count == 0)
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
            txtSalesCode.Clear();
            dtpDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
            optCredit.Checked = true;
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtSalesmanId.Clear();
            txtSalesmanName.Clear();
            txtNotes.Clear();

            lvwPayableBalance.Items.Clear();
            lblPaidStatus.Text = "";
            lblTotal.Text = "0";
            txtTermOfPayment.Clear();
        }

        private void EnableForm()
        {
            txtSalesCode.Enabled = true;
            txtSalesCode.BackColor = Color.White;

            dtpDate.Enabled = true;
            //dtpDueDate.Enabled = true;
            
            txtCustomerName.BackColor = Color.White;
            btnBrowseCustomer.Enabled = true;

            txtSalesmanName.BackColor = Color.White;
            btnBrowseSalesman.Enabled = true;
                      
            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;

            txtTermOfPayment.BackColor = Color.White;

            tsbBack.Enabled = false;
            tsbNext.Enabled = false;
            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;
            tsbHistory.Enabled = false;

            txtProduct.Enabled = false;
            txtProduct.BackColor = Color.White;

            txtPrice.Enabled = true;
            txtPrice.BackColor = Color.White;

            txtQty.Enabled = true;
            txtQty.BackColor = Color.White;

            btnBrowse.Enabled = true;
            btnAdd.Enabled = true;
         

        }

        private void EnableFormForEdit()
        {
            EnableForm();

            txtSalesCode.Enabled = false;
            txtSalesCode.BackColor = System.Drawing.SystemColors.ButtonFace;

            dtpDate.Focus();
        }

        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();
            txtSalesCode.Focus();

        }

        private void DisableForm()
        {
            txtSalesCode.Enabled = false;
            txtSalesCode.BackColor = System.Drawing.SystemColors.ButtonFace;

            dtpDate.Enabled = false;
            dtpDueDate.Enabled = false;
           
            txtCustomerName.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnBrowseCustomer.Enabled = false;

            txtSalesmanName.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnBrowseSalesman.Enabled = false;
            
            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtTermOfPayment.BackColor = System.Drawing.SystemColors.ButtonFace;

            tsbBack.Enabled = true;
            tsbNext.Enabled = true;
            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;
            tsbHistory.Enabled = true;

            txtProduct.Enabled = false;
            txtProduct.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPrice.Enabled = false;
            txtPrice.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtQty.Enabled = false;
            txtQty.BackColor = System.Drawing.SystemColors.ButtonFace;

            btnBrowse.Enabled = false;
            btnAdd.Enabled = false;

            txtProductId.Clear();
            txtProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
      
            lvwPayableBalance.Enabled = true;
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;


            if (lvwPayableBalance.Items.Count == 0)
            {
                tsbBack.Enabled = false;
                tsbNext.Enabled = false;
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbHistory.Enabled = false;
            }

          
             
          
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Piutang" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Sales sales = salesRepository.GetByCode(txtSalesCode.Text);
                //bool isUsed=payableBalanceRepository.IsPayableBalanceUsedByBillReceipt(sales.ID);

                if (Store.IsPeriodClosed)
                {
                    MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //else if (isUsed)
                //{
                //    MessageBox.Show("Tidak bisa ubah " + "\n\n" + "Dokumen : " + txtSalesCode.Text + "\n\n" + "dipakai di TTNT ", "Perhatian",
                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                else
                {

                    PayableBalance payableBalance = payableBalanceRepository.GetById(new Guid(txtID.Text));
                    if (Store.ActiveMonth != Store.StartDate.Month || Store.ActiveYear != Store.StartDate.Year)
                    {
                        MessageBox.Show("Tanggal harus sesuai periode awal pemakaian" + "\n" + Store.GetMonthName(Store.StartDate.Month) + " " + Store.StartDate.Year, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else if (payableBalance.IsStatus == true)
                    {
                        MessageBox.Show("Tidak bisa diubah " + "\n\n" + "Dokumen : " + txtSalesCode.Text + "\n\n" + "dipakai di Pelunasan Piutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        formMode = FormMode.Edit;
                        this.Text = "Saldo Awal Piutang - Edit";

                        EnableFormForEdit();


                    }
                }
            }
        }

     

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Piutang" && u.IsAdd);

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
                    this.Text = "Saldo Awal Piutang - Tambah";
                    EnableFormForAdd();
                }
            }
        }

      

        private void SavePayableBalance()
        {
            if (dtpDate.Value.Month >= Store.StartDate.Month && dtpDate.Value.Year >= Store.StartDate.Year)
            {
                MessageBox.Show("Tanggal harus sebelum periode awal pemakaian"  + "\n" + Store.GetMonthName(Store.StartDate.Month) + " " + Store.StartDate.Year  , "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (formMode == FormMode.Add && payableBalanceRepository.IsSalesCodeExisted(txtSalesCode.Text))
            {
                MessageBox.Show("Dokumen : \n\n" + txtSalesCode.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtSalesCode.Text == "")
            {
                MessageBox.Show("Dokumen harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSalesCode.Focus();
            }
            else if (txtCustomerName.Text=="")
            {
                MessageBox.Show("Customer harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowseCustomer.Focus();
            }
            else if (txtSalesmanName.Text=="")
            {
                MessageBox.Show("Salesman harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowseSalesman.Focus();
            }
            else if (dtpDate.Value > dtpDueDate.Value)
            {
                MessageBox.Show("Tanggal jatuh tempo harus lebih besar dari tanggal transaksi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            else if (lvwPayableBalance.Items.Count == 0 )
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                PayableBalance payableBalance = new PayableBalance();

                payableBalance.BalanceYear = Store.StartDate.Year;
                payableBalance.BalanceMonth = Store.StartDate.Month - 1;
                payableBalance.SalesCode = txtSalesCode.Text;
                payableBalance.SalesDate = dtpDate.Value;
                payableBalance.CustomerId = new Guid(txtCustomerId.Text);
                payableBalance.SalesmanId = new Guid(txtSalesmanId.Text);
                payableBalance.DueDate = dtpDueDate.Value;
                payableBalance.TermOfPayment = int.Parse(txtTermOfPayment.Text);

                payableBalance.PaymentMethod = 2;
                payableBalance.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));
                payableBalance.Notes = txtNotes.Text;

                string amountInWords = Store.GetAmounInWords(Convert.ToInt32(payableBalance.GrandTotal));

                string firstLetter = amountInWords.Substring(0, 2).Trim().ToUpper();
                string theRest = amountInWords.Substring(2, amountInWords.Length - 2);

                payableBalance.AmountInWords = firstLetter + theRest + " rupiah";

                var payableBalanceItems = new List<PayableBalanceItem>();

                foreach (ListViewItem item in lvwPayableBalance.Items)
                {
                    string productId = item.SubItems[0].Text;
                    string price = item.SubItems[3].Text;
                    string qty = item.SubItems[4].Text;

                    PayableBalanceItem pbi = new PayableBalanceItem();

                    pbi.ProductId = new Guid(productId);
                    pbi.Qty = int.Parse(qty.Replace(".", ""));
                    pbi.Price = decimal.Parse(price.Replace(".", ""));

                    payableBalanceItems.Add(pbi);
                }

                payableBalance.PayableBalanceItems = payableBalanceItems;


                if (formMode == FormMode.Add)
                {
                    payableBalanceRepository.Save(payableBalance);
                    GetLastPayableBalance();
                }
                else if (formMode == FormMode.Edit)
                {
                    payableBalance.ID = new Guid(txtID.Text);
                    payableBalance.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));
                    
                    payableBalanceRepository.Update(payableBalance);
                }
                

                DisableForm();
                formMode = FormMode.View;
                FillCode();
                this.Text = "Saldo Awal Piutang";


            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SavePayableBalance();

           
        }

        private void GetPayableBalanceById(Guid id)
        {
            PayableBalance payableBalance = payableBalanceRepository.GetById(id);
            ViewPayableBalanceDetail(payableBalance);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            GetLastPayableBalance();          
            DisableForm();

            formMode = FormMode.View;
            this.Text = "Saldo Awal Piutang";
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Piutang" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Sales sales = salesRepository.GetByCode(txtSalesCode.Text);

                if (Store.IsPeriodClosed)
                {
                    MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (payableBalanceRepository.IsPayableBalanceUsedByBillReceipt(sales.ID))
                {
                    MessageBox.Show("Tidak bisa dihapus " + "\n\n" + "Dokumen : " + txtSalesCode.Text + "\n\n" + "dipakai di TTNT ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PayableBalance payableBalance = payableBalanceRepository.GetById(new Guid(txtID.Text));
                    if (payableBalance.IsStatus == true)
                    {
                        MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Dokumen : " + txtSalesCode.Text + "\n\n" + "dipakai di Pelunasan Piutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + txtSalesCode.Text + "'", "Perhatian",
                                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            payableBalanceRepository.Delete(new Guid(txtID.Text), txtSalesCode.Text);
                            GetLastPayableBalance();


                        }

                    }
                }
            }
        }

                
        
        private void btnBrowseCustomer_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new CustomerListUI(this);
            frmCustomerList.ShowDialog();
        }

        private void btnBrowseSalesman_Click(object sender, EventArgs e)
        {
            var frmSalesmanList = new SalesmanListUI(this);
            frmSalesmanList.ShowDialog();
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var frmProductList = new ProductListUI(this);
            frmProductList.ShowDialog();
        }



        private bool IsProductExist(string productName)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwPayableBalance.Items)
            {
                if (productName == item.SubItems[1].Text)
                {
                    isExist = true;
                }
            }

            return isExist;
        }


        private void ClearProductEntry()
        {
            txtProductId.Clear();
            txtProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
        }


        private decimal GetTotalSales()
        {
            decimal totalSales = 0;

            foreach (ListViewItem item in lvwPayableBalance.Items)
            {
                string price = item.SubItems[5].Text;
                totalSales = totalSales + decimal.Parse(price.Replace(".", ""));

            }

            return totalSales;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text == "")
            {
                MessageBox.Show("Nama barang harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Focus();
            }
            else if (txtPrice.Text == "" || int.Parse(txtPrice.Text.Replace(".", "")) == 0)
            {
                MessageBox.Show("Harga harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrice.Focus();
            }
            else if (txtQty.Text == "" || int.Parse(txtQty.Text.Replace(".", "")) == 0)
            {
                MessageBox.Show("Qty harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQty.Focus();
            }
            else if (IsProductExist(txtProduct.Text) && btnAdd.Text == "Tambah")
            {
                MessageBox.Show("Barang sudah ditambahkan, silahkan pilih yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }
            else
            {
                if (btnAdd.Text == "Update")
                {
                    lvwPayableBalance.FocusedItem.Remove();
                    lvwPayableBalance.Enabled = true;

                    btnAdd.Text = "Tambah";
                    btnCancel.Visible = false;
                }


                var item = new ListViewItem(txtProductId.Text.ToString());

                decimal price = decimal.Parse(txtPrice.Text.Replace(".", ""));
                int qty = int.Parse(txtQty.Text.Replace(".", ""));

                decimal total = price * qty;

                item.SubItems.Add(txtProduct.Text);
                item.SubItems.Add(txtUnit.Text);
                item.SubItems.Add(price.ToString("N0").Replace(",", "."));
                item.SubItems.Add(qty.ToString("N0").Replace(",", "."));
                item.SubItems.Add(total.ToString("N0").Replace(",", "."));

                lvwPayableBalance.Items.Add(item);

                ClearProductEntry();

                lblTotal.Text = GetTotalSales().ToString("N0").Replace(",", ".");

            }
        }

        private void tsbBack_Click(object sender, EventArgs e)
        {
            if (lstDocument.SelectedIndex < lstDocument.Items.Count - 1)
            {
                lstDocument.SelectedIndex = lstDocument.SelectedIndex + 1;
            }
           
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (lstDocument.SelectedIndex > 0)
            {
                lstDocument.SelectedIndex = lstDocument.SelectedIndex - 1;
            }
        }

        private void lstDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sales = payableBalanceRepository.GetByCode(lstDocument.Text);
            if (sales != null)
            {
                ViewPayableBalanceDetail(sales);
                LoadPayableItems(new Guid(txtID.Text));
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text != string.Empty)
            {
                string textBoxData = txtPrice.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtPrice.Text = StringBldr.ToString();
                txtPrice.SelectionStart = txtPrice.Text.Length;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text != string.Empty)
            {
                string textBoxData = txtQty.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtQty.Text = StringBldr.ToString();
                txtQty.SelectionStart = txtQty.Text.Length;
            }
        }


        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lvwPayableBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwPayableBalance.Items.Count > 0)
            {

                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwPayableBalance.FocusedItem.Remove();
                    }

                    lblTotal.Text = GetTotalSales().ToString("N0").Replace(",", ".");
                }
            }
        }

        private void lvwPayableBalance_DoubleClick(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
            {
                if (lvwPayableBalance.Items.Count > 0)
                {
                    btnAdd.Text = "Update";
                    btnCancel.Visible = true;

                    lvwPayableBalance.Enabled = false;

                    txtProductId.Text = lvwPayableBalance.FocusedItem.SubItems[0].Text;
                    txtProduct.Text = lvwPayableBalance.FocusedItem.SubItems[1].Text;
                    txtUnit.Text = lvwPayableBalance.FocusedItem.SubItems[2].Text;
                    txtPrice.Text = lvwPayableBalance.FocusedItem.SubItems[3].Text;
                    txtQty.Text = lvwPayableBalance.FocusedItem.SubItems[4].Text;
                                        
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            txtProductId.Clear();
            txtProduct.Clear();
            txtQty.Clear();
            txtPrice.Clear();
           
            lvwPayableBalance.Enabled = true;
        }

        private void tsbHistory_Click(object sender, EventArgs e)
        {
            var frmPayableBalanceHistory = new PayableBalanceHistoryUI(this);
            frmPayableBalanceHistory.ShowDialog();
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
