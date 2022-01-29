using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data
{
    public enum Relationships { spouse, significantOther, grandparent, parent, child, grandchild, nieceNephew, auntUncle, cousin, friend, colleague }
    public class Relationship
    {
        public int Id { get; set; }
        public Guid User { get; set; }
        // public Guid RelatedUser { get; set; }
        public int RelatedUser { get; set; }
        public Relationships HowRelated { get; set; }
        public bool Connected { get; set; }
    }
}
