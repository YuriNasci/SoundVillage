using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SoundVillage.Admin.Attributes
{
    public class DurationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var duration = value as string;
            if (!string.IsNullOrEmpty(duration))
            {
                var regex = new Regex(@"^\d{2}:\d{2}$");
                if (regex.IsMatch(duration))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("A duração deve estar no formato mm:ss.");
        }
    }
}
