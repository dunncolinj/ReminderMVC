using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    class Message
    {
        public int Id { get; set; }
        public int RelationshipId { get; set; }
        [Display(Name="Sent Date/Time")]
        public DateTime WhenSent { get; set; }
        [Display(Name ="Subject")]
        public string Subject { get; set; }
        [Display(Name ="Message Text")]
        public string MessageText { get; set; }
        // byte array non-nullable - stuff with default image when creating
        [Display(Name = "Image")]
        public byte[] Image { get; set; }
        [Display(Name ="Read Date/Time")]
        public DateTime? WhenRead { get; set; }
    }
}
