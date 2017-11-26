using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.OleDb;
using BizCare.View.Report;
using EntityMap;
using BizCare.Repository;
using System.Configuration;
using BizCare.View;

namespace BizCare.Report
{
    public partial class ReportUI : Form
    {
        private DataSet ds;
        private ReportRepository reportRepository;
        private IInventoryRepository inventoryRepository;
        private ISalesmanFeeRepository salesmanFeeRepository;
        private IProfitStatementRepository profitStatementRepository;
        private ReportDocument rpt;

        private ReportParamDateUI frmReportParamDate;
        private ReportParamPeriodUI frmReportParamPeriod;
        private SalesUI frmSales;
        private PurchaseUI frmPurchase;
        private StockCorrectionUI frmStockCorrection;
        private ExpenseUI frmExpense;
        private BillReceiptUI frmBillReceipt;
        private ReportPrintUI frmReportPrint;
        private PayablePaymentUI frmPayablePayment;

        public ReportUI()
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();
            inventoryRepository = ServiceLocator.GetObject<IInventoryRepository>();
            salesmanFeeRepository = ServiceLocator.GetObject<ISalesmanFeeRepository>();
            profitStatementRepository = ServiceLocator.GetObject<IProfitStatementRepository>();
            
        
        
        }

        public ReportUI(ReportParamDateUI frmReportParamDate)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();
            inventoryRepository = ServiceLocator.GetObject<IInventoryRepository>();
            salesmanFeeRepository = ServiceLocator.GetObject<ISalesmanFeeRepository>();

