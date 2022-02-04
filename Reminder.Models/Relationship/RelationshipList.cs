using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models.Relationships
{
    class RelationshipList
    {
        public int Id { get; set; }
        public Guid User { get; set; }
        public Guid RelatedUser { get; set; }
        public RelationshipType HowRelated { get; set; }
        public bool Connected { get; set; }
    }
}
