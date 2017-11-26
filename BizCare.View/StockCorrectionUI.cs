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
    public partial class StockCorrectionUI : Form
    {
        private MainUI frmMain;
        private FormMode formMode;
        private FormFilter formFilter;

        private IStockCorrectionRepository stockCorrectionRepository;
        private IStockCorrectionItemRepository stockCorrectionItemRepository;
        private IUserAccessRepository userAccessRepository;

        public StockCorrectionUI()
        {
            InitializeComponent();
        }

         public StockCorrectionUI(MainUI frmMain)
        {
            this.frmMain = frmMain;

     
            stockCorrectionRepository = ServiceLocator.GetObject<IStockCorrectionRepository>();
            stockCorrectionItemRepository = ServiceLocator.GetObject<IStockCorrectionItemRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
            InitializeComponent();
        }

         public string StockCorrectionCode
         {
             get { return lblCode.Text; }
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

             txtProduct.Enabled = false;
             txtProduct.BackColor = Color.White;

             txtQtyPlus.Enabled = true;
             txtQtyPlus.BackColor = Color.White;

             txtQtyMinus.Enabled = true;
             txtQtyMinus.BackColor = Color.White;

             txtValuePlus.Enabled = true;
             txtValuePlus.BackColor = Color.White;

             txtValueMinus.Enabled = true;
             txtValueMinus.BackColor = Color.White;

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

             txtProduct.Enabled = false;
             txtProduct.BackColor = System.Drawing.SystemColors.ButtonFace;

             txtQtyPlus.Enabled = false;
             txtQtyPlus.BackColor = System.Drawing.SystemColors.ButtonFace;

             txtQtyMinus.Enabled = false;
             txtQtyMinus.BackColor = System.Drawing.SystemColors.ButtonFace;

             txtValuePlus.Enabled = false;
             txtValuePlus.BackColor = System.Drawing.SystemColors.ButtonFace;

             txtValueMinus.Enabled = false;
             txtValueMinus.BackColor = System.Drawing.SystemColors.ButtonFace;

             btnBrowse.Enabled = false;
             btnAdd.Enabled = false;

             txtProduct.Clear();
             txtQtyPlus.Clear();
             txtQtyMinus.Clear();
              txtValuePlus.Clear();
              txtValueMinus.Clear();

             lvwStockCorrection.Enabled = true;
             btnAdd.Text = "Tambah";
             btnCancel.Visible = false;

             if (lvwStockCorrection.Items.Count == 0)
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

             txtProduct.Clear();
             txtQtyPlus.Clear();
             txtQtyMinus.Clear();
              txtValuePlus.Clear();
              txtValueMinus.Clear();

             lvwStockCorrection.Items.Clear();
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

         private void ViewStockCorrectionDetail(StockCorrection stockCorrection)
         {
             txtID.Text = stockCorrection.ID.ToString();
             txtStockCorrectionId.Text = stockCorrection.ID.ToString();
             lblCode.Text = stockCorrection.Code;
             
             dtpDate.Text = stockCorrection.Date.ToShortDateString();

             txtNotes.Text = stockCorrection.Notes;

         }

         private void PopulateStockCorrectionItem(StockCorrectionItem stockCorrectionItem)
         {
             var item = new ListViewItem(stockCorrectionItem.ProductId.ToString());

             item.SubItems.Add(stockCorrectionItem.Product.Name);
             item.SubItems.Add(stockCorrectionItem.Product.Unit);
             item.SubItems.Add(stockCorrectionItem.QtyPlus.ToString("N0").Replace(",", "."));
             item.SubItems.Add(stockCorrectionItem.QtyMinus.ToString("N0").Replace(",", "."));
             item.SubItems.Add(stockCorrectionItem.ValuePlus.ToString("N0").Replace(",", "."));
             item.SubItems.Add(stockCorrectionItem.ValueMinus.ToString("N0").Replace(",", "."));

             lvwStockCorrection.Items.Add(item);

         }

         private void LoadStockCorrectionItems(Guid id)
         {
             var stockCorrectionItems = stockCorrectionItemRepository.GetByStockCorrectionId(id);

             lvwStockCorrection.Items.Clear();

             foreach (var stockCorrectionItem in stockCorrectionItems)
             {
                 PopulateStockCorrectionItem(stockCorrectionItem);
             }

             
         }

         public void GetStockCorrectionHistory(string code)
         {
             var stockCorrection = stockCorrectionRepository.GetByCode(code);

             if (stockCorrection != null)
             {
                 ViewStockCorrectionDetail(stockCorrection);
                 LoadStockCorrectionItems(new Guid(txtID.Text));
             }
         }


         private void GetLastStockCorrection()
         {
             var stockCorrection = stockCorrectionRepository.GetLast(Store.ActiveMonth, Store.ActiveYear);
             if (stockCorrection != null)
             {
                 ViewStockCorrectionDetail(stockCorrection);
                 LoadStockCorrectionItems(new Guid(txtID.Text));
             }
         }

         private void FillCode()
         {
             var stockCorrection = stockCorrectionRepository.GetAllCode(Store.ActiveMonth, Store.ActiveYear);

             lstStockCorrection.Items.Clear();

             foreach (var s in stockCorrection)
             {
                 lstStockCorrection.Items.Add(s);
             }

             if (lstStockCorrection.Items.Count > 0) lstStockCorrection.SelectedIndex = 0;

         }

        private void StockCorrectionUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.SupplierName;

            FillCode();
            GetLastStockCorrection();

            if (lvwStockCorrection.Items.Count == 0)
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
            var frmHistory = new StockCorrectionHistoryUI(this);
            frmHistory.ShowDialog();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Koreksi Stok" && u.IsAdd);

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
                    lblCode.Text = stockCorrectionRepository.GenerateCorrectionCode(Store.ActiveMonth, Store.ActiveYear);

                    this.Text = "Koreksi Stok - Tambah";

                }
            }
        }


        public void PutProductName(string productId, string productName, string unit,string price)
        {
            txtProductId.Text = productId;
            txtProduct.Text = productName;
            txtUnit.Text = unit;

            txtQtyPlus.Enabled = true;
            txtQtyMinus.Enabled = true;
            txtValuePlus.Enabled = true;
            txtValueMinus.Enabled = true;

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var frmProductList = new ProductListUI(this);
            frmProductList.ShowDialog();
        }

        private bool IsProductExist(string productName)
        {
            bool isExist = false;

            foreach (ListViewItem item in lvwStockCorrection.Items)
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
            txtQtyPlus.Clear();
            txtQtyMinus.Clear();
            txtValuePlus.Clear();
            txtValueMinus.Clear();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text == "")
            {
                MessageBox.Show("Nama Produk harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Focus();
            }
            else if (txtQtyPlus.Text == "" && txtQtyMinus.Text == "" && txtValuePlus.Text == "" && txtValuePlus.Text == "")
            {
                MessageBox.Show("Qty atau Nilai koreksi harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQtyPlus.Focus();
            }
            else if (IsProductExist(txtProduct.Text) && btnAdd.Text == "Tambah")
            {
                MessageBox.Show("Produk sudah ditambahkan, silahkan pilih yang lain", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnAdd.Focus();
            }

            else
            {
                if (btnAdd.Text == "Update")
                {
                    lvwStockCorrection.FocusedItem.Remove();
                    lvwStockCorrection.Enabled = true;

                    btnAdd.Text = "Tambah";
                    btnCancel.Visible = false;
                }


                var item = new ListViewItem(txtProductId.Text.ToString());

                txtQtyPlus.Text = txtQtyPlus.Text == string.Empty ? "0" : txtQtyPlus.Text;
                txtQtyMinus.Text = txtQtyMinus.Text == string.Empty ? "0" : txtQtyMinus.Text;
                txtValuePlus.Text = txtValuePlus.Text == string.Empty ? "0" : txtValuePlus.Text;
                txtValueMinus.Text = txtValueMinus.Text == string.Empty ? "0" : txtValueMinus.Text; 

                int qtyPlus = int.Parse(txtQtyPlus.Text.Replace(".", ""));
                int qtyMinus = int.Parse(txtQtyMinus.Text.Replace(".", ""));
                decimal valuePlus = int.Parse(txtValuePlus.Text.Replace(".", ""));
                decimal valueMinus = int.Parse(txtValueMinus.Text.Replace(".", ""));

                item.SubItems.Add(txtProduct.Text);
                item.SubItems.Add(txtUnit.Text);
                item.SubItems.Add(qtyPlus.ToString("N0").Replace(",", "."));
                item.SubItems.Add(qtyMinus.ToString("N0").Replace(",", "."));
                item.SubItems.Add(valuePlus.ToString("N0").Replace(",", "."));
                item.SubItems.Add(valueMinus.ToString("N0").Replace(",", "."));

                lvwStockCorrection.Items.Add(item);

                ClearProductEntry();

            }
        }

        private void lvwStockCorrection_DoubleClick(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
            {
                if (lvwStockCorrection.Items.Count > 0)
                {
                    btnAdd.Text = "Update";
                    btnCancel.Visible = true;

                    lvwStockCorrection.Enabled = false;

                    txtProductId.Text = lvwStockCorrection.FocusedItem.SubItems[0].Text;
                    txtProduct.Text = lvwStockCorrection.FocusedItem.SubItems[1].Text;
                    txtUnit.Text = lvwStockCorrection.FocusedItem.SubItems[2].Text;
                    txtQtyPlus.Text = lvwStockCorrection.FocusedItem.SubItems[3].Text;
                    txtQtyMinus.Text = lvwStockCorrection.FocusedItem.SubItems[4].Text;
                    txtValuePlus.Text = lvwStockCorrection.FocusedItem.SubItems[5].Text;
                    txtValueMinus.Text = lvwStockCorrection.FocusedItem.SubItems[6].Text;


                }

            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (formMode == FormMode.Add) stockCorrectionRepository.Delete(lblCode.Text);

            GetLastStockCorrection();

            DisableForm();

            formMode = FormMode.View;
            this.Text = "Koreksi Stok";
        }

        private void txtQtyPlus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtQtyMinus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValuePlus_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValueMinus_KeyPress(object sender, KeyPressEventArgs e)
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
                && u.ObjectName == "Koreksi Stok" && u.IsEdit);

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
                    StockCorrection stockCorrection = stockCorrectionRepository.GetById(new Guid(txtID.Text));

                    if (stockCorrection.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        formMode = FormMode.Edit;
                        this.Text = "Koreksi Stok - Edit";

                        EnableFormForEdit();
                    }
                }
            }
        }

        private void ShowStockCorrectionReport()
        {
            Store.ActiveReport = "StockCorrection";

            var frmReportPrint = new ReportPrintUI(this);
            frmReportPrint.Show();

        }

        private void SaveStockCorrection()
        {
            if (dtpDate.Value.Month != Store.ActiveMonth || dtpDate.Value.Year != Store.ActiveYear)
            {
                MessageBox.Show("Tanggal diluar periode aktif", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            
            else if (lvwStockCorrection.Items.Count == 0)
            {
                MessageBox.Show("Detail tidak boleh kosong", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var stockCorrection = new StockCorrection();

                stockCorrection.Code = lblCode.Text;
                stockCorrection.Date = dtpDate.Value;
                stockCorrection.Notes = txtNotes.Text;
                stockCorrection.CreatedBy = string.Empty;

                var stockCorrectionItems = new List<StockCorrectionItem>();

                foreach (ListViewItem item in lvwStockCorrection.Items)
                {
                    string productId = item.SubItems[0].Text;
                    string qtyPlus = item.SubItems[3].Text;
                    string qtyMinus = item.SubItems[4].Text;
                    string valuePlus = item.SubItems[5].Text;
                    string valueMinus = item.SubItems[6].Text;

                    StockCorrectionItem si = new StockCorrectionItem();

                    si.ProductId = new Guid(productId);
                    si.QtyPlus = int.Parse(qtyPlus.Replace(".", ""));
                    si.QtyMinus = int.Parse(qtyMinus.Replace(".", ""));
                    si.ValuePlus = decimal.Parse(valuePlus.Replace(".", ""));
                    si.ValueMinus = decimal.Parse(valueMinus.Replace(".", ""));
                    si.Notes = "";

                    stockCorrectionItems.Add(si);
                }


                stockCorrection.StockCorrectionItems = stockCorrectionItems;


                if (formMode == FormMode.Add)
                {
                    stockCorrectionRepository.Save(stockCorrection);
                    ShowStockCorrectionReport();
                    GetLastStockCorrection();
                }
                else if (formMode == FormMode.Edit)
                {
                    stockCorrection.ID = new Guid(txtID.Text);
                    stockCorrection.ModifiedBy = Store.ActiveUser;
                    stockCorrection.Notes = txtNotes.Text;

                    stockCorrectionRepository.Update(stockCorrection);
                    ShowStockCorrectionReport();
                }

                LoadStockCorrectionItems(new Guid(txtID.Text));
                DisableForm();
                formMode = FormMode.View;

                FillCode();
                this.Text = "Koreksi Stok";
            }

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveStockCorrection();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Koreksi Stok" && u.IsDelete);

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
                    StockCorrection stockCorrection = stockCorrectionRepository.GetById(new Guid(txtID.Text));
                    if (stockCorrection.Notes.Contains("DIBATALKAN"))
                    {
                        MessageBox.Show("Sudah pernah di hapus ", "Perhatian",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        if (MessageBox.Show("Anda yakin ingin menghapus '" + lblCode.Text + "'", "Perhatian",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var stockCorrection1 = new StockCorrection();
                            stockCorrection1.ID = new Guid(txtID.Text);
                            stockCorrection1.Notes = txtNotes.Text;

                            stockCorrectionRepository.Delete(stockCorrection1);
                            GetLastStockCorrection();

                        }

                        if (lvwStockCorrection.Items.Count == 0)
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
            if (lstStockCorrection.SelectedIndex < lstStockCorrection.Items.Count - 1)
            {
                lstStockCorrection.SelectedIndex = lstStockCorrection.SelectedIndex + 1;
            }
            
        }

        private void tsbNext_Click(object sender, EventArgs e)
        {
            if (lstStockCorrection.SelectedIndex > 0)
            {
                lstStockCorrection.SelectedIndex = lstStockCorrection.SelectedIndex - 1;
            }
        }

        private void txtQtyPlus_TextChanged(object sender, EventArgs e)
        {
            if (txtQtyPlus.Text != string.Empty)
            {
                string textBoxData = txtQtyPlus.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtQtyPlus.Text = StringBldr.ToString();
                txtQtyPlus.SelectionStart = txtQtyPlus.Text.Length;
            }
        }

        private void txtQtyMinus_TextChanged(object sender, EventArgs e)
        {
            if (txtQtyMinus.Text != string.Empty)
            {
                string textBoxData = txtQtyMinus.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtQtyMinus.Text = StringBldr.ToString();
                txtQtyMinus.SelectionStart = txtQtyMinus.Text.Length;
            }
        }

        private void txtValuePlus_TextChanged(object sender, EventArgs e)
        {
            if (txtValuePlus.Text != string.Empty)
            {
                string textBoxData = txtValuePlus.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtValuePlus.Text = StringBldr.ToString();
                txtValuePlus.SelectionStart = txtValuePlus.Text.Length;
            }
        }

        private void txtValueMinus_TextChanged(object sender, EventArgs e)
        {
            if (txtValueMinus.Text != string.Empty)
            {
                string textBoxData = txtValueMinus.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtValueMinus.Text = StringBldr.ToString();
                txtValueMinus.SelectionStart = txtValueMinus.Text.Length;
            }
        }

        private void lvwStockCorrection_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvwStockCorrection.Items.Count > 0)
            {
                if (formMode != FormMode.View)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        lvwStockCorrection.FocusedItem.Remove();
                    }
                }
            }
        }


        private void lstStockCorrection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var stockCorrection = stockCorrectionRepository.GetByCode(lstStockCorrection.Text);
            if (stockCorrection != null)
            {
                ViewStockCorrectionDetail(stockCorrection);
                LoadStockCorrectionItems(new Guid(txtID.Text));
            }
        }








    }
}
