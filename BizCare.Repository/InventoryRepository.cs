using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizCare.Model;
using EntityMap;
using BizCare.Repository.Mapping;


namespace BizCare.Repository
{
    public interface IInventoryRepository
    {
        void GenerateInventory(int month, int year);
    }

    public class InventoryRepository : IInventoryRepository
    {
        private DataSource ds;
        
        private string tableName = "Inventory";
        private IProductRepository productRepository;        
        private IProductQtyRepository productQtyRepository;
        private IPurchaseItemRepository purchaseItemRepository;
        private ISalesItemRepository salesItemRepository;
        private IStockCorrectionItemRepository stockCorrectionItemRepository;
        private IPayablePaymentItemRepository payablePaymentItemRepository;


        public InventoryRepository(DataSource ds)
        {
            this.ds = ds;
            productRepository = ServiceLocator.GetObject<IProductRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
            purchaseItemRepository = ServiceLocator.GetObject<IPurchaseItemRepository>();
            salesItemRepository = ServiceLocator.GetObject<ISalesItemRepository>();
            stockCorrectionItemRepository = ServiceLocator.GetObject<IStockCorrectionItemRepository>();
            payablePaymentItemRepository = ServiceLocator.GetObject<IPayablePaymentItemRepository>();
        }

        public void GenerateInventory(int month, int year)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                 
                    Guid productId = Guid.Empty;
                    string productCode = "";
                    string productName = "";
                    string productUnit = "";
                    string productCategory = "";

                    int qtyBegin = 0;
                    decimal valueBegin = 0;

                    int qtyIn = 0;
                    decimal purchasePriceTemp = 0;
                    decimal purchasePrice = 0;

                    int qtyAvailable = 0;
                    decimal valueAverage = 0; //harga rata2
                    decimal valueAvailable = 0; //harga pokok penjualan

                    int qtyOut = 0;
                    decimal salesPrice = 0;
                    decimal salesValue = 0;

                    int qtyEnd = 0;
                    decimal valueEnd = 0;
                    
                    int qtyPlusCorrection = 0;
                    int qtyMinusCorrection = 0;
                    decimal valuePlusCorrection = 0;
                    decimal valueMinusCorrection = 0;

                    int qtyPayment = 0;
                    decimal paymentPrice = 0;
                    decimal paymentValue = 0;

               
                    //PRODUCT
                    List<Product> products = productRepository.GetAll();

