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
    public partial class UserUI : Form
    {

        private MainUI frmMain;
        private FormMode formMode;
        private FormFilter formFilter;
        private IUserLoginRepository userRepository;
        private IUserAccessRepository userAccessRepository;

        public UserUI()
        {
            InitializeComponent();
        }
        
        public UserUI(MainUI frmMain)
        {
            userRepository = ServiceLocator.GetObject<IUserLoginRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
            this.frmMain = frmMain;
            InitializeComponent();
        }


        private void DisableForm()
        {
            txtUserName.Enabled = false;
            txtUserName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPassword.Enabled = false;
            txtPassword.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtFullName.Enabled = false;
            txtFullName.BackColor = System.Drawing.SystemColors.ButtonFace;

            chkIsAdmin.Enabled = false;
            
            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
                        
            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;
            
        }

        private void ClearForm()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtNotes.Clear();

        }

        private void EnableForm()
        {
            txtUserName.Enabled = true;
            txtUserName.BackColor = Color.White;

            txtPassword.Enabled = true;
            txtPassword.BackColor = Color.White;

            txtFullName.Enabled = true;
            txtFullName.BackColor = Color.White;

            chkIsAdmin.Enabled = true;

            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;

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
            txtUserName.Focus();
            chkIsAdmin.Checked = false;
        }
        
        
        private void EnableFormForEdit()
        {
            EnableForm();

            txtUserName.SelectionStart = 0;
            txtUserName.Focus();
        }



        private void PopulateUser(UserLogin user)
        {
            var item = new ListViewItem(user.ID.ToString());

            item.SubItems.Add(user.UserName);
            item.SubItems.Add(user.Password);
            item.SubItems.Add(user.FullName);
            item.SubItems.Add(user.LastLogin.ToString("dd/MM/yyyy"));

            lvwUser.Items.Add(item);

        }


        private void LoadUsers()
        {
            var users = userRepository.GetAll();

            lvwUser.Items.Clear();

            foreach (var user in users)
            {
                PopulateUser(user);
            }
        }



        private void ViewUserDetail(UserLogin user)
        {
            txtID.Text = user.ID.ToString();
            txtUserName.Text = user.UserName;
            txtPassword.Text = user.Password;
            txtFullName.Text = user.FullName;
            chkIsAdmin.Checked = user.IsAdministrator;
            txtNotes.Text = user.Notes;
        }
        

        private void GetLastUser()
        {
            UserLogin user = userRepository.GetLast();
            if (user!=null) ViewUserDetail(user);
        }


        private void UserUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.SupplierName;

            GetLastUser();
            LoadUsers();
        }

        private void lvwUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwUser.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    var user = userRepository.GetById(new Guid(lvwUser.FocusedItem.Text));
                    ViewUserDetail(user);
                }
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "User" && u.IsAdd);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menambah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Add;
                this.Text = "Tambah User";
                EnableFormForAdd();
            }
        }



        private void SaveUser()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Nama user harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
            else if (txtFullName.Text == "")
            {
                MessageBox.Show("Nama lengkap harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFullName.Focus();
            }
            else
            {
                var user = new UserLogin();

                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.FullName = txtFullName.Text;
                user.IsAdministrator = chkIsAdmin.Checked;
                user.Notes = txtNotes.Text;

                if (formMode == FormMode.Add)
                {
                    userRepository.Save(user);
                    GetLastUser();
                }
                else if (formMode == FormMode.Edit)
                {
                    user.ID = new Guid(txtID.Text);

                   
                    userRepository.Update(user);
                    Store.IsAdministrator = user.IsAdministrator;

                }

                LoadUsers();
                DisableForm();

                this.Text = "User";
                formMode = FormMode.View;  

            }

        }
        

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveUser();
                     
        }


        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "User" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Edit;
                this.Text = "Edit User";

                EnableFormForEdit();
            }

        }

        private void GetUserById(Guid id)
        {
            var user = userRepository.GetById(id);
            if (user != null) ViewUserDetail(user);
        }



        private void tsbCancel_Click(object sender, EventArgs e)
        {
            GetUserById(new Guid(txtID.Text));

            DisableForm();
            lvwUser.Enabled = true;

            formMode = FormMode.View;
            this.Text = "User";
        }

        private void lvwUser_DoubleClick(object sender, EventArgs e)
        {
            if (lvwUser.Items.Count > 0)
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

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "User" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat meghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Anda yakin ingin menghapus '" + txtUserName.Text + "'", "Perhatian",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    userRepository.Delete(new Guid(txtID.Text));
                    GetLastUser();

                    LoadUsers();

                }
            }
        }



    }
}
