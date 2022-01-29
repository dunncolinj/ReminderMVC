using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data
{
    public enum Genders { male, female, other };

    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Genders Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        // byte array not nullable. Stuff with default photo when creating object?
        public byte[] Photo { get; set; }
        // public string Email { get; set; } - get from user account?
        [Required] 
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
    }
}
