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
            BindPnLReport(portfolio);
        }

        public void BindPortfolio(Portfolio portfolio)
        {
            dgPortfolio.ItemsSource = portfolio.Trades;
        }

        public void BindPnLReport(Portfolio portfolio)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lblLoading.Visibility = Visibility.Visible;
                    }));

                    PnLReportBL bl = new PnLReportBL();
                    List<Stock> list = bl.GetPnLReportAsync(portfolio).Result;

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        dgPnLReport.ItemsSource = list;
                        lblLoading.Visibility = Visibility.Hidden;
                    }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show( "Error, please contact system administrator!", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
                    //Write logs here or email to administrator
                }
            });
        }
        
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            List<Trade> list = (List<Trade>)this.dgPortfolio.ItemsSource;

            Portfolio portfolio = new Portfolio();
            portfolio.Trades = list;

            PortfolioBL bl = new PortfolioBL();
            bl.WritePortfolio(portfolio);

            BindPnLReport(portfolio);

            MessageBox.Show("Save successfully!", "System Message", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}
