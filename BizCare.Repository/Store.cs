using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BizCare.Repository
{
    public class Store
    {
        public static int ActiveMonth;
        public static int ActiveYear;
        public static string ActiveUser;
        public static bool IsAdministrator;

        public static DateTime StartDate;
        public static bool IsPeriodClosed;
        public static string ActiveReport;

        public static string ConnStr = ConfigurationManager.AppSettings["ConnectionString"];
        public static string ReportPath = ConfigurationManager.AppSettings["ReportPath"];
        

        public static string GetAmounInWords(int amount)
        {
            string[] strDigits = { "", "satu", "dua", "tiga", "empat", "lima", "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas" };
            string words = "";
            
            if (amount < 12)
            {
                words = " " + strDigits[amount];
            }
            else if (amount < 20)
            {
                words = GetAmounInWords(amount - 10).ToString() + " belas";
            }
            else if (amount < 100)
            {
                words = GetAmounInWords(amount / 10) + " puluh" + GetAmounInWords(amount % 10);
            }
            else if (amount < 200)
            {
                words = " seratus" + GetAmounInWords(amount - 100);
            }
            else if (amount < 1000)
            {
                words = GetAmounInWords(amount / 100) + " ratus" + GetAmounInWords(amount % 100);
            }
            else if (amount < 2000)
            {
                words = " seribu" + GetAmounInWords(amount - 1000);
            }
            else if (amount < 1000000)
            {
                words = GetAmounInWords(amount / 1000) + " ribu" + GetAmounInWords(amount % 1000);
            }
            else if (amount < 1000000000)
            {
                words = GetAmounInWords(amount / 1000000) + " juta" + GetAmounInWords(amount % 1000000);
            }
            else if (amount < 1000000000000)
            {
                words = GetAmounInWords(amount / 1000000000) + " milyar" + GetAmounInWords(amount % 1000000000);
            }

            return words;
        
        }
        

       
        public static string GetMonthName(int monthCode)
        {
            string monthName = "";

            if (monthCode == 1)
            {
                monthName = "Januari";
            }
            else if (monthCode == 2)
            {
                monthName = "Februari";
            }
            else if (monthCode == 3)
            {
                monthName = "Maret";
            }
            else if (monthCode == 4)
            {
                monthName = "April";
            }
            else if (monthCode == 5)
            {
                monthName = "Mei";
            }
            else if (monthCode == 6)
            {
                monthName = "Juni";
            }
            else if (monthCode == 7)
            {
                monthName = "Juli";
            }
            else if (monthCode == 8)
            {
                monthName = "Agustus";
            }
            else if (monthCode == 9)
            {
                monthName = "September";
            }
            else if (monthCode == 10)
            {
                monthName = "Oktober";
            }
            else if (monthCode == 11)
            {
                monthName = "November";
            }
            else
            {
                monthName = "Desember";
            }


            return monthName;

        }


        public static int GetMonthCode(string monthName)
        {
            int monthCode = 0;

            if (monthName == "Januari")
            {
                monthCode = 1;
            }
            else if (monthName == "Februari")
            {
                monthCode = 2;
            }
            else if (monthName == "Maret")
            {
                monthCode = 3;
            }
            else if (monthName == "April")
            {
                monthCode = 4;
            }
            else if (monthName == "Mei")
            {
                monthCode = 5;
            }
            else if (monthName == "Juni")
            {
                monthCode = 6;
            }
            else if (monthName == "Juli")
            {
                monthCode = 7;
            }
            else if (monthName == "Agustus")
            {
                monthCode = 8;
            }
            else if (monthName == "September")
            {
                monthCode = 9;
            }
            else if (monthName == "Oktober")
            {
                monthCode = 10;
            }
            else if (monthName == "November")
            {
                monthCode = 11;
            }
            else
            {
                monthCode = 12;
            }


            return monthCode;

        }
             
    }
}