                    foreach (var p in products) 
                    {

                        productId = p.ID;
                        productCode = p.Code;
                        productName = p.Name;
                        productUnit = p.Unit;
                        productCategory = p.Category.Name;

                        qtyBegin = 0; //A = qty awal
                        valueBegin = 0; //B = nilai awal

                        qtyIn = 0; //C = qty beli
                        purchasePriceTemp = 0; //D = temporary per item barang (qty * price) 
                        purchasePrice = 0; //E = total pembelian per item barang

                        qtyAvailable = 0; //F = A + C
                        valueAverage = 0; //G = H : F
                        valueAvailable = 0; //H = B + E

                        qtyOut = 0;
                        salesPrice = 0;
                        salesValue = 0;

                        qtyEnd = 0;
                        valueEnd = 0;
                        
                        qtyPlusCorrection = 0;
                        qtyMinusCorrection = 0;
                        valuePlusCorrection = 0;
                        valueMinusCorrection = 0;

                        qtyPayment = 0;
                        paymentPrice = 0;
                        paymentValue = 0;
                        

                        //BEGIN
                        //PRODUCT QTY - cek qty begin & value begin
                        var productQty = productQtyRepository.GetByMonthAndYear(month, year, productId);
                        if (productQty != null) 
                        {
                            qtyBegin = productQty.QtyBegin;
                            valueBegin = productQty.ValueBegin;
                        }

                        //KOREKSI
                        List<StockCorrectionItem> stockCorrectionItem = stockCorrectionItemRepository.GetByMonthAndYear(month, year, productId);
                        foreach (var correction in stockCorrectionItem)
                        {
                            qtyPlusCorrection = qtyPlusCorrection + correction.QtyPlus;
                            qtyMinusCorrection = qtyMinusCorrection + correction.QtyMinus;
                            valuePlusCorrection = valuePlusCorrection + correction.ValuePlus;
                            valueMinusCorrection = valueMinusCorrection + correction.ValueMinus;
                        }
                        
                        //IN
                        //PURCHASE - get total qty & purchase price average
                        List<PurchaseItem> purchaseItems = purchaseItemRepository.GetByMonthAndYear(month, year, productId);
                        foreach (var purchase in purchaseItems)
                        {
                            qtyIn = qtyIn + purchase.Qty;
                            purchasePriceTemp = purchasePriceTemp + (purchase.Price * purchase.Qty);
                        }
                       
                        //pengaruh koreksi nilai
                        purchasePriceTemp = (purchasePriceTemp + valuePlusCorrection) - valueMinusCorrection;
                        if (qtyIn > 0)
                        {
                            purchasePrice = purchasePriceTemp / qtyIn;
                        }
                        else
                        {
                            purchasePrice = purchasePriceTemp;
                        }

                        //AVAILABLE
                        qtyAvailable = qtyBegin + qtyIn;
                        valueAvailable = valueBegin + purchasePrice;
                        if (qtyAvailable > 0) {
                            valueAverage = valueAvailable / qtyAvailable;
                        }

                        //OUT
                        //SALES - get total qty sales
                        List<SalesItem> salesItems = salesItemRepository.GetByMonthAndYear(month, year, productId);
                        foreach (var sales in salesItems)
                        {
                            qtyOut = qtyOut + sales.Qty;
                            salesValue = salesValue + (sales.Qty * sales.Price);
                        }
                        qtyOut = (qtyOut + qtyMinusCorrection) - qtyPlusCorrection;
                        salesPrice = qtyOut * valueAverage;


                        //END
                        qtyEnd = qtyAvailable - qtyOut;
                        valueEnd = valueAvailable - salesPrice;


                        //PAYMENT
                        List<PaymentItemQty> paymentItemQty = payablePaymentItemRepository.GetPaymentItemQty(month, year, productId);
                        foreach (var payment in paymentItemQty)
                        {
                            qtyPayment = qtyPayment + payment.Qty;
                            paymentValue = paymentValue + payment.Total;
                        }
                        paymentPrice = qtyPayment * valueAverage;



                        //PRODUCT QTY - update
                        productQtyRepository.UpdateQtyFromInventory(month, year, productId,
                            qtyIn, purchasePrice, 
                            qtyAvailable, valueAverage, valueAvailable,
                            qtyOut, salesPrice, salesValue,
                            qtyEnd, valueEnd,
                            qtyPlusCorrection, qtyMinusCorrection,
                            valuePlusCorrection, valueMinusCorrection,
                            qtyPayment, paymentPrice, paymentValue);
                    

                    }


                  
                }
            }
            catch (Exception ex)
            {
              
                throw ex;
            }
        }





        ////SAVE TO INVENTORY
        //Guid ID = Guid.NewGuid();

        //string[] columns = { "ID","ActiveMonth", "ActiveYear", 
        //                   "ProductCode", "ProductName", "Unit", "CategoryName", 
        //                   "QtyBegin", "ValueBegin", 
        //                   "QtyIn", "PurchasePrice",
        //                   "QtyAvailable", "ValueAverage", "ValueAvailable",
        //                   "QtyOut", "SalesPrice",
        //                   "QtyEnd", "ValueEnd",
        //                   "QtyPlusCorrection", "QtyMinusCorrection",
        //                   "ValuePlusCorrection", "ValueMinusCorrection" };

        //object[] values = { ID, Store.ActiveMonth, Store.ActiveYear, 
        //                  productCode, productName, productUnit, productCategory,
        //                qtyBegin, valueBegin,
        //                qtyIn, purchasePrice,
        //                qtyAvailable, valueAverage, valueAvailable,
        //                qtyOut, salesPrice,
        //                qtyEnd, valueEnd,
        //                qtyPlusCorrection, qtyMinusCorrection,
        //                valuePlusCorrection, valueMinusCorrection};

        //var q = new Query().Select(columns).From(tableName).Insert(values);

        //em.ExecuteNonQuery(q.ToSql(), tx);








    }
}
