using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePortfolioTracking.DataAccess.Model
{
    public class CurrentStock
    {
        public string StockCode { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Price { get; set; }
        public long Volume { get; set; }
        public DateTime LatestTradingDay { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
    }
}
