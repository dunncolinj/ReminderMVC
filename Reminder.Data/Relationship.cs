using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data
{
    public enum RelationshipType { spouse, significantOther, grandparent, parent, child, grandchild, nieceNephew, auntUncle, cousin, friend, colleague }
    public class Relationship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public Guid User { get; set; }
        [ForeignKey(nameof(RelatedUser))]
        [Required]
        public Guid RelatedUser { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public RelationshipType HowRelated { get; set; }
        [Required]
        public bool Connected { get; set; }
    }
}
