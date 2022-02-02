using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public Guid User { get; set; }
        public Guid RelatedUser { get; set; }
        [Display(Name="Type of Relationship")]
        public Relationship HowRelated { get; set; }
        [Display(Name ="Connection Accepted?")]
        public bool Connected { get; set; }
    }
}
