using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizCare.Repository;
using BizCare.Model;
using EntityMap;

namespace BizCare.View
{
    public partial class SalesmanUI : Form
    {
        private MainUI frmMain;
        private ISalesmanRepository salesmanRepository;
        private FormMode formMode;
        private FormFilter formFilter;
        private IUserAccessRepository userAccessRepository;

        public SalesmanUI()
        {
            InitializeComponent();
        }

        public string SalesmanName
        {
            get { return txtSalesmanName.Text; }
        }

        public string SalesmanID
        {
            get { return txtID.Text; }
        }


        public SalesmanUI(MainUI frmMain)
        {
            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();
            this.frmMain = frmMain;
            InitializeComponent();
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
        }

        private void ViewSalesmanDetail(Salesman salesman)
        {
            txtID.Text = salesman.ID.ToString();
            txtSalesmanName.Text = salesman.Name;
            txtAddress.Text = salesman.Address;
            txtPhone1.Text = salesman.Phone1;
            txtPhone2.Text = salesman.Phone2;
            txtNotes.Text = salesman.Notes;
            chkIsActive.Checked = salesman.IsActive;
        }

        private void GetLastSalesman()
        {
            Salesman salesman = salesmanRepository.GetLast();
            if (salesman!=null) ViewSalesmanDetail(salesman);
        }

        private void RenderSalesman(Salesman salesman)
        {
            var item = new ListViewItem(salesman.ID.ToString());

            item.SubItems.Add(salesman.Name);
            item.SubItems.Add(salesman.Address);
            item.SubItems.Add(salesman.Phone1);
            item.SubItems.Add(salesman.Phone2);

            lvwSalesman.Items.Add(item);

        }

        private void LoadSalesmen()
        {
            var salesmans = salesmanRepository.GetAll();

            lvwSalesman.Items.Clear();

            foreach (var salesman in salesmans)
            {
                RenderSalesman(salesman);
            }
        }

        private void SalesmanUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;
            formFilter = FormFilter.SupplierName;

            GetLastSalesman();
            LoadSalesmen();

            if (lvwSalesman.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbRefresh.Enabled = false;
                tsbMenuFilter.Enabled = false;
                txtSearch.Enabled = false;
                tsbFilter.Enabled = false;
            }
        }

