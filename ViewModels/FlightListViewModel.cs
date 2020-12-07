using System.Windows;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ITU_Desktop.Views;
using ITU_Desktop.Models;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using ITU_Desktop.Annotations;

namespace ITU_Desktop.ViewModels
{
    public class FlightListViewModel : INotifyPropertyChanged
    {

        private static HttpClient _client;

        private ObservableCollection<Event> _flightsObj;

        public List<EventType> EventTypesObj { get; set; }

        public ObservableCollection<Event> FlightsObj
        {
            get => _flightsObj;
            set
            {
                if (Equals(value, _flightsObj)) return;
                _flightsObj = value;
                OnPropertyChanged();
            }
        }
        
        public AddFlightWindow AddFlightWindow { get; set; }
        public CustomizeFlightWindow CustomizeFlightWindow { get; set; }
        public AssignCrewWindow AssignCrewWindow { get; set; }
        public ICommand RemoveFlightCommand { get; }
        public ICommand OpenCustomizeFlightWindowCommand { get; } 
        public ICommand OpenAddFlightWindowCommand { get; }
        public ICommand OpenAssignCrewWindowCommand { get; }
        public ICommand CloseCustomizeFlightWindowCommand { get; }
        public ICommand CloseAddFlightWindowCommand { get; }
        public ICommand CloseAssignCrewWindowCommand { get; }
        public Event SelectedFlight { get; set; }



        public FlightListViewModel()
        {
            _client = new HttpClient();
            SelectedFlight = new Event();

            OpenCustomizeFlightWindowCommand = new RelayCommand(OpenCustomizeFlightWindow);
            OpenAddFlightWindowCommand = new RelayCommand(OpenAddFlightWindow);
            OpenAssignCrewWindowCommand = new RelayCommand(OpenAssignCrewWindow);
            CloseCustomizeFlightWindowCommand = new RelayCommand(CloseCustomizeFlightWindow);
            CloseAddFlightWindowCommand = new RelayCommand(CloseAddFlightWindow);
            CloseAssignCrewWindowCommand = new RelayCommand(CloseAssignCrewWindow);
            RemoveFlightCommand = new RelayCommand(RemoveFlight);

            RefreshEvents();
        }



        private void OpenAssignCrewWindow()
        {
            if (SelectedFlight.id != null)
            {
                AssignCrewWindow = new AssignCrewWindow(CloseAssignCrewWindowCommand, SelectedFlight, EventTypesObj);
                AssignCrewWindow.Show();
            }
        }

        private void OpenCustomizeFlightWindow()
        {
            if (SelectedFlight.id!=null)
            {
                CustomizeFlightWindow = new CustomizeFlightWindow(CloseCustomizeFlightWindowCommand, SelectedFlight, EventTypesObj);
                CustomizeFlightWindow.Show();
            }
        }
        private void OpenAddFlightWindow()
        {

                AddFlightWindow = new AddFlightWindow(CloseAddFlightWindowCommand);
                AddFlightWindow.Show();
            
        }
        private async void RemoveFlight()
        {
            if (SelectedFlight.id != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var response =
                        await httpClient.DeleteAsync(@"https://ituapi.herokuapp.com/events/" + SelectedFlight.id);

                    if (response != null)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                    }

                }

                RefreshEvents();
            }
        }

        private void CloseAddFlightWindow()
        {
            AddFlightWindow.Close();
            RefreshEvents();
        }
        private void CloseCustomizeFlightWindow()
        {
            CustomizeFlightWindow.Close();
            RefreshEvents();
        }
        private void CloseAssignCrewWindow()
        {
            AssignCrewWindow.Close();
            RefreshEvents();
        }

        public async void RefreshEvents()
        {
            string flights = await _client.GetStringAsync(@"https://ituapi.herokuapp.com/events");
            string users = await _client.GetStringAsync(@"https://ituapi.herokuapp.com/users");
            string eventTypes = await _client.GetStringAsync(@"https://ituapi.herokuapp.com/event-types");
            FlightsObj = JsonConvert.DeserializeObject<ObservableCollection<Event>>(flights);
            List<User> usersObj = JsonConvert.DeserializeObject<List<User>>(users);
            EventTypesObj = JsonConvert.DeserializeObject<List<EventType>>(eventTypes);

            foreach (Event flight in FlightsObj)
            {
                flight.pilotObj = usersObj.Find(x => x.id == flight.pilotId); 
                flight.escortObj = usersObj.Find(x => x.id == flight.escortId);
                flight.eventTypeObj = EventTypesObj.Find(x => x.id == flight.eventType);

                flight.registeredEscortObj = new List<User>();
                flight.registeredPilotObj = new List<User>();

                foreach (int user in flight.registeredEscortIds)
                {
                    flight.registeredEscortObj.Add(usersObj.Find(x => x.id == user));
                }

                foreach (int user in flight.registeredPilotIds)
                {
                    flight.registeredPilotObj.Add(usersObj.Find(x => x.id == user));                    
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
