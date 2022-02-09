using Reminder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class EventDetails
    {
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        // Name field - populate with first / middle / last name of person related to currently logged on user
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime NotifyBefore { get; set; }
    }
}
