using SimplePortfolioTracking.DataAccess.Model;
using SimplePortfolioTracking.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimplePortfolioTracking.BusinessLogic
{
    public class PortfolioBL
    {
        public string Path
        {
            get
            {
                return Directory.GetCurrentDirectory() + @"\Portfolio\Portfolio.xml";
            }
        }
        public Portfolio ReadPortfolio()
        {
            SerializerHelper ser = new SerializerHelper();
            string xmlInputData = File.ReadAllText(this.Path);
            Portfolio portfolio = ser.Deserialize<Portfolio>(xmlInputData);
            
            return portfolio;
        }

        public void WritePortfolio(Portfolio portfolio)
        {
            SerializerHelper ser = new SerializerHelper();
            string xmlOutputData = ser.Serialize<Portfolio>(portfolio);
            File.WriteAllText(this.Path, xmlOutputData);
        }
    }
}
