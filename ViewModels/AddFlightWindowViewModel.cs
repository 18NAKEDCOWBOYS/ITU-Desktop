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
        public ICommand AddNewFlightCommand { get; }

        public Event NewFlight { get; set; }

        public AddFlightWindowViewModel(ICommand closeAddFlightWindowCommand)
        {
            AddNewFlightCommand = new RelayCommand(AddNewFlight);
            NewFlight = new Event();
            CloseAddFlightWindowCommand = closeAddFlightWindowCommand;
        }

        private async void AddNewFlight()
        {
            EventToLoad newFlightToLoad = new EventToLoad()
            {
                registeredEscortIds = new List<int>(),
                registeredPilotIds = new List<int>(),
                eventType = 1,
                customerCount = NewFlight.customerCount,
                id = NewFlight.id,
                meetPoint = NewFlight.meetPoint,
                startPoint = NewFlight.startPoint,
                pilotId = NewFlight.pilotId,
                escortId = NewFlight.escortId,
                meetDate = NewFlight.meetDate,
                startDate = NewFlight.startDate,
                customerPhone = NewFlight.customerPhone,
                description = NewFlight.description
            };

            string json = JsonConvert.SerializeObject(newFlightToLoad);

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
