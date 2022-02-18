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
        [Display(Name ="Related User ID")]
        public string RelatedUserId { get; set; }

        [Display(Name = "Relationship")]
        public RelationshipType HowRelated { get; set; }
    }
}