            this.frmReportParamDate = frmReportParamDate;


        }

        public ReportUI(ReportParamPeriodUI frmReportParamPeriod)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();
            inventoryRepository = ServiceLocator.GetObject<IInventoryRepository>();

            this.frmReportParamPeriod = frmReportParamPeriod;
            profitStatementRepository = ServiceLocator.GetObject<IProfitStatementRepository>();
            salesmanFeeRepository = ServiceLocator.GetObject<ISalesmanFeeRepository>();

        }

        public ReportUI(SalesUI frmSales)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();
          
            this.frmSales = frmSales;


        }

        public ReportUI(PurchaseUI frmPurchase)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();

            this.frmPurchase = frmPurchase;


        }

        public ReportUI(PayablePaymentUI frmPayablePayment)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();

            this.frmPayablePayment = frmPayablePayment;


        }


        public ReportUI(StockCorrectionUI frmStockCorrection)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();

            this.frmStockCorrection = frmStockCorrection;


        }

        public ReportUI(ExpenseUI frmExpense)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();

            this.frmExpense = frmExpense;


        }

        public ReportUI(BillReceiptUI frmBillReceipt)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();

            this.frmBillReceipt = frmBillReceipt;


        }


        public ReportUI(ReportPrintUI frmReportPrint)
        {
            InitializeComponent();

            ds = new BizCareDataSet();
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();

            this.frmReportPrint = frmReportPrint;


        }




        private void ReportUI_Load(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;

            rpt.Load(Store.ReportPath + "\\" + Store.ActiveReport + ".rpt");

            switch (Store.ActiveReport)
            {

                case "PayableBalanceDetail":
                    reportRepository.GetPayableBalanceDetail(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;

                    break;

                case "PayableBalanceRecap":
                    reportRepository.GetPayableBalanceRecap(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;

                    break;


                case "DebtBalanceDetail":
                    reportRepository.GetDebtBalance(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;
                    
                    break;


                case "ProfitStatementSales" :
                    profitStatementRepository.GenerateProfitStatementSales(frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    reportRepository.GetProfitStatementSales(ds);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;
                    
                    break;

                case "ProfitStatementPayablePayment":
                    profitStatementRepository.GenerateProfitStatementPayablePayment(frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    reportRepository.GetProfitStatementPayablePayment(ds);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;

                    break;

                case "Inventory" :
                    inventoryRepository.GenerateInventory(frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    reportRepository.GetInventory(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;
                    break;

                case "Sales":
                    reportRepository.GetSales(ds,frmReportPrint.SalesCode);
                    break;

                case "Purchase":
                    reportRepository.GetPurchase(ds, frmReportPrint.PurchaseCode);
                    break;

                case "BillReceipt":
                    reportRepository.GetBillReceipt(ds, frmReportPrint.BillReceiptCode);
                    break;

                case "Expense":
                    reportRepository.GetExpense(ds, frmReportPrint.ExpenseCode);
                    break;

                case "StockCorrection":
                    reportRepository.GetStockCorrection(ds, frmReportPrint.StockCorrectionCode);
                    break;


                case "SalesDetail":
                    reportRepository.GetSalesDetail(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "SalesRecap":
                    reportRepository.GetSalesRecap(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "SalesPerProduct":
                    reportRepository.GetSalesPerProduct(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;
                    
                case "SalesUnPaidSalesman":
                    reportRepository.GetSalesUnPaidSalesman(ds);
                    rpt.SummaryInfo.ReportTitle = "Per Tanggal : " + DateTime.Now.ToString("d/MM/yyyy");
                    
                    break;

                case "SalesUnPaidCustomer":
                    reportRepository.GetSalesUnPaidCustomer(ds);
                    rpt.SummaryInfo.ReportTitle = "Per Tanggal : " + DateTime.Now.ToString("d/MM/yyyy");
                    break;

                case "PurchaseDetail":
                    reportRepository.GetPurchaseDetail(ds,frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    break;

                case "PurchaseRecap":
                    reportRepository.GetPurchaseRecap(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "PurchasePerProduct":
                    reportRepository.GetPurchasePerProduct(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "PurchaseUnPaidSupplier":
                    reportRepository.GetPurchaseUnPaidSupplier(ds);
                    rpt.SummaryInfo.ReportTitle = "Per Tanggal : " + DateTime.Now.ToString("d/MM/yyyy");
                    
                    break;

                case "DebtPaymentDetail":
                    reportRepository.GetDebtPaymentDetail(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "DebtPaymentRecap":
                    reportRepository.GetDebtPaymentRecap(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "PayablePaymentDetail":
                    reportRepository.GetPayablePaymentDetail(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "PayablePaymentRecap":
                    reportRepository.GetPayablePaymentRecap(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");

                    break;

                case "PayablePaymentRecapCustomer":
                    reportRepository.GetPayablePaymentRecapCustomer(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "PayablePaymentRecapSalesman":
                    reportRepository.GetPayablePaymentRecapSalesman(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;


              

                case "ExpenseDetail":
                    reportRepository.GetExpenseDetail(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    break;

                case "ExpenseRecap":
                    reportRepository.GetExpenseRecap(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");                    
                    break;


               
                case "BillReceiptRecap":
                    reportRepository.GetBillReceiptRecap(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");                                        
                    break;

                case "Product":
                    inventoryRepository.GenerateInventory(frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    reportRepository.GetProduct(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;
                    
                    break;

                case "ProductMinus":
                    inventoryRepository.GenerateInventory(frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    reportRepository.GetProductMinus(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;

                    break;


                case "StockOpname":
                    inventoryRepository.GenerateInventory(frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    reportRepository.GetProduct(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;

                    break;

               

                case "StockCorrectionDetail":
                    reportRepository.GetStockCorrectionDetail(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "StockCorrectionRecap":
                    reportRepository.GetStockCorrectionRecap(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "StockCorrectionPerProduct":
                    reportRepository.GetStockCorrectionProduct(ds, frmReportParamDate.BeginDate, frmReportParamDate.EndDate);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + frmReportParamDate.BeginDate.ToString("d/MM/yyyy") + " s.d " + frmReportParamDate.EndDate.ToString("d/MM/yyyy");
                    
                    break;

                case "SalesmanCommision":
                    salesmanFeeRepository.GenerateCommision(frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    reportRepository.GetSalesmanCommision(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;                    
                    break;


                case "Customer":
                    reportRepository.GetCustomer(ds);
                    rpt.SummaryInfo.ReportTitle = "Per Tanggal : " + DateTime.Now.ToString("d/MM/yyyy");
                    
                    break;

                case "Supplier":
                    reportRepository.GetSupplier(ds);
                    rpt.SummaryInfo.ReportTitle = "Per Tanggal : " + DateTime.Now.ToString("d/MM/yyyy");

                    break;


                case "Salesman":
                    reportRepository.GetSalesman(ds, frmReportParamPeriod.PeriodMonth, frmReportParamPeriod.PeriodYear);
                    rpt.SummaryInfo.ReportTitle = "Periode : " + Store.GetMonthName(frmReportParamPeriod.PeriodMonth) + " " + frmReportParamPeriod.PeriodYear;

                    break;

            }

            rpt.SetDataSource(ds);

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();

            //if (frmReportPrint != null)
            //{
            //    if (frmReportPrint.IsToPrinter)
            //    {
            //        rpt.PrintToPrinter(1, false, 0, 0);
            //        rpt.Dispose();
 
            //        this.Close();
            //    }
            //    else
            //    {
            //        crystalReportViewer1.ReportSource = rpt;
            //        crystalReportViewer1.Refresh();
            //    }
            //}
            //else
            //{
            //    crystalReportViewer1.ReportSource = rpt;
            //    crystalReportViewer1.Refresh();
            //}


            Application.UseWaitCursor = false;

        }

       

        

      
    }
}
