using System.ComponentModel.DataAnnotations;
using StudentManagementService.Models;
using StudentManagementService.Helpers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StudentManagementService.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<UniversityValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management Service V1");
});

app.MapPost("/student/create", (Student student) =>
{
    if (!IsValid(student, out var validationResult))
        return Results.BadRequest(validationResult);

    return Results.Ok();
}).AddEndpointFilter(async (efiContext, next) =>
{
    var tdparam = efiContext.GetArgument<Student>(0);

    var validationError = Utilities.IsValid(tdparam);

    if (!string.IsNullOrEmpty(validationError))
    {
        app.Logger.LogInformation($"Error when creating a new student: {validationError}");
        return Results.Problem(validationError);
    }
    return await next(efiContext);
});

static bool IsValid<T>(T obj, out ICollection<ValidationResult> results) where T : class
{
    var validationContext = new ValidationContext(obj);
    results = new List<ValidationResult>();

    return Validator.TryValidateObject(obj, validationContext, results, true);
}

app.MapPost("/university/create", (University university, [FromServices] IValidator<University> validator) =>
{
    var validationResult = validator.Validate(university);

    if (validationResult.IsValid)
        return Results.Ok("University object is valid.");
    else
        return Results.BadRequest(validationResult.Errors);
});

app.Run();