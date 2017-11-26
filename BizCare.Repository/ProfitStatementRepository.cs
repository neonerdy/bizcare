using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IProfitStatementRepository
    {
        List<ProfitStatement> GetAll();
        void GenerateProfitStatementSales(int month, int year);
        void GenerateProfitStatementPayablePayment(int month, int year);
        void UpdateSales(string salesItem, decimal lastMonth, decimal thisMonth, decimal cumulative);
        void UpdatePayment(string salesItem, decimal lastMonth, decimal thisMonth, decimal cumulative);        
        void UpdateToZero();
    }



    public class ProfitStatementRepository : IProfitStatementRepository
    {
        private DataSource ds;
        
        private string tableName = "ProfitStatement";
        private IInventoryRepository inventoryRepository;
        private IExpenseItemRepository expenseItemRepository;
        private IProductQtyRepository productQtyRepository; 

        public ProfitStatementRepository(DataSource ds)
        {
            this.ds = ds;
            inventoryRepository = ServiceLocator.GetObject<IInventoryRepository>();
            expenseItemRepository = ServiceLocator.GetObject<IExpenseItemRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
        }

        public List<ProfitStatement> GetAll()
        {
            List<ProfitStatement> profitStatement = new List<ProfitStatement>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).OrderBy("RowNumber ASC");
                profitStatement = em.ExecuteList<ProfitStatement>(q.ToSql(), new ProfitStatementMapper());
            }

            return profitStatement;
        }

        public void UpdateSales(string salesItem, decimal lastMonth, decimal thisMonth, decimal cumulative)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string sql = "UPDATE " + tableName + " SET LastMonth = " + lastMonth + ", "
                            + "ThisMonth = " + thisMonth + ", "
                             + "Cumulative = " + cumulative + " "
                              + " WHERE "
                            + "SalesItem = '" + salesItem + "'";

                    em.ExecuteNonQuery(sql);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePayment(string payablePaymentItem, decimal lastMonth, decimal thisMonth, decimal cumulative)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    string sql = "UPDATE " + tableName + " SET LastMonth = " + lastMonth + ", "
                            + "ThisMonth = " + thisMonth + ", "
                             + "Cumulative = " + cumulative + " "
                              + " WHERE "
                            + "PayablePaymentItem = '" + payablePaymentItem + "'";

                    em.ExecuteNonQuery(sql);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateToZero()
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                     var profitStatement = GetAll();
                     foreach (var p in profitStatement)
                     {
                         string sql = "UPDATE " + tableName + " SET LastMonth = " + 0 + ", "
                                 + "ThisMonth = " + 0 + ", "
                                  + "Cumulative = " + 0 + " "
                                   + " WHERE "
                                 + "SalesItem = '" + p.SalesItem + "'";

                         em.ExecuteNonQuery(sql);
                     }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GenerateProfitStatementSales(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int lastYearPeriod = 0;
                    int lastMonthPeriod = 0;

                    if (month == 1)
                    {
                        lastYearPeriod = year - 1;
                        lastMonthPeriod = 12;
                    }
                    else
                    {
                        lastYearPeriod = year;
                        lastMonthPeriod = month - 1;
                    }

                    inventoryRepository.GenerateInventory(month, year);
                    UpdateToZero();

                        //penjualan
                        decimal salesValueThisMonth = 0;
                        decimal salesValueLastMonth = 0;
                        decimal salesValueCumulative = 0;

                        //harga pokok penjualan
                        decimal salesPriceThisMonth = 0;
                        decimal salesPriceLastMonth = 0;
                        decimal salesPriceCumulative = 0;

                        //laba kotor
                        decimal grossProfitLastMonth = 0;
                        decimal grossProfitThisMonth = 0;
                        decimal grossProfitCumulative = 0;

                        //Biaya
                        decimal expenseThisMonth = 0;
                        decimal expenseLastMonth = 0;
                        decimal expenseCumulative = 0;

                        //laba bersih
                        decimal nettProfitLastMonth = 0;
                        decimal nettProfitThisMonth = 0;
                        decimal nettProfitCumulative = 0;


                        //PENJUALAN & HARGA POKOK PENJUALAN
                            //PRODUCT QTY  - LAST MONTH
                            var productQtyLastMonth = productQtyRepository.GetSummary(lastMonthPeriod, lastYearPeriod);
                            if(productQtyLastMonth != null)
                            {
                                salesValueLastMonth = productQtyLastMonth.SalesValue;
                                salesPriceLastMonth = productQtyLastMonth.SalesPrice;
                            }

                            //PRODUCT QTY  - THIS MONTH
                            var productQtyThisMonth = productQtyRepository.GetSummary(month, year);
                            if (productQtyThisMonth != null)
                            {
                                salesValueThisMonth = productQtyThisMonth.SalesValue;
                                salesPriceThisMonth = productQtyThisMonth.SalesPrice;
                            }
                            salesValueCumulative = salesValueLastMonth + salesValueThisMonth;
                            salesPriceCumulative = salesPriceLastMonth + salesPriceThisMonth;

                        //LABA KOTOR
                        grossProfitLastMonth = salesValueLastMonth - salesPriceLastMonth;
                        grossProfitThisMonth = salesValueThisMonth - salesPriceThisMonth;
                        grossProfitCumulative = grossProfitLastMonth + grossProfitThisMonth;


                        //BIAYA
                        expenseLastMonth = expenseItemRepository.GetSummary(lastMonthPeriod, lastYearPeriod);
                        expenseThisMonth = expenseItemRepository.GetSummary(month, year);
                        expenseCumulative = expenseThisMonth + expenseLastMonth;


                        //LABA BERSIH
                        nettProfitLastMonth = grossProfitLastMonth - expenseLastMonth;
                        nettProfitThisMonth = grossProfitThisMonth - expenseThisMonth;
                        nettProfitCumulative = nettProfitLastMonth + nettProfitThisMonth;


                        var profitStatement = GetAll();
                        foreach (var p in profitStatement)
                        {
                            string salesItem = p.SalesItem;
                            decimal lastMonth = 0;
                            decimal thisMonth = 0;
                            decimal cumulative = 0;

                            if (salesItem == "PENJUALAN") {
                                lastMonth = salesValueLastMonth;
                                thisMonth = salesValueThisMonth;
                                cumulative = salesValueCumulative;

                                UpdateSales(salesItem, lastMonth, thisMonth, cumulative);
                            }
                            else if (salesItem == "HARGA POKOK PENJUALAN")
                            {
                                lastMonth = salesPriceLastMonth;
                                thisMonth = salesPriceThisMonth;
                                cumulative = salesPriceCumulative;

                                UpdateSales(salesItem, lastMonth, thisMonth, cumulative);
                            }
                            else if (salesItem == "LABA (RUGI) KOTOR")
                            {
                                lastMonth = grossProfitLastMonth;
                                thisMonth = grossProfitThisMonth;
                                cumulative = grossProfitCumulative;

                                UpdateSales(salesItem, lastMonth, thisMonth, cumulative);
                            }
                            else if (salesItem == "BIAYA")
                            {
                                lastMonth = expenseLastMonth;
                                thisMonth = expenseThisMonth;
                                cumulative = expenseCumulative;

                                UpdateSales(salesItem, lastMonth, thisMonth, cumulative);
                            }
                            else if (salesItem == "LABA (RUGI) BERSIH")
                            {
                                lastMonth = nettProfitLastMonth;
                                thisMonth = nettProfitThisMonth;
                                cumulative = nettProfitCumulative;

                                UpdateSales(salesItem, lastMonth, thisMonth, cumulative);
                            }


                      
                        
                        }

                  
                }
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }


        public void GenerateProfitStatementPayablePayment(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {

                    int lastYearPeriod = 0;
                    int lastMonthPeriod = 0;

                    if (month == 1)
                    {
                        lastYearPeriod = year - 1;
                        lastMonthPeriod = 12;
                    }
                    else
                    {
                        lastYearPeriod = year;
                        lastMonthPeriod = month - 1;
                    }

                    inventoryRepository.GenerateInventory(month, year);
                    UpdateToZero();

                    //penagihan
                    decimal paymentValueThisMonth = 0;
                    decimal paymentValueLastMonth = 0;
                    decimal paymentValueCumulative = 0;

                    //harga pokok penjualan
                    decimal paymentPriceThisMonth = 0;
                    decimal paymentPriceLastMonth = 0;
                    decimal paymentPriceCumulative = 0;

                    //laba kotor
                    decimal grossProfitLastMonth = 0;
                    decimal grossProfitThisMonth = 0;
                    decimal grossProfitCumulative = 0;

                    //Biaya
                    decimal expenseThisMonth = 0;
                    decimal expenseLastMonth = 0;
                    decimal expenseCumulative = 0;

                    //laba bersih
                    decimal nettProfitLastMonth = 0;
                    decimal nettProfitThisMonth = 0;
                    decimal nettProfitCumulative = 0;


                    //PENJUALAN & HARGA POKOK PENJUALAN
                    //PRODUCT QTY  - LAST MONTH
                    var productQtyLastMonth = productQtyRepository.GetSummary(lastMonthPeriod, lastYearPeriod);
                    if (productQtyLastMonth != null)
                    {
                        paymentValueLastMonth = productQtyLastMonth.PaymentValue;
                        paymentPriceLastMonth = productQtyLastMonth.PaymentPrice;
                    }

                    //PRODUCT QTY  - THIS MONTH
                    var productQtyThisMonth = productQtyRepository.GetSummary(month, year);
                    if (productQtyThisMonth != null)
                    {
                        paymentValueThisMonth = productQtyThisMonth.PaymentValue;
                        paymentPriceThisMonth = productQtyThisMonth.PaymentPrice;
                    }
                    paymentValueCumulative = paymentValueLastMonth + paymentValueThisMonth;
                    paymentPriceCumulative = paymentPriceLastMonth + paymentPriceThisMonth;

                    //LABA KOTOR
                    grossProfitLastMonth = paymentValueLastMonth - paymentPriceLastMonth;
                    grossProfitThisMonth = paymentValueThisMonth - paymentPriceThisMonth;
                    grossProfitCumulative = grossProfitLastMonth + grossProfitThisMonth;


                    //BIAYA
                    expenseLastMonth = expenseItemRepository.GetSummary(lastMonthPeriod, lastYearPeriod);
                    expenseThisMonth = expenseItemRepository.GetSummary(month, year);
                    expenseCumulative = expenseThisMonth + expenseLastMonth;


                    //LABA BERSIH
                    nettProfitLastMonth = grossProfitLastMonth - expenseLastMonth;
                    nettProfitThisMonth = grossProfitThisMonth - expenseThisMonth;
                    nettProfitCumulative = nettProfitLastMonth + nettProfitThisMonth;


                    var profitStatement = GetAll();
                    foreach (var p in profitStatement)
                    {
                        string paymentItem = p.PayablePaymentItem;
                        decimal lastMonth = 0;
                        decimal thisMonth = 0;
                        decimal cumulative = 0;

                        if (paymentItem == "PENAGIHAN")
                        {
                            lastMonth = paymentValueLastMonth;
                            thisMonth = paymentValueThisMonth;
                            cumulative = paymentValueCumulative;

                            UpdatePayment(paymentItem, lastMonth, thisMonth, cumulative);
                        }
                        else if (paymentItem == "HARGA POKOK")
                        {
                            lastMonth = paymentPriceLastMonth;
                            thisMonth = paymentPriceThisMonth;
                            cumulative = paymentPriceCumulative;

                            UpdatePayment(paymentItem, lastMonth, thisMonth, cumulative);
                        }
                        else if (paymentItem == "LABA (RUGI) KOTOR")
                        {
                            lastMonth = grossProfitLastMonth;
                            thisMonth = grossProfitThisMonth;
                            cumulative = grossProfitCumulative;

                            UpdatePayment(paymentItem, lastMonth, thisMonth, cumulative);
                        }
                        else if (paymentItem == "BIAYA")
                        {
                            lastMonth = expenseLastMonth;
                            thisMonth = expenseThisMonth;
                            cumulative = expenseCumulative;

                            UpdatePayment(paymentItem, lastMonth, thisMonth, cumulative);
                        }
                        else if (paymentItem == "LABA (RUGI) BERSIH")
                        {
                            lastMonth = nettProfitLastMonth;
                            thisMonth = nettProfitThisMonth;
                            cumulative = nettProfitCumulative;

                            UpdatePayment(paymentItem, lastMonth, thisMonth, cumulative);
                        }




                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }














    }
}
