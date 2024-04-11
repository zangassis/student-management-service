using StudentManagementService.Models;

namespace StudentManagementService.Helpers;

public static class Utilities
{
    public static string IsValid(Student student)
    {
        string errorMessage = string.Empty;

        if (string.IsNullOrEmpty(student.Name))
            errorMessage = "Student name is required";

        return errorMessage;
    }
}