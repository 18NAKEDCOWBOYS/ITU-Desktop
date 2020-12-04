using System;
using System.Net.Http;
using System.Net;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using ITU_Desktop.ViewModels;
using ITU_Desktop.Models;
using Newtonsoft.Json;
using System.IO;

namespace ITU_Desktop
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            
        }

        private void FlightListView_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new FlightListViewModel();

        }

        private void WorkerListView_clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new WorkerListViewModel();
        }
    }

}
