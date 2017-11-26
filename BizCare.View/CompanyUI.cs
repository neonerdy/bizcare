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
    public partial class CompanyUI : Form
    {

        private MainUI frmMain;
        private ICompanyRepository companyRepository;
        private FormMode formMode;
        private FormFilter formFilter;

        public CompanyUI()
        {
            InitializeComponent();
        }

        public CompanyUI(MainUI frmMain)
        {
            companyRepository = ServiceLocator.GetObject<ICompanyRepository>();
            this.frmMain = frmMain;
            InitializeComponent();
        }

        private void ViewCompanyDetail(Company company)
        {
            txtCode.Text = company.Code;
            txtCompanyName.Text = company.Name;
            txtAddress.Text = company.Address;
            txtPhone1.Text = company.Phone1;
            txtPhone2.Text = company.Phone2;
            txtFax.Text = company.Fax;
            txtEmail.Text = company.Email;
            txtNotes.Text = company.Notes;
            udReportDivider.Text = company.ReportDivider.ToString();
            dtpDate.Text = company.FirstUsedDate.ToShortDateString();
        }

        private void CompanyUI_Load(object sender, EventArgs e)
        {
            formMode = FormMode.View;

            Company company = companyRepository.GetById(Guid.Empty);
            ViewCompanyDetail(company);
           
        }

        private void SaveCompany()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Kode harus diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCode.Focus();
            }
            else if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Nama harus diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCompanyName.Focus();
            }
            else if (txtPhone1.Text == "")
            {
                MessageBox.Show("Telepon 1 harus diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhone1.Focus();
            }
            else if (int.Parse(udReportDivider.Text) < 1)
            {
                MessageBox.Show("Pembagi laporan minimal 1", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPhone1.Focus();
            }
           
            else
            {

                Company company = new Company();

                company.Code = txtCode.Text;
                company.Name = txtCompanyName.Text;
                company.Phone1 = txtPhone1.Text;
                company.Phone2 = txtPhone2.Text;
                company.ReportDivider = int.Parse(udReportDivider.Text);
                company.Address = txtAddress.Text;
                company.Fax = txtFax.Text;
                company.Email = txtEmail.Text;
                company.Notes = txtNotes.Text;
                company.FirstUsedDate = dtpDate.Value;
               
                company.ID = Guid.Empty;
                companyRepository.Update(company);

                Company company1 = companyRepository.GetById(Guid.Empty);
                ViewCompanyDetail(company1);

                MessageBox.Show("Perusahaan berhasil di update", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

      

        private void txtReportDivider_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveCompany();
            this.Text = "Perusahaan";
        }

      
       


    }
}
