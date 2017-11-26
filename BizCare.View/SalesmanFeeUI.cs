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
    public partial class SalesmanFeeUI : Form
    {
        private SalesmanUI frmSalesman;
        private ISalesmanFeeRepository salesmanFeeRepository;
        private ISalesmanRepository salesmanRepository;
        private FormMode formMode;

        private int activeMonth;
        private int activeYear;

        public SalesmanFeeUI()
        {
            InitializeComponent();
        }

        public SalesmanFeeUI(SalesmanUI frmSalesman)
        {
            this.frmSalesman = frmSalesman;
            InitializeComponent();

            salesmanFeeRepository = ServiceLocator.GetObject<ISalesmanFeeRepository>();
            salesmanRepository = ServiceLocator.GetObject<ISalesmanRepository>();

            //activeMonth = frmMain.ActiveMonth;
            //activeYear = frmMain.ActiveYear;

            //activeMonth = DateTime.Now.Month;
            //activeYear = DateTime.Now.Year;
        }

        private void FillMonth()
        {

            cboMonth.Items.Add("Januari");
            cboMonth.Items.Add("Februari");
            cboMonth.Items.Add("Maret");
            cboMonth.Items.Add("April");
            cboMonth.Items.Add("Mei");
            cboMonth.Items.Add("Juni");
            cboMonth.Items.Add("Juli");
            cboMonth.Items.Add("Agustus");
            cboMonth.Items.Add("September");
            cboMonth.Items.Add("Oktober");
            cboMonth.Items.Add("November");
            cboMonth.Items.Add("Desember");


        }

        private void FillSalesman()
        {
            var salesmen = salesmanRepository.GetActiveSalesman();

            foreach (var salesman in salesmen)
            {
                cboSalesman.Items.Add(salesman.Name);
            }
        }

        private void ViewSalesmanFeeDetail(SalesmanFee salesmanFee)
        {
            txtID.Text = salesmanFee.ID.ToString();
            nudYear.Value = salesmanFee.ActiveYear;
            cboMonth.Text = Store.GetMonthName(salesmanFee.ActiveMonth);
            txtFeePercentage.Text = salesmanFee.FeePercentage.ToString();
            cboSalesman.Text = salesmanFee.Salesman.Name;
        }

        private void GetLastSalesmanFee()
        {
            SalesmanFee salesmanFee = salesmanFeeRepository.GetLast(new Guid(frmSalesman.SalesmanID));
            if (salesmanFee != null) ViewSalesmanFeeDetail(salesmanFee);
        }

        private void RenderSalesmanFee(SalesmanFee salesmanFee)
        {
            var item = new ListViewItem(salesmanFee.ID.ToString());


            item.SubItems.Add(salesmanFee.ActiveYear.ToString());
            item.SubItems.Add(Store.GetMonthName(salesmanFee.ActiveMonth));
            item.SubItems.Add(salesmanFee.Salesman.Name);
            item.SubItems.Add(salesmanFee.FeePercentage.ToString());
            
            lvwSalesmanFee.Items.Add(item);

        }

        private void LoadSalesmanFee()
        {
            var salesmanFees = salesmanFeeRepository.GetAll(new Guid(frmSalesman.SalesmanID));

            lvwSalesmanFee.Items.Clear();

            foreach (var salesmanFee in salesmanFees)
            {
                RenderSalesmanFee(salesmanFee);
            }
        }


        private void SalesmanFeeUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;

            FillMonth();
            FillSalesman();
            cboSalesman.Text = frmSalesman.SalesmanName;
            txtSalesmanId.Text = frmSalesman.SalesmanID;
            GetLastSalesmanFee();
            LoadSalesmanFee();

            nudYear.Value = Store.ActiveYear;

            if (lvwSalesmanFee.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                //tsbRefresh.Enabled = false;
                //tsbMenuFilter.Enabled = false;
                //txtSearch.Enabled = false;
                //tsbFilter.Enabled = false;
            }



        }


        

        private void lvwSalesmanFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwSalesmanFee.Items.Count > 0)
            {
                if (formMode == FormMode.Add || formMode == FormMode.Edit)
                {
                }
                else
                {
                    SalesmanFee salesmanFee = salesmanFeeRepository.GetById(new Guid(lvwSalesmanFee.FocusedItem.Text));
                    ViewSalesmanFeeDetail(salesmanFee);
                }
            }
        }


        private void ClearForm()
        {
            cboMonth.SelectedIndex = -1;
            //cboSalesman.SelectedIndex = -1;
            nudYear.Value = Store.ActiveYear;
            txtFeePercentage.Clear();

        }


        private void EnableForm()
        {
            cboMonth.Enabled = true;
            cboMonth.BackColor = Color.White;

            nudYear.Enabled = true;
            nudYear.BackColor = Color.White;

            //cboSalesman.Enabled = true;
            //cboSalesman.BackColor = Color.White;

            txtFeePercentage.Enabled = true;
            txtFeePercentage.BackColor = Color.White;

            tsbAdd.Enabled = false;
            tsbEdit.Enabled = false;
            tsbSave.Enabled = true;
            tsbDelete.Enabled = false;
            tsbCancel.Enabled = true;

        }

        private void DisableForm()
        {
            cboMonth.Enabled = false;
            cboMonth.BackColor = System.Drawing.SystemColors.ButtonFace;

            nudYear.Enabled = false;
            nudYear.BackColor = System.Drawing.SystemColors.ButtonFace;
            
            cboSalesman.Enabled = false;
            cboSalesman.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtFeePercentage.Enabled = false;
            txtFeePercentage.BackColor = System.Drawing.SystemColors.ButtonFace;

           
           
            tsbAdd.Enabled = true;
            tsbEdit.Enabled = true;
            tsbSave.Enabled = false;
            tsbDelete.Enabled = true;
            tsbCancel.Enabled = false;

            //tsbRefresh.Enabled = true;
            //txtSearch.Enabled = true;
            //txtSearch.BackColor = Color.White;
            //tsbMenuFilter.Enabled = true;
            //tsbFilter.Enabled = true;

            if (lvwSalesmanFee.Items.Count == 0)
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                //tsbRefresh.Enabled = false;
                //tsbMenuFilter.Enabled = false;
                //txtSearch.Enabled = false;
                //tsbFilter.Enabled = false;
                //txtSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            }
        }


        private void EnableFormForEdit()
        {
            EnableForm();

            cboMonth.Enabled = false;
            cboMonth.BackColor = System.Drawing.SystemColors.ButtonFace;

            nudYear.Enabled = false;
            nudYear.BackColor = System.Drawing.SystemColors.ButtonFace;

            cboSalesman.Enabled = false;
            cboSalesman.BackColor = System.Drawing.SystemColors.ButtonFace;

            txtFeePercentage.SelectionStart = 0;
            txtFeePercentage.Focus();
        }

        private void EnableFormForAdd()
        {

            EnableForm();
            ClearForm();
            cboMonth.Focus();

        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (Store.IsPeriodClosed)
            {
                MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Edit;
                this.Text = "Presentase Komisi Salesman - Edit";
                EnableFormForEdit();
            }
        }

        private void lvwSalesmanFee_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSalesmanFee.Items.Count > 0)
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
            if (Store.IsPeriodClosed)
            {
                MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                formMode = FormMode.Add;
                this.Text = "Presentase Komisi Salesman - Tambah";
                EnableFormForAdd();
            }
        }


        private void SaveSalesmanFee()
        {
            if (cboMonth.SelectedIndex == -1)
            {
                MessageBox.Show("Bulan harus diisi", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMonth.Focus();
            }
           
            else if (formMode == FormMode.Add && salesmanFeeRepository.IsSalesmanFeeExisted(Store.GetMonthCode(cboMonth.Text), Convert.ToInt32((nudYear.Value))
                ,new Guid(txtSalesmanId.Text)))
            {
                MessageBox.Show("Salesman : " + cboSalesman.Text  + "\n" + "Periode : " + cboMonth.Text + " - " + nudYear.Value + "\n\n" + "sudah ada ", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            else
            {

                SalesmanFee salesmanFee = new SalesmanFee();

                salesmanFee.ActiveMonth = Store.GetMonthCode(cboMonth.Text);
                salesmanFee.ActiveYear = Convert.ToInt32(nudYear.Value);
                salesmanFee.FeePercentage = int.Parse(txtFeePercentage.Text == "" ? "0" : txtFeePercentage.Text);
                salesmanFee.SalesmanId = new Guid(txtSalesmanId.Text);


                if (formMode == FormMode.Add)
                {
                    salesmanFeeRepository.Save(salesmanFee);

                    GetLastSalesmanFee();
                }
                else if (formMode == FormMode.Edit)
                {
                    salesmanFee.ID = new Guid(txtID.Text);
                    salesmanFeeRepository.Update(salesmanFee);
                }

                LoadSalesmanFee();
                DisableForm();

                formMode = FormMode.View;
            }
        }

        private void cboSalesman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSalesman.SelectedIndex >= 0)
            {
                var salesman = salesmanRepository.GetByName(cboSalesman.Text);
                txtSalesmanId.Text = salesman.ID.ToString();
            }     
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveSalesmanFee();

            this.Text = "Presentase Komisi Salesman";
        }

        private void GetSalesmanFeeById(Guid id)
        {
            SalesmanFee salesmanFee = salesmanFeeRepository.GetById(id);
            ViewSalesmanFeeDetail(salesmanFee);
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            if (lvwSalesmanFee.Items.Count > 0)
            {
                GetSalesmanFeeById(new Guid(txtID.Text));
            }

            DisableForm();

            lvwSalesmanFee.Enabled = true;

            formMode = FormMode.View;
            this.Text = "Presentase Komisi Salesman";
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (Store.IsPeriodClosed)
            {
                MessageBox.Show("Tidak dapat menambah/ubah/hapus \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "\n\n" + "Sudah Tutup Buku", "Perhatian",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("Anda yakin ingin menghapus '" + "\n\n" + "Salesman : " + cboSalesman.Text + "\n" + "Periode : " + cboMonth.Text + " " + nudYear.Value + "'", "Perhatian",
                                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    salesmanFeeRepository.Delete(new Guid(txtID.Text));
                    GetLastSalesmanFee();
                    LoadSalesmanFee();

                }

                if (lvwSalesmanFee.Items.Count == 0)
                {
                    tsbEdit.Enabled = false;
                    tsbDelete.Enabled = false;
                    //tsbRefresh.Enabled = false;
                    //tsbMenuFilter.Enabled = false;
                    //txtSearch.Enabled = false;
                    //tsbFilter.Enabled = false;

                    ClearForm();
                }
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            //txtSearch.Clear();
            LoadSalesmanFee();
        }

        private void FilterSalesmanFee(string field, string value)
        {

            var salesmanFees = salesmanFeeRepository.Search(value);

            lvwSalesmanFee.Items.Clear();

            foreach (var salesmanFee in salesmanFees)
            {
                RenderSalesmanFee(salesmanFee);
            }

        }

     







    }
}
