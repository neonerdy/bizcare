using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityMap;
using BizCare.Model;
using BizCare.Repository;

namespace BizCare.View
{
    public partial class CategoryUI : Form
    {

        private MainUI frmMain;
        private ICategoryRepository categoryRepository;
        private FormMode formMode;
        private FormFilter formFilter;
        private IUserAccessRepository userAccessRepository;

        public CategoryUI()
        {
            InitializeComponent();
        }

        public CategoryUI(MainUI frmMain)
        {
            categoryRepository = ServiceLocator.GetObject<ICategoryRepository>();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();

            this.frmMain = frmMain;
            InitializeComponent();
        }

        private void ViewCategoryDetail(Category category)
        {
            txtID.Text = category.ID.ToString();
            txtCategoryName.Text = category.Name;
            txtNotes.Text = category.Notes;
            
        }

        private void GetLastCategory()
        {
            Category category = categoryRepository.GetLast();
            if (category != null) ViewCategoryDetail(category);
        }

        private void RenderCategory(Category category)
        {
            var item = new ListViewItem(category.ID.ToString());

            item.SubItems.Add(category.Name);
            item.SubItems.Add(category.Notes);

            lvwCategory.Items.Add(item);

        }

        private void LoadCategories()
        {
            var categories = categoryRepository.GetAll();

            lvwCategory.Items.Clear();

            foreach (var category in categories)
            {
                RenderCategory(category);
            }
        }


        private void CategoryUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            
            GetLastCategory();
            LoadCategories();

            if (lvwCategory.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
            }

        }

        private void lvwCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwCategory.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    Category category = categoryRepository.GetById(new Guid(lvwCategory.FocusedItem.Text));
                    ViewCategoryDetail(category);
                }
            }
        }

        private void ClearForm()
        {
            txtCategoryName.Clear();
            txtNotes.Clear();

        }

        private void EnableForm()
        {
            txtCategoryName.Enabled = true;
            txtCategoryName.BackColor = Color.White;

            txtNotes.Enabled = true;
            txtNotes.BackColor = Color.White;

            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;

        }

        private void EnableFormForEdit()
        {
            EnableForm();

            txtCategoryName.Enabled = false;
            txtCategoryName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtNotes.SelectionStart = 0;
            txtNotes.Focus();
        }

        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();

            txtCategoryName.Focus();

        }

        private void DisableForm()
        {
            txtCategoryName.Enabled = false;
            txtCategoryName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtNotes.Enabled = false;
            txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;

            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;

             if (lvwCategory.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
               
            }
           
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Kategori" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Edit;
                this.Text = "Kategori - Edit";

                EnableFormForEdit();
            }
        }

        private void lvwCategory_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCategory.Items.Count > 0)
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

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Kategori" && u.IsAdd);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menambah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Add;
                this.Text = "Kategori - Tambah";
                EnableFormForAdd();
            }
        }

        private void SaveCategory()
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Nama harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCategoryName.Focus();
            }
            else if (formMode == FormMode.Add && categoryRepository.IsCategoryNameExisted(txtCategoryName.Text))
            {
                MessageBox.Show("Kategori : " + txtCategoryName.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {

                Category category = new Category();

                category.Name = txtCategoryName.Text;
                category.Notes = txtNotes.Text;

                if (formMode == FormMode.Add)
                {
                    categoryRepository.Save(category);
                    GetLastCategory();
                }
                else if (formMode == FormMode.Edit)
                {
                    category.ID = new Guid(txtID.Text);
                    categoryRepository.Update(category);
                }

                LoadCategories();
                DisableForm();

                formMode = FormMode.View;
                this.Text = "Kategori";

            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveCategory();
            

        }

        private void GetCategoryById(Guid id)
        {
            Category category = categoryRepository.GetById(id);
            ViewCategoryDetail(category);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwCategory.Items.Count > 0)
            {
                GetCategoryById(new Guid(txtID.Text));
            }

                DisableForm();
                lvwCategory.Enabled = true;

                formMode = FormMode.View;
                this.Text = "Kategori";
            

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Kategori" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (categoryRepository.IsCategoryUsedByProduct(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Kategori : " + txtCategoryName.Text + "\n\n" + "dipakai di Master Barang ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Anda yakin ingin menghapus '" + txtCategoryName.Text + "'", "Perhatian",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        categoryRepository.Delete(new Guid(txtID.Text));
                        GetLastCategory();
                        LoadCategories();

                    }

                    if (lvwCategory.Items.Count == 0)
                    {
                        tsbEdit.Enabled = false;
                        tsbDelete.Enabled = false;
                        ClearForm();

                    }

                }
            }

        }

    }
}
