using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
//        [ForeignKey(nameof(RelationshipId))]
        public int RelationshipId { get; set; }
        [ForeignKey(nameof(RelationshipId))]
        public virtual Relationship Relationship { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime NotifyBefore { get; set; }
    }
}
