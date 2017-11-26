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
    public partial class ProductUI : Form
    {
        private MainUI frmMain;
        private FormMode formMode;
        
        private IProductRepository productRepository;
        private IProductQtyRepository productQtyRepository;
        private ISupplierRepository supplierRepository;
        private ICategoryRepository categoryRepository;
        private IUserAccessRepository userAccessRepository;
        
        public ProductUI()
        {
            
            InitializeComponent();
        }
        

        public void UpdateProductQty(string id,string year,string month, 
            string qtyBegin, string valueBegin, 
            string qtyIn, string purchasePrice,
            string qtyAvailable, string valueAverage, string valueAvailable,
            string qtyOut, string salesPrice,           
            string qtyEnd, string valueEnd, 
            string qtyPlusCorrection, string qtyMinusCorrection,
            string valuePlusCorrection, string valueMinusCorrection )
        {
            lvwProductQty.FocusedItem.Remove();

            var item = new ListViewItem(id);

            item.SubItems.Add(year);
            item.SubItems.Add(month);
            item.SubItems.Add(qtyBegin.Replace(",", "."));
            item.SubItems.Add(valueBegin.Replace(",", "."));
            item.SubItems.Add(qtyIn.Replace(",", "."));
            item.SubItems.Add(purchasePrice.Replace(",", "."));
            item.SubItems.Add(qtyAvailable.Replace(",", "."));
            item.SubItems.Add(valueAverage.Replace(",", "."));
            item.SubItems.Add(valueAvailable.Replace(",", "."));
            item.SubItems.Add(qtyOut.Replace(",", "."));
            item.SubItems.Add(salesPrice.Replace(",", "."));
            item.SubItems.Add(qtyEnd.Replace(",", "."));
            item.SubItems.Add(valueEnd.Replace(",", "."));
            item.SubItems.Add(qtyPlusCorrection.Replace(",", "."));
            item.SubItems.Add(qtyMinusCorrection.Replace(",", "."));
            item.SubItems.Add(valuePlusCorrection.Replace(",", "."));
            item.SubItems.Add(valueMinusCorrection.Replace(",", "."));
            
                   
            lvwProductQty.Items.Add(item);
       }

        public void UpdateProductQty2(string id, string year, string month,
            string qtyBegin, string valueBegin,
            string qtyIn, string purchasePrice,
            string qtyAvailable, string valueAverage, string valueAvailable,
            string qtyOut, string salesPrice,
            string qtyEnd, string valueEnd,
            string qtyPlusCorrection, string qtyMinusCorrection,
            string valuePlusCorrection, string valueMinusCorrection)
        {
            lvwProductQty2.FocusedItem.Remove();

            var item = new ListViewItem(id);

            item.SubItems.Add(year);
            item.SubItems.Add(month);
            item.SubItems.Add(qtyBegin.Replace(",", "."));
            item.SubItems.Add(valueBegin.Replace(",", "."));
            item.SubItems.Add(qtyIn.Replace(",", "."));
            item.SubItems.Add(purchasePrice.Replace(",", "."));
            item.SubItems.Add(qtyAvailable.Replace(",", "."));
            item.SubItems.Add(valueAverage.Replace(",", "."));
            item.SubItems.Add(valueAvailable.Replace(",", "."));
            item.SubItems.Add(qtyOut.Replace(",", "."));
            item.SubItems.Add(salesPrice.Replace(",", "."));
            item.SubItems.Add(qtyEnd.Replace(",", "."));
            item.SubItems.Add(valueEnd.Replace(",", "."));
            item.SubItems.Add(qtyPlusCorrection.Replace(",", "."));
            item.SubItems.Add(qtyMinusCorrection.Replace(",", "."));
            item.SubItems.Add(valuePlusCorrection.Replace(",", "."));
            item.SubItems.Add(valueMinusCorrection.Replace(",", "."));


            lvwProductQty2.Items.Add(item);
        }

        public string ID
        {
            get { return lvwProductQty.FocusedItem.SubItems[0].Text; }
        }


        public string ActiveMonth
        {
            get
            {
                return lvwProductQty.FocusedItem.SubItems[2].Text;
            }
        }


        public string ActiveYear
        {
            get
            {
                return lvwProductQty.FocusedItem.SubItems[1].Text;
            }
        }


        public string QtyBegin
        {
            get { return lvwProductQty.FocusedItem.SubItems[3].Text; } 
        }

        public string ValueBegin
        {
            get { return lvwProductQty.FocusedItem.SubItems[4].Text; }
        }

        public string QtyIn
        {
            get { return lvwProductQty.FocusedItem.SubItems[5].Text; }
        }

        public string PurchasePrice
        {
            get { return lvwProductQty.FocusedItem.SubItems[6].Text; } 
        }

        public string QtyAvailable
        {
            get { return lvwProductQty.FocusedItem.SubItems[7].Text; }
        }

        public string ValueAverage
        {
            get { return lvwProductQty.FocusedItem.SubItems[8].Text; }
        }

        public string ValueAvailable
        {
            get { return lvwProductQty.FocusedItem.SubItems[9].Text; }
        }

        public string QtyOut
        {
            get { return lvwProductQty.FocusedItem.SubItems[10].Text; }
        }


        public string SalesPrice
        {
            get { return lvwProductQty.FocusedItem.SubItems[11].Text; }
        }

      

        public string QtyEnd
        {
            get { return lvwProductQty.FocusedItem.SubItems[12].Text; }
        }

        public string ValueEnd
        {
            get { return lvwProductQty.FocusedItem.SubItems[13].Text; }
        }

  

        public string QtyPlusCorrection
        {
            get { return lvwProductQty.FocusedItem.SubItems[14].Text; }
        }

        public string QtyMinusCorrection
        {
            get { return lvwProductQty.FocusedItem.SubItems[15].Text; }
        }


        public string ValuePlusCorrection
        {
            get { return lvwProductQty.FocusedItem.SubItems[16].Text; }
        }

        public string ValueMinusCorrection
        {
            get { return lvwProductQty.FocusedItem.SubItems[17].Text; }
        }





        public string ID2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[0].Text; }
        }


        public string ActiveMonth2
        {
            get
            {
                return lvwProductQty2.FocusedItem.SubItems[2].Text;
            }
        }


        public string ActiveYear2
        {
            get
            {
                return lvwProductQty2.FocusedItem.SubItems[1].Text;
            }
        }


        public string QtyBegin2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[3].Text; }
        }

        public string ValueBegin2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[4].Text; }
        }

        public string QtyIn2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[5].Text; }
        }

        public string PurchasePrice2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[6].Text; }
        }

        public string QtyAvailable2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[7].Text; }
        }

        public string ValueAverage2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[8].Text; }
        }

        public string ValueAvailable2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[9].Text; }
        }

        public string QtyOut2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[10].Text; }
        }


        public string SalesPrice2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[11].Text; }
        }



        public string QtyEnd2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[12].Text; }
        }

        public string ValueEnd2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[13].Text; }
        }



        public string QtyPlusCorrection2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[14].Text; }
        }

        public string QtyMinusCorrection2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[15].Text; }
        }


        public string ValuePlusCorrection2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[16].Text; }
        }

        public string ValueMinusCorrection2
        {
            get { return lvwProductQty2.FocusedItem.SubItems[17].Text; }
        }


        public ProductUI(MainUI frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;

            productRepository = ServiceLocator.GetObject<IProductRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
            supplierRepository = ServiceLocator.GetObject<ISupplierRepository>();
            categoryRepository = ServiceLocator.GetObject<ICategoryRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
        }

      
        private void FillCategory()
        {
            var categories = categoryRepository.GetAll();

            foreach (var category in categories)
            {
                cboCategory.Items.Add(category.Name);
            }
        }



        private void PopulateProduct(Product product)
        {
            var item = new ListViewItem(product.ID.ToString());

            item.SubItems.Add(product.Code);
            item.SubItems.Add(product.Name);
            item.SubItems.Add(product.Category.Name);
            item.SubItems.Add(product.Unit);
            item.SubItems.Add(product.Notes);

            
            lvwProduct.Items.Add(item);

        }



        private void LoadProducts()
        {
            var products = productRepository.GetAll();

            lvwProduct.Items.Clear();

            foreach (var product in products)
            {
                PopulateProduct(product);
            }
        }


        private void PopulateProductQty(ProductQty productQty)
        {
            var item = new ListViewItem(productQty.ID.ToString());

            item.SubItems.Add(productQty.ActiveYear.ToString());
            item.SubItems.Add(Store.GetMonthName(productQty.ActiveMonth));
            item.SubItems.Add(productQty.QtyBegin.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueBegin.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyIn.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.PurchasePrice.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyAvailable.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueAverage.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueAvailable.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyOut.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.SalesPrice.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyEnd.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueEnd.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyPlusCorrection.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyMinusCorrection.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValuePlusCorrection.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueMinusCorrection.ToString("N0").Replace(",", "."));

            lvwProductQty.Items.Add(item);

        }

        private void PopulateProductQty2(ProductQty productQty)
        {
            var item = new ListViewItem(productQty.ID.ToString());

            item.SubItems.Add(productQty.ActiveYear.ToString());
            item.SubItems.Add(Store.GetMonthName(productQty.ActiveMonth));
            item.SubItems.Add(productQty.QtyBegin.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueBegin.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyIn.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.PurchasePrice.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyAvailable.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueAverage.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueAvailable.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyOut.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.SalesPrice.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyEnd.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueEnd.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyPlusCorrection.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.QtyMinusCorrection.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValuePlusCorrection.ToString("N0").Replace(",", "."));
            item.SubItems.Add(productQty.ValueMinusCorrection.ToString("N0").Replace(",", "."));

            lvwProductQty2.Items.Add(item);

        }


        private void LoadProductQty(Guid productId)
        {
            var list = productQtyRepository.GetByProductId(productId);
            
            lvwProductQty.Items.Clear();
            
            foreach (var pq in list)
            {
                
                PopulateProductQty(pq);
                
            }

        }

        private void LoadProductQty2(Guid productId)
        {
            var list = productQtyRepository.GetByProductId(productId);

            lvwProductQty2.Items.Clear();

            foreach (var pq in list)
            {

                PopulateProductQty2(pq);
            }

        }


        private void ViewProductDetail(Product product)
        {
            txtID.Text = product.ID.ToString();
            txtCode.Text = product.Code;
            txtName.Text = product.Name;
            txtCategoryId.Text = product.CategoryId.ToString();
            cboCategory.Text = product.Category.Name;
            txtUnit.Text = product.Unit;            
            txtNotes.Text = product.Notes;
            chkIsActive.Checked = product.IsActive;

            if (Store.IsAdministrator)
            {
                LoadProductQty(product.ID);
            }
            else
            {
                LoadProductQty2(product.ID);
            }
        }        



        private void GetLastProduct()
        {
            var product = productRepository.GetLast();
            if (product != null) ViewProductDetail(product);
        }


        private void ProductUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
         
            FillCategory();

            if (Store.IsAdministrator)
            {
                lvwProductQty.Visible = true;
                lvwProductQty2.Visible = false;
            }
            else
            {
                lvwProductQty.Visible = false;
                lvwProductQty2.Visible = true;

            }
            GetLastProduct();
            LoadProducts();

            if (lvwProduct.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbMenuFilter.Enabled = false;
                txtSearch.Enabled = false;
                tsbFilter.Enabled = false;
            }

           
        }

        private void lvwProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwProduct.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    var product = productRepository.GetById(new Guid(lvwProduct.FocusedItem.Text));
                    ViewProductDetail(product);
                }
            }
        }


        private void ClearForm()
        {
            txtCode.Clear();
            cboCategory.SelectedIndex = -1;
            txtName.Clear();
            txtUnit.Clear();
            txtNotes.Clear();
            chkIsActive.Checked = true;
            

        }


        private void EnableForm()
        {
            txtCode.Enabled = true;
            txtCode.BackColor = Color.White;

            txtName.Enabled = true;
            txtName.BackColor = Color.White;

            cboCategory.Enabled = true;
            cboCategory.BackColor = Color.White;

            txtUnit.Enabled = true;
            txtUnit.BackColor = Color.White;

            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;

            chkIsActive.Enabled = true;

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

        private void DisableForm()
        {
            txtCode.Enabled = false;
            txtCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            
            txtName.Enabled = false;
            txtName.BackColor = System.Drawing.SystemColors.ButtonFace;
            
            cboCategory.Enabled = false;
            cboCategory.BackColor = System.Drawing.SystemColors.ButtonFace;
            
            txtUnit.Enabled = false;
            txtUnit.BackColor = System.Drawing.SystemColors.ButtonFace;
            
            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;

            chkIsActive.Enabled = false;

            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;

            tsbRefresh.Enabled = false;
            txtSearch.Enabled = true;
            txtSearch.BackColor = Color.White;
            tsbMenuFilter.Enabled = true;
            tsbFilter.Enabled = true;

            if (lvwProduct.Items.Count == 0)
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


        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();
            txtCode.Focus();

        }


        private void EnableFormForEdit()
        {
            EnableForm();

            txtCode.Enabled = false;
            txtCode.BackColor = System.Drawing.SystemColors.ButtonFace;

            cboCategory.Enabled = true;
            cboCategory.BackColor = Color.White;

            txtName.Enabled = false;
            txtName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtUnit.SelectionStart = 0;
            txtUnit.Focus();


        }




        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Barang" && u.IsAdd);

            if (isAllowed || Store.IsAdministrator)
            {

                formMode = FormMode.Add;
                this.Text = "Tambah Barang";

                lvwProductQty.Items.Clear();

                EnableFormForAdd();
            }
            else
            {
                MessageBox.Show("Anda tidak berhak menambah data", "Perhatian", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

              

        
        private void GetProductById(Guid id)
        {
            Product product = productRepository.GetById(id);
            ViewProductDetail(product);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwProduct.Items.Count > 0)
            {
                GetProductById(new Guid(txtID.Text));
            }
            
            DisableForm();

            lvwProduct.Enabled = true;

            formMode = FormMode.View;
            this.Text = "Barang";
        }


        private void SaveProduct()
        {

            if (txtCode.Text == "")
            {
                MessageBox.Show("Kode harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
            }
            else if (formMode == FormMode.Add && productRepository.IsProductCodeExisted(txtCode.Text))
            {
                MessageBox.Show("Kode : " + txtCode.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cboCategory.Text=="")
            {
                MessageBox.Show("Kategori harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Nama harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (formMode == FormMode.Add && productRepository.IsProductNameExisted(txtName.Text))
            {
                MessageBox.Show("Nama : " + txtName.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtUnit.Text == "")
            {
                MessageBox.Show("Satuan harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUnit.Focus();
            }
            else
            {
                var product = new Product();

                product.Code = txtCode.Text;
                product.Name = txtName.Text;
                product.CategoryId = new Guid(txtCategoryId.Text);
                product.Unit = txtUnit.Text;
                product.Notes = txtNotes.Text;
                product.IsActive = chkIsActive.Checked;
          
                if (formMode == FormMode.Add)
                {
                    productRepository.Save(product);
                    GetLastProduct();
                }
                else if (formMode == FormMode.Edit)
                {
                    product.ID = new Guid(txtID.Text);

                    var productQtyItems = new List<ProductQty>();
                    
                    if (Store.IsAdministrator)
                    {                        
                        foreach (ListViewItem item in lvwProductQty.Items)
                        {
                            string id = item.SubItems[0].Text;
                            string year = item.SubItems[1].Text;
                            string month = item.SubItems[2].Text;
                            string qtyBegin = item.SubItems[3].Text;
                            string valueBegin = item.SubItems[4].Text;
                            string qtyIn = item.SubItems[5].Text;
                            string purchasePrice = item.SubItems[6].Text;
                            string qtyAvailable = item.SubItems[7].Text;
                            string valueAverage = item.SubItems[8].Text;
                            string valueAvailable = item.SubItems[9].Text;
                            string qtyOut = item.SubItems[10].Text;
                            string salesPrice = item.SubItems[11].Text;
                            string qtyEnd = item.SubItems[12].Text;
                            string valueEnd = item.SubItems[13].Text;
                            string qtyPlusCorrection = item.SubItems[14].Text;
                            string qtyMinusCorrection = item.SubItems[15].Text;
                            string valuePlusCorrection = item.SubItems[16].Text;
                            string valueMinusCorrection = item.SubItems[17].Text;

                            var pq = new ProductQty();

                            pq.ID = new Guid(id);
                            pq.ProductId = new Guid(txtID.Text);
                            pq.ActiveMonth = Store.GetMonthCode(month);
                            pq.ActiveYear = int.Parse(year);
                            pq.QtyBegin = int.Parse(qtyBegin);
                            pq.ValueBegin = decimal.Parse(valueBegin.Replace(".", ""));
                            pq.QtyIn = int.Parse(qtyIn);
                            pq.PurchasePrice = decimal.Parse(purchasePrice.Replace(".", ""));
                            pq.QtyAvailable = int.Parse(qtyAvailable);
                            pq.ValueAverage = decimal.Parse(valueAverage.Replace(".", ""));
                            pq.ValueAvailable = decimal.Parse(valueAvailable.Replace(".", ""));
                            pq.QtyOut = int.Parse(qtyOut);
                            pq.SalesPrice = decimal.Parse(salesPrice.Replace(".", ""));
                            pq.QtyEnd = int.Parse(qtyEnd);
                            pq.ValueEnd = decimal.Parse(valueEnd.Replace(".", ""));
                            pq.QtyPlusCorrection = int.Parse(qtyPlusCorrection);
                            pq.QtyMinusCorrection = int.Parse(qtyMinusCorrection);
                            pq.ValuePlusCorrection = decimal.Parse(valuePlusCorrection.Replace(".", ""));
                            pq.ValueMinusCorrection = decimal.Parse(valueMinusCorrection.Replace(".", ""));

                            productQtyItems.Add(pq);
                        }
                        
                    }

                    else //dummy
                    {
                        foreach (ListViewItem item in lvwProductQty2.Items)
                        {
                            string id = item.SubItems[0].Text;
                            string year = item.SubItems[1].Text;
                            string month = item.SubItems[2].Text;
                            string qtyBegin = item.SubItems[3].Text;
                            string valueBegin = item.SubItems[4].Text;
                            string qtyIn = item.SubItems[5].Text;
                            string purchasePrice = item.SubItems[6].Text;
                            string qtyAvailable = item.SubItems[7].Text;
                            string valueAverage = item.SubItems[8].Text;
                            string valueAvailable = item.SubItems[9].Text;
                            string qtyOut = item.SubItems[10].Text;
                            string salesPrice = item.SubItems[11].Text;
                            string qtyEnd = item.SubItems[12].Text;
                            string valueEnd = item.SubItems[13].Text;
                            string qtyPlusCorrection = item.SubItems[14].Text;
                            string qtyMinusCorrection = item.SubItems[15].Text;
                            string valuePlusCorrection = item.SubItems[16].Text;
                            string valueMinusCorrection = item.SubItems[17].Text;

                            var pq = new ProductQty();

                            pq.ID = new Guid(id);
                            pq.ProductId = new Guid(txtID.Text);
                            pq.ActiveMonth = Store.GetMonthCode(month);
                            pq.ActiveYear = int.Parse(year);
                            pq.QtyBegin = int.Parse(qtyBegin);
                            pq.ValueBegin = decimal.Parse(valueBegin.Replace(".", ""));
                            pq.QtyIn = int.Parse(qtyIn);
                            pq.PurchasePrice = decimal.Parse(purchasePrice.Replace(".", ""));
                            pq.QtyAvailable = int.Parse(qtyAvailable);
                            pq.ValueAverage = decimal.Parse(valueAverage.Replace(".", ""));
                            pq.ValueAvailable = decimal.Parse(valueAvailable.Replace(".", ""));
                            pq.QtyOut = int.Parse(qtyOut);
                            pq.SalesPrice = decimal.Parse(salesPrice.Replace(".", ""));
                            pq.QtyEnd = int.Parse(qtyEnd);
                            pq.ValueEnd = decimal.Parse(valueEnd.Replace(".", ""));
                            pq.QtyPlusCorrection = int.Parse(qtyPlusCorrection);
                            pq.QtyMinusCorrection = int.Parse(qtyMinusCorrection);
                            pq.ValuePlusCorrection = decimal.Parse(valuePlusCorrection.Replace(".", ""));
                            pq.ValueMinusCorrection = decimal.Parse(valueMinusCorrection.Replace(".", ""));

                            productQtyItems.Add(pq);
                        }

                    }



                    product.ProductQty = productQtyItems;
                    productRepository.Update(product);
                }

                LoadProducts();
                DisableForm();
                formMode = FormMode.View;
            
            }

        }


        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Barang" && u.IsEdit);

            if (isAllowed || Store.IsAdministrator)
            {

                formMode = FormMode.Edit;
                this.Text = "Edit Barang";

                EnableFormForEdit();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveProduct();

            this.Text = "Barang";
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex >= 0 )
            {
                var category = categoryRepository.GetByName(cboCategory.Text);
                txtCategoryId.Text = category.ID.ToString();
            }
        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {
            if (lvwProduct.Items.Count > 0)
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


        private void FilterProducts(string value)
        {
            var products = productRepository.Search(value);

            lvwProduct.Items.Clear();

            foreach (var product in products)
            {
                PopulateProduct(product);
            }

        }


        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterProducts(txtSearch.Text);
            }
            else
            {
                LoadProducts();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadProducts();
        }

        
        private void txtQtyBegin_KeyPress(object sender, KeyPressEventArgs e)
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

        

        

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterProducts(txtSearch.Text);
            }
            else
            {
                LoadProducts();
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Barang" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false )
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (productRepository.IsProductUsedBySalesItem(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Barang : " + txtName.Text + "\n\n" + "dipakai di Transaksi Penjualan ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Anda yakin ingin menghapus '" + txtCode.Text + " - " + txtName.Text + "'", "Perhatian",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        productRepository.Delete(new Guid(txtID.Text));
                        GetLastProduct();
                        LoadProducts();

                    }

                    if (lvwProduct.Items.Count == 0)
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

     

        private void lvwProductQty_DoubleClick(object sender, EventArgs e)
        {
            if (lvwProduct.Items.Count > 0)
            {
                if (formMode == FormMode.Edit)
                {
                    var frmProductQtyUpdate = new ProductQtyUpdateUI(this);
                    frmProductQtyUpdate.ShowDialog();
                }
            }
        }

        private void lvwProductQty2_DoubleClick(object sender, EventArgs e)
        {
            if (lvwProductQty2.Items.Count > 0)
            {
                if (formMode == FormMode.Edit)
                {
                    var frmProductQtyUpdate = new ProductQtyUpdateUI(this);
                    frmProductQtyUpdate.ShowDialog();
                }
            }
        }

       

      

      

        





    }
}
