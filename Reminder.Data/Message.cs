using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int RelationshipId { get; set; }
        [Required]
        public DateTime WhenSent { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageText { get; set; }
        // byte array non-nullable - stuff with default image when creating
        [Required]
        public byte[] Image { get; set; }
        public DateTime? WhenRead { get; set; }
    }
}
