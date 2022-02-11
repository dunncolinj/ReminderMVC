using Reminder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Name")] 
        public string Name { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)] 
        public DateTime Date { get; set; }
        [Display(Name = "Event Description")]
        public string Description { get; set; }
        [Display(Name = "Notify Me On")]
        [DataType(DataType.Date)] 
        public DateTime NotifyBefore { get; set; }
    }
}
