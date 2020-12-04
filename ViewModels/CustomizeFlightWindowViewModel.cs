using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITU_Desktop.ViewModels
{
    class CustomizeFlightWindowViewModel
    {
        public ICommand CloseCustomizeFlightWindowCommand { get; }
        public CustomizeFlightWindowViewModel(ICommand closeCustomizeFlightWindowCommand)
        {
            CloseCustomizeFlightWindowCommand = closeCustomizeFlightWindowCommand;
        }
    }
}