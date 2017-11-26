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

namespace BizCare.View
{
    public partial class ProductQtyUpdateUI : Form
    {
        private ProductUI frmProduct;
        private IProductQtyRepository productQtyRepository;
        
        public ProductQtyUpdateUI()
        {
            InitializeComponent();
        }


        public ProductQtyUpdateUI(ProductUI frmProduct)
        {
            this.frmProduct = frmProduct;
            InitializeComponent();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();

           
        }

        private void txtQtyBegin_TextChanged(object sender, EventArgs e)
        {
            if (txtQtyBegin.Text != string.Empty)
            {
                string textBoxData = txtQtyBegin.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtQtyBegin.Text = StringBldr.ToString();

                txtQtyBegin.SelectionStart = txtQtyBegin.Text.Length;
            }
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

        private void ProductQtyUpdateUI_Load(object sender, EventArgs e)
        {
            

            if (Store.IsAdministrator)
            {

                this.Text = "Update Qty - " + frmProduct.ActiveMonth + " " + frmProduct.ActiveYear;

                lblID.Text = frmProduct.ID;
                lblMonth.Text = frmProduct.ActiveMonth;
                lblYear.Text = frmProduct.ActiveYear;

                txtQtyBegin.Text = frmProduct.QtyBegin;
                txtValueBegin.Text = frmProduct.ValueBegin;

                lblQtyIn.Text = frmProduct.QtyIn;
                txtPurchasePrice.Text = frmProduct.PurchasePrice;

                lblQtyOut.Text = frmProduct.QtyOut;
                txtSalesPrice.Text = frmProduct.SalesPrice;

                lblQtyAvailable.Text = frmProduct.QtyAvailable;
                txtValueAverage.Text = frmProduct.ValueAverage;
                lblValueAvailable.Text = frmProduct.ValueAvailable;

                lblQtyEnd.Text = frmProduct.QtyEnd;
                lblValueEnd.Text = frmProduct.ValueEnd;
                lblQtyPlusCorrection.Text = frmProduct.QtyPlusCorrection;
                lblQtyMinusCorrection.Text = frmProduct.QtyMinusCorrection;

                lblValuePlusCorrection.Text = frmProduct.ValuePlusCorrection;
                lblValueMinusCorrection.Text = frmProduct.ValueMinusCorrection;

            }
            else
            {
                lblValueBegin.Visible = false;
                txtValueBegin.Visible = false;
                lblSalesPrice.Visible=false;
                txtSalesPrice.Visible = false;
                lblPurchasePrice.Visible = false;
                txtPurchasePrice.Visible = false;
                lblValueAverage.Visible = false;
                txtValueAverage.Visible = false;

                this.Text = "Update Qty - " + frmProduct.ActiveMonth2 + " " + frmProduct.ActiveYear2;

                //dummy
                lblID.Text = frmProduct.ID2;
                lblMonth.Text = frmProduct.ActiveMonth2;
                lblYear.Text = frmProduct.ActiveYear2;

                txtQtyBegin.Text = frmProduct.QtyBegin2;
                txtValueBegin.Text = frmProduct.ValueBegin2;

                lblQtyIn.Text = frmProduct.QtyIn2;
                txtPurchasePrice.Text = frmProduct.PurchasePrice2;

                lblQtyOut.Text = frmProduct.QtyOut2;
                txtSalesPrice.Text = frmProduct.SalesPrice2;

                lblQtyAvailable.Text = frmProduct.QtyAvailable2;
                txtValueAverage.Text = frmProduct.ValueAverage2;
                lblValueAvailable.Text = frmProduct.ValueAvailable2;

                lblQtyEnd.Text = frmProduct.QtyEnd2;
                lblValueEnd.Text = frmProduct.ValueEnd2;
                lblQtyPlusCorrection.Text = frmProduct.QtyPlusCorrection2;
                lblQtyMinusCorrection.Text = frmProduct.QtyMinusCorrection2;

                lblValuePlusCorrection.Text = frmProduct.ValuePlusCorrection2;
                lblValueMinusCorrection.Text = frmProduct.ValueMinusCorrection2;

            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Store.IsPeriodClosed)
            {
                MessageBox.Show("Tidak dapat menambah/ubah \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                var productQty = productQtyRepository.GetByMonthAndYear(Store.ActiveMonth, Store.ActiveYear, new Guid(lblID.Text));
                if (productQty != null)
                {
                    int qtyBegin = (productQty.QtyBegin - productQty.QtyBegin) + int.Parse(txtQtyBegin.Text);
                    int qtyIn = productQty.QtyIn;
                    int qtyOut = (productQty.QtyOut - productQty.QtyPlusCorrection) + productQty.QtyMinusCorrection;

                    lblQtyEnd.Text = ((qtyBegin + qtyIn) - qtyOut).ToString();

                }
                else
                {
                    lblQtyEnd.Text = txtQtyBegin.Text;
                }

                if (Store.IsAdministrator)
                {
                    frmProduct.UpdateProductQty(lblID.Text, lblYear.Text, lblMonth.Text,
                        txtQtyBegin.Text, txtValueBegin.Text,
                        lblQtyIn.Text, txtPurchasePrice.Text,
                        lblQtyAvailable.Text, txtValueAverage.Text, lblValueAvailable.Text,
                        lblQtyOut.Text, txtSalesPrice.Text,
                        lblQtyEnd.Text, lblValueEnd.Text,
                        lblQtyPlusCorrection.Text, lblQtyMinusCorrection.Text,
                        lblValuePlusCorrection.Text, lblValueMinusCorrection.Text);
                }
                else
                {
                    frmProduct.UpdateProductQty2(lblID.Text, lblYear.Text, lblMonth.Text,
                        txtQtyBegin.Text, txtValueBegin.Text,
                        lblQtyIn.Text, txtPurchasePrice.Text,
                        lblQtyAvailable.Text, txtValueAverage.Text, lblValueAvailable.Text,
                        lblQtyOut.Text, txtSalesPrice.Text,
                        lblQtyEnd.Text, lblValueEnd.Text,
                        lblQtyPlusCorrection.Text, lblQtyMinusCorrection.Text,
                        lblValuePlusCorrection.Text, lblValueMinusCorrection.Text);
                }
                this.Close();
            }
        }

        private void txtValueBegin_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPurchasePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValueAverage_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValueBegin_TextChanged(object sender, EventArgs e)
        {
            if (txtValueBegin.Text != string.Empty)
            {
                string textBoxData = txtValueBegin.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtValueBegin.Text = StringBldr.ToString();

                txtValueBegin.SelectionStart = txtValueBegin.Text.Length;
            }
        }

        private void txtPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchasePrice.Text != string.Empty)
            {
                string textBoxData = txtPurchasePrice.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtPurchasePrice.Text = StringBldr.ToString();

                txtPurchasePrice.SelectionStart = txtPurchasePrice.Text.Length;
            }
        }

        private void txtSalesPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtSalesPrice.Text != string.Empty)
            {
                string textBoxData = txtSalesPrice.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtSalesPrice.Text = StringBldr.ToString();

                txtSalesPrice.SelectionStart = txtSalesPrice.Text.Length;
            }
        }

        private void txtValueAverage_TextChanged(object sender, EventArgs e)
        {
            if (txtValueAverage.Text != string.Empty)
            {
                string textBoxData = txtValueAverage.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtValueAverage.Text = StringBldr.ToString();

                txtValueAverage.SelectionStart = txtValueAverage.Text.Length;
            }
        }      





    }
}
