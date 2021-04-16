using Microsoft.AspNetCore.Mvc;
using Model.Validation.Common.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Validation.API.Validator
{
    public class PersonValidator : Person, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var (valid, result) = PerformValidation(FirstName, LastName);
            if (!valid)
            {
                yield return result;
            }
        }

        private (bool, ValidationResult) PerformValidation(string firstName, string lastName)
        {
            return (string.IsNullOrWhiteSpace(firstName), string.IsNullOrWhiteSpace(lastName)) switch
            {
                (true, true) => (false, new ValidationResult("First Name and Last Name is empty", new[] { nameof(FirstName), nameof(LastName) })),
                (true, false) => (false, new ValidationResult("First Name is empty", new[] { nameof(FirstName) })),
                (false, true) => (false, new ValidationResult("Last Name is empty", new[] { nameof(LastName) })),
                _ => (true, null)
            };
        }
    }
}
