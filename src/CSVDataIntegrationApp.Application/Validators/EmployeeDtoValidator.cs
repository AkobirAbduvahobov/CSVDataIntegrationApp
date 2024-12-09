using CSVDataIntegrationApp.Application.DTOs;
using FluentValidation;

namespace CSVDataIntegrationApp.Application.Validators;

public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
{
    public EmployeeDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .WithMessage("Id is required");

        RuleFor(x => x.PayrollNumber)
            .NotEmpty()
            .WithMessage("Payroll Number is required.");

        RuleFor(x => x.Forenames)
            .NotEmpty()
            .WithMessage("Forenames are required.")
            .MaximumLength(100)
            .WithMessage("Forenames cannot exceed 100 characters.");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("Surname is required.")
            .MaximumLength(100)
            .WithMessage("Surname cannot exceed 100 characters.");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now)
            .WithMessage("Date of Birth must be in the past.");

        RuleFor(x => x.Telephone)
            .Must(value => value != null && value.All(char.IsDigit))
            .WithMessage("Telephone must contain only digits.")
            .Length(5, 15)
            .WithMessage("Telephone must be between 5 and 15 digits.");

        RuleFor(x => x.Mobile)
            .Must(value => value != null && value.All(char.IsDigit))
            .WithMessage("Mobile must contain only digits.")
            .Length(5, 15)
            .WithMessage("Mobile must be between 5 and 15 digits.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required.");

        RuleFor(x => x.Postcode)
            .NotEmpty()
            .WithMessage("Postcode is required.")
            .MaximumLength(10)
            .WithMessage("Postcode cannot exceed 10 characters.");

        RuleFor(x => x.EmailHome)
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .When(x => !string.IsNullOrWhiteSpace(x.EmailHome));

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(new DateTime(2000, 1, 1))
            .WithMessage("Start Date must be on or after January 1, 2000.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Start Date cannot be in the future.");
    }
}
