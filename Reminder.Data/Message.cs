using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(RelationshipId))] 
        public virtual Relationship Relationship { get; set; }
        [Required]
        public DateTime WhenSent { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageText { get; set; }
        public DateTime? WhenRead { get; set; }
    }
}
