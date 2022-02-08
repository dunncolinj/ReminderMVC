using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Data;

namespace Reminder.Models
{
    public class RelationshipList
    {
        public int Id { get; set; }
        public Guid User { get; set; }
        public string RelatedUserId { get; set; }
        // populate with name of related user based on related user ID
        public string RelatedUserName { get; set; }
        public RelationshipType HowRelated { get; set; }
        public bool Connected { get; set; }
    }
}
