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
    class CsvManager
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(CsvManager));

        public static Dictionary<DateTime, decimal> InfoCsv = new Dictionary<DateTime, decimal>();



        public static void ReadCvs()
        {

            string[] lineFile = File.ReadAllLines("C:/Users/usuario/Desktop/ZaraTech/ZaraTech/bin/Debug/stocks-ITX.csv");
            foreach (var line in lineFile)
            {

                var values = line.Split(';');
                if (values[0] != "Fecha" || values[2] != "Apertura")
                {
                    CultureInfo culturedec = new CultureInfo("es-US");
                    var PriceBuy = decimal.Round(decimal.Parse(values[2], culturedec), 3);
                    var PriceSale = decimal.Round(decimal.Parse(values[1], culturedec), 3);
                    CultureInfo MyCultureInfo = new CultureInfo("es-US");
                    var DateBuy = DateTime.Parse(values[0], MyCultureInfo);
                    GenerateList(DateBuy, PriceBuy, PriceSale);
                }
            }

            SearchDays.getFirstLastDate(InfoCsv.First(), InfoCsv.Last());
        }
        public static void GenerateList(DateTime date, decimal priceBuy, decimal salePrice)
        {
            CultureInfo MyCultureInfo = new CultureInfo("es-US");
            DateTime MaxDate = DateTime.Parse("28-dic-2017", MyCultureInfo);
            if (date == MaxDate)
            {
                InfoCsv.Add(date, salePrice);
            }
            else
            {
                InfoCsv.Add(date, priceBuy);
            }
        }


    }
}
