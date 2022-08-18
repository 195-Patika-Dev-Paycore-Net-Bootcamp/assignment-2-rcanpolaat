using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace StaffApplication
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }
        public int Salary { get; set; }

    }
}
