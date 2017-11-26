using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityMap;
using BizCare.Model;
using BizCare.Repository.Mapping;
using Corbis.Repository;


namespace BizCare.Repository
{
    public interface IStockCorrectionRepository
    {
        string GenerateCorrectionCode(int month, int year);
        StockCorrection GetById(Guid id);
        StockCorrection GetByCode(string code);
        List<string> GetAllCode(int month, int year);
        int GetStockCorrectionIdByCode(string code);
        List<StockCorrection> GetAll(int month, int year);
        List<StockCorrection> GetAll();
        StockCorrection GetLast(int month, int year);
        void SaveHeader(IEntityManager em, Transaction tx, StockCorrection stockCorrection);
        void Save(StockCorrection stockCorrection);
        void Update(StockCorrection stockCorrection);
        void UpdateHeader(IEntityManager em, Transaction tx, StockCorrection stockCorrection);
        void Delete(string code);
        void Delete(Guid id);
        void Delete(IEntityManager em, Transaction tx, string stockCorrectionCode);
        void Delete(StockCorrection stockCorrection);
        List<StockCorrection> Search(string value, int month, int year);
        void UpdatePrintCounter(string stockCorrectionCode);
    }

    public class StockCorrectionRepository : IStockCorrectionRepository
    {
         private DataSource ds;
        private string tableName = "StockCorrection";

        private IStockCorrectionItemRepository stockCorrectionItemRepository;
        private IRecordCounterRepository recordCounterRepository;
        private IProductQtyRepository productQtyRepository;

        public StockCorrectionRepository(DataSource ds)
        {
            this.ds = ds;
            stockCorrectionItemRepository = ServiceLocator.GetObject<IStockCorrectionItemRepository>();
            recordCounterRepository = ServiceLocator.GetObject<IRecordCounterRepository>();
            productQtyRepository = ServiceLocator.GetObject<IProductQtyRepository>();
        }



        private string GetMonthCode(int month)
        {
            string monthCode = string.Empty;

            switch (month)
            {
                case 1 :
                    monthCode = "A";
                    break;
                case 2 :
                    monthCode = "B";
                    break;
                case 3 :
                    monthCode = "C";
                    break;
                case 4:
                    monthCode = "D";
                    break;
                case 5:
                    monthCode = "E";
                    break;
                case 6:
                    monthCode = "F";
                    break;
                case 7:
                    monthCode = "G";
                    break;
                case 8:
                    monthCode = "H";
                    break;
                case 9:
                    monthCode = "I";
                    break;
                case 10:
                    monthCode = "J";
                    break;
                case 11:
                    monthCode = "K";
                    break;
                case 12:
                    monthCode = "L";
                    break;

            }

            return monthCode;
        }
        

       

        public string GenerateCorrectionCode(int month,int year)
        {

            string strYear = year.ToString().Substring(2);

            string code = "KR-" + strYear + GetMonthCode(month) ;

            int counter = 0;
            int newCounter = 0;

            var recordCounter = recordCounterRepository.GetByMonthAndYear(month,year);
            if (recordCounter != null)
                counter = recordCounter.StockCorrectionCounter;

            if (counter == 0)
            {
                code = code + "0001";
            }
            else
            {
                newCounter = counter + 1;
                code = code + newCounter.ToString("D4");
            }

            return code;
        }

        public StockCorrection GetById(Guid id)
        {
            StockCorrection stockCorrection = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, CorrectionCode, CorrectionDate, "
                        + "Notes, PrintCounter, "
                        + "CreatedDate,ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM "
                        + "StockCorrection "
                        + "WHERE "
                        + "ID='{" + id + "}'";

                stockCorrection = em.ExecuteObject<StockCorrection>(sql, new StockCorrectionMapper());

                if (stockCorrection != null)
                {
                    stockCorrection.StockCorrectionItems = stockCorrectionItemRepository.GetByStockCorrectionId(stockCorrection.ID);
                }
            }

            return stockCorrection;
        }


