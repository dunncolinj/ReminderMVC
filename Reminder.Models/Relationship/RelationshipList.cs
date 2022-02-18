using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminder.Data;

namespace Reminder.Models
{
    public class RelationshipList
    {
        public int Id { get; set; }
        public string RelatedUserId { get; set; }
        // populate with name of related user based on related user ID
        [Display(Name = "Name")] 
        public string RelatedUserName { get; set; }
        [Display(Name = "Relationship")] 
        public RelationshipType HowRelated { get; set; }
        [Display(Name = "Connected?")] 
        public bool Connected { get; set; }
    }
}
