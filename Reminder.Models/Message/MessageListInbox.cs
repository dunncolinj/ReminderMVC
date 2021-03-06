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
        [Display(Name = "Relationship ID")]
        public int RelationshipId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Sent")] 
        public DateTime WhenSent { get; set; }
        // populate with name of sender
        [Display(Name = "From")]
        public string SenderName { get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Display(Name = "Message Text")] 
        public string MessageText { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Read")] 
        public DateTime? WhenRead { get; set; }
    }
}
