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

        public List<EventType> EventTypesObj { get; set; }

        public AssignCrewWindowViewModel(ICommand closeAssignCrewWindowCommand, Event selectedFlight, List<EventType> eventTypesObj)
        {
            Flight = selectedFlight;
            EventTypesObj=eventTypesObj;
            CloseAssignCrewWindowCommand = closeAssignCrewWindowCommand;
            AssignFlightCommand = new RelayCommand(AssignFlight);
        }

        private async void AssignFlight()
        {
            int? escortId=null;
            int? pilotId=null;
            int? eventType = null;

            if (Flight.escortObj!=null)
            {
                escortId = Flight.escortObj.id;
            }if (Flight.eventTypeObj!= null)
            {
                eventType = Flight.eventTypeObj.id;
            }
            if (Flight.pilotObj!=null)
            {
                pilotId = Flight.pilotObj.id;
            }


            string json = JsonConvert.SerializeObject(new
            {
                escortId = escortId,
                pilotId = pilotId,
                registeredEscortIds = Flight.registeredEscortIds,
                registeredPilotIds = Flight.registeredPilotIds,
                eventType = eventType,
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
