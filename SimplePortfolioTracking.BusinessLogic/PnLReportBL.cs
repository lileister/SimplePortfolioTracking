using SimplePortfolioTracking.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePortfolioTracking.BusinessLogic
{
    public class PnLReportBL
    {
        public async Task<List<Stock>> GetPnLReportAsync(Portfolio portfolio)
        {
            List<Stock> list = new List<Stock>();

            List<Trade> distinctList = portfolio.Trades.GroupBy(t => t.Ticker).Select(t => t.FirstOrDefault()).ToList();

            foreach (var distinctRow in distinctList)
            {
                StockBL stockBL = new StockBL(distinctRow.Ticker);
             
                CurrentStock currentQuote = await stockBL.GetCurrentStockAsync();

                Stock stock = new Stock();

                stock.Ticker = distinctRow.Ticker;
                stock.Quantity = portfolio.Trades.Where(t => t.Ticker == stock.Ticker).Sum(t => t.Quantity * (t.BuySell == "Buy" ? 1 : -1));
                stock.Cost = portfolio.Trades.Where(t => t.Ticker == stock.Ticker).Sum(t => t.Cost);
                stock.AsOfDate = currentQuote.LatestTradingDay;
                stock.PreClose = currentQuote.PreviousClose;
                stock.Price = currentQuote.Price;
                stock.MarketValue = stock.Price * stock.Quantity;
                stock.DailyPnL = (stock.Price - stock.PreClose) * stock.Quantity;
                stock.InceptionPnL = stock.Price * stock.Quantity - stock.Cost;

                list.Add(stock);
            }

            return list;
        }
    }
}
