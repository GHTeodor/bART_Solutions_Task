using System.ComponentModel.DataAnnotations;
using bARTSolutionTask.Infrastructure.DbContext;

namespace bARTSolutionTask.Infrastructure.DbModelValidation;

public class UniqEmail : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DBContext _dbContext = (DBContext)validationContext.GetService(typeof(DBContext))!;

        if (_dbContext.Contacts.FirstOrDefault(contact =>
                contact.Email.ToUpper() == value.ToString().ToUpper()) is null)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Email already exist");
    }
}