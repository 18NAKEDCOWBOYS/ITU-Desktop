using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ITU_Desktop.ViewModels
{
    class AddFlightWindowViewModel
    {
        public ICommand CloseAddFlightWindowCommand { get; }
        public AddFlightWindowViewModel(ICommand closeAddFlightWindowCommand)
        {
            CloseAddFlightWindowCommand = closeAddFlightWindowCommand;
        }
    }
}
