using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITU_Desktop.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public UserType typeObj { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class EventType
    {
        public int id { get; set; }
        public string key { get; set; }
        public string displayString { get; set; }
    }

    public class UserType
    {
        public int id { get; set; }
        public string key { get; set; }
        public string displayString { get; set; }
    }

    public class Event
    {
        public int? id { get; set; }
        public string meetPoint { get; set; }
        public string startPoint { get; set; }
        public int? pilotId { get; set; }        
        public User pilotObj { get; set; }
        public int? escortId { get; set; }
        public User escortObj { get; set; }
        public List<int> registeredPilotIds { get; set; }
        public List<User> registeredPilotObj { get; set; }
        public List<int> registeredEscortIds { get; set; }
        public List<User> registeredEscortObj { get; set; }
        public int eventType { get; set; }
        public EventType eventTypeObj { get; set; }
        public string meetDate { get; set; }
        public string startDate { get; set; }
        public string customerPhone { get; set; }
        public string description { get; set; }
        public int customerCount { get; set; }
    }
}