        private void lvwSalesman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwSalesman.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    Salesman salesman = salesmanRepository.GetById(new Guid(lvwSalesman.FocusedItem.Text));
                    ViewSalesmanDetail(salesman);
                }
            }
        }

        private void ClearForm()
        {
            txtSalesmanName.Clear();
            txtPhone1.Clear();
            txtPhone2.Clear();
            txtAddress.Clear();
            txtNotes.Clear();
            chkIsActive.Checked = true;

        }

        private void EnableForm()
        {
            txtSalesmanName.Enabled = true;
            txtSalesmanName.BackColor = Color.White;

            txtPhone1.Enabled = true;
            txtPhone1.BackColor = Color.White;

            txtPhone2.Enabled = true;
            txtPhone2.BackColor = Color.White;

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


        private void EnableFormForEdit()
        {
            EnableForm();

            txtSalesmanName.Enabled = false;
            txtSalesmanName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPhone1.SelectionStart = 0;
            txtPhone1.Focus();
        }

        private void EnableFormForAdd()
        {
            EnableForm();
            ClearForm();

            txtSalesmanName.Focus();

        }

        private void DisableForm()
        {
            txtSalesmanName.Enabled = false;
            txtSalesmanName.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPhone1.Enabled = false;
            txtPhone1.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtPhone2.Enabled = false;
            txtPhone2.BackColor = System.Drawing.SystemColors.ButtonFace;

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

            if (lvwSalesman.Items.Count == 0)
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

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Salesman" && u.IsEdit);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat merubah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Edit;
                this.Text = "Salesman - Edit";

                EnableFormForEdit();
            }
        }

        private void lvwSalesman_DoubleClick(object sender, EventArgs e)
        {

            if (lvwSalesman.Items.Count > 0) 
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
                && u.ObjectName == "Salesman" && u.IsAdd);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menambah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Add;
                this.Text = "Salesman - Tambah";
                EnableFormForAdd();
            }

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveSalesman();
        }

        private void SaveSalesman()
        {
            if (txtSalesmanName.Text == "")
            {
                MessageBox.Show("Nama harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSalesmanName.Focus();
            }
            else if (formMode == FormMode.Add && salesmanRepository.IsSalesmanNameExisted(txtSalesmanName.Text))
            {
                MessageBox.Show("Salesman : " + txtSalesmanName.Text + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (txtPhone1.Text == "")
            {
                MessageBox.Show("Telepon 1 harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone1.Focus();
            }
            
            else
            {

                Salesman salesman = new Salesman();

                salesman.Name = txtSalesmanName.Text;
                salesman.Phone1 = txtPhone1.Text;
                salesman.Phone2 = txtPhone2.Text;
                salesman.Address = txtAddress.Text;
                salesman.Notes = txtNotes.Text;
                salesman.IsActive = chkIsActive.Checked;

                if (formMode == FormMode.Add)
                {
                    salesmanRepository.Save(salesman);
                    GetLastSalesman();
                }
                else if (formMode == FormMode.Edit)
                {
                    salesman.ID = new Guid(txtID.Text);
                    salesmanRepository.Update(salesman);
                }

                LoadSalesmen();
                DisableForm();
                formMode = FormMode.View;
                this.Text = "Salesman";
     
            

            }
        }

        private void GetSalesmanById(Guid id)
        {
            Salesman salesman = salesmanRepository.GetById(id);
            ViewSalesmanDetail(salesman);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwSalesman.Items.Count > 0)
            {
                GetSalesmanById(new Guid(txtID.Text));
            }

            DisableForm();
            lvwSalesman.Enabled = true;

            formMode = FormMode.View;
            this.Text = "Salesman";
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Salesman" && u.IsDelete);

            if (isAllowed == false && Store.IsAdministrator == false)
            {
                MessageBox.Show("Anda tidak dapat menghapus", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (salesmanRepository.IsSalesmanUsedBySales(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Salesman : " + txtSalesmanName.Text + "\n\n" + "dipakai di Transaksi Penjualan ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (salesmanRepository.IsSalesmanUsedByPayableBalance(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Salesman : " + txtSalesmanName.Text + "\n\n" + "sudah dipakai di Saldo Awal Piutang ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (salesmanRepository.IsSalesmanUsedBySalesmanFee(new Guid(txtID.Text)))
                {
                    MessageBox.Show("Tidak bisa menghapus " + "\n\n" + "Salesman : " + txtSalesmanName.Text + "\n\n" + "sudah dipakai di Presentase Komisi Salesman ", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Anda yakin ingin menghapus '" + txtSalesmanName.Text + "'", "Perhatian",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        salesmanRepository.Delete(new Guid(txtID.Text));
                        GetLastSalesman();
                        LoadSalesmen();

                    }


                    if (lvwSalesman.Items.Count == 0)
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

        private void FilterSalesmans(string field, string value)
        {
            var salesmans = salesmanRepository.Search(value);

            lvwSalesman.Items.Clear();

            foreach (var salesman in salesmans)
            {
                RenderSalesman(salesman);
            }

        }

      
        

        private void tsbFilter_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                FilterSalesmans(formFilter.ToString(), txtSearch.Text);
            }
            else
            {
                LoadSalesmen();
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadSalesmen();
        }

       
        private void txtFeePrecentage_KeyPress(object sender, KeyPressEventArgs e)
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
                FilterSalesmans(formFilter.ToString(), txtSearch.Text);
            }
            else
            {
                LoadSalesmen();
            }
        }

        private void tsbFee_Click(object sender, EventArgs e)
        {
            var frmSalesmanFee = new SalesmanFeeUI(this);
            frmSalesmanFee.ShowDialog();

        }

     
      


    


            
    }
}
