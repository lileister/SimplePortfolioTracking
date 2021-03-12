using SimplePortfolioTracking.BusinessLogic;
using SimplePortfolioTracking.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplePortfolioTracking.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PortfolioBL bl = new PortfolioBL();
            Portfolio portfolio = bl.ReadPortfolio();

            BindPortfolio(portfolio);
            Task.Factory.StartNew(() => BindPnLReport(portfolio));
        }

        public void BindPortfolio(Portfolio portfolio)
        {
            dgPortfolio.ItemsSource = portfolio.Trades;
        }

        public void BindPnLReport(Portfolio portfolio)
        {
            PnLReportBL bl = new PnLReportBL();
            List<Stock> list = bl.GetPnLReportAsync(portfolio).Result;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                dgPnLReport.ItemsSource = list;
                dgPnLReport.IsReadOnly = true;
            }));

        }

    }

}
