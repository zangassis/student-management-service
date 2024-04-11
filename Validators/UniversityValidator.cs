using FluentValidation;
using StudentManagementService.Models;

namespace StudentManagementService.Validators
{
    public class UniversityValidator : AbstractValidator<University>
    {
        public UniversityValidator()
        {
            RuleFor(university => university.Name)
            .NotEmpty()
            .WithMessage("The name is required.")
            .MaximumLength(50);
            
            RuleFor(university => university.Location)
            .NotEmpty()
            .WithMessage("The Location is required.")
            .MaximumLength(50);
        }
    }
}
