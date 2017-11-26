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
    public partial class SalesUI : Form
    {
        private MainUI frmMain;
        private FormMode formMode;
        private ISalesRepository salesRepository;
        private ISalesItemRepository salesItemRepository;
        private ICustomerRepository customerRepository;
        private ISalesmanRepository salesmanRepository;
        private IProductQtyRepository productQtyRepository;
        private IUserAccessRepository userAccessRepository;

        public SalesUI()
        {
            InitializeComponent();
        }

        public SalesUI(MainUI frmMain)
        {
            this.frmMain = frmMain;
         
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
            salesItemRepository = ServiceLocator.GetObject<ISalesItemRepository>();
            customerRepository = ServiceLocator.GetObject<ICustomerRepository>();
            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
            InitializeComponent();
        }


        public string SalesCode
        {
            get { return lblCode.Text; }
        }

        public void PutCustomer(string id,string name, string address, int termOfPayment)
        {
            txtCustomerId.Text = id;
            txtCustomerName.Text = name;
            txtCustomerAddress.Text = address;
            txtTermOfPayment.Text = termOfPayment.ToString();
        }

        public void PutSalesman(string id, string name)
        {
            txtSalesmanId.Text = id;
            txtSalesmanName.Text = name;
        }
        

        public void PutProductName(string productId,string productName,string unit,string price)
        {
            txtProductId.Text = productId;
            txtProduct.Text = productName;
            txtUnit.Text = unit;
            txtPrice.Text = price;

            txtPrice.Enabled = true;
            txtQty.Enabled = true;

            var productQty = productQtyRepository.GetByMonthAndYear(Store.ActiveMonth, Store.ActiveYear, new Guid(productId));
            if (productQty != null)
            {
                txtQtyEnd.Text = productQty.QtyEnd.ToString();
            }
            else
            {
                txtQtyEnd.Text = "0";
            }
        }


        private void FillCode()
        {
            var sales = salesRepository.GetAllCode(Store.ActiveMonth, Store.ActiveYear);

            lstSales.Items.Clear();

            foreach (var s in sales)
            {
                lstSales.Items.Add(s);
            }

            if (lstSales.Items.Count > 0) lstSales.SelectedIndex = 0;

        }

       
        
        private void DisableForm()
        {           
            txtCustomerName.Enabled = false;
            txtCustomerName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtCustomerAddress.Enabled = false;
            txtCustomerAddress.BackColor = System.Drawing.SystemColors.ButtonFace;

            btnBrowseCustomer.Enabled = false;

            txtSalesmanName.Enabled = false;
            txtSalesmanName.BackColor = System.Drawing.SystemColors.ButtonFace;
            btnBrowseSalesman.Enabled = false;
                        
            dtpDate.Enabled = false;
            dtpDueDate.Enabled = false;
            optCash.Enabled = false;
            optCredit.Enabled = false;

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
            txtQtyEnd.Clear();

            lvwSales.Enabled = true;
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            if (lvwSales.Items.Count == 0)
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
            txtCustomerName.BackColor = Color.White;
            txtCustomerAddress.BackColor = Color.White;
            btnBrowseCustomer.Enabled = true;

            txtSalesmanName.BackColor = Color.White;
            btnBrowseSalesman.Enabled = true;
                        
            dtpDate.Enabled = true;
            optCash.Enabled = true;
            optCredit.Enabled = true;

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



        private void EnableFormForAdd()
        {            
            EnableForm();
            ClearForm();
            
            optCredit.Checked = true;
        }


        private void EnableFormForEdit()
        {
            EnableForm();
        }


        public void GetSalesHistory(string code)
        {
            var sales = salesRepository.GetByCode(code);
            
            if (sales != null)
            {
                ViewSalesDetail(sales);
                LoadSalesItems(new Guid(txtID.Text));
            }
        }

        
        private void PopulateSalesItem(SalesItem salesItem)
        {
            var item = new ListViewItem(salesItem.ProductId.ToString());

            item.SubItems.Add(salesItem.Product.Name);
            item.SubItems.Add(salesItem.Product.Unit);
            item.SubItems.Add(salesItem.Price.ToString("N0").Replace(",", "."));
            item.SubItems.Add(salesItem.Qty.ToString("N0").Replace(",", "."));

            decimal total = salesItem.Qty * salesItem.Price;

            item.SubItems.Add(total.ToString("N0").Replace(",", "."));

            lvwSales.Items.Add(item);

        }


        private void LoadSalesItems(Guid id)
        {
            var salesItems = salesItemRepository.GetBySalesId(id);

            lvwSales.Items.Clear();

            decimal total = 0;

            foreach (var salesItem in salesItems)
            {
                total=total + (salesItem.Qty*salesItem.Price); 
                PopulateSalesItem(salesItem);
            }

            lblTotal.Text = total.ToString("N0").Replace(",", ".");
        }




        private void ViewSalesDetail(Sales sales)
        {
            txtID.Text = sales.ID.ToString();
            txtSalesId.Text = sales.ID.ToString();
            lblCode.Text = sales.Code;
            
            txtCustomerId.Text = sales.CustomerId.ToString();
            txtCustomerName.Text = sales.Customer.Name;
            txtCustomerAddress.Text = sales.Customer.Address;

            txtSalesmanId.Text = sales.SalesmanId.ToString();
            txtSalesmanName.Text = sales.Salesman.Name;

            dtpDate.Text = sales.Date.ToShortDateString();
            dtpDueDate.Text = sales.DueDate.ToShortDateString();

            txtTermOfPayment.Text = sales.TermOfPayment.ToString();

            if (sales.PaymentMethod == 1)
            {
                optCash.Checked = true;
            }
            else if (sales.PaymentMethod == 2)
            {
                optCredit.Checked = true;
            }


            txtNotes.Text = sales.Notes;

            if (sales.Status == true)
            {
                lblPaidStatus.Visible = true;
            }
            else
            {
                lblPaidStatus.Visible = false;
            }

        }



        private void GetLastSales()
        {
            var sales = salesRepository.GetLast(Store.ActiveMonth, Store.ActiveYear);
            if (sales != null)
            {                
                ViewSalesDetail(sales);
                LoadSalesItems(new Guid(txtID.Text));
            }
        }


        private void SalesUI_Load(object sender, EventArgs e)
        {                        
            formMode = FormMode.View;
            FillCode();
            
            GetLastSales();

            if (lvwSales.Items.Count == 0)
            {
                tsbBack.Enabled = false;
                tsbNext.Enabled = false;
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbHistory.Enabled = false;
            }
            
        }

      

        private void lstSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sales = salesRepository.GetByCode(lstSales.Text);
            if (sales != null)
            {
                ViewSalesDetail(sales);
                LoadSalesItems(new Guid(txtID.Text));
            }
        }

        private void tsbHistory_Click(object sender, EventArgs e)
        {
            var frmHistory = new SalesHistoryUI(this);
            frmHistory.ShowDialog();
        }


        private void ClearForm()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtCustomerAddress.Clear();

            txtSalesmanId.Clear();
            txtSalesmanName.Clear();

            dtpDate.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;
            optCredit.Checked = true;
            txtNotes.Clear();
            txtTermOfPayment.Clear();

            txtProductId.Clear();
            txtProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtQtyEnd.Clear();
            lvwSales.Items.Clear();

            lblPaidStatus.Text = "";
        }



      

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Penjualan" && u.IsAdd);

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
                    lblCode.Text = salesRepository.GenerateSalesCode(Store.ActiveMonth, Store.ActiveYear);
                    lblTotal.Text = "0";

                    this.Text = "Penjualan - Tambah";

                }
            }
        }


        private void tsbCancel_Click(object sender, EventArgs e)
        {
            //if (formMode==FormMode.Add) salesRepository.Delete(lblCode.Text);

            GetLastSales();
           
            DisableForm();
           
            formMode = FormMode.View;
            this.Text = "Penjualan";
        }



        private void SaveSales()
        {
            if (dtpDate.Value.Month != Store.ActiveMonth || dtpDate.Value.Year != Store.ActiveYear)
            {
                MessageBox.Show("Tanggal diluar periode aktif", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtCustomerName.Text=="")
            {
                MessageBox.Show("Customer harus dipilih", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowseCustomer.Focus();
            }
            else if (txtSalesmanName.Text=="")
            {
                MessageBox.Show("Salesman harus dipilih", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowseSalesman.Focus();
            }
            else if (dtpDate.Value > dtpDueDate.Value && optCredit.Checked)
            {
                MessageBox.Show("Tanggal jatuh tempo harus lebih besar dari tanggal transaksi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lvwSales.Items.Count == 0)
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else if (customerRepository.IsPlafonInsuficient(new Guid(txtCustomerId.Text)) && optCredit.Checked)
            //{
            //    MessageBox.Show("Plafon Piutang tidak mencukupi ", "Perhatian",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            else
            {
                var sales = new Sales();

                sales.Code = lblCode.Text;

                sales.CustomerId = new Guid(txtCustomerId.Text);
                sales.SalesmanId = new Guid(txtSalesmanId.Text);
                sales.Date = dtpDate.Value;
                sales.DueDate = dtpDueDate.Value;
                sales.TermOfPayment = int.Parse(txtTermOfPayment.Text.Replace(".", ""));

                if (optCash.Checked == true)
                {
                    sales.PaymentMethod = 1;
                    sales.Status = true;
                }
                else if (optCredit.Checked == true)
                {
                    sales.PaymentMethod = 2;
                    sales.Status = false;
                }

                sales.Notes = txtNotes.Text;
                sales.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));

                if (sales.GrandTotal > 0)
                {
                    string amountInWords = Store.GetAmounInWords(Convert.ToInt32(sales.GrandTotal));
                    string firstLetter = amountInWords.Substring(0, 2).Trim().ToUpper();
                    string theRest = amountInWords.Substring(2, amountInWords.Length - 2);
                    sales.AmountInWords = firstLetter + theRest + " rupiah";
                }
                else
                {
                    sales.AmountInWords = "Nol rupiah";

                }
 
                sales.CreatedBy = Store.ActiveUser;

                var salesItems = new List<SalesItem>();

                foreach (ListViewItem item in lvwSales.Items)
                {
                    string productId = item.SubItems[0].Text;
                    string price = item.SubItems[3].Text;
                    string qty = item.SubItems[4].Text;

                    SalesItem si = new SalesItem();

                    si.ProductId = new Guid(productId);
                    si.Qty = int.Parse(qty.Replace(".", ""));
                    si.Price = decimal.Parse(price.Replace(".", ""));

                    salesItems.Add(si);
                }
                
                sales.SalesItems = salesItems;


                if (formMode == FormMode.Add)
                {
                    salesRepository.Save(sales);
                    ShowSalesReport();
                    GetLastSales();
                }
                else if (formMode == FormMode.Edit)
                {
                    sales.ID = new Guid(txtID.Text);
                    sales.ModifiedBy = Store.ActiveUser;
                    //sales.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));

                    salesRepository.Update(sales);

                    ShowSalesReport();
                }

                //LoadSalesItems(int.Parse(txtID.Text));
               
                DisableForm();
                formMode = FormMode.View;
                FillCode();
                this.Text = "Penjualan";
            }

        }
        



        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveSales();
           
          
        }

        private void ShowSalesReport()
        {
            Store.ActiveReport = "Sales";
            
            var frmReportPrint = new ReportPrintUI(this);
            frmReportPrint.Show();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var frmProductList = new ProductListUI(this);
            frmProductList.ShowDialog();
        }

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
           
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


        private void SalesUI_Activated(object sender, EventArgs e)
        {
            txtQty.Focus();
        }

        private void ClearProductEntry()
        {
            txtProductId.Clear();
            txtProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtQtyEnd.Clear();

        }


        private bool IsProductExist(string productName)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwSales.Items)
            {
                if (productName==item.SubItems[1].Text)
                {
                    isExist = true;
                }
            }

            return isExist;
        }


        private decimal GetTotalSales()
        {
            decimal totalSales = 0;

            foreach (ListViewItem item in lvwSales.Items)
            {
                string price=item.SubItems[5].Text;
                totalSales = totalSales + decimal.Parse(price.Replace(".",""));

            }

            return totalSales;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            int qtyEnd = 0;
            if (btnAdd.Text == "Update")
            {
                int currentQty = lvwSales.FocusedItem.SubItems[4].Text == "" ? 0 : int.Parse(lvwSales.FocusedItem.SubItems[4].Text);
                qtyEnd = int.Parse(txtQtyEnd.Text) + currentQty;
            }

            if (btnAdd.Text == "Tambah" && int.Parse(txtQty.Text.Replace(".", "")) > int.Parse(txtQtyEnd.Text.Replace(".", "")))
            {
                MessageBox.Show("Stok tidak mencukupi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }
            
            if (btnAdd.Text == "Update" && int.Parse(txtQty.Text.Replace(".", "")) > qtyEnd)
            {
                MessageBox.Show("Stok tidak mencukupi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();

            }

            if (txtProduct.Text == "")
            {
                MessageBox.Show("Nama barang harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Focus();
            }
            //else if (txtPrice.Text == "" || int.Parse(txtPrice.Text.Replace(".", "")) == 0)
            //{
            //    MessageBox.Show("Harga harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtPrice.Focus();
            //}
            else if (txtQty.Text == "" || int.Parse(txtQty.Text.Replace(".", "")) == 0)
            {
                MessageBox.Show("Qty harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQty.Focus();
            }
            //else if (IsProductExist(txtProduct.Text) && btnAdd.Text=="Tambah")
            //{
            //    MessageBox.Show("Barang sudah ditambahkan, silahkan pilih yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btnAdd.Focus();
            //}
            
           
            else
            {
                if (btnAdd.Text == "Update")
                {
                    lvwSales.FocusedItem.Remove();
                    lvwSales.Enabled = true;

                    btnAdd.Text = "Tambah";
                    btnCancel.Visible = false;

                    

                }
                

                var item = new ListViewItem(txtProductId.Text.ToString());

                txtPrice.Text = txtPrice.Text == string.Empty ? "0" : txtPrice.Text;
                
                decimal price = decimal.Parse(txtPrice.Text.Replace(".", ""));
                int qty = int.Parse(txtQty.Text.Replace(".", ""));

                decimal total = price * qty;
                                
                item.SubItems.Add(txtProduct.Text);
                item.SubItems.Add(txtUnit.Text);
                item.SubItems.Add(price.ToString("N0").Replace(",", "."));
                item.SubItems.Add(qty.ToString("N0").Replace(",", "."));
                item.SubItems.Add(total.ToString("N0").Replace(",", "."));
                
                lvwSales.Items.Add(item);

                ClearProductEntry();
                
                lblTotal.Text = GetTotalSales().ToString("N0").Replace(",", ".");
                
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

        private void txtQy_KeyPress(object sender, KeyPressEventArgs e)
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
                && u.ObjectName == "Penjualan" && u.IsEdit);

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
                    Sales sales = salesRepository.GetById(new Guid(txtID.Text));

                    if (salesRepository.IsSalesUsedByPayment(new Guid(txtID.Text)))
                    {
                        MessageBox.Show("Tidak bisa ubah/hapus " + "\n\n" + "Dokumen : " + lblCode.Text + "\n\n" + "dipakai di Pelunasan Piutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //else if (salesRepository.IsSalesUsedByBillReceipt(new Guid(txtID.Text)))
                    //{
                    //    MessageBox.Show("Tidak bisa ubah " + "\n\n" + "Dokumen : " + lblCode.Text + "\n\n" + "dipakai di TTNT ", "Perhatian",
                    //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    else if (sales.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        formMode = FormMode.Edit;
                        this.Text = "Penjualan - Edit";

                        EnableFormForEdit();
                    }
                }
            }
        }

      
        private void lvwSales_DoubleClick(object sender, EventArgs e)
        {
            if (formMode != FormMode.View )
            {
                if (lvwSales.Items.Count > 0)
                {
                    btnAdd.Text = "Update";
                    btnCancel.Visible = true;

                    lvwSales.Enabled = false;

                    txtProductId.Text = lvwSales.FocusedItem.SubItems[0].Text;
                    txtProduct.Text = lvwSales.FocusedItem.SubItems[1].Text;
                    txtUnit.Text = lvwSales.FocusedItem.SubItems[2].Text;
                    txtPrice.Text = lvwSales.FocusedItem.SubItems[3].Text;
                    txtQty.Text = lvwSales.FocusedItem.SubItems[4].Text;

                    var productQty = productQtyRepository.GetByMonthAndYear(Store.ActiveMonth, Store.ActiveYear, new Guid(txtProductId.Text));
                    if (productQty != null)
                    {
                        txtQtyEnd.Text = productQty.QtyEnd.ToString();
                    }
                    else
                    {
                        txtQtyEnd.Text = "0";
                    }
                }
            }
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //lvwSales.FocusedItem.Remove();

            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            txtProductId.Clear();
            txtProduct.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            txtQtyEnd.Clear();

            lvwSales.Enabled = true;
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Penjualan" && u.IsDelete);

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
                    Sales sales = salesRepository.GetById(new Guid(txtID.Text));
                    if (sales.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (salesRepository.IsSalesUsedByPayment(new Guid(txtID.Text)))
                    {
                        MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Dokumen : " + lblCode.Text + "\n\n" + "dipakai di Pelunasan Piutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (salesRepository.IsSalesUsedByBillReceipt(new Guid(txtID.Text)))
                    {
                        MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Dokumen : " + lblCode.Text + "\n\n" + "dipakai di TTNT ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + lblCode.Text + "'", "Perhatian",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var sales1 = new Sales();
                            sales1.ID = new Guid(txtID.Text);
                            sales1.Notes = txtNotes.Text;

                            salesRepository.Delete(sales1);
                            GetLastSales();

                        }

                        if (lvwSales.Items.Count == 0)
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
            if (lstSales.SelectedIndex < lstSales.Items.Count - 1)
            {
                lstSales.SelectedIndex = lstSales.SelectedIndex + 1;
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
          
            if (lstSales.SelectedIndex > 0)
            {
                lstSales.SelectedIndex = lstSales.SelectedIndex - 1;
            }
        }

        private void txtQy_TextChanged(object sender, EventArgs e)
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

        private void lvwSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwSales.Items.Count > 0)
            {

                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwSales.FocusedItem.Remove();
                    }

                    lblTotal.Text = GetTotalSales().ToString("N0").Replace(",", ".");
                }
            }
        }

       

        private void txtQtyEnd_TextChanged_1(object sender, EventArgs e)
        {
            if (txtQtyEnd.Text != string.Empty)
            {
                string textBoxData = txtQtyEnd.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtQtyEnd.Text = StringBldr.ToString();
                txtQtyEnd.SelectionStart = txtQtyEnd.Text.Length;
            }
        }

        private void btnBrowseCustomer_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new CustomerListUI(this);
            frmCustomerList.SearchSetFocus();
            frmCustomerList.ShowDialog();
        }


        private void btnBrowseSalesman_Click(object sender, EventArgs e)
        {
            var frmSalesmanList = new SalesmanListUI(this);
            frmSalesmanList.ShowDialog();
        }

        private void optCredit_CheckedChanged(object sender, EventArgs e)
        {
            txtTermOfPayment_TextChanged(sender, e);
        }

        private void optCash_CheckedChanged(object sender, EventArgs e)
        {
            dtpDueDate.Enabled = false;
            dtpDueDate.Value = DateTime.Now;
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTermOfPayment_TextChanged(object sender, EventArgs e)
        {
            if (txtTermOfPayment.Text!="" && int.Parse(txtTermOfPayment.Text) > 0)
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
