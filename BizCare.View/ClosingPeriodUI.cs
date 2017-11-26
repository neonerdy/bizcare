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
    public partial class ClosingPeriodUI : Form
    {
        private MainUI frmMain;
        private FormMode formMode;
        private FormFilter formFilter;

        private ISalesRepository salesRepository;
        private IPurchaseRepository purchaseRepository;
        private IPayableBalanceRepository payableBalanceRepository;
        private IDebtBalanceRepository debtBalanceRepository;
        private IRecordCounterRepository recordCounterRepository;
        private ISalesmanFeeRepository salesmanFeeRepository;
        private IProductQtyRepository productQtyRepository;
        private IInventoryRepository inventoryRepository;


        public ClosingPeriodUI()
        {
            InitializeComponent();
        }

        public ClosingPeriodUI(MainUI frmMain)
        {
            this.frmMain = frmMain;


            salesRepository = ServiceLocator.GetObject<ISalesRepository>();
            purchaseRepository = ServiceLocator.GetObject<IPurchaseRepository>();
            payableBalanceRepository = ServiceLocator.GetObject<IPayableBalanceRepository>();
            debtBalanceRepository = ServiceLocator.GetObject<IDebtBalanceRepository>();
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            salesmanFeeRepository = ServiceLocator.GetObject<ISalesmanFeeRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
            inventoryRepository = ServiceLocator.GetObject<IInventoryRepository>();


            InitializeComponent();
        }


        private void ClosingPeriodUI_Load(object sender, EventArgs e)
        {
            txtActiveMonth.Text = Store.GetMonthName(Store.ActiveMonth);
            txtActiveYear.Text = Store.ActiveYear.ToString();
        }


        private void CopyToPayableBalance(Sales s, PayableBalance payableBalance)
        {
            payableBalance.BalanceYear = Store.ActiveYear;
            payableBalance.BalanceMonth = Store.ActiveMonth;
            payableBalance.SalesCode = s.Code;
            payableBalance.SalesDate = s.Date;
            payableBalance.CustomerId = s.CustomerId;
            payableBalance.SalesmanId = s.SalesmanId;
            payableBalance.PaymentMethod = s.PaymentMethod;
            payableBalance.IsStatus = s.Status;
            payableBalance.Notes = s.Notes;
            payableBalance.GrandTotal = s.GrandTotal;
            payableBalance.AmountInWords = s.AmountInWords;
            payableBalance.DueDate = s.DueDate;
            payableBalance.TermOfPayment = s.TermOfPayment;

            List<PayableBalanceItem> payableBalanceItems=new List<PayableBalanceItem>();

            foreach (var salesItem in s.SalesItems)
            {
                PayableBalanceItem pbi = new PayableBalanceItem();

                pbi.PayableBalanceId = salesItem.SalesId;
                pbi.ProductId = salesItem.ProductId;
                pbi.Qty = salesItem.Qty;
                pbi.Price = salesItem.Price;

                payableBalanceItems.Add(pbi);
            }

            payableBalance.PayableBalanceItems = payableBalanceItems;

        }



        private void SalesToPayableBalance()
        {
            var sales = salesRepository.GetByStatusFalse();
    
            foreach (var s in sales)
            {
                var oldPayableBalance = payableBalanceRepository.GetByMonthYear(Store.ActiveMonth, Store.ActiveYear, s.Code);

                PayableBalance payableBalance = new PayableBalance();

                if (oldPayableBalance == null)
                {
                    CopyToPayableBalance(s, payableBalance);
                    payableBalanceRepository.SaveFromClosingPeriod(payableBalance);
                }
                else
                {
                    payableBalance.ID = oldPayableBalance.ID;
                    CopyToPayableBalance(s, payableBalance);

                    //payableBalance.BalanceYear = Store.ActiveYear;
                    //payableBalance.BalanceMonth = Store.ActiveMonth;
                    //payableBalance.SalesCode = s.Code;
                    //payableBalance.SalesDate = s.Date;
                    //payableBalance.CustomerId = s.CustomerId;
                    //payableBalance.SalesmanId = s.SalesmanId;
                    //payableBalance.PaymentMethod = s.PaymentMethod;
                    //payableBalance.IsStatus = s.Status;
                    //payableBalance.Notes = s.Notes;
                    //payableBalance.GrandTotal = s.GrandTotal;
                    //payableBalance.AmountInWords = s.AmountInWords;
                    //payableBalance.DueDate = s.DueDate;

                    payableBalanceRepository.UpdateFromClosingPeriod(payableBalance);
                }
            }
        }

      

        private void PurchaseToDebtBalance()
        {
            var purchase = purchaseRepository.GetByStatusFalse();

            foreach (var s in purchase)
            {
                var oldDebtBalance = debtBalanceRepository.GetByMonthYear(Store.ActiveMonth, Store.ActiveYear, s.Code);

                DebtBalance debtBalance = new DebtBalance();
                if (oldDebtBalance == null) 
                {
                    debtBalance.BalanceYear = Store.ActiveYear;
                    debtBalance.BalanceMonth = Store.ActiveMonth;
                    debtBalance.PurchaseCode = s.Code;
                    debtBalance.PurchaseDate = s.Date;
                    debtBalance.SupplierId = s.SupplierId;
                    debtBalance.PaymentMethod = s.PaymentMethod;
                    debtBalance.IsStatus = s.Status;
                    debtBalance.Notes = s.Notes;
                    debtBalance.GrandTotal = s.GrandTotal;
                    debtBalance.AmountInWords = s.AmountInWords;
                    debtBalance.DueDate = s.DueDate;
                    debtBalance.TermOfPayment = s.TermOfPayment;

                    debtBalanceRepository.SaveFromClosingPeriod(debtBalance);
                }
                else
                {
                    debtBalance.ID = oldDebtBalance.ID;
                    debtBalance.BalanceYear = Store.ActiveYear;
                    debtBalance.BalanceMonth = Store.ActiveMonth;
                    debtBalance.PurchaseCode = s.Code;
                    debtBalance.PurchaseDate = s.Date;
                    debtBalance.SupplierId = s.SupplierId;
                    debtBalance.PaymentMethod = s.PaymentMethod;
                    debtBalance.IsStatus = s.Status;
                    debtBalance.Notes = s.Notes;
                    debtBalance.GrandTotal = s.GrandTotal;
                    debtBalance.AmountInWords = s.AmountInWords;
                    debtBalance.DueDate = s.DueDate;
                    debtBalance.TermOfPayment = s.TermOfPayment;

                    debtBalanceRepository.UpdateFromClosingPeriod(debtBalance);

                }
            }
        }

        private void UpdateRecordCounterStatus()
        {
            //ubah status periode jadi closed
            recordCounterRepository.UpdateClosingStatus(Store.ActiveMonth, Store.ActiveYear);
            Store.IsPeriodClosed = recordCounterRepository.IsPeriodClosed(Store.ActiveMonth, Store.ActiveYear);

            int newYear = 0;
            int newMonth = 0;
            if (Store.ActiveMonth < 12)
            {
                newYear = Store.ActiveYear;
                newMonth = Store.ActiveMonth + 1;
            }
            else
            {
                newYear = Store.ActiveYear + 1;
                newMonth = 1;
            }

            var oldRecordCounter = recordCounterRepository.GetByMonthAndYear(newMonth, newYear);

            if (oldRecordCounter == null)
            {
                //buat periode baru
                RecordCounter recordCounter = new RecordCounter();

                recordCounter.ActiveYear = newYear;
                recordCounter.ActiveMonth = newMonth;
                recordCounter.SalesCounter = 0;
                recordCounter.PurchaseCounter = 0;
                recordCounter.ExpenseCounter = 0;
                recordCounter.PayablePaymentCounter = 0;
                recordCounter.DebtPaymentCounter = 0;
                recordCounter.BillReceiptCounter = 0;
                recordCounter.StockCorrectionCounter = 0;
                recordCounter.ClosingStatus = false;

                recordCounterRepository.Save(recordCounter);
            }
           

            

        }

        private void SalesmanFeeNewPeriod()
        {
            //cek periode baru
            int newYear = 0;
            int newMonth = 0;
            if (Store.ActiveMonth < 12)
            {
                newYear = Store.ActiveYear;
                newMonth = Store.ActiveMonth + 1;
            }
            else
            {
                newYear = Store.ActiveYear + 1;
                newMonth = 1;
            }

            SalesmanFee salesmanFee = new SalesmanFee();
            var newSalesman = salesmanFeeRepository.GetAll(newMonth, newYear);

            if (newSalesman.Count == 0)
            {
                var salesmanFees = salesmanFeeRepository.GetByActivePeriod(Store.ActiveMonth, Store.ActiveYear);
                foreach (var s in salesmanFees)
                {
                    salesmanFee.ActiveYear = newYear;
                    salesmanFee.ActiveMonth = newMonth;
                    salesmanFee.FeePercentage = s.FeePercentage;
                    salesmanFee.SalesmanId = s.SalesmanId;

                    salesmanFeeRepository.Save(salesmanFee);
                }
            }
            else
            {
                foreach (var newS in newSalesman)
                {
                    //cari data lama
                    var oldSalesmanFee = salesmanFeeRepository.GetByActivePeriod(Store.ActiveMonth, Store.ActiveYear);

                    foreach (var p1 in oldSalesmanFee)
                    {
                        salesmanFee.ID = newS.ID;
                        salesmanFee.ActiveYear = newYear;
                        salesmanFee.ActiveMonth = newMonth;
                        salesmanFee.FeePercentage = p1.FeePercentage;
                        salesmanFee.SalesmanId = newS.SalesmanId;

                        salesmanFeeRepository.Update(salesmanFee);
                        

                    }
                }
            }

        }

        private void ProductQtyNewPeriod()
        {
            

            //cek periode baru
            int newYear = 0;
            int newMonth = 0;
            if (Store.ActiveMonth < 12)
            {
                newYear = Store.ActiveYear;
                newMonth = Store.ActiveMonth + 1;
            }
            else
            {
                newYear = Store.ActiveYear + 1;
                newMonth = 1;
            }

            ProductQty productQty = new ProductQty();

            var newQty = productQtyRepository.GetAll(newMonth, newYear);

            if (newQty.Count == 0)
            {
                //cari data lama
                var oldQty = productQtyRepository.GetAll(Store.ActiveMonth, Store.ActiveYear);

                foreach (var p in oldQty)
                {
                    
                    productQty.ActiveYear = newYear;
                    productQty.ActiveMonth = newMonth;
                    productQty.ProductId = p.ProductId;
                    productQty.QtyBegin = p.QtyEnd;
                    productQty.ValueBegin = p.ValueEnd;
                    productQty.QtyIn = 0;
                    productQty.PurchasePrice = 0;
                    productQty.QtyAvailable = 0;
                    productQty.ValueAverage = 0;
                    productQty.ValueAvailable = 0;
                    productQty.QtyOut = 0;
                    productQty.SalesPrice = 0;
                    productQty.QtyEnd = p.QtyEnd;
                    productQty.ValueEnd = p.ValueEnd;
                    productQty.QtyPlusCorrection = 0;
                    productQty.QtyMinusCorrection = 0;
                    productQty.ValuePlusCorrection = 0;
                    productQty.ValueMinusCorrection = 0;

                    productQtyRepository.Save(productQty);
                }
            }
            else
            {
                foreach (var newQ in newQty)
                {
                    //cari data lama
                    var oldQty1 = productQtyRepository.GetByMonthAndYear(Store.ActiveMonth, Store.ActiveYear, newQ.ProductId);

                    if (oldQty1 != null)
                    {
                        productQtyRepository.UpdateQtyBegin(newMonth, newYear, oldQty1.ProductId, oldQty1.QtyEnd, oldQty1.ValueEnd);
                    }
                }
                inventoryRepository.GenerateInventory(newMonth, newYear);
            }

        }




        private void btnOk_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin ingin menutup Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "'", "Perhatian",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Application.UseWaitCursor = true;

                inventoryRepository.GenerateInventory(Store.ActiveMonth, Store.ActiveYear);

                SalesToPayableBalance();
                PurchaseToDebtBalance();
                UpdateRecordCounterStatus();
                SalesmanFeeNewPeriod();
                ProductQtyNewPeriod();


                Application.UseWaitCursor = false;
                MessageBox.Show("Proses Tutup Buku \n\n Periode : " + Store.GetMonthName(Store.ActiveMonth) + " " + Store.ActiveYear + "' \n\n Sukses", "Sukses",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
