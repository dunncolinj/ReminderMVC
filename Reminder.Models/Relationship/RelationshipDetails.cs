using Reminder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class RelationshipDetails
    {
        [Display(Name = "Relationship ID")]
        public int Id { get; set; }
        [Display(Name = "Related User ID")]
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
