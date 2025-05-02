
using System.ComponentModel.DataAnnotations;

namespace CommonLayer.Models
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                var age = DateTime.Today.Year - birthDate.Year;
                if (DateTime.Today < birthDate.AddYears(age))
                {
                    age--;
                }

                if (age < _minimumAge)
                {
                    return new ValidationResult($"Age must be greater than {_minimumAge}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}