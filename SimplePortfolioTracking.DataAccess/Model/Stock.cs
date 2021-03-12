using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePortfolioTracking.DataAccess.Model
{
    public class Stock
    {
        public string Ticker { get; set; }
        public DateTime AsOfDate { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal MarketValue { get; set; }
        public decimal PreClose { get; set; }
        public decimal DailyPnL { get; set; }
        public decimal InceptionPnL { get; set; }

    }
}
