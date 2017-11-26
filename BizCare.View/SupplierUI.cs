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
    public partial class SupplierUI : Form
    {

        private MainUI frmMain;
        private ISupplierRepository supplierRepository;
        private FormMode formMode;
        private FormFilter formFilter;
        private IUserAccessRepository userAccessRepository;

        public SupplierUI()
        {
            InitializeComponent();
        }

        public SupplierUI(MainUI frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;

            supplierRepository = ServiceLocator.GetObject<ISupplierRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
        }

        private void DisableForm()
        {
            txtName.Enabled = false;
            txtName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtEmail.Enabled = false;
            txtEmail.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPlafon.Enabled = false;
            txtPlafon.BackColor = Color.White;

            txtTermOfPayment.Enabled = false;
            txtTermOfPayment.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtEmail.Enabled = false;
            txtEmail.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPlafon.Enabled = false;
            txtPlafon.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtContact.Enabled = false;
            txtContact.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPhone.Enabled = false;
            txtPhone.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtFax.Enabled = false;
            txtFax.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtAddress.Enabled = false;
            txtAddress.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;

            chkIsActive.Enabled = false;

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

            if (lvwSupplier.Items.Count == 0)
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

        private void ClearForm()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPlafon.Clear();
            txtEmail.Clear();
            txtPlafon.Clear();
            txtTermOfPayment.Clear();
            txtContact.Clear();
            txtPhone.Clear();
            txtFax.Clear();
            txtAddress.Clear();
            txtNotes.Clear();
            chkIsActive.Checked = true;

        }

        private void EnableForm()
        {
            txtName.Enabled = true;
            txtName.BackColor = Color.White;
            
            txtEmail.Enabled = true;
            txtEmail.BackColor = Color.White;
            
            txtPlafon.Enabled = true;
            txtPlafon.BackColor = Color.White;
            
            txtEmail.Enabled = true;
            txtEmail.BackColor = Color.White;
            
            txtPlafon.Enabled = true;
            txtPlafon.BackColor = Color.White;

            txtTermOfPayment.Enabled = true;
            txtTermOfPayment.BackColor = Color.White;
            
            txtContact.Enabled = true;
            txtContact.BackColor = Color.White;
            
            txtPhone.Enabled = true;
            txtPhone.BackColor = Color.White;
            
            txtFax.Enabled = true;
            txtFax.BackColor = Color.White;
            
            txtAddress.Enabled = true;
            txtAddress.BackColor = Color.White;
            
            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;
            
            chkIsActive.Enabled = true;

            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;
        }

        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();
            txtName.Focus();

        }


        private void EnableFormForEdit()
        {
            EnableForm();

            txtName.Enabled = false;
            txtName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtEmail.SelectionStart = 0;
            txtEmail.Focus();
        }



        private void ViewSupplierDetail(Supplier supplier)
        {
            txtID.Text = supplier.ID.ToString();
            txtName.Text = supplier.Name;
            txtAddress.Text = supplier.Address;
            txtPhone.Text = supplier.Phone;
            txtFax.Text = supplier.Fax;
            txtEmail.Text = supplier.Email;
            txtContact.Text = supplier.ContactPerson;
            txtNotes.Text = supplier.Notes;
            chkIsActive.Checked = supplier.IsActive;
            txtPlafon.Text = supplier.Plafon==0?string.Empty:supplier.Plafon.ToString();
            txtTermOfPayment.Text = supplier.TermOfPayment == 0 ? string.Empty : supplier.TermOfPayment.ToString();
        }


        private void PopulateSupplier(Supplier supplier)
        {
            var item = new ListViewItem(supplier.ID.ToString());

            item.SubItems.Add(supplier.Name);
            item.SubItems.Add(supplier.Address);
            item.SubItems.Add(supplier.Phone);
            item.SubItems.Add(supplier.ContactPerson);
            item.SubItems.Add(supplier.CreatedDate.ToShortDateString());

            lvwSupplier.Items.Add(item);

        }


        private void LoadSuppliers()
        {
            var suppliers = supplierRepository.GetAll();

            lvwSupplier.Items.Clear();

            foreach (var supplier in suppliers)
            {
                PopulateSupplier(supplier);
            }
        }


        private void GetLastSupplier()
        {
            var supplier = supplierRepository.GetLast();
            if (supplier!=null) ViewSupplierDetail(supplier);
        }


        private void SupplierUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.SupplierName;

            GetLastSupplier();
            LoadSuppliers();

            if (lvwSupplier.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbMenuFilter.Enabled = false;
                txtSearch.Enabled = false;
                tsbFilter.Enabled = false;
            }

        }

             

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Supplier" && u.IsAdd);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menambah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Add;
                this.Text = "Supplier - Tambah";
                EnableFormForAdd();
            }
        }


        private void SaveSupplier()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nama harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (formMode == FormMode.Add && supplierRepository.IsSupplierNameExisted(txtName.Text))
            {
                MessageBox.Show("Supplier : " + txtName.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Supplier supplier = new Supplier();

                supplier.Name = txtName.Text;
                supplier.Address = txtAddress.Text;
                supplier.Phone = txtPhone.Text;
                supplier.Fax = txtFax.Text;
                supplier.Email = txtEmail.Text;
                supplier.ContactPerson = txtContact.Text;
                supplier.Notes = txtNotes.Text;
                supplier.IsActive = chkIsActive.Checked;

                supplier.Plafon = decimal.Parse(txtPlafon.Text == "" ? "0" : txtPlafon.Text.Replace(".", string.Empty));
                supplier.TermOfPayment = int.Parse(txtTermOfPayment.Text == string.Empty ? "0" : txtTermOfPayment.Text);
                supplier.FirstBalance = 0;

                if (formMode == FormMode.Add)
                {
                    supplierRepository.Save(supplier);
                    GetLastSupplier();
                }
                else if (formMode == FormMode.Edit)
                {
                    supplier.ID = new Guid(txtID.Text);
                    supplierRepository.Update(supplier);
                }

                LoadSuppliers();
                DisableForm();

                formMode = FormMode.View;
                this.Text = "Supplier";
            }

        }




        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveSupplier();

           
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Supplier" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Edit;
                this.Text = "Supplier - Edit";

                EnableFormForEdit();
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Supplier" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (supplierRepository.IsSupplierUsedByDebtBalance(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Supplier : " + txtName.Text + "\n\n" + "dipakai di Saldo Awal Hutang ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Anda yakin ingin menghapus '" + txtName.Text + "'", "Perhatian",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        supplierRepository.Delete(new Guid(txtID.Text));
                        GetLastSupplier();
                        LoadSuppliers();

                    }

                    if (lvwSupplier.Items.Count == 0)
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


        private void lvwSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwSupplier.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    Supplier supplier = supplierRepository.GetById(new Guid(lvwSupplier.FocusedItem.Text));
                    ViewSupplierDetail(supplier);
                }
            }
        }


        private void lvwSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSupplier.Items.Count > 0)
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


        private void GetSupplierById(Guid id)
        {
            Supplier supplier = supplierRepository.GetById(id);
            if (supplier!=null) ViewSupplierDetail(supplier);
        }



        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwSupplier.Items.Count > 0)
            {
                GetSupplierById(new Guid(txtID.Text));
            }

            DisableForm();
            lvwSupplier.Enabled = true;

            formMode = FormMode.View;
            this.Text = "Supplier";
        }

      
        private void FilterSuppliers(string value)
        {
            var suppliers = supplierRepository.Search(value);

            lvwSupplier.Items.Clear();

            foreach (var supplier in suppliers)
            {
                PopulateSupplier(supplier);
            }

        }


        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterSuppliers(txtSearch.Text);
            }
            else
            {
                LoadSuppliers();
            }
        }

        private void txtPlafon_TextChanged(object sender, EventArgs e)
        {
            if (txtPlafon.Text != string.Empty)
            {
                string textBoxData = txtPlafon.Text;

                StringBuilder StringBldr = new StringBuilder(textBoxData);
                StringBldr.Replace(".", "");
                int textLength = StringBldr.Length;
                while (textLength > 3)
                {
                    StringBldr.Insert(textLength - 3, ".");
                    textLength = textLength - 3;
                }
                txtPlafon.Text = StringBldr.ToString();

                txtPlafon.SelectionStart = txtPlafon.Text.Length;
            }
        }


      

        private void txtPlafon_KeyPress(object sender, KeyPressEventArgs e)
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



       

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadSuppliers();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterSuppliers(txtSearch.Text);
            }
            else
            {
                LoadSuppliers();
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtTermOfPayment_KeyPress(object sender, KeyPressEventArgs e)
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
