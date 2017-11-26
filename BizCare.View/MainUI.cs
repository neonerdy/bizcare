
/*===================================================
 * 
 * BIZCARE 
 * 
 * Created Date : 08/04/2013
 * 
 * 
 * (c) 2013, XERIS 
 * 
 * 
 * ===================================================
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Corbis.Repository;
using EntityMap;
using BizCare.Repository;

using BizCare.Report;
using BizCare.View.Report;
using BizCare.Model;
using System.IO;
using System.Configuration;

namespace BizCare.View
{
    public enum FormMode
    {
        View, Add, Edit
    }

    public enum FormFilter
    {
       CustomerName, SupplierName, Address,ProductCode, ProductName, CategoryName
    }

    public partial class MainUI : Form
    {

        private Timer clock;

        private int activeMonth;
        private int activeYear;
        private string userLogin;
        private IUserAccessRepository userAccessRepository;

        public MainUI()
        {
            userAccessRepository = ServiceLocator.GetObject<IUserAccessRepository>();
      
            InitializeComponent();
        }
        
        
        public int ActiveMonth
        {
            get { return activeMonth; }
            set { activeMonth = value; }
        }

        public int ActiveYear
        {
            get { return activeYear; }
            set { activeYear = value; }
        }
          
        public string UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }

        public string Statusbar
        {
            get { return tslLogin.Text; }
            set { tslLogin.Text = value; }
        }


        public string GetDay(int day)
        {
            string strDay = string.Empty;

            switch (day)
            {
                case 0 :
                    strDay = "Sun";
                    break;
                case 1:
                    strDay = "Mon";
                    break;
                case 2:
                    strDay = "Tue";
                    break;
                case 3:
                    strDay = "Wed";
                    break;
                case 4:
                    strDay = "Thu";
                    break;
                case 5:
                    strDay = "Fri";
                    break;
                case 6:
                    strDay = "Sat";
                    break;

            }

            return strDay;
        }

        
        public string GetMonth(int month)
        {
            string strMonth = string.Empty;

            switch (month)
            {
                case 1:
                    strMonth = "Jan";
                    break;
                case 2:
                    strMonth = "Feb";
                    break;
                case 3:
                    strMonth = "Mar";
                    break;
                case 4:
                    strMonth = "Apr";
                    break;
                case 5:
                    strMonth = "May";
                    break;
                case 6:
                    strMonth = "Jun";
                    break;
                case 7:
                    strMonth = "Jul";
                    break;
                case 8 :
                    strMonth = "Aug";
                    break;
                case 9 :
                    strMonth = "Sep";
                    break;
                case 10:
                    strMonth = "Oct";
                    break;
                case 11:
                    strMonth = "Nov";
                    break;
                case 12:
                    strMonth = "Dec";
                    break;

            }


            return strMonth;

        }

        private void Form1_Load(object sender, EventArgs e)
        {   
       
            var companyRepository = ServiceLocator.GetObject<ICompanyRepository>();
            var recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();

            //Store.ActiveMonth = DateTime.Now.Month;
            //Store.ActiveYear = DateTime.Now.Year;
            //Store.ActiveUser = "";

            Store.StartDate = companyRepository.GetById(Guid.Empty).FirstUsedDate;
            Store.IsPeriodClosed = recordCounterRepository.IsPeriodClosed(Store.ActiveMonth, Store.ActiveYear);
                      
            clock = new Timer();
            clock.Interval = 1000;
            clock.Start();

            clock.Tick += new EventHandler(Timer_Tick);

            int day = (int)DateTime.Now.DayOfWeek;
            int date = DateTime.Now.Day;
            int month = DateTime.Now.Month;

            lblDate.Text = GetDay(day) + " , " + date + " " + GetMonth(month);

            tslLogin.Text = "Periode : " + Store.GetMonthName(Store.ActiveMonth)
               + " " + Store.ActiveYear + "  |  User : " + Store.ActiveUser;
            

        }

        public void Timer_Tick(object sender, EventArgs args)
        {
            if (sender == clock)
            {
                lblHour.Text = DateTime.Now.ToShortTimeString();
            }

        }



       
        private void tsbProduct_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Barang" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                var frmProduct = new ProductUI(this);
                frmProduct.MdiParent = this;
                frmProduct.Show();

            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuSalesman_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Salesman" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                var frmSalesman = new SalesmanUI(this);
                frmSalesman.MdiParent = this;
                frmSalesman.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Customer" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {

                var frmCustomer = new CustomerUI(this);
                frmCustomer.MdiParent = this;
                frmCustomer.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

        private void mnuSupplier_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Supplier" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {            
                var frmSupplier = new SupplierUI(this);
                
                frmSupplier.MdiParent = this;
                frmSupplier.Left = 0;
                frmSupplier.Top = 0;

                frmSupplier.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuSaldoAwalPiutang_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Piutang" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                var frmPayableBalance = new PayableBalanceUI(this);

                frmPayableBalance.MdiParent = this;
             
                frmPayableBalance.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuSaldoAwalHutang_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Saldo Awal Hutang" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {            
                var frmDebtBalance = new DebtBalanceUI(this);

                frmDebtBalance.MdiParent = this;
                frmDebtBalance.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuCompany_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Perusahaan" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                var frmCompany = new CompanyUI(this);

                frmCompany.MdiParent = this;
                frmCompany.Show();
             }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuCategory_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Kategori" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {

                var frmCategory = new CategoryUI(this);

                frmCategory.MdiParent = this;
                frmCategory.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbExpense_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Biaya" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {

                var frmExpense = new ExpenseUI(this);
                frmExpense.MdiParent = this;
                frmExpense.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbSales_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Penjualan" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {            
                var frmSales = new SalesUI(this);
                frmSales.MdiParent = this;
                frmSales.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuUser_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuRecordCounter_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Dokumen" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
            var frmRecordCounter = new RecordCounterUI(this);
            frmRecordCounter.MdiParent = this;
            frmRecordCounter.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuSalesmanFee_Click(object sender, EventArgs e)
        {
          
        }

        private void tsbPurchase_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pembelian" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                var frmPurchase = new PurchaseUI(this);
                frmPurchase.MdiParent = this;
                frmPurchase.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuPelunasanPiutang_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pelunasan Piutang" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {            
                var frmPayablePayment = new PayablePaymentUI(this);
                frmPayablePayment.MdiParent = this;
                frmPayablePayment.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuPembayaranHutang_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Pelunasan Hutang" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {            
                var frmDebtPayment = new DebtPaymentUI(this);
                frmDebtPayment.MdiParent = this;
                frmDebtPayment.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbBillReceipt_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "TTNT" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
            
                var frmBillReceipt = new BillReceiptUI(this);
                frmBillReceipt.MdiParent = this;
                frmBillReceipt.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbStockCorrection_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Koreksi Stok" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
            
                var frmStockCorrection = new StockCorrectionUI(this);
                frmStockCorrection.MdiParent = this;
                frmStockCorrection.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbSalesRinci_Click(object sender, EventArgs e)
        {
            var userAccess=userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Penjualan -> Rinci" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "SalesDetail";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Penjualan - Rinci";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbSalesRekap_Click(object sender, EventArgs e)
        {
            var userAccess=userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Penjualan -> Rekap" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "SalesRecap";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Penjualan - Rekap";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbSalesProduct_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Penjualan -> Per Barang" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "SalesPerProduct";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Penjualan - Per Barang";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void tsbPiutang_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuClosingPeriod_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Tutup Buku" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                var frmClosingPeriod = new ClosingPeriodUI(this);
                frmClosingPeriod.ShowDialog();


            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
      
        private void tsbPurchaseRinci_Click(object sender, EventArgs e)
        {
            var userAccess=userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Pembelian -> Rinci" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PurchaseDetail";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pembelian - Rinci";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        


        private void tsbPurchaseRekap_Click(object sender, EventArgs e)
        {
            var userAccess=userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Pembelian -> Rekap" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PurchaseRecap";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pembelian - Rekap";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbPurchaseProduct_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Pembelian -> Per Barang" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PurchasePerProduct";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pembelian - Per Barang";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void tsbExpenseRinci_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Biaya -> Rinci" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "ExpenseDetail";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Biaya - Rinci";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbExpenseRekap_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Biaya -> Rekap" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "ExpenseRecap";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Biaya - Rekap";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
       

     
        private void tsbStockCorrectionDetail_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Koreksi Stok -> Rinci" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
            
                Store.ActiveReport = "StockCorrectionDetail";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Koreksi Stok - Rinci";
                frm1.Show();

            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbStockCorrectionRecap_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Koreksi Stok -> Rekap" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "StockCorrectionRecap";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Koreksi Stok - Rekap";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbStockCorrectionProduct_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Koreksi Stok -> Per Barang" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "StockCorrectionPerProduct";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Koreksi Stok - Per Barang";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbSalesmanCommision_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Komisi Salesman" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "SalesmanCommision";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Komisi Salesman";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void tsbProfitStatementSales_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Rugi Laba -> Penjualan" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "ProfitStatementSales";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Rugi (Laba) Penjualan";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbBillReceiptRecap_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "TTNT" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "BillReceiptRecap";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "TTNT";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void tsbProfitStatementPayablePayment_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Rugi Laba -> Penagihan" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "ProfitStatementPayablePayment";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Rugi (Laba) Penagihan";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
      
        private void tsbDebtPaymentRinci_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Hutang -> Pembayaran -> Rinci" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "DebtPaymentDetail";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pembayaran Hutang - Rinci";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbDebtPaymentRecap_Click(object sender, EventArgs e)
        {
             var userAccess = userAccessRepository.GetAll();

             bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Hutang -> Pembayaran -> Rekap" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "DebtPaymentRecap";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pembayaran Hutang - Rekap";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbPurchaseUnPaidSupplier_Click(object sender, EventArgs e)
        {
             var userAccess = userAccessRepository.GetAll();

             bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Hutang -> Belum Lunas" && u.IsOpen);
             if (isAllowed || Store.IsAdministrator)
             {
                 Store.ActiveReport = "PurchaseUnPaidSupplier";
                 var frm1 = new ReportUI();
                 frm1.Show();
             }
             else
             {
                 MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
        }



        private void tsbPayablePaymentRinci_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Pelunasan -> Rinci" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PayablePaymentDetail";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pelunasan Piutang - Rinci";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void tsbSalesUnpaidCustomer_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Belum Lunas -> Per Customer" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "SalesUnPaidCustomer";
                var frm1 = new ReportUI();
                frm1.Text = "Piutang Belum Lunas - Per Customer";
                frm1.Show();

             }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbSalesUnpaidSalesman_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Belum Lunas -> Per Salesman" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "SalesUnPaidSalesman";
                var frm1 = new ReportUI();
                frm1.Text = "Piutang Belum Lunas - Per Customer";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbDebtBalance_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Hutang -> Saldo Awal" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "DebtBalanceDetail";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Saldo Awal Hutang";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbPayableBalanceDetail_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Saldo Awal -> Rinci" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PayableBalanceDetail";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Saldo Awal Piutang - Rinci";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void tsbPayableBalanceRecap_Click(object sender, EventArgs e)
        {
             var userAccess = userAccessRepository.GetAll();

             bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Saldo Awal -> Rekap" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PayableBalanceRecap";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Saldo Awal Piutang - Rekap";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbStockOpname_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Persediaan -> Stock Opname" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "StockOpname";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Stock Opname";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbInventory_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Persediaan -> Rekap" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "Inventory";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Persediaan";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void tsbProductDetails_Click(object sender, EventArgs e)
        {
            var userAccess=userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Master -> Barang" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "Product";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Barang";

                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void tsbCustomer_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Master -> Customer" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "Customer";
                var frm1 = new ReportUI();
               
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        
        
        private void tsbSupplier_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Master -> Supplier" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "Supplier";
                var frm1 = new ReportUI();
               
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void tsbSalesman_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Master -> Salesman" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {

                Store.ActiveReport = "Salesman";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Salesman";

                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void picLock_Click(object sender, EventArgs e)
        {
            var frmLogin = new LoginUI(this);
            frmLogin.ShowDialog();
        }

        private void mnuUserAccess_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Hak Akses" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                var frmUserAccess = new UserAccessUI();
                frmUserAccess.MdiParent = this;
                frmUserAccess.Show();

            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mnuLogoff_Click(object sender, EventArgs e)
        {
            picLock_Click(sender, e);
        }

        private void mnuUser_Click_1(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "User" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {

                var frmUser = new UserUI(this);
                frmUser.MdiParent = this;
                frmUser.Show();

            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbPayableBalance_Click(object sender, EventArgs e)
        {

        }

        private void mnuBackup_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Backup" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                string destinationFile = string.Empty;

                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter =
                 "BizCare database (*.mdb)|*.mdb";

                dialog.InitialDirectory = "C:";
                dialog.Title = "Backup Data";

                if (dialog.ShowDialog() == DialogResult.OK)
                    destinationFile = dialog.FileName;
                if (destinationFile == String.Empty)
                    return;

                string pathName = ConfigurationManager.AppSettings["DatabasePath"];

                try
                {
                    if (!File.Exists(destinationFile))
                    {
                        File.Copy(pathName + "\\BIZCARE.mdb", destinationFile);
                        MessageBox.Show("Backup data sukses", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("File " + destinationFile + " sudah ada!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal backup data!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void mnuRestore_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser
                && u.ObjectName == "Restore" && u.IsOpen);

            if (isAllowed || Store.IsAdministrator)
            {
                string fromFile = string.Empty;

                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter =
                 "BizCare database (*.mdb)|*.mdb";

                dialog.InitialDirectory = "C:";
                dialog.Title = "Restore Data";

                if (dialog.ShowDialog() == DialogResult.OK)
                    fromFile = dialog.FileName;
                if (fromFile == String.Empty)
                    return;

                string pathName = ConfigurationManager.AppSettings["DatabasePath"];

                try
                {
                    if (File.Exists(pathName + "\\BIZCARE.mdb"))
                    {
                        if (File.Exists(pathName + "\\BIZCARE.old.mdb")) File.Delete(pathName + "\\BIZCARE.old.mdb");

                        File.Move(pathName + "\\BIZCARE.mdb", pathName + "\\BIZCARE.old.mdb");
                        File.Copy(fromFile, pathName + "\\BIZCARE.mdb");

                        MessageBox.Show("Restore data sukses, tutup aplikasi dan buka kembali untuk memuat data baru", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal restore data!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka form ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbStockMinus_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Persediaan -> Stock Minus" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "ProductMinus";
                var frm1 = new ReportParamPeriodUI();
                frm1.Text = "Stock Minus";

                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbPayablePaymentRecap_Click(object sender, EventArgs e)
        {
            {
                var userAccess = userAccessRepository.GetAll();

                bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Pelunasan -> Rekap" && u.IsOpen);
                if (isAllowed || Store.IsAdministrator)
                {
                    Store.ActiveReport = "PayablePaymentRecap";
                    var frm1 = new ReportParamDateUI();
                    frm1.Text = "Pelunasan Piutang Rekap";
                    frm1.Show();
                }
                else
                {
                    MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tsbPayablePaymentSalesman_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Pelunasan -> Per Salesman" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PayablePaymentRecapSalesman";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pelunasan Piutang Rekap - Per Salesman";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsbPayablePaymentCustomer_Click(object sender, EventArgs e)
        {
            var userAccess = userAccessRepository.GetAll();

            bool isAllowed = userAccess.Exists(u => u.FullName == Store.ActiveUser && u.ObjectName == "Piutang -> Pelunasan -> Per Customer" && u.IsOpen);
            if (isAllowed || Store.IsAdministrator)
            {
                Store.ActiveReport = "PayablePaymentRecapCustomer";
                var frm1 = new ReportParamDateUI();
                frm1.Text = "Pelunasan Piutang Rekap - Per Customer";
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Anda tidak dapat membuka laporan ini", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       

    
        

       

       
       
       

      
    }
}
