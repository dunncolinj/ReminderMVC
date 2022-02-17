using Microsoft.AspNetCore.Mvc.Rendering;
using Reminder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace Reminder.Models
{
    public class RelationshipCreate
    {
        public int Id { get; set; }
        public Guid User { get; set; }
        public string RelatedUserId { get; set; }
        public SelectListItem RelatedUserItem { get; set; }
        // populate with name of related user based on related user ID
        [Display(Name = "Name")]
        public string RelatedUserName { get; set; }
        [Display(Name = "Relationship")]
        public RelationshipType HowRelated { get; set; }
        [Display(Name = "Connected?")]
        public bool Connected { get; set; }
        public List<ApplicationUser> RelatedUsers { get; set; }
    }
}
