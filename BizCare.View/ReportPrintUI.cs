using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizCare.Report;
using BizCare.Repository;
using EntityMap;
using BizCare.View.Report;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.Configuration;

namespace BizCare.View
{
    public partial class ReportPrintUI : Form
    {
        private MainUI frmMain;

        private SalesUI frmSales;
        private PurchaseUI frmPurchase;
        private BillReceiptUI frmBillReceipt;
        private ExpenseUI frmExpense;
        private StockCorrectionUI frmStockCorrection;

        private ISalesRepository salesRepository;
        private IPurchaseRepository purchaseRepository;
        private IBillReceiptRepository billReceiptRepository;
        private IExpenseRepository expenseRepository;
        private IStockCorrectionRepository stockCorrectionRepository;

        private DataSet ds;
        private ReportDocument rpt;
        private ReportRepository reportRepository;

        public ReportPrintUI()
        {
            InitializeComponent();
        }

        public ReportPrintUI(MainUI frmMain)
        {
            this.frmMain = frmMain;

            ds = new BizCareDataSet();
            

            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();
            billReceiptRepository = ServiceLocator.GetObject<IBillReceiptRepository>();
            expenseRepository = ServiceLocator.GetObject<IExpenseRepository>();
            stockCorrectionRepository = ServiceLocator.GetObject<IStockCorrectionRepository>();

           
            InitializeComponent();
        }

        public string SalesCode
        {
            get { return txtCode.Text; }
        }

        public string PurchaseCode
        {
            get { return txtCode.Text; }
        }

        public string PayablePaymentCode
        {
            get { return txtCode.Text; }
        }

        public string BillReceiptCode
        {
            get { return txtCode.Text; }
        }

        public string ExpenseCode
        {
            get { return txtCode.Text; }
        }

        public string StockCorrectionCode
        {
            get { return txtCode.Text; }
        }

        public bool IsToPrinter
        {
            get { return optPrinter.Checked; }
        }

        public ReportPrintUI(SalesUI frmSales)
        {
            InitializeComponent();
            this.frmSales = frmSales;
            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
        }

        public ReportPrintUI(PurchaseUI frmPurchase)
        {
            InitializeComponent();
            this.frmPurchase = frmPurchase;
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();
        }

        public ReportPrintUI(BillReceiptUI frmBillReceipt)
        {
            InitializeComponent();
            this.frmBillReceipt = frmBillReceipt;
            billReceiptRepository = ServiceLocator.GetObject<IBillReceiptRepository>();
        }

        public ReportPrintUI(ExpenseUI frmExpense)
        {
            InitializeComponent();
            this.frmExpense = frmExpense;
            expenseRepository = ServiceLocator.GetObject<IExpenseRepository>();
        }

        public ReportPrintUI(StockCorrectionUI frmStockCorrection)
        {
            InitializeComponent();
            this.frmStockCorrection = frmStockCorrection;
            stockCorrectionRepository = ServiceLocator.GetObject<IStockCorrectionRepository>();
        }


        private void ReportPrintUI_Load(object sender, EventArgs e)
        {
            rpt = new ReportDocument();
            reportRepository = new ReportRepository();
            ds = new BizCareDataSet();
            
            if (Store.ActiveReport == "Sales")
            {
                txtCode.Text = frmSales.SalesCode;
            }
            else if (Store.ActiveReport == "Purchase")
            {
                txtCode.Text = frmPurchase.PurchaseCode;
            }
            else if (Store.ActiveReport == "BillReceipt")
            {
                txtCode.Text = frmBillReceipt.BillReceiptCode;
            }
            else if (Store.ActiveReport == "Expense")
            {
                txtCode.Text = frmExpense.ExpenseCode;
            }
            else if (Store.ActiveReport == "StockCorrection")
            {
                txtCode.Text = frmStockCorrection.StockCorrectionCode;
            }

        }


