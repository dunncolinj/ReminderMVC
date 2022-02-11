using Reminder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class MessageListInbox
    {
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        [DataType(DataType.Date)] 
        public DateTime WhenSent { get; set; }
        // populate with name of sender
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        [DataType(DataType.Date)] 
        public DateTime? WhenRead { get; set; }
    }
}
