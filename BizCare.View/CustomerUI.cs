using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityMap;

using BizCare.Repository;
using BizCare.Model;

namespace BizCare.View
{    

    public partial class CustomerUI : Form
    {
        private MainUI frmMain;
        private FormMode formMode;
        private FormFilter formFilter;
        private ICustomerRepository customerRepository;
        private IUserAccessRepository userAccessRepository;

        public CustomerUI()
        {
            InitializeComponent();
            customerRepository = ServiceLocator.GetObject<ICustomerRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();

        }

        public CustomerUI(MainUI frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;

            customerRepository = ServiceLocator.GetObject<ICustomerRepository>();
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

            txtEmail.Enabled = false;
            txtEmail.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPlafon.Enabled = false;
            txtPlafon.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtTermOfPayment.Enabled = false;
            txtTermOfPayment.BackColor = System.Drawing.SystemColors.ButtonFace;

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


            if (lvwCustomer.Items.Count == 0)
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
            txtPhone.Clear();

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

            tsbRefresh.Enabled = false;
            txtSearch.Enabled = false;
            txtSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            tsbMenuFilter.Enabled = false;
            tsbFilter.Enabled = false;

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



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Customer" && u.IsAdd);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menambah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Add;
                this.Text = "Customer - Tambah";
                EnableFormForAdd();
            }
        }



        private void RenderCustomer(Customer customer)
        {
            var item = new ListViewItem(customer.ID.ToString());

            item.SubItems.Add(customer.Name);
            item.SubItems.Add(customer.Address);
            item.SubItems.Add(customer.Phone);
            item.SubItems.Add(customer.ContactPerson);
            item.SubItems.Add(customer.CreatedDate.ToShortDateString());
                        
            lvwCustomer.Items.Add(item);

        }

        private void FilterCustomers(string value)
        {
            var customers = customerRepository.Search(value);

            lvwCustomer.Items.Clear();

            foreach (var customer in customers)
            {
                RenderCustomer(customer);
            }

        }


        private void LoadCustomers()
        {
            var customers = customerRepository.GetAll();
            
            lvwCustomer.Items.Clear();

            foreach (var customer in customers)
            {
                RenderCustomer(customer);
            }      
        }

        

        private void CustomerListUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.CustomerName;

            GetLastCustomer();
            LoadCustomers();

            if (lvwCustomer.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbMenuFilter.Enabled = false;
                txtSearch.Enabled = false;
                tsbFilter.Enabled = false;
            }
        }


        private void ViewCustomerDetail(Customer customer)
        {
            txtID.Text = customer.ID.ToString();
            txtName.Text = customer.Name;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
            txtFax.Text = customer.Fax;
            txtEmail.Text = customer.Email;
            txtContact.Text = customer.ContactPerson;
            txtNotes.Text = customer.Notes;
            chkIsActive.Checked = customer.IsActive;
            
            txtPlafon.Text = customer.Plafon==0?string.Empty:customer.Plafon.ToString();
            txtTermOfPayment.Text = customer.TermOfPayment == 0 ? string.Empty : customer.TermOfPayment.ToString();
            
            //txtBalance.Text = customer.FirstBalance.ToString();
        }

        private void GetLastCustomer()
        {
            Customer customer=customerRepository.GetLast();
            if (customer!=null) ViewCustomerDetail(customer);
        }
               

        private void GetCustomerById(Guid id)
        {
            Customer customer = customerRepository.GetById(id);
            if (customer!=null) ViewCustomerDetail(customer);
        }


        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwCustomer.Items.Count > 0)
            {
                GetCustomerById(new Guid
                    (txtID.Text));
            }
            
            DisableForm();
            lvwCustomer.Enabled = true;

            formMode = FormMode.View;
            
            this.Text = "Customer";
        }
              

        private void SaveCustomer()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Nama harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (formMode == FormMode.Add && customerRepository.IsCustomerNameExisted(txtName.Text))
            {
                MessageBox.Show("Customer : " + txtName.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                Customer customer = new Customer();
                
                customer.Name = txtName.Text;
                customer.Address = txtAddress.Text;
                customer.Phone = txtPhone.Text;
                customer.Fax = txtFax.Text;
                customer.Email = txtEmail.Text;
                customer.ContactPerson = txtContact.Text;
                customer.Notes = txtNotes.Text;
                customer.IsActive = chkIsActive.Checked;

              
                customer.Plafon = decimal.Parse(txtPlafon.Text=="" ? "0" : txtPlafon.Text.Replace(".",string.Empty));
                customer.TermOfPayment = int.Parse(txtTermOfPayment.Text == string.Empty ? "0" : txtTermOfPayment.Text);
                customer.FirstBalance = 0;

                if (formMode == FormMode.Add)
                {
                    customerRepository.Save(customer);
                    GetLastCustomer();
                }
                else if (formMode == FormMode.Edit)
                {
                    customer.ID = new Guid(txtID.Text);
                    customerRepository.Update(customer);
                }
                
                LoadCustomers();
                DisableForm();

                formMode = FormMode.View;
                this.Text = "Customer";            
            }

        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }

        

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Customer" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (customerRepository.IsCustomerUsedBySales(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Customer : " + txtName.Text + "\n\n" + "dipakai di Transaksi Penjualan ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (customerRepository.IsCustomerUsedByPayableBalance(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Customer : " + txtName.Text + "\n\n" + "dipakai di Saldo Awal Piutang ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {

                    if (MessageBox.Show("Anda yakin ingin menghapus '" + txtName.Text + "'", "Perhatian",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        customerRepository.Delete(new Guid(txtID.Text));
                        GetLastCustomer();
                        LoadCustomers();

                    }

                    if (lvwCustomer.Items.Count == 0)
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

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Customer" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Edit;
                this.Text = "Customer - Edit";

                EnableFormForEdit();
            }
                        
        }

        private void tsbFilter_Click(object sender, EventArgs e)
        {   
            if (txtSearch.Text.Length > 0)
            {
                FilterCustomers(txtSearch.Text);
            }
            else
            {
                LoadCustomers();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCustomers();
        }

      
        private void lvwCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwCustomer.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    Customer customer = customerRepository.GetById(new Guid(lvwCustomer.FocusedItem.Text));
                    ViewCustomerDetail(customer);
                }
            }
        }


        private void lvwCustomer_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCustomer.Items.Count > 0)
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterCustomers(txtSearch.Text);
            }
            else
            {
                LoadCustomers();
            }
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
