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
    public partial class PurchaseUI : Form
    {

        private MainUI frmMain;
        private FormMode formMode;
        
        private IPurchaseRepository purchaseRepository;
        private IPurchaseItemRepository purchaseItemRepository;
        private ISupplierRepository supplierRepository;
        private IDebtBalanceRepository debtBalanceRepository;
        private IUserAccessRepository userAccessRepository;
     
        public PurchaseUI()
        {
            InitializeComponent();
        }

        public PurchaseUI(MainUI frmMain)
        {
            this.frmMain = frmMain;

     
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();
            purchaseItemRepository = ServiceLocator.GetObject<IPurchaseItemRepository>();
            supplierRepository = ServiceLocator.GetObject<ISupplierRepository>();
            debtBalanceRepository = ServiceLocator.GetObject<IDebtBalanceRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();

            InitializeComponent();
        }

        public string PurchaseCode
        {
            get { return lblCode.Text; }
        }
        
        public void PutSupplier(string id, string name, int termOfPayment)
        {
            txtSupplierId.Text = id;
            txtSupplierName.Text = name;
            txtTermOfPayment.Text = termOfPayment.ToString();
        }


         private void EnableForm()
         {
             txtSupplierName.BackColor = Color.White;
             btnBrowseSupplier.Enabled = true;
             
             dtpDate.Enabled = true;
             //dtpDueDate.Enabled = true;
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

         private void DisableForm()
         {
             txtSupplierName.Enabled = false;
             txtSupplierName.BackColor = System.Drawing.SystemColors.ButtonFace;
             btnBrowseSupplier.Enabled = false;
             
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

             txtProduct.Clear();
             txtPrice.Clear();
             txtQty.Clear();

             lvwPurchase.Enabled = true;
             btnAdd.Text = "Tambah";
             btnCancel.Visible = false;

             if (lvwPurchase.Items.Count == 0)
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
             txtSupplierId.Clear();
             txtSupplierName.Clear();
             dtpDate.Value = DateTime.Now;
             dtpDueDate.Value = DateTime.Now;
             optCredit.Checked = true;
             txtNotes.Clear();
             txtTermOfPayment.Clear();

             txtProduct.Clear();
             txtPrice.Clear();
             txtQty.Clear();

             lvwPurchase.Items.Clear();
             lblPaidStatus.Text = "";
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

         private void ViewPurchaseDetail(Purchase purchase)
         {
             txtID.Text = purchase.ID.ToString();
             txtPurchaseId.Text = purchase.ID.ToString();
             lblCode.Text = purchase.Code;

             txtSupplierId.Text = purchase.SupplierId.ToString();
             txtSupplierName.Text = purchase.Supplier.Name;


             dtpDate.Text = purchase.Date.ToShortDateString();
             dtpDueDate.Text = purchase.DueDate.ToShortDateString();
             txtPrintCounter.Text = purchase.PrintCounter.ToString();
             txtTermOfPayment.Text = purchase.TermOfPayment.ToString();
           
             if (purchase.PaymentMethod == 1)
             {
                 optCash.Checked = true;
             }
             else if (purchase.PaymentMethod == 2)
             {
                 optCredit.Checked = true;
             }


             txtNotes.Text = purchase.Notes;

             if (purchase.Status == true)
             {
                 lblPaidStatus.Visible = true;
             }
             else
             {
                 lblPaidStatus.Visible = false;
             }

         }

         private void PopulatePurchaseItem(PurchaseItem purchaseItem)
         {
             var item = new ListViewItem(purchaseItem.ProductId.ToString());

             item.SubItems.Add(purchaseItem.Product.Name);
             item.SubItems.Add(purchaseItem.Product.Unit);
             item.SubItems.Add(purchaseItem.Price.ToString("N0").Replace(",", "."));
             item.SubItems.Add(purchaseItem.Qty.ToString("N0").Replace(",", "."));

             decimal total = purchaseItem.Qty * purchaseItem.Price;

             item.SubItems.Add(total.ToString("N0").Replace(",", "."));

             lvwPurchase.Items.Add(item);

         }


         private void LoadPurchaseItems(Guid id)
         {
             var purchaseItems = purchaseItemRepository.GetByPurchaseId(id);

             lvwPurchase.Items.Clear();

             decimal total = 0;

             foreach (var purchaseItem in purchaseItems)
             {
                 total = total + (purchaseItem.Qty * purchaseItem.Price);
                 PopulatePurchaseItem(purchaseItem);
             }

             lblTotal.Text = total.ToString("N0").Replace(",", ".");
         }


         public void GetPurchaseHistory(string code)
         {
             var purchase = purchaseRepository.GetByCode(code);

             if (purchase != null)
             {
                 ViewPurchaseDetail(purchase);
                 LoadPurchaseItems(new Guid(txtID.Text));
             }
         }

        

         private void GetLastPurchase()
         {
             var purchase = purchaseRepository.GetLast(Store.ActiveMonth, Store.ActiveYear);
             if (purchase != null)
             {
                 ViewPurchaseDetail(purchase);
                 LoadPurchaseItems(new Guid(txtID.Text));
             }
         }

        private void PurchaseUI_Load(object sender, EventArgs e)
        {

            formMode = FormMode.View;
         
            FillCode();
            GetLastPurchase();

            if (lvwPurchase.Items.Count == 0)
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
            var frmHistory = new PurchaseHistoryUI(this);
            frmHistory.ShowDialog();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pembelian" && u.IsAdd);

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

                    lblCode.Text = purchaseRepository.GeneratePurchaseCode(Store.ActiveMonth, Store.ActiveYear);
                    lblTotal.Text = "0";

                    this.Text = "Pembelian - Tambah";

                }
            }
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var frmProductList = new ProductListUI(this);
            frmProductList.ShowDialog();
        }

        private bool IsProductExist(string productName)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwPurchase.Items)
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
            txtProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();

        }

        private decimal GetTotalPurchase()
        {
            decimal totalPurchase = 0;

            foreach (ListViewItem item in lvwPurchase.Items)
            {
                string price = item.SubItems[5].Text;
                totalPurchase = totalPurchase + decimal.Parse(price.Replace(".", ""));

            }

            return totalPurchase;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
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
            //else if (IsProductExist(txtProduct.Text) && btnAdd.Text == "Tambah")
            //{
            //    MessageBox.Show("Barang sudah ditambahkan, silahkan pilih yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    btnAdd.Focus();
            //}

            else
            {
                if (btnAdd.Text == "Update")
                {
                    lvwPurchase.FocusedItem.Remove();
                    lvwPurchase.Enabled = true;

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

                lvwPurchase.Items.Add(item);

                ClearProductEntry();

                lblTotal.Text = GetTotalPurchase().ToString("N0").Replace(",", ".");

            }
        }

        private void lvwPurchase_DoubleClick(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
            {
                if (lvwPurchase.Items.Count > 0)
                {
                    btnAdd.Text = "Update";
                    btnCancel.Visible = true;

                    lvwPurchase.Enabled = false;

                    txtProductId.Text = lvwPurchase.FocusedItem.SubItems[0].Text;
                    txtProduct.Text = lvwPurchase.FocusedItem.SubItems[1].Text;
                    txtUnit.Text = lvwPurchase.FocusedItem.SubItems[2].Text;
                    txtPrice.Text = lvwPurchase.FocusedItem.SubItems[3].Text;
                    txtQty.Text = lvwPurchase.FocusedItem.SubItems[4].Text;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Tambah";
            btnCancel.Visible = false;

            txtProduct.Clear();
            txtQty.Clear();
            txtPrice.Clear();

            lvwPurchase.Enabled = true;
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

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pembelian" && u.IsEdit);

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
                    Purchase purchase = purchaseRepository.GetById(new Guid(txtID.Text));
                    if (purchaseRepository.IsPurchaseUsedByPayment(new Guid(txtID.Text)))
                    {
                        MessageBox.Show("Tidak bisa ubah/hapus " + "\n\n" + "Dokumen : " + lblCode.Text + "\n\n" + "dipakai di Pembayaran Hutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        if (purchase.Notes.Contains("DIBATALKAN"))
                        {
                            MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {

                            formMode = FormMode.Edit;
                            this.Text = "Pembelian - Edit";

                            EnableFormForEdit();
                        }
                }
            }
        }


        private void FillCode()
        {
            var purchase = purchaseRepository.GetAllCode(Store.ActiveMonth, Store.ActiveYear);

            lstPurchase.Items.Clear();

            foreach (var s in purchase)
            {
                lstPurchase.Items.Add(s);
            }

            if (lstPurchase.Items.Count > 0) lstPurchase.SelectedIndex = 0;

        }


        private void ShowPurchaseReport()
        {
            Store.ActiveReport = "Purchase";

            var frmReportPrint = new ReportPrintUI(this);
            frmReportPrint.Show();

        }

        private void SavePurchase()
        {
            if (dtpDate.Value.Month != Store.ActiveMonth || dtpDate.Value.Year != Store.ActiveYear)
            {
                MessageBox.Show("Tanggal diluar periode aktif", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtSupplierName.Text=="")
            {
                MessageBox.Show("Supplier harus dipilih", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowseSupplier.Focus();
            }
            else if (dtpDate.Value > dtpDueDate.Value && optCredit.Checked)
            {
                MessageBox.Show("Tanggal jatuh tempo harus lebih besar dari tanggal transaksi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (lvwPurchase.Items.Count == 0)
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else if (supplierRepository.IsPlafonInsuficient(new Guid(txtSupplierId.Text)) && optCredit.Checked )
            //{
            //    MessageBox.Show("Plafon Hutang tidak mencukupi ", "Perhatian",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            else
            {
                var purchase = new Purchase();

                purchase.Code = lblCode.Text;
                purchase.SupplierId = new Guid(txtSupplierId.Text);
                purchase.Date = dtpDate.Value;
                purchase.DueDate = dtpDueDate.Value;
                purchase.TermOfPayment = int.Parse(txtTermOfPayment.Text);

                if (optCash.Checked == true)
                {
                    purchase.PaymentMethod = 1;
                    purchase.Status = true;
                }
                else if (optCredit.Checked == true)
                {
                    purchase.PaymentMethod = 2;
                    purchase.Status = false;
                }

                purchase.Notes = txtNotes.Text;
                purchase.GrandTotal = decimal.Parse(lblTotal.Text.Replace(".", ""));
                purchase.CreatedBy = Store.ActiveUser;

                if (purchase.GrandTotal > 0)
                {
                    string amountInWords = Store.GetAmounInWords(Convert.ToInt32(purchase.GrandTotal));
                    string firstLetter = amountInWords.Substring(0, 2).Trim().ToUpper();
                    string theRest = amountInWords.Substring(2, amountInWords.Length - 2);

                    purchase.AmountInWords = firstLetter + theRest + " rupiah";

                }
                else
                {
                    purchase.AmountInWords = "Nol rupiah";
                
                }

                //purchase.PrintCounter = txtPrintCounter.Text==""?0:int.Parse(txtPrintCounter.Text);

                var purchaseItems = new List<PurchaseItem>();

                foreach (ListViewItem item in lvwPurchase.Items)
                {
                    string productId = item.SubItems[0].Text;
                    string price = item.SubItems[3].Text;
                    string qty = item.SubItems[4].Text;

                    PurchaseItem si = new PurchaseItem();

                    si.ProductId = new Guid(productId);
                    si.Qty = int.Parse(qty.Replace(".", ""));
                    si.Price = decimal.Parse(price.Replace(".", ""));

                    purchaseItems.Add(si);
                }


                purchase.PurchaseItems = purchaseItems;


                if (formMode == FormMode.Add)
                {
                    purchaseRepository.Save(purchase);
                    ShowPurchaseReport();
                    GetLastPurchase();
                }
                else if (formMode == FormMode.Edit)
                {
                    purchase.ID = new Guid(txtID.Text);
                    purchase.ModifiedBy = Store.ActiveUser;
                  
                    purchaseRepository.Update(purchase);

                    ShowPurchaseReport();
                }

                //LoadPurchaseItems(int.Parse(txtID.Text));
                DisableForm();
                formMode = FormMode.View;

                FillCode();
                this.Text = "Pembelian";
            }

        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
            SavePurchase();
            
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (formMode == FormMode.Add) purchaseRepository.Delete(lblCode.Text);

            GetLastPurchase();

            DisableForm();

            formMode = FormMode.View;
            this.Text = "Pembelian";
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pembelian" && u.IsDelete);

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
                    Purchase purchase = purchaseRepository.GetById(new Guid(txtID.Text));
                    if (purchase.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (purchaseRepository.IsPurchaseUsedByPayment(new Guid(txtID.Text)))
                    {
                        MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Dokumen : " + lblCode.Text + "\n\n" + "dipakai di Pembayaran Hutang ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + lblCode.Text + "'", "Perhatian",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var purchase1 = new Purchase();
                            purchase1.ID = new Guid(txtID.Text);
                            purchase1.Notes = txtNotes.Text;

                            purchaseRepository.Delete(purchase1);
                            GetLastPurchase();

                        }

                        if (lvwPurchase.Items.Count == 0)
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
            if (lstPurchase.SelectedIndex < lstPurchase.Items.Count - 1)
            {
                lstPurchase.SelectedIndex = lstPurchase.SelectedIndex + 1;
            }
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
           
            if (lstPurchase.SelectedIndex > 0)
            {
                lstPurchase.SelectedIndex = lstPurchase.SelectedIndex - 1;
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

        private void lvwPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwPurchase.Items.Count > 0)
            {
                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwPurchase.FocusedItem.Remove();
                    }

                    lblTotal.Text = GetTotalPurchase().ToString("N0").Replace(",", ".");
                }
            }
        }

        private void lstPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            var purchase = purchaseRepository.GetByCode(lstPurchase.Text);
            if (purchase != null)
            {
                ViewPurchaseDetail(purchase);
                LoadPurchaseItems(new Guid(txtID.Text));
            }
        }

        private void btnBrowseSupplier_Click(object sender, EventArgs e)
        {
            var frmSupplierList = new SupplierListUI(this);
            frmSupplierList.ShowDialog();
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
