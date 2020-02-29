using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using log4net;

namespace ZaraTech
{
     class SearchDays
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SearchDays));
        static List<DateTime> thursday = new List<DateTime>();
        static List<Decimal> PriceAc = new List<Decimal>();
        public static Dictionary<DateTime, decimal> Stocks = new Dictionary<DateTime, decimal>();
        public static void getFirstLastDate(KeyValuePair<DateTime, decimal> valueFirst, KeyValuePair<DateTime, decimal> valueLast)
        {

            var FirstDate = valueLast.Key;
            var LastDay = valueFirst.Key;
            LastThursday(FirstDate.Year, FirstDate.Month, LastDay.Year);



        }

        public static void LastThursday(int fyear, int month, int lyear)
        {

            var date = CsvManager.InfoCsv.First();
            var maxDate = date.Key;
            for (var i = fyear; i <= lyear; i++)
            {
                for (var j = month; j <= 12; j++)
                {
                    var LastThr = TheLast(i, j);
                    DateTime thisDate1 = new DateTime(i, j, LastThr);
                    if (thisDate1 != maxDate)
                    {
                        thursday.Add(thisDate1);
                    }
                }
                month = 1;
            }

            checkDates();
        }
         public static int TheLast(int year, int month)
        {

            var last = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            while (last.DayOfWeek != DayOfWeek.Thursday)
                last = last.AddDays(-1);

            return last.Day;

        }
         public static void checkDates()
        {


            for (var i = 0; i <= thursday.Count - 1; i++)
            {
                var friday = thursday[i].AddDays(1);
                if (CsvManager.InfoCsv.ContainsKey(friday))
                {
                    var price = CsvManager.InfoCsv[friday];
                    Stocks.Add(friday,price);
                }
                else
                {
                    for (var k = 0; k <= 5; k++)
                    {
                        friday = friday.AddDays(1);
                        if (CsvManager.InfoCsv.ContainsKey(friday))
                        {
                            var price = CsvManager.InfoCsv[friday];
                            Stocks.Add(friday, price);
                            break;
                        }

                    }
                }


            }

            StocksCalculator.calculateStocks(Stocks);

        }

    }
}
