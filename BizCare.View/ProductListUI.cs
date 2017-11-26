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

namespace BizCare.View
{
    public partial class ProductListUI : Form
    {
        private SalesUI frmSales;
        private PurchaseUI frmPurchase;
        private StockCorrectionUI frmStockCorrection;
        private PayableBalanceUI frmPayableBalance;

        private IProductQtyRepository productQtyRepository;
        private string formActive;

        public ProductListUI()
        {
            InitializeComponent();
        }

        public ProductListUI(SalesUI frmSales)
        {
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();

            this.frmSales = frmSales;
            formActive = "SalesUI";

            InitializeComponent();
        }

        public ProductListUI(PurchaseUI frmPurchase)
        {
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();

            this.frmPurchase = frmPurchase;
            formActive = "PurchaseUI";

            InitializeComponent();
        }


        public ProductListUI(StockCorrectionUI frmStockCorrection)
        {
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();

            this.frmStockCorrection = frmStockCorrection;
            formActive = "StockCorrectionUI";

            InitializeComponent();
        }


        public ProductListUI(PayableBalanceUI frmPayableBalance)
        {
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();

            this.frmPayableBalance = frmPayableBalance;
            formActive = "PayableBalanceUI";

            InitializeComponent();
        }
        

        private void PopulateProduct(ProductQty productQty)
        {
            var item = new ListViewItem(productQty.ProductId.ToString());

            item.SubItems.Add(productQty.Product.Code);
            item.SubItems.Add(productQty.Product.Name);
            item.SubItems.Add(productQty.Product.Unit);
            item.SubItems.Add(productQty.SalesPrice.ToString("N0").Replace(",", "."));
                                  
            lvwProduct.Items.Add(item);

        }


        private void LoadProduct()
        {
            var product = productQtyRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

            lvwProduct.Items.Clear();

            foreach (var s in product)
            {
                PopulateProduct(s);
            }
        }


        private void ProductListUI_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
            LoadProduct();
        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {
            string productId=lvwProduct.FocusedItem.Text;
            string productName=lvwProduct.FocusedItem.SubItems[2].Text;
            string unit = lvwProduct.FocusedItem.SubItems[3].Text;
            string price = lvwProduct.FocusedItem.SubItems[4].Text;

            if (formActive == "SalesUI")
            {
                frmSales.PutProductName(productId, productName, unit, price);
            }
            else if (formActive == "PurchaseUI")
            {
                frmPurchase.PutProductName(productId, productName, unit, price);
            }
            else if (formActive == "StockCorrectionUI")
            {
                frmStockCorrection.PutProductName(productId, productName, unit, "");
            }
            else if (formActive == "PayableBalanceUI")
            {
                frmPayableBalance.PutProductName(productId, productName, unit, price);
            }
            
            this.Close();
        }

        private void FilterProducts(string value)
        {
            var product = productQtyRepository.Search(Store.ActiveMonth, Store.ActiveYear,value);

            lvwProduct.Items.Clear();

            foreach (var s in product)
            {
                PopulateProduct(s);
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
                LoadProduct();
            }
        }



       
    }
}
