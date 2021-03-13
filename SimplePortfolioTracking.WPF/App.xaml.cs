using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimplePortfolioTracking.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errorMessage = string.Format("An unhandled exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            // whatever you want like logging etc. MessageBox it's just example for quick debugging etc.
            e.Handled = true;
        }

        void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs eventArgs)
        {
            eventArgs.SetObserved();
            ((AggregateException)eventArgs.Exception).Handle(ex =>
              {
                  // MessageBox.Show("Task Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                  // Write log or send email
                  // The method is not trigger immediate until the GC.Collection
                  return true;
              });
        }
}
}
