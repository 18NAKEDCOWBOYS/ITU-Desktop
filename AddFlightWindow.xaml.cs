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
using System.Windows.Shapes;
using ITU_Desktop.ViewModels;

namespace ITU_Desktop
{
    /// <summary>
    /// Interaction logic for AddFlightWindow.xaml
    /// </summary>
    public partial class AddFlightWindow : Window
    {
        public AddFlightWindow(ICommand closeAddFlightWindowCommand)
        {
            InitializeComponent();
            DataContext = new AddFlightWindowViewModel(closeAddFlightWindowCommand);
        }
    }
}