        public int GetStockCorrectionIdByCode(string code)
        {

            int stockCorrectionId = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().From(tableName).Where("CorrectionCode").Equal(code);

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    if (rdr.Read())
                    {
                        stockCorrectionId = (int)rdr["ID"];
                    }
                }
            }

            return stockCorrectionId;
        }

        public StockCorrection GetByCode(string code)
        {
            StockCorrection stockCorrection = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, CorrectionCode, CorrectionDate, Notes, PrintCounter, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM "
                        + "StockCorrection " 
                        + "WHERE "
                        + "CorrectionCode='" + code + "'";


                stockCorrection = em.ExecuteObject<StockCorrection>(sql, new StockCorrectionMapper());
            }

            return stockCorrection;
        }



        public List<string> GetAllCode(int month, int year)
        {
            List<string> list = new List<string>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                var q = new Query().Select("CorrectionCode").From(tableName)
                    .Where("Month(CorrectionDate)").Equal(month).And("Year(CorrectionDate)").Equal(year)
                    .OrderBy("CorrectionCode DESC");

                using (var rdr = em.ExecuteReader(q.ToSql()))
                {
                    while (rdr.Read())
                    {
                        string code = rdr["CorrectionCode"].ToString();
                        list.Add(code);
                    }
                }
            }

            return list;
        }


        public List<StockCorrection> GetAll(int month, int year)
        {
            List<StockCorrection> stockCorrection = new List<StockCorrection>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, CorrectionCode, CorrectionDate, "
                        + "Notes, PrintCounter, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM "
                        + "StockCorrection "
                        + "WHERE Month(CorrectionDate)=" + month + " AND Year(CorrectionDate)=" + year + " "
                        + "ORDER BY CorrectionCode DESC";

                stockCorrection = em.ExecuteList<StockCorrection>(sql, new StockCorrectionMapper());
            }

            return stockCorrection;
        }



        public List<StockCorrection> GetAll()
        {
            List<StockCorrection> stockCorrection = new List<StockCorrection>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, CorrectionCode, CorrectionDate, "
                        + "Notes, PrintCounter, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM "
                        + "StockCorrection "
                        + "ORDER BY CorrectionCode DESC";

                stockCorrection = em.ExecuteList<StockCorrection>(sql, new StockCorrectionMapper());
            }

            return stockCorrection;
        }





        public StockCorrection GetLast(int month, int year)
        {
            StockCorrection stockCorrection = null;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT TOP 1 ID, CorrectionCode, CorrectionDate, Notes, PrintCounter, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM "
                        + "StockCorrection "
                        + "WHERE Month(CorrectionDate)=" + month + " AND Year(CorrectionDate)=" + year
                        + " ORDER BY CorrectionCode DESC";

                stockCorrection = em.ExecuteObject<StockCorrection>(sql, new StockCorrectionMapper());
            }

            return stockCorrection;
        }

        
        public void SaveHeader(IEntityManager em, Transaction tx, StockCorrection stockCorrection)
        {
            string[] columns = { "ID", "CorrectionCode", "CorrectionDate", "Notes", "PrintCounter", 
                                         "CreatedDate", "CreatedBy" };

            object[] values = { Guid.NewGuid(),stockCorrection.Code, stockCorrection.Date.ToShortDateString(), stockCorrection.Notes,
                                  stockCorrection.PrintCounter,
                                  DateTime.Now.ToShortDateString(),Store.ActiveUser};

            var q = new Query().Select(columns).From(tableName).Insert(values);

            em.ExecuteNonQuery(q.ToSql(), tx);
        }

        public void Save(StockCorrection stockCorrection)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    Guid ID = Guid.NewGuid();

                    string[] columns = { "ID", "CorrectionCode", "CorrectionDate", "Notes", "PrintCounter", 
                                         "CreatedDate", "CreatedBy" };

                    object[] values = { ID, stockCorrection.Code, stockCorrection.Date.ToShortDateString(), stockCorrection.Notes,
                                          stockCorrection.PrintCounter,
                                          DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Insert(values);

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    foreach (var stockCorrectionItems in stockCorrection.StockCorrectionItems)
                    {
                        stockCorrectionItems.StockCorrectionId = ID;

                        stockCorrectionItemRepository.Save(em, tx, stockCorrectionItems);

                        //update product
                        productQtyRepository.UpdateQtyCorrection(Store.ActiveMonth, Store.ActiveYear, stockCorrectionItems.ProductId, stockCorrectionItems.QtyPlus, stockCorrectionItems.QtyMinus, true);

                    }

                    recordCounterRepository.UpdateStockCorrectionCounter(stockCorrection.Date.Month, stockCorrection.Date.Year);

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        public void Update(StockCorrection stockCorrection)
        {
            Transaction tx = null;

            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    string[] columns = {  "CorrectionCode", "CorrectionDate", "Notes", "PrintCounter", 
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { stockCorrection.Code, stockCorrection.Date, stockCorrection.Notes,
                                          stockCorrection.PrintCounter,
                                          DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + stockCorrection.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    ////detail dihapus -> update qty
                    var list = stockCorrectionItemRepository.GetByStockCorrectionId(stockCorrection.ID);
                    foreach (var stockCorrectionItem in list)
                    {
                        productQtyRepository.UpdateQtyCorrection(Store.ActiveMonth, Store.ActiveYear, stockCorrectionItem.ProductId, stockCorrectionItem.QtyPlus, stockCorrectionItem.QtyMinus, false);

                    }

                    stockCorrectionItemRepository.Delete(em, tx, stockCorrection.ID);

                    foreach (var stockCorrectionItem in stockCorrection.StockCorrectionItems)
                    {
                        stockCorrectionItem.StockCorrectionId = stockCorrection.ID;

                        stockCorrectionItemRepository.Save(em, tx, stockCorrectionItem);

                        ////update product
                        productQtyRepository.UpdateQtyCorrection(Store.ActiveMonth, Store.ActiveYear, stockCorrectionItem.ProductId, stockCorrectionItem.QtyPlus, stockCorrectionItem.QtyMinus, true);

                    }

                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();

                throw ex;
            }

        }

        public void UpdateHeader(IEntityManager em, Transaction tx, StockCorrection stockCorrection)
        {
            string[] columns = { "CorrectionDate", "Notes", "PrintCounter", 
                                         "ModifiedDate","ModifiedBy"};

            object[] values = { stockCorrection.Date.ToShortDateString(),stockCorrection.Notes, stockCorrection.PrintCounter,
                                  DateTime.Now.ToShortDateString(),Store.ActiveUser};

            var q = new Query().Select(columns).From(tableName).Update(values)
                .Where("CorrectionCode").Equal(stockCorrection.Code);

            em.ExecuteNonQuery(q.ToSql(), tx);
        }

        public void Delete(string code)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("CorrectionCode").Equal(code);
                    em.ExecuteNonQuery(q.ToSql());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Delete(Guid id)
        {
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    var q = new Query().From(tableName).Delete().Where("ID").Equal(id);
                    em.ExecuteNonQuery(q.ToSql());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(IEntityManager em, Transaction tx, string stockCorrectionCode)
        {
            var q = new Query().From(tableName).Delete().Where("CorrectionCode").Equal(stockCorrectionCode);
            em.ExecuteNonQuery(q.ToSql(), tx);
        }

        public void Delete(StockCorrection stockCorrection)
        {
            Transaction tx = null;
            try
            {
                using (var em = EntityManagerFactory.CreateInstance(ds))
                {
                    tx = em.BeginTransaction();

                    String notes = "";
                    if (stockCorrection.Notes != "")
                    {
                        notes = "DIBATALKAN - " + stockCorrection.Notes;
                    }
                    else
                    {
                        notes = "DIBATALKAN";
                    }

                    string[] columns = { "Notes",
                                         "ModifiedDate","ModifiedBy"};

                    object[] values = { notes,
                                        DateTime.Now.ToShortDateString(),Store.ActiveUser};

                    var q = new Query().Select(columns).From(tableName).Update(values)
                        .Where("ID").Equal("{" + stockCorrection.ID + "}");

                    em.ExecuteNonQuery(q.ToSql(), tx);

                    var itemList = stockCorrectionItemRepository.GetByStockCorrectionId(stockCorrection.ID);
                    foreach (var stockCorrectionItems in itemList)
                    {
                        stockCorrectionItemRepository.Delete(em, tx, stockCorrectionItems);
                        
                        //productQtyRepository.UpdateQtyOut(Store.ActiveMonth, Store.ActiveYear, stockCorrectionItems.ProductId, stockCorrectionItems.Qty, false);

                    }

                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                tx.Rollback();
                throw ex;
            }
        }

        public List<StockCorrection> Search(string value, int month, int year)
        {
            List<StockCorrection> stockCorrection = new List<StockCorrection>();

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                string sql = "SELECT ID, CorrectionCode, Notes, PrintCounter, "
                        + "CreatedDate, ModifiedDate, CreatedBy, ModifiedBy "
                        + "FROM "
                        + "StockCorrection "
                        + "WHERE "
                        + "(CorrectionCode like '%" + value + "%' "
                        + "OR Notes like  '%" + value + "%') "
                        + "AND Month(CorrectionDate)=" + month + " AND Year(CorrectionDate)=" + year
                        + " ORDER BY CorrectionCode DESC";

                stockCorrection = em.ExecuteList<StockCorrection>(sql, new StockCorrectionMapper());
            }

            return stockCorrection;
        }

        public void UpdatePrintCounter(string stockCorrectionCode)
        {
            int printCounter = 0;

            using (var em = EntityManagerFactory.CreateInstance(ds))
            {
                StockCorrection stockCorrection = GetByCode(stockCorrectionCode);
                if (stockCorrection != null)
                {
                    printCounter = stockCorrection.PrintCounter + 1;
                    string sql = "UPDATE " + tableName + " SET PrintCounter = " + printCounter + " WHERE CorrectionCode='" + stockCorrectionCode + "'";
                    em.ExecuteNonQuery(sql);

                }
            }


        }









    }
}
