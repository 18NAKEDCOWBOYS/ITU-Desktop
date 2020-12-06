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
    class CustomizeWorkerWindowViewModel
    {
        public ICommand CloseCustomizeWorkerWindowCommand { get; set; }
        public ICommand CustomizeWorkerCommand { get; set; }
        public User Worker { get; set; }
        public List<UserType> UserTypesObj { get; set; }
        public CustomizeWorkerWindowViewModel(ICommand closeCustomizeWorkerWindowCommand, User selectedWorker, List<UserType> userTypesObj)
        {
            CustomizeWorkerCommand = new RelayCommand(CustomizeWorker);
            UserTypesObj = userTypesObj;
            CloseCustomizeWorkerWindowCommand = closeCustomizeWorkerWindowCommand;
            Worker = selectedWorker;
        }

        private async void CustomizeWorker()
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
                var response = await httpClient.PutAsync(@"https://ituapi.herokuapp.com/users/" + Worker.id, httpContent);

                if (response != null)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                }

            }

            CloseCustomizeWorkerWindowCommand.Execute(null);
        }
    }
}
