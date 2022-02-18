using Reminder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class EventList
    {
        [Display(Name = "Event ID")]
        public int Id { get; set; }
        [Display(Name = "Relationship ID")]
        public int RelationshipId { get; set; }
        // Name field - populate with first / middle / last name of person related to currently logged on user
        [Display(Name = "Name")] 
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Event Description")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Notify Me On")]
        public DateTime NotifyBefore { get; set; }
    }
}
