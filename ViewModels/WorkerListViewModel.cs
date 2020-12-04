using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ITU_Desktop.Models;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace ITU_Desktop.ViewModels
{
    public class WorkerListViewModel
    {
        public List<User> usr { get; set; }
        public WorkerListViewModel()
        {
            string content = GetData(@"https://ituapi.herokuapp.com/users");
            usr = JsonConvert.DeserializeObject<List<User>>(content);
            //zpracuje získání dat ze serveru pomocí ajax requestu
            //parsne json do objektů
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

            Console.WriteLine(html);
            return html;
        }
    }
}
