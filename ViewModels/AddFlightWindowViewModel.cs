using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using ITU_Desktop.Models;
using Newtonsoft.Json;

namespace ITU_Desktop.ViewModels
{
    class AddFlightWindowViewModel
    {
        public ICommand CloseAddFlightWindowCommand { get; }
        public ICommand AddFlightCommand { get; }

        public Event Flight { get; set; }

        public AddFlightWindowViewModel(ICommand closeAddFlightWindowCommand)
        {
            AddFlightCommand = new RelayCommand(AddFlight);
            Flight = new Event();
            CloseAddFlightWindowCommand = closeAddFlightWindowCommand;
           
        }

        private async void AddFlight()
        {
            string json = JsonConvert.SerializeObject(new
            {
                registeredEscortIds = new List<int>(),
                registeredPilotIds = new List<int>(),
                eventType = 1,
                customerCount = Flight.customerCount,
                meetPoint = Flight.meetPoint,
                startPoint = Flight.startPoint,
                pilotId = Flight.pilotId,
                escortId = Flight.escortId,
                meetDate = Flight.meetDate,
                startDate = Flight.startDate,
                customerPhone = Flight.customerPhone,
                description = Flight.description
            });

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(@"https://ituapi.herokuapp.com/events",httpContent);

                if (response != null)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                }
                
            }

            CloseAddFlightWindowCommand.Execute(null);
        }
    }
}
