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
    public partial class LoginUI : Form
    {

        private IUserLoginRepository userLoginRepository;
        private MainUI frmMain;

        public LoginUI(MainUI frmMain)
        {
            InitializeComponent();
            userLoginRepository = ServiceLocator.GetObject<IUserLoginRepository>();

            this.frmMain = frmMain;        
        }


        public LoginUI()
        {
            InitializeComponent();
            userLoginRepository = ServiceLocator.GetObject<IUserLoginRepository>();
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {
            lblCopyRight.Text = "Copyright \u00a9 2013, XERIS";

            int month=DateTime.Now.Month;
            int year=DateTime.Now.Year;

            nudMonth.Value = month;
            nudYear.Value = year;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            var user = userLoginRepository.GetByUserAndPassword(txtUser.Text, txtPassword.Text);

            if (user!=null)
            {
                Store.ActiveMonth = Convert.ToInt32(nudMonth.Value);
                Store.ActiveYear = Convert.ToInt32(nudYear.Value);
                Store.ActiveUser = user.FullName;
                Store.IsAdministrator = user.IsAdministrator;
                
                DialogResult = DialogResult.OK;
               
                userLoginRepository.UpdateLastLogin(user.ID);

                if (frmMain != null)
                {
                    frmMain.Statusbar = "Periode : " + Store.GetMonthName(Store.ActiveMonth)
                               + " " + Store.ActiveYear + "  |  User : " + Store.ActiveUser;

                    var recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();

                    Store.IsPeriodClosed = recordCounterRepository.IsPeriodClosed(Store.ActiveMonth, Store.ActiveYear);
          

                    this.Close();
                }               

                             
            }
            else
            {
                MessageBox.Show("Login gagal, silahkan coba lagi", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        
        }

        
    }
}
