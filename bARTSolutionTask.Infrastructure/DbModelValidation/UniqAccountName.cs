using System.ComponentModel.DataAnnotations;
using bARTSolutionTask.Infrastructure.DbContext;

namespace bARTSolutionTask.Infrastructure.DbModelValidation;

public class UniqAccountName: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DBContext _dbContext = (DBContext)validationContext.GetService(typeof(DBContext));

        if (_dbContext.Accounts.FirstOrDefault(account => account.Name.ToUpper() == value.ToString().ToUpper()) is null)
        {
            return ValidationResult.Success;
        }
        return new ValidationResult(ErrorMessage ?? "Name must be unique");
    }
}