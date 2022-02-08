using Reminder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class MessageList
    {
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        public DateTime WhenSent { get; set; }
        // populate with name of recipient
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        // byte array non-nullable - stuff with default image when creating
        public byte[] Image { get; set; }
        public DateTime? WhenRead { get; set; }
    }
}
