using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParseJSON
{
    class Program
    {
        private static void dateAndPrices(string startDate, string endDate)
        {
            var client = new WebClient();
            var text = client.DownloadString("https://jsonmock.hackerrank.com/api/stocks");

            RootObject stockPrices = JsonConvert.DeserializeObject<RootObject>(text);

            DateTime dateStartDate = DateTime.Parse(startDate);
            DateTime dateEndDate = DateTime.Parse(endDate);
            
            for (int i = 0; i < stockPrices.data.Count; i++)
            {
                DateTime date = DateTime.Parse(stockPrices.data[i].date);
                if (date >= dateStartDate && date <= dateEndDate)
                {
                    Console.WriteLine("Date: " + stockPrices.data[i].date);
                    Console.WriteLine("Open Price: " + stockPrices.data[i].open);
                    Console.WriteLine("Close Price: " + stockPrices.data[i].close);

                    Console.WriteLine();
                }
            }

            Console.ReadLine();
           
            
        }

        static void Main(string[] args)
        {
            //5-January-2000
            var sDate = "7-January-2000";
            var eDate = "15-January-2000";

            dateAndPrices(sDate, eDate);
        }
    }
}

