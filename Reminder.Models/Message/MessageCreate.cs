using Reminder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class MessageCreate
    {
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        public DateTime WhenSent { get; set; }
        // populate with name of recipient
        public string RecipientName { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public DateTime? WhenRead { get; set; }
    }
}
