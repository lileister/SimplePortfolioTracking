using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SimplePortfolioTracking.DataAccess.Model
{

    [XmlRoot("Portfolio")]
    public class Portfolio
    {
        [XmlElement("Trade")]
        public List<Trade> Trades { get; set; }
    }
}
