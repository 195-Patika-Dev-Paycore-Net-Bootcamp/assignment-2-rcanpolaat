using FluentValidation;
using System.Text.RegularExpressions;

namespace StaffApplication
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            DateTime max = new DateTime(2002, 10, 10, 00, 00, 00); //Created a new datetime named max
            DateTime min = new DateTime(1945, 11, 11, 00, 00, 00); //Created a new datetime named min
            RuleFor(Staff => Staff.Name).Length(3, 20).NotEmpty().WithMessage("Name lenght must be between 3-20"); //
            RuleFor(Staff => Staff.LastName).Length(3, 20).NotEmpty().WithMessage("LastName lenght must be between 3-20");
            RuleFor(Staff => Staff.DateOfBirth).NotEmpty().Must(DateOfBirth => DateOfBirth < max && DateOfBirth > min).WithMessage("DateOfBirth must be between 10.10.2002 - 11.11.1945");
            RuleFor(Staff => Staff.Email).Matches(new Regex(@"^[a-zA-Z\.@]{2,100}$")).WithMessage("Email must not include numbers or special characters");
            RuleFor(Staff => Staff.PhoneNumber).NotEmpty().WithMessage("Phone Number must not be empty");
            RuleFor(Staff => Staff.Salary).GreaterThan(3000).LessThan(9000).NotEmpty().WithMessage("Salary must be between 3000 - 9000");
        }

    }
}
