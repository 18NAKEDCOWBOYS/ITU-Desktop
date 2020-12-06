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
    class AssignCrewWindowViewModel
    {
        public ICommand CloseAssignCrewWindowCommand { get; }
        public ICommand AssignFlightCommand { get; }

        public Event Flight { get; set; }
        public AssignCrewWindowViewModel(ICommand closeAssignCrewWindowCommand, Event selectedFlight)
        {
            Flight = selectedFlight;
            CloseAssignCrewWindowCommand = closeAssignCrewWindowCommand;
            AssignFlightCommand = new RelayCommand(AssignFlight);
        }

        private async void AssignFlight()
        {
            string json = JsonConvert.SerializeObject(new
            {
                escortId = Flight.escortObj.id,
                pilotId = Flight.pilotObj.id,
                registeredEscortIds = Flight.registeredEscortIds,
                registeredPilotIds = Flight.registeredPilotIds,
                eventType = Flight.eventType,
                customerCount = Flight.customerCount,
                meetPoint = Flight.meetPoint,
                startPoint = Flight.startPoint,
                meetDate = Flight.meetDate,
                startDate = Flight.startDate,
                customerPhone = Flight.customerPhone,
                description = Flight.description
            });

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(@"https://ituapi.herokuapp.com/events/" + Flight.id, httpContent);

                if (response != null)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                }

            }

            CloseAssignCrewWindowCommand.Execute(null);
        }
    }
}
