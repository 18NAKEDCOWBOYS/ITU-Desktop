using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    class AddWorkerWindowViewModel
    {
        public ICommand CloseAddWorkerWindowCommand { get; set; }
        public ICommand AddWorkerCommand { get; }
        public User Worker { get; set; }
        public List<UserType> UserTypesObj { get; set; }
        public AddWorkerWindowViewModel(ICommand closeAddWorkerWindowCommand, List<UserType> userTypesObj)
        {
            AddWorkerCommand = new RelayCommand(AddWorker);
            UserTypesObj = userTypesObj;
            Worker = new User();
            CloseAddWorkerWindowCommand = closeAddWorkerWindowCommand;
        }

        private async void AddWorker()
        {

            string json = JsonConvert.SerializeObject(new
            {
                name = Worker.name,
                type = Worker.typeObj.id,
                phone = Worker.phone,
                email = Worker.email
            });

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(@"https://ituapi.herokuapp.com/users", httpContent);

                if (response != null)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                }

            }

            CloseAddWorkerWindowCommand.Execute(null);
        }
    }
}
