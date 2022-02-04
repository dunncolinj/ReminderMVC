using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class EventEdit
    {
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        public virtual Relationship Relationship { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTimeOffset NotifyBefore { get; set; }
    }
}
