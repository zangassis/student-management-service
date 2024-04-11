using System.ComponentModel.DataAnnotations;
using StudentManagementService.Attributes;

namespace StudentManagementService.Models;

public class Student
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "The name is required.")]
    [StringLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "The LastName is required.")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "The email is required.")]

    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "The phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string PhoneNumber { get; set; }

    [MaxLength(15)]
    [Required(ErrorMessage = "The street address is required.")]
    public string StreetAddress { get; set; }

    [CityValidation]
    [Required(ErrorMessage = "The city is required.")]
    public string City { get; set; }

    [Required(ErrorMessage = "The state is required.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "The state abbreviation must be 2 characters.")]
    public string State { get; set; }
}