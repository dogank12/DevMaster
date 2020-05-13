using FluentValidation;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeFluent.Validators
{
    public class PersonValidator: AbstractValidator<PersonModel>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is blank")
                .Length(2,30).WithMessage("Length ({TotalLength}) of {PropertyName} is invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters")
                ;


            RuleFor(p => p.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is blank")
                .Length(2, 30).WithMessage("Length ({TotalLength}) of {PropertyName} is invalid")
                .Must(BeAValidName).WithMessage("{PropertyName} Contains Invalid Characters")
                ;

            RuleFor(p => p.DateOfBirth)
                .Must(BeAValidAge).WithMessage("Invalid {PropertyName}");
        }

        protected bool BeAValidName(string Name)
        {
            bool _output = false;

            Name = Name.Replace(" ", "");
            Name = Name.Replace("-", "");
            _output = Name.All(char.IsLetter);
            return _output;

        }

        protected bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
                return true;
            return false;
        }
    }
}