        private void ConfigurePrinter()
        {
            string printerName = ConfigurationManager.AppSettings["PrinterName"];
            string paperName = ConfigurationManager.AppSettings["PaperName"];

            //string printerName = "LX300";
            //string printerName = "EPSON LX-310 ESC/P";
            //string paperName = "8.5x5.5";

            var docToPrint = new PrintDocument();
            docToPrint.PrinterSettings.PrinterName = printerName;

            for (int i = 0; i < docToPrint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                int rawKind;
                if (docToPrint.PrinterSettings.PaperSizes[i].PaperName == paperName)
                {
                    rawKind = Convert.ToInt32(docToPrint.PrinterSettings.PaperSizes[i]
                        .GetType().GetField("kind", System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance).GetValue(docToPrint.PrinterSettings.PaperSizes[i]));


                    rpt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                }
            }


           


        }


        private void SendToPrinter()
        {
            

            if (Store.ActiveReport == "Sales")
            {
                ConfigurePrinter();

                salesRepository.UpdatePrintCounter(txtCode.Text);

                rpt.Load(Store.ReportPath + "\\" + Store.ActiveReport + ".rpt");
                reportRepository.GetSales(ds, txtCode.Text);

                rpt.SetDataSource(ds);
                rpt.PrintToPrinter(1, false, 0, 0);
            }
            else if (Store.ActiveReport == "Purchase")
            {
                ConfigurePrinter();

                purchaseRepository.UpdatePrintCounter(txtCode.Text);

                rpt.Load(Store.ReportPath + "\\" + Store.ActiveReport + ".rpt");
                reportRepository.GetPurchase(ds, txtCode.Text);

                rpt.SetDataSource(ds);
                rpt.PrintToPrinter(1, false, 0, 0);

            }
            else if (Store.ActiveReport == "BillReceipt")
            {
                billReceiptRepository.UpdatePrintCounter(txtCode.Text);

                rpt.Load(Store.ReportPath + "\\" + Store.ActiveReport + ".rpt");
                reportRepository.GetBillReceipt(ds, txtCode.Text);

                rpt.SetDataSource(ds);
                rpt.PrintToPrinter(1, false, 0, 0);
            }
            else if (Store.ActiveReport == "Expense")
            {
                ConfigurePrinter();

                expenseRepository.UpdatePrintCounter(txtCode.Text);

                rpt.Load(Store.ReportPath + "\\" + Store.ActiveReport + ".rpt");
                reportRepository.GetExpense(ds, txtCode.Text);

                rpt.SetDataSource(ds);
                rpt.PrintToPrinter(1, false, 0, 0);
            }
            else if (Store.ActiveReport == "StockCorrection")
            {
                ConfigurePrinter();

                stockCorrectionRepository.UpdatePrintCounter(txtCode.Text);

                rpt.Load(Store.ReportPath + "\\" + Store.ActiveReport + ".rpt");
                reportRepository.GetStockCorrection(ds, txtCode.Text);

                rpt.SetDataSource(ds);
                rpt.PrintToPrinter(1, false, 0, 0);
            }

           

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (optPrinter.Checked)
            {

                SendToPrinter();
                this.Close();

                //if (Store.ActiveReport == "Sales")
                //{
                //    salesRepository.UpdatePrintCounter(txtCode.Text);
                //}
                //else if (Store.ActiveReport == "Purchase")
                //{
                //    purchaseRepository.UpdatePrintCounter(txtCode.Text);
                //}
                //else if (Store.ActiveReport == "BillReceipt")
                //{
                //    billReceiptRepository.UpdatePrintCounter(txtCode.Text);
                //}
                //else if (Store.ActiveReport == "Expense")
                //{
                //    expenseRepository.UpdatePrintCounter(txtCode.Text);
                //}
                //else if (Store.ActiveReport == "StockCorrection")
                //{
                //    stockCorrectionRepository.UpdatePrintCounter(txtCode.Text);
                //}
            }
            else
            {
                var frmReport = new ReportUI(this);
                frmReport.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
