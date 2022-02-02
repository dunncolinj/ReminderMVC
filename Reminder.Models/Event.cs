using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        [Display(Name="Relationship")]
        public Relationship Relationship { get; set; }
        [Display(Name="Date of Event")]
        public DateTime Date { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Display(Name ="Notify How Long Before?")]
        public DateTimeOffset NotifyBefore { get; set; }
    }
}
