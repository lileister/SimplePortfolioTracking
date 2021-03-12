using SimplePortfolioTracking.DataAccess.Model;
using SimplePortfolioTracking.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SimplePortfolioTracking.BusinessLogic
{
    public class StockBL
    {
        public StockBL(string StockCode)
        {
            this.StockCode = StockCode;
        }

        public string StockCode { get; set; }

        public async Task<CurrentStock> GetCurrentStockAsync()
        {
            CurrentStock currentStock = new CurrentStock();
            string url = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=" + this.StockCode + "&apikey=1Y6QD6PXHK10FIOI";
            string jsonString = await HttpHelper.GetAsync(url);

            JObject stockDetail = JObject.Parse(jsonString);

            foreach (JProperty y in stockDetail["Global Quote"])
            {
                switch (y.Name)
                {
                    case "01. symbol":
                        currentStock.StockCode = y.Value.ToString();
                        break;
                    case "02. open":
                        currentStock.Open = Convert.ToDecimal(y.Value.ToString());
                        break;
                    case "03. high":
                        currentStock.High = Convert.ToDecimal(y.Value.ToString());
                        break;
                    case "04. low":
                        currentStock.Low = Convert.ToDecimal(y.Value.ToString());
                        break;
                    case "05. price":
                        currentStock.Price = Convert.ToDecimal(y.Value.ToString());
                        break;
                    case "06. volume":
                        currentStock.Volume = Convert.ToInt64(y.Value.ToString());
                        break;
                    case "07. latest trading day":
                        currentStock.LatestTradingDay = Convert.ToDateTime(y.Value.ToString());
                        break;
                    case "08. previous close":
                        currentStock.PreviousClose = Convert.ToDecimal(y.Value.ToString());
                        break;
                    case "09. change":
                        currentStock.Change = Convert.ToDecimal(y.Value.ToString());
                        break;
                    case "10. change percent":
                        currentStock.ChangePercent = Convert.ToDecimal(y.Value.ToString().Replace("%", "")) / 100;
                        break;
                }

            }

            return currentStock;
        }

    }
}
