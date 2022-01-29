using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Data
{
    public enum Genders { male, female, other };

    public class UserProfile
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Genders Gender { get; set; }
        public DateTime BirthDate { get; set; }
        // byte array not nullable. Stuff with default photo when creating object?
        public byte[] Photo { get; set; }
        // public string Email { get; set; } - get from user account?
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
