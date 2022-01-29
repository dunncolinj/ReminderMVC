using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data
{
    public enum Relationships { spouse, significantOther, grandparent, parent, child, grandchild, nieceNephew, auntUncle, cousin, friend, colleague }
    public class Relationship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid User { get; set; }
        // public Guid RelatedUser { get; set; }
        [Required]
        public int RelatedUser { get; set; }
        [Required]
        public Relationships HowRelated { get; set; }
        [Required]
        public bool Connected { get; set; }
    }
}
