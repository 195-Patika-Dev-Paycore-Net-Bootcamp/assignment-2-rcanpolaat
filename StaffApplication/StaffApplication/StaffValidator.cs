using FluentValidation;

namespace StaffApplication
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(Staff => Staff.Name).Length(3, 20).NotEmpty();
            RuleFor(Staff => Staff.LastName).Length(3, 20).NotEmpty();
            RuleFor(Staff => Staff.DateOfBirth).Must(BeValidAge);
            RuleFor(Staff => Staff.Email);
            RuleFor(Staff => Staff.PhoneNumber);
            RuleFor(Staff => Staff.Salary).GreaterThan(3000).LessThan(9000);
        }
        private bool BeValidAge(DateTime date)
        {
            DateTime MinDate = new DateTime(1945, 11, 11);
            DateTime MaxDate = new DateTime(2002, 10, 10);

            if (date.Year > MinDate.Year && date.Year < MaxDate.Year)
                return true;

            else if (date.Year == MinDate.Year)
            {
                if (date.Month > MinDate.Month)
                    return true;
                else if (date.Month == MinDate.Month)
                {
                    if (date.Day > MinDate.Day)
                        return true;
                    else
                        return false;
                }
            }
            else if (date.Year == MaxDate.Year)
            {
                if (date.Month < MaxDate.Month)
                    return true;
                else if (date.Month == MaxDate.Month)
                {
                    if (date.Day < MaxDate.Day)
                        return true;
                    else
                        return false;
                }
            }
            return false;

        }
    }
}
