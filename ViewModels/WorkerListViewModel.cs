using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using ITU_Desktop.Models;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using ITU_Desktop.Annotations;

namespace ITU_Desktop.ViewModels
{
    public class WorkerListViewModel : INotifyPropertyChanged
    {
        public AddWorkerWindow AddWorkerWindow { get; set;}
        public CustomizeWorkerWindow CustomizeWorkerWindow { get; set; }

        private static HttpClient _client;

        private ObservableCollection<User> _flightsObj;

        public List<UserType> UserTypesObj { get; set; }

        public User SelectedWorker { get; set; }

        public ObservableCollection<User> WorkersObj
        {
            get => _flightsObj;
            set
            {
                if (Equals(value, _flightsObj)) return;
                _flightsObj = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenAddWorkerWindowCommand { get; }

        public ICommand RemoveWorkerCommand { get; }
        public ICommand OpenCustomizeWorkerWindowCommand { get; }
        public ICommand CloseCustomizeWorkerWindowCommand { get; }
        public ICommand CloseAddWorkerWindowCommand { get; }

        public WorkerListViewModel()
        {
            OpenAddWorkerWindowCommand = new RelayCommand(OpenAddWorkerWindow);
            RemoveWorkerCommand = new RelayCommand(RemoveWorker);
            OpenCustomizeWorkerWindowCommand = new RelayCommand(OpenCustomizeWorkerWindow);
            CloseCustomizeWorkerWindowCommand = new RelayCommand(CloseCustomizeWorkerWindow);
            CloseAddWorkerWindowCommand = new RelayCommand(CloseAddWorkerWindow);

            _client = new HttpClient();
            UserTypesObj = new List<UserType>();
            SelectedWorker = new User();
            RefreshEvents();
        }

        private void CloseAddWorkerWindow()
        {
            AddWorkerWindow.Close();
            RefreshEvents();
        }

        private void CloseCustomizeWorkerWindow()
        {
            CustomizeWorkerWindow.Close();
            RefreshEvents();
        }

        private void OpenCustomizeWorkerWindow()
        {
            if (SelectedWorker != null)
            {
                CustomizeWorkerWindow = new CustomizeWorkerWindow(CloseCustomizeWorkerWindowCommand,SelectedWorker, UserTypesObj);
                CustomizeWorkerWindow.Show();
            }
        }

        private async void RemoveWorker()
        {
            if (SelectedWorker != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var response =
                        await httpClient.DeleteAsync(@"https://ituapi.herokuapp.com/users/" + SelectedWorker.id);

                    if (response != null)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                    }
                }

                RefreshEvents();
            }
        }

        private void OpenAddWorkerWindow()
        {
            AddWorkerWindow = new AddWorkerWindow(CloseAddWorkerWindowCommand, UserTypesObj);
            AddWorkerWindow.Show();
        }

        public async void RefreshEvents()
        {
            string users = await _client.GetStringAsync(@"https://ituapi.herokuapp.com/users");
            string UserTypes = await _client.GetStringAsync(@"https://ituapi.herokuapp.com/user-types");
            WorkersObj = JsonConvert.DeserializeObject<ObservableCollection<User>>(users);
            UserTypesObj = JsonConvert.DeserializeObject<List<UserType>>(UserTypes);

            foreach (User user in WorkersObj)
            {
                user.typeObj = UserTypesObj.Find(x => x.id == user.type);
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
