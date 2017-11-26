using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using System.Configuration;

namespace BizCare.Repository
{
    public class RepositoryRegistry : IRegistry
    {
        public void Configure()
        {
            
            string provider = ConfigurationManager.AppSettings["Provider"];
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                        
            DataSource ds = new DataSource(provider, connectionString);
            object[] depedency={ds};

            ServiceLocator.RegisterObject<ICustomerRepository, CustomerRepository>(depedency);
            ServiceLocator.RegisterObject<ISupplierRepository, SupplierRepository>(depedency);
            ServiceLocator.RegisterObject<IProductRepository, ProductRepository>(depedency);
            ServiceLocator.RegisterObject<ICategoryRepository, CategoryRepository>(depedency);
            ServiceLocator.RegisterObject<ISalesmanRepository, SalesmanRepository>(depedency);
            ServiceLocator.RegisterObject<IExpenseRepository, ExpenseRepository>(depedency);
            ServiceLocator.RegisterObject<ISalesmanRepository, SalesmanRepository>(depedency);
            ServiceLocator.RegisterObject<ICompanyRepository, CompanyRepository>(depedency);
            ServiceLocator.RegisterObject<IPayableBalanceRepository, PayableBalanceRepository>(depedency);
            ServiceLocator.RegisterObject<IPayableBalanceItemRepository, PayableBalanceItemRepository>(depedency);
            ServiceLocator.RegisterObject<IDebtBalanceRepository, DebtBalanceRepository>(depedency);
            ServiceLocator.RegisterObject<IUserLoginRepository, UserLoginRepository>(depedency);
            ServiceLocator.RegisterObject<ISalesRepository, SalesRepository>(depedency);
            ServiceLocator.RegisterObject<ISalesItemRepository, SalesItemRepository>(depedency);
            ServiceLocator.RegisterObject<IRecordCounterRepository, RecordCounterRepository>(depedency);
            ServiceLocator.RegisterObject<ISalesmanFeeRepository, SalesmanFeeRepository>(depedency);
            ServiceLocator.RegisterObject<IPurchaseRepository, PurchaseRepository>(depedency);
            ServiceLocator.RegisterObject<IPurchaseItemRepository, PurchaseItemRepository>(depedency);
            ServiceLocator.RegisterObject<IPayablePaymentRepository, PayablePaymentRepository>(depedency);
            ServiceLocator.RegisterObject<IPayablePaymentItemRepository, PayablePaymentItemRepository>(depedency);
            ServiceLocator.RegisterObject<IProductQtyRepository, ProductQtyRepository>(depedency);
            ServiceLocator.RegisterObject<IDebtPaymentRepository, DebtPaymentRepository>(depedency);
            ServiceLocator.RegisterObject<IDebtPaymentItemRepository, DebtPaymentItemRepository>(depedency);
            ServiceLocator.RegisterObject<IBillReceiptRepository, BillReceiptRepository>(depedency);
            ServiceLocator.RegisterObject<IBillReceiptItemRepository, BillReceiptItemRepository>(depedency);
            ServiceLocator.RegisterObject<IExpenseRepository, ExpenseRepository>(depedency);
            ServiceLocator.RegisterObject<IExpenseItemRepository, ExpenseItemRepository>(depedency);
            ServiceLocator.RegisterObject<IStockCorrectionRepository, StockCorrectionRepository>(depedency);
            ServiceLocator.RegisterObject<IStockCorrectionItemRepository, StockCorrectionItemRepository>(depedency);
            ServiceLocator.RegisterObject<IInventoryRepository, InventoryRepository>(depedency);
            ServiceLocator.RegisterObject<IProfitStatementRepository, ProfitStatementRepository>(depedency);
            ServiceLocator.RegisterObject<IUserAccessRepository, UserAccessRepository>(depedency);
        }


        public void Dispose()
        {
     
        }
    }
}
