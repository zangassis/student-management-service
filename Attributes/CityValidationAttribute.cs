using System.ComponentModel.DataAnnotations;

namespace StudentManagementService.Attributes;

public class CityValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var cityName = value as string;
        var newYorkCities = new List<string>
        {
            "New York City",
            "Buffalo",
            "Rochester",
            "Yonkers",
            "Syracuse",
            "Albany",
            "New Rochelle",
            "Mount Vernon",
            "Schenectady",
            "Utica"
        };

        if (!newYorkCities.Contains(cityName))
            return new ValidationResult("The city provided is not a valid city in New York.", new[] { validationContext.MemberName });

        return ValidationResult.Success;
    }
}
