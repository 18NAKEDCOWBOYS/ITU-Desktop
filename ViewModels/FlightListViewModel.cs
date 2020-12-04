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
using ITU_Desktop.Annotations;

namespace ITU_Desktop.ViewModels
{
    public class FlightListViewModel : INotifyPropertyChanged
    {
        private static HttpClient Client;

        private ObservableCollection<Event> _flightsObj;

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
        public ICommand RemoveFlightCommand { get; }
        public ICommand OpenCustomizeFlightWindowCommand { get; } 
        public ICommand OpenAddFlightWindowCommand { get; }
        public ICommand CloseCustomizeFlightWindowCommand { get; }
        public ICommand CloseAddFlightWindowCommand { get; }

        public FlightListViewModel()
        {
            Client = new HttpClient();

            OpenCustomizeFlightWindowCommand = new RelayCommand(OpenCustomizeFlightWindow);
            OpenAddFlightWindowCommand = new RelayCommand(OpenAddFlightWindow);
            CloseCustomizeFlightWindowCommand = new RelayCommand(CloseCustomizeFlightWindow);
            CloseAddFlightWindowCommand = new RelayCommand(CloseAddFlightWindow);
            RemoveFlightCommand = new RelayCommand(RemoveFlight);

            RefreshEvents();
        }



        private void OpenCustomizeFlightWindow()
        {
            CustomizeFlightWindow = new CustomizeFlightWindow(CloseCustomizeFlightWindowCommand);
            CustomizeFlightWindow.Show();
        }
        private void OpenAddFlightWindow()
        {
            AddFlightWindow = new AddFlightWindow(CloseAddFlightWindowCommand);
            AddFlightWindow.Show();
        }
        private void RemoveFlight()
        {
            throw new NotImplementedException();
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

        public async void RefreshEvents()
        {
            string flights = await Client.GetStringAsync(@"https://ituapi.herokuapp.com/events");
            string users = await Client.GetStringAsync(@"https://ituapi.herokuapp.com/users");
            string eventTypes = await Client.GetStringAsync(@"https://ituapi.herokuapp.com/event-types");
            FlightsObj = JsonConvert.DeserializeObject<ObservableCollection<Event>>(flights);
            List<User> usersObj = JsonConvert.DeserializeObject<List<User>>(users);
            List<EventType> eventTypesObj = JsonConvert.DeserializeObject<List<EventType>>(eventTypes);

            foreach (Event flight in FlightsObj)
            {
                flight.pilotObj = usersObj.Find(x => x.id == flight.pilotId); 
                flight.escortObj = usersObj.Find(x => x.id == flight.escortId);
                flight.eventTypeObj = eventTypesObj.Find(x => x.id == flight.eventType);
            }
        }



        private string GetData(string url)
        {
            string html = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            return html;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
