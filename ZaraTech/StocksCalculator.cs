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
using System.Collections;

namespace ZaraTech
{
   
    class StocksCalculator
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(StocksCalculator));
        public const decimal BROKER = 0.98m;
        public const decimal INVERSTMENT = 50m;

        public static void calculateStocks(Dictionary<DateTime, decimal> TotalSotcks)
        {
            Console.WriteLine("-----Date-----Price of Stocks-----Total Stocks-----");
            logger.Info("-----Date-----Price of Stocks-----Total Stocks-----");
            var RealInverstment = decimal.Round(INVERSTMENT * BROKER,3);
            var TotalStocks=0.0m;
            var TotalStocksMonth = 0.0m;
            foreach (var month in TotalSotcks)
            {
                 TotalStocksMonth = decimal.Round(RealInverstment / month.Value,3);
                TotalStocks += TotalStocksMonth;
                logger.Info(month.Key.ToShortDateString()+"-----"+month.Value+ "------" + TotalStocksMonth);
                Console.WriteLine(month.Key.ToShortDateString() + "------" + month.Value + "------" + TotalStocksMonth);
            }

            
            PriceOfSoldStocks(TotalStocks);
        }

        public static void PriceOfSoldStocks(decimal totalStocks)
        {
            
            var DaySoldStocks = CsvManager.InfoCsv.First();
           var PriceStocks = DaySoldStocks.Value;
            var TotalObtained = decimal.Round(totalStocks * PriceStocks, 3);
            Console.WriteLine("Al vender las acciones obtiene: " + TotalObtained);
            Console.ReadLine();
            logger.Info("Al vender las acciones obtiene: " + TotalObtained);
           
        }
    }
}
