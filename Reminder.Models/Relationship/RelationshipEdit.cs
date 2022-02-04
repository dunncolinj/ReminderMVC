﻿using Reminder.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models.Relationships
{
    class RelationshipEdit
    {
        public int Id { get; set; }
        public Guid User { get; set; }
        public string RelatedUser { get; set; }
        public RelationshipType HowRelated { get; set; }
        public bool Connected { get; set; }
    }
}
