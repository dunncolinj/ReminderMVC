using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RelationshipId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTimeOffset NotifyBefore { get; set; }
    }
}
