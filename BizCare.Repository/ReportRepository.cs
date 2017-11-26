using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace BizCare.Repository
{
    public class ReportRepository
    {

        public void GetPurchaseRecap(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.ID, Purchase.DueDate, Purchase.PaymentMethod, Purchase.Status, Purchase.Notes, "
                         + "Purchase.GrandTotal, Purchase.AmountInWords, Purchase.PrintCounter, Supplier.SupplierName, Purchase.TermOfPayment "
                         + "FROM (Purchase INNER JOIN "
                         + "Supplier ON Purchase.SupplierId = Supplier.ID) "
                              + "WHERE Purchase.PurchaseDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PurchaseHeader");

                da.Dispose();
                cmd.Dispose();
            }
        }



        public void GetPurchaseDetail(DataSet ds,DateTime from,DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.PaymentMethod, Purchase.Status, Purchase.GrandTotal, Purchase.Notes, PurchaseItem.Qty, "
                              + "PurchaseItem.Price, PurchaseItem.Notes AS Expr1, Product.ProductCode, Product.ProductName, Product.CategoryId, Product.Unit, Supplier.SupplierName, "
                              + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                              + "FROM (((Purchase INNER JOIN "
                              + "PurchaseItem ON Purchase.ID = PurchaseItem.PurchaseId) INNER JOIN "
                              + "Product ON PurchaseItem.ProductId = Product.ID) INNER JOIN "
                              + "Supplier ON Purchase.SupplierId = Supplier.ID) "
                              + "WHERE Purchase.PurchaseDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";
                    

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Purchase");

                ds.Dispose();
                cmd.Dispose();            
            }
        }


        public void GetPurchasePerProduct(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.PaymentMethod, Purchase.Status, Purchase.GrandTotal, Purchase.Notes, PurchaseItem.Qty, "
                              + "PurchaseItem.Price, PurchaseItem.Notes AS Expr1, Product.ProductCode, Product.ProductName, Product.CategoryId, Product.Unit, Supplier.SupplierName, "
                              + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                              + "FROM (((Purchase INNER JOIN "
                              + "PurchaseItem ON Purchase.ID = PurchaseItem.PurchaseId) INNER JOIN "
                              + "Product ON PurchaseItem.ProductId = Product.ID) INNER JOIN "
                              + "Supplier ON Purchase.SupplierId = Supplier.ID) "
                              + "WHERE Purchase.PurchaseDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
            
                da.Fill(ds, "Purchase");

                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetPurchaseUnPaidSupplier(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.PaymentMethod, Purchase.Status, Purchase.Notes, Purchase.GrandTotal, Supplier.SupplierName, "
                              + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                             + "FROM (Purchase INNER JOIN "
                             + "Supplier ON Purchase.SupplierId = Supplier.ID) "
                             + "WHERE "
                             + "Purchase.Status = false";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PurchaseHeader");

                da.Dispose();
                cmd.Dispose();
            }
        }



        public void GetSales(DataSet ds,string salesCode)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Sales.SalesCode, Sales.SalesDate, Sales.DueDate, Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, Sales.AmountInWords, Sales.PrintCounter, Sales.TermOfPayment, "
                             + "Salesman.SalesmanName, Customer.CustomerName, SalesItem.Qty, SalesItem.Price, Product.ProductCode, Product.ProductName, Product.Unit, Category.ID, "
                             + "Customer.Address, Customer.Phone "
                             + "FROM (((((Sales INNER JOIN "
                             + "SalesItem ON Sales.ID = SalesItem.SalesId) INNER JOIN "
                             + "Product ON SalesItem.ProductId = Product.ID) INNER JOIN "
                             + "Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) INNER JOIN "
                             + "Category ON Product.CategoryId = Category.ID) "
                             + "WHERE Sales.SalesCode='" + salesCode + "'";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Sales");

                da.Dispose();
                cmd.Dispose();
            }
        }



        public void GetSalesRecap(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Sales.SalesCode, Sales.SalesDate, Sales.DueDate, Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, Sales.AmountInWords, Sales.PrintCounter, "
                         + "Salesman.SalesmanName, Customer.CustomerName, Sales.TermOfPayment "
                         + "FROM ((Sales INNER JOIN "
                         + "Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                         + "Salesman ON Sales.SalesmanId = Salesman.ID) "
                             + "WHERE Sales.SalesDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "SalesHeader");

                ds.Dispose();
                cmd.Dispose();
            }
        }



        public void GetSalesDetail(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, Salesman.SalesmanName, "
                             + "Customer.CustomerName, Product.ProductCode, Product.ProductName, Product.CategoryId, Product.Unit, SalesItem.Qty, SalesItem.Price, "
                             + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment "
                             + "FROM ((SalesItem INNER JOIN "
                             + "Product ON SalesItem.ProductId = Product.ID) INNER JOIN "
                             + "((Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) ON SalesItem.SalesId = Sales.ID)"
                              + "WHERE Sales.SalesDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Sales");

                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetSalesPerProduct(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Sales.ID, Sales.SalesCode, Sales.SalesDate, Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, Salesman.SalesmanName, "
                             + "Customer.CustomerName, Product.ProductCode, Product.ProductName, Product.CategoryId, Product.Unit, SalesItem.Qty, SalesItem.Price, "
                             + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment "
                             + "FROM ((SalesItem INNER JOIN "
                             + "Product ON SalesItem.ProductId = Product.ID) INNER JOIN "
                             + "((Sales INNER JOIN Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) ON SalesItem.SalesId = Sales.ID)"
                              + "WHERE Sales.SalesDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Sales");

                da.Dispose();
                cmd.Dispose();
            
            }
        }


        public void GetSalesUnPaidSalesman(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Sales.SalesCode, Sales.SalesDate, Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, Salesman.SalesmanName, Salesman.IsActive, "
                             + "Customer.CustomerName, Customer.IsActive AS Expr1, Customer.Plafon, "
                             + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment "
                             + "FROM ((Sales INNER JOIN "
                             + "Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) "
                             + "WHERE "
                             + "Sales.Status = false";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "SalesHeader");

                ds.Dispose();
                cmd.Dispose();
            }
        }


        public void GetSalesUnPaidCustomer(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Sales.SalesCode, Sales.SalesDate, Sales.PaymentMethod, Sales.Status, Sales.Notes, Sales.GrandTotal, Salesman.SalesmanName, Salesman.IsActive, "
                             + "Customer.CustomerName, Customer.IsActive AS Expr1, Customer.Plafon, "
                             + "Sales.AmountInWords, Sales.DueDate, Sales.PrintCounter, Sales.TermOfPayment "
                             + "FROM ((Sales INNER JOIN "
                             + "Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) "
                             + "WHERE "
                             + "Sales.Status = false";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "SalesHeader");

                ds.Dispose();
                cmd.Dispose();
            }
        }



        public void GetDebtPaymentRecap(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT ID, PaymentCode, PaymentDate, TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy "
                             + "FROM DebtPayment "
                             + "WHERE DebtPayment.PaymentDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "DebtPaymentHeader");
                ds.Dispose();
                cmd.Dispose();
            }
        }



        public void GetDebtPaymentDetail(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT DebtPayment.PaymentCode, DebtPayment.PaymentDate, DebtPayment.TotalCash, DebtPayment.TotalBank, DebtPayment.TotalGiro, DebtPayment.TotalCorrection, "
                             + "DebtPayment.GrandTotal, DebtPayment.Notes, DebtPaymentItem.Cash, DebtPaymentItem.Bank, DebtPaymentItem.Giro, DebtPaymentItem.GiroNumber, "
                             + "DebtPaymentItem.Correction, DebtPaymentItem.Total, DebtPaymentItem.Notes AS ItemNotes, Purchase.PurchaseCode, Purchase.PurchaseDate, "
                             + "Purchase.PaymentMethod, Purchase.Status, Purchase.Notes AS PurchaseNotes, Purchase.GrandTotal AS PurchaseGrandTotal, Supplier.SupplierName "
                             + "FROM (DebtPayment INNER JOIN "
                             + "((Supplier INNER JOIN "
                             + "Purchase ON Supplier.ID = Purchase.SupplierId) INNER JOIN "
                             + "DebtPaymentItem ON Purchase.ID = DebtPaymentItem.PurchaseId) ON DebtPayment.ID = DebtPaymentItem.DebtPaymentId) "
                              + "WHERE DebtPayment.PaymentDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "DebtPayment");

                da.Dispose();
                cmd.Dispose();
            }
        }



        public void GetPayablePaymentDetail(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT PayablePayment.PaymentCode, PayablePayment.PaymentDate, PayablePayment.TotalCash, PayablePayment.TotalBank, PayablePayment.TotalGiro, "
                             + "PayablePayment.TotalCorrection, PayablePayment.GrandTotal, PayablePayment.Notes, PayablePaymentItem.Cash, PayablePaymentItem.Bank, "
                             + "PayablePaymentItem.Giro, PayablePaymentItem.GiroNumber, PayablePaymentItem.Correction, PayablePaymentItem.Total, Sales.SalesCode, Sales.SalesDate, "
                             + "Sales.PaymentMethod, Sales.Status, Sales.Notes AS SalesNotes, Sales.GrandTotal AS SalesGrandTotal, Customer.CustomerName, Salesman.SalesmanName "
                             + "FROM (PayablePayment INNER JOIN "
                             + "(((Customer INNER JOIN "
                             + "Sales ON Customer.ID = Sales.CustomerId) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) INNER JOIN "
                             + "PayablePaymentItem ON Sales.ID = PayablePaymentItem.SalesId) ON PayablePayment.ID = PayablePaymentItem.PayablePaymentId) "
                              + "WHERE PayablePayment.PaymentDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                
                da.Fill(ds, "PayablePayment");
                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetPayablePaymentRecap(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT ID, PaymentCode, PaymentDate, TotalCash, TotalBank, TotalGiro, TotalCorrection, GrandTotal, Notes, CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                              + "FROM PayablePayment "
                              + "WHERE PayablePayment.PaymentDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PayablePaymentHeader");
                ds.Dispose();
                cmd.Dispose();
            }
        }

        public void GetPayablePaymentRecapCustomer(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT PayablePayment.PaymentCode, PayablePayment.PaymentDate, PayablePayment.TotalCash, PayablePayment.TotalBank, PayablePayment.TotalGiro, "
                             + "PayablePayment.TotalCorrection, PayablePayment.GrandTotal, PayablePayment.Notes, PayablePaymentItem.Cash, PayablePaymentItem.Bank, "
                             + "PayablePaymentItem.Giro, PayablePaymentItem.GiroNumber, PayablePaymentItem.Correction, PayablePaymentItem.Total, Sales.SalesCode, Sales.SalesDate, "
                             + "Sales.PaymentMethod, Sales.Status, Sales.Notes AS SalesNotes, Sales.GrandTotal AS SalesGrandTotal, Customer.CustomerName, Salesman.SalesmanName "
                             + "FROM (PayablePayment INNER JOIN "
                             + "(((Customer INNER JOIN "
                             + "Sales ON Customer.ID = Sales.CustomerId) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) INNER JOIN "
                             + "PayablePaymentItem ON Sales.ID = PayablePaymentItem.SalesId) ON PayablePayment.ID = PayablePaymentItem.PayablePaymentId) "
                              + "WHERE PayablePayment.PaymentDate BETWEEN #" + from.ToShortDateString() + "# "
                              + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PayablePayment");
                ds.Dispose();
                cmd.Dispose();
            }
        }


        public void GetPayablePaymentRecapSalesman(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {

                conn.Open();

                string sql = "SELECT PayablePayment.PaymentCode, PayablePayment.PaymentDate, PayablePayment.TotalCash, PayablePayment.TotalBank, PayablePayment.TotalGiro, "
                             + "PayablePayment.TotalCorrection, PayablePayment.GrandTotal, PayablePayment.Notes, PayablePaymentItem.Cash, PayablePaymentItem.Bank, "
                             + "PayablePaymentItem.Giro, PayablePaymentItem.GiroNumber, PayablePaymentItem.Correction, PayablePaymentItem.Total, Sales.SalesCode, Sales.SalesDate, "
                             + "Sales.PaymentMethod, Sales.Status, Sales.Notes AS SalesNotes, Sales.GrandTotal AS SalesGrandTotal, Customer.CustomerName, Salesman.SalesmanName "
                             + "FROM (PayablePayment INNER JOIN "
                             + "(((Customer INNER JOIN "
                             + "Sales ON Customer.ID = Sales.CustomerId) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) INNER JOIN "
                             + "PayablePaymentItem ON Sales.ID = PayablePaymentItem.SalesId) ON PayablePayment.ID = PayablePaymentItem.PayablePaymentId) "
                                + "WHERE PayablePayment.PaymentDate BETWEEN #" + from.ToShortDateString() + "# "
                                + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PayablePayment");
                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetExpense(DataSet ds, string expenseCode)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Expense.ExpenseCode, Expense.ExpenseDate, Expense.AccountType, Expense.AccountName, Expense.AccountNumber, Expense.GrandTotal, Expense.Notes, "
                         + "Expense.AmountInWords, Expense.PrintCounter, ExpenseItem.Total, ExpenseItem.Notes AS DetailNotes "
                         + "FROM (Expense INNER JOIN "
                         + "ExpenseItem ON Expense.ID = ExpenseItem.ExpenseId) "
                         + "WHERE Expense.ExpenseCode='" + expenseCode + "'";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Expense");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetExpenseRecap(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT ID, ExpenseDate, ExpenseCode, AccountType, AccountName, AccountNumber, GrandTotal, Notes, AmountInWords, PrintCounter "
                    + "FROM Expense "
                    + "WHERE ExpenseDate BETWEEN #" + from.ToShortDateString() + "# "
                    + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "ExpenseHeader");

                da.Dispose();
                cmd.Dispose();
            }
        }



        public void GetExpenseDetail(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Expense.ExpenseCode, Expense.ExpenseDate, Expense.AccountType, Expense.AccountName, Expense.AccountNumber, Expense.GrandTotal, Expense.Notes, "
                         + "Expense.AmountInWords, Expense.PrintCounter, ExpenseItem.Total, ExpenseItem.Notes AS DetailNotes "
                         + "FROM (Expense INNER JOIN "
                         + "ExpenseItem ON Expense.ID = ExpenseItem.ExpenseId) "
                         + "WHERE Expense.ExpenseDate BETWEEN #" + from.ToShortDateString() + "# "
                         + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Expense");
                da.Dispose();
                cmd.Dispose();            
            }
        }

        public void GetBillReceipt(DataSet ds, string billReceiptCode)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT BillReceipt.BillReceiptCode, BillReceipt.BillReceiptDate, BillReceipt.GrandTotal, BillReceipt.Notes, BillReceipt.PrintCounter, BillReceiptItem.Total, "
                         + "BillReceiptItem.Notes AS DetailNotes, Sales.SalesCode, Sales.SalesDate, Sales.DueDate, Sales.PaymentMethod, Sales.Status, "
                         + "Customer.CustomerName, Salesman.SalesmanName "
                         + "FROM (((Customer INNER JOIN "
                         + "Sales ON Customer.ID = Sales.CustomerId) INNER JOIN "
                         + "Salesman ON Sales.SalesmanId = Salesman.ID) INNER JOIN "
                         + "(BillReceipt INNER JOIN "
                         + "BillReceiptItem ON BillReceipt.ID = BillReceiptItem.BillReceiptId) ON Sales.ID = BillReceiptItem.SalesId) "
                              + "WHERE BillReceipt.BillReceiptCode='" + billReceiptCode + "'";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "BillReceipt");

                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetBillReceiptDetail(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT BillReceipt.BillReceiptCode, BillReceipt.BillReceiptDate, BillReceipt.GrandTotal, BillReceipt.Notes, BillReceiptItem.Total, Sales.SalesCode, Sales.SalesDate, "
                             + "Sales.PaymentMethod, Sales.Status, Salesman.SalesmanName, Customer.CustomerName "
                             + "FROM ((((BillReceipt INNER JOIN "
                             + "BillReceiptItem ON BillReceipt.ID = BillReceiptItem.BillReceiptId) INNER JOIN "
                             + "Sales ON BillReceiptItem.SalesId = Sales.ID) INNER JOIN "
                             + "Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID)";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "BillReceipt");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetBillReceiptRecap(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT BillReceipt.BillReceiptCode, BillReceipt.BillReceiptDate, BillReceipt.GrandTotal, BillReceipt.Notes, BillReceiptItem.Total, Sales.SalesCode, Sales.SalesDate, "
                             + "Sales.PaymentMethod, Sales.Status, Salesman.SalesmanName, Customer.CustomerName "
                             + "FROM ((((BillReceipt INNER JOIN "
                             + "BillReceiptItem ON BillReceipt.ID = BillReceiptItem.BillReceiptId) INNER JOIN "
                             + "Sales ON BillReceiptItem.SalesId = Sales.ID) INNER JOIN "
                             + "Customer ON Sales.CustomerId = Customer.ID) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) "
                             + "WHERE BillReceipt.BillReceiptDate BETWEEN #" + from.ToShortDateString() + "# "
                             + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "BillReceipt");

                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetInventory(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Product.ProductCode, Product.ProductName, Product.Unit, Product.Notes, Product.IsActive, ProductQty.QtyBegin, ProductQty.ValueBegin, ProductQty.QtyIn, "
                         + "ProductQty.PurchasePrice, ProductQty.QtyOut, ProductQty.SalesPrice, ProductQty.QtyAvailable, ProductQty.ValueAverage, ProductQty.ValueAvailable, "
                         + "ProductQty.QtyEnd, ProductQty.ValueEnd, ProductQty.ValuePlusCorrection, ProductQty.ValueMinusCorrection, ProductQty.QtyPlusCorrection, "
                         + "ProductQty.QtyMinusCorrection, Category.CategoryName "
                         + "FROM ((Product INNER JOIN "
                         + "ProductQty ON Product.ID = ProductQty.ProductId) INNER JOIN "
                         + "Category ON Product.CategoryId = Category.ID) "
                         + "WHERE ProductQty.ActiveMonth = " + month + " AND ProductQty.ActiveYear = " + year;

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Product");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetProduct(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Product.ProductCode, Product.ProductName, Product.Unit, Product.Notes, Product.IsActive, ProductQty.QtyBegin, ProductQty.ValueBegin, ProductQty.QtyIn, "
                         + "ProductQty.PurchasePrice, ProductQty.QtyOut, ProductQty.SalesPrice, ProductQty.QtyAvailable, ProductQty.ValueAverage, ProductQty.ValueAvailable, "
                         + "ProductQty.QtyEnd, ProductQty.ValueEnd, ProductQty.ValuePlusCorrection, ProductQty.ValueMinusCorrection, ProductQty.QtyPlusCorrection, "
                         + "ProductQty.QtyMinusCorrection, Category.CategoryName "
                         + "FROM ((Product INNER JOIN "
                         + "ProductQty ON Product.ID = ProductQty.ProductId) INNER JOIN "
                         + "Category ON Product.CategoryId = Category.ID) "
                         + "WHERE ProductQty.ActiveMonth = " + month + " AND ProductQty.ActiveYear = " + year;

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Product");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetProductMinus(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Product.ProductCode, Product.ProductName, Product.Unit, Product.Notes, Product.IsActive, ProductQty.QtyBegin, ProductQty.ValueBegin, ProductQty.QtyIn, "
                         + "ProductQty.PurchasePrice, ProductQty.QtyOut, ProductQty.SalesPrice, ProductQty.QtyAvailable, ProductQty.ValueAverage, ProductQty.ValueAvailable, "
                         + "ProductQty.QtyEnd, ProductQty.ValueEnd, ProductQty.ValuePlusCorrection, ProductQty.ValueMinusCorrection, ProductQty.QtyPlusCorrection, "
                         + "ProductQty.QtyMinusCorrection, Category.CategoryName "
                         + "FROM ((Product INNER JOIN "
                         + "ProductQty ON Product.ID = ProductQty.ProductId) INNER JOIN "
                         + "Category ON Product.CategoryId = Category.ID) "
                         + "WHERE ProductQty.QtyEnd<0 and ProductQty.ActiveMonth = " + month + " AND ProductQty.ActiveYear = " + year;

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Product");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetStockCorrection(DataSet ds, string stockCorrectionCode)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT StockCorrection.CorrectionCode, StockCorrection.CorrectionDate, StockCorrection.Notes, StockCorrection.PrintCounter, Product.ProductCode, Product.ProductName, "
                         + "Product.Unit, StockCorrectionItem.QtyPlus, StockCorrectionItem.QtyMinus, StockCorrectionItem.ValuePlus, StockCorrectionItem.ValueMinus, "
                         + "StockCorrectionItem.Notes AS DetailNotes, Category.CategoryName "
                         + "FROM (((StockCorrection INNER JOIN "
                         + "StockCorrectionItem ON StockCorrection.ID = StockCorrectionItem.StockCorrectionId) INNER JOIN "
                         + "Product ON StockCorrectionItem.ProductId = Product.ID) INNER JOIN "
                         + "Category ON Product.CategoryId = Category.ID) "
                        + "WHERE StockCorrection.CorrectionCode='" + stockCorrectionCode + "'";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "StockCorrection");

                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetStockCorrectionDetail(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT StockCorrection.CorrectionCode, StockCorrection.CorrectionDate, StockCorrection.Notes, StockCorrection.PrintCounter, Product.ProductCode, Product.ProductName, "
                         + "Product.Unit, StockCorrectionItem.QtyPlus, StockCorrectionItem.QtyMinus, StockCorrectionItem.ValuePlus, StockCorrectionItem.ValueMinus, "
                         + "StockCorrectionItem.Notes AS DetailNotes, Category.CategoryName "
                         + "FROM (((StockCorrection INNER JOIN "
                         + "StockCorrectionItem ON StockCorrection.ID = StockCorrectionItem.StockCorrectionId) INNER JOIN "
                         + "Product ON StockCorrectionItem.ProductId = Product.ID) INNER JOIN "
                         + "Category ON Product.CategoryId = Category.ID) "
                        + "WHERE StockCorrection.CorrectionDate BETWEEN #" + from.ToShortDateString() + "# "
                        + "AND #" + to.ToShortDateString() + "#";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "StockCorrection");

                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetStockCorrectionRecap(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT ID, CorrectionCode, CorrectionDate, Notes, PrintCounter, CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                            + "FROM StockCorrection " 
                            + "WHERE StockCorrection.CorrectionDate BETWEEN #" + from.ToShortDateString() + "# "
                            + "AND #" + to.ToShortDateString() + "#";


                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "StockCorrectionHeader");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetStockCorrectionProduct(DataSet ds, DateTime from, DateTime to)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT StockCorrection.CorrectionCode, StockCorrection.CorrectionDate, StockCorrection.Notes, StockCorrection.PrintCounter, Product.ProductCode, Product.ProductName, "
                         + "Product.Unit, StockCorrectionItem.QtyPlus, StockCorrectionItem.QtyMinus, StockCorrectionItem.ValuePlus, StockCorrectionItem.ValueMinus, "
                         + "StockCorrectionItem.Notes AS DetailNotes, Category.CategoryName "
                         + "FROM (((StockCorrection INNER JOIN "
                         + "StockCorrectionItem ON StockCorrection.ID = StockCorrectionItem.StockCorrectionId) INNER JOIN "
                         + "Product ON StockCorrectionItem.ProductId = Product.ID) INNER JOIN "
                         + "Category ON Product.CategoryId = Category.ID) "
                         + "WHERE StockCorrection.CorrectionDate BETWEEN #" + from.ToShortDateString() + "# "
                            + "AND #" + to.ToShortDateString() + "#";


                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "StockCorrection");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetSalesmanCommision(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT ActiveYear, ActiveMonth, SalesmanName, FeePercentage, "
                        + "PayablePaymentValue, CommisionValue, ID "
                        + "FROM SalesmanCommision "
                        + "WHERE ActiveMonth = " + month + " AND ActiveYear = " + year;


                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "SalesmanCommision");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetProfitStatementSales(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT RowNumber, SalesItem, PayablePaymentItem, ThisMonth, Cumulative, LastMonth, ID "
                    + "FROM ProfitStatement";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "ProfitStatement");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetProfitStatementPayablePayment(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT RowNumber, SalesItem, PayablePaymentItem, ThisMonth, Cumulative, LastMonth, ID "
                    + "FROM ProfitStatement";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "ProfitStatement");

                da.Dispose();
                cmd.Dispose();
            }
        }


        public void GetDebtBalance(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                int monthPeriod = 0;
                int yearPeriod = 0;
               
                if (month == 1)
                {
                    yearPeriod = year - 1;
                    monthPeriod = 12;
                }
                else
                {
                    yearPeriod = year;
                    monthPeriod = month - 1;
                }


                string sql = "SELECT DebtBalance.ID, DebtBalance.BalanceYear, DebtBalance.BalanceMonth, DebtBalance.PurchaseCode, DebtBalance.PurchaseDate, DebtBalance.DueDate, "
                         + "DebtBalance.PaymentMethod, DebtBalance.GrandTotal, DebtBalance.IsStatus, "
                         + "DebtBalance.Notes, DebtBalance.AmountInWords, Supplier.SupplierName, DebtBalance.TermOfPayment "
                         + "FROM (DebtBalance INNER JOIN "
                         + "Supplier ON DebtBalance.SupplierId = Supplier.ID) "
                         + "WHERE DebtBalance.BalanceMonth = " + monthPeriod + " AND DebtBalance.BalanceYear = " + yearPeriod;

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "DebtBalance");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetPayableBalanceDetail(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                int monthPeriod = 0;
                int yearPeriod = 0;

                if (month == 1)
                {
                    yearPeriod = year - 1;
                    monthPeriod = 12;
                }
                else
                {
                    yearPeriod = year;
                    monthPeriod = month - 1;
                }


                string sql = "SELECT PayableBalance.BalanceYear, PayableBalance.BalanceMonth, PayableBalance.SalesCode, PayableBalance.SalesDate, PayableBalance.DueDate, PayableBalance.TermOfPayment, "
                         + "PayableBalance.PaymentMethod, PayableBalance.GrandTotal, PayableBalance.IsStatus, PayableBalance.Notes, PayableBalance.AmountInWords, "
                         + "Customer.CustomerName, Salesman.SalesmanName, Product.ProductCode, Product.ProductName, Category.CategoryName, Product.Unit, PayableBalanceItem.Qty, "
                         + "PayableBalanceItem.Price "
                         + "FROM (((((PayableBalance INNER JOIN "
                         + "Customer ON PayableBalance.CustomerId = Customer.ID) INNER JOIN "
                         + "Salesman ON PayableBalance.SalesmanId = Salesman.ID) INNER JOIN "
                         + "PayableBalanceItem ON PayableBalance.ID = PayableBalanceItem.PayableBalanceId) INNER JOIN "
                         + "Product ON PayableBalanceItem.ProductId = Product.ID) INNER JOIN "
                         + "Category ON Product.CategoryId = Category.ID) "
                         + "WHERE PayableBalance.BalanceMonth = " + monthPeriod + " AND PayableBalance.BalanceYear = " + yearPeriod;

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PayableBalance");

                da.Dispose();
                cmd.Dispose();
            }
        }



        public void GetPayableBalanceRecap(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                int monthPeriod = 0;
                int yearPeriod = 0;

                if (month == 1)
                {
                    yearPeriod = year - 1;
                    monthPeriod = 12;
                }
                else
                {
                    yearPeriod = year;
                    monthPeriod = month - 1;
                }


                string sql = "SELECT PayableBalance.BalanceYear, PayableBalance.BalanceMonth, PayableBalance.SalesCode, PayableBalance.SalesDate, PayableBalance.DueDate, PayableBalance.TermOfPayment, "
                         + "PayableBalance.PaymentMethod, PayableBalance.GrandTotal, PayableBalance.IsStatus, PayableBalance.Notes, PayableBalance.AmountInWords, "
                         + "Salesman.SalesmanName, Customer.CustomerName "
                         + "FROM ((PayableBalance INNER JOIN "
                         + "Customer ON PayableBalance.CustomerId = Customer.ID) INNER JOIN "
                         + "Salesman ON PayableBalance.SalesmanId = Salesman.ID) "
                         + "WHERE PayableBalance.BalanceMonth = " + monthPeriod + " AND PayableBalance.BalanceYear = " + yearPeriod;

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PayableBalance");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetPurchase(DataSet ds, string purchaseCode)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Purchase.PurchaseCode, Purchase.PurchaseDate, Purchase.PaymentMethod, Purchase.Status, Purchase.GrandTotal, Purchase.Notes, PurchaseItem.Qty, "
                              + "PurchaseItem.Price, PurchaseItem.Notes AS Expr1, Product.ProductCode, Product.ProductName, Product.CategoryId, Product.Unit, Supplier.SupplierName, "
                              + "Purchase.AmountInWords, Purchase.DueDate, Purchase.PrintCounter, Purchase.TermOfPayment "
                              + "FROM (((Purchase INNER JOIN "
                              + "PurchaseItem ON Purchase.ID = PurchaseItem.PurchaseId) INNER JOIN "
                              + "Product ON PurchaseItem.ProductId = Product.ID) INNER JOIN "
                              + "Supplier ON Purchase.SupplierId = Supplier.ID) "
                              + "WHERE Purchase.PurchaseCode='" + purchaseCode + "'";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Purchase");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetPayablePayment(DataSet ds, string payablePaymentCode)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT PayablePayment.PaymentCode, PayablePayment.PaymentDate, PayablePayment.TotalCash, PayablePayment.TotalBank, PayablePayment.TotalGiro, "
                             + "PayablePayment.TotalCorrection, PayablePayment.GrandTotal, PayablePayment.Notes, PayablePaymentItem.Cash, PayablePaymentItem.Bank, "
                             + "PayablePaymentItem.Giro, PayablePaymentItem.GiroNumber, PayablePaymentItem.Correction, PayablePaymentItem.Total, Sales.SalesCode, Sales.SalesDate, "
                             + "Sales.PaymentMethod, Sales.Status, Sales.Notes AS SalesNotes, Sales.GrandTotal AS SalesGrandTotal, Customer.CustomerName, Salesman.SalesmanName "
                             + "FROM (PayablePayment INNER JOIN "
                             + "(((Customer INNER JOIN "
                             + "Sales ON Customer.ID = Sales.CustomerId) INNER JOIN "
                             + "Salesman ON Sales.SalesmanId = Salesman.ID) INNER JOIN "
                             + "PayablePaymentItem ON Sales.ID = PayablePaymentItem.SalesId) ON PayablePayment.ID = PayablePaymentItem.PayablePaymentId) "
                              + "WHERE PayablePayment.PaymentCode='" + payablePaymentCode + "'";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "PayablePayment");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetCustomer(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT * FROM CUSTOMER";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Customer");

                da.Dispose();
                cmd.Dispose();
            }
        }

        public void GetSupplier(DataSet ds)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT * FROM SUPPLIER";

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Supplier");

                da.Dispose();
                cmd.Dispose();
            }
        }
        public void GetSalesman(DataSet ds, int month, int year)
        {
            using (var conn = new OleDbConnection(Store.ConnStr))
            {
                conn.Open();

                string sql = "SELECT Salesman.SalesmanName, Salesman.Address, Salesman.Phone1, Salesman.Phone2, Salesman.Notes, Salesman.IsActive, SalesmanFee.FeePercentage, "
                         + "SalesmanFee.ActiveYear, SalesmanFee.ActiveMonth "
                         + "FROM (Salesman INNER JOIN "
                         + "SalesmanFee ON Salesman.ID = SalesmanFee.SalesmanId) "
                         + "WHERE SalesmanFee.ActiveMonth = " + month + " AND SalesmanFee.ActiveYear = " + year;

                var cmd = new OleDbCommand(sql, conn);
                var da = new OleDbDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds, "Salesman");

                da.Dispose();
                cmd.Dispose();
            }
        }












    }
}
