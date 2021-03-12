using System;
using System.Collections.Generic;
using System.Text;

namespace SimplePortfolioTracking.DataAccess.Model
{
    public class Trade
    {
        public string Ticker { get; set; }
        public string TradeDate { get; set; }
        public string BuySell { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
