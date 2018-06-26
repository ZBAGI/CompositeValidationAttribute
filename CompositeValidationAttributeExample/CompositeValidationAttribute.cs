using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompositeValidationAttributeExample
{
    public abstract class CompositeValidationAttribute : ValidationAttribute
    {
        protected List<ValidationAttribute> ValidationAttributes { get; } = new List<ValidationAttribute>();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errorMessageBuilder = new StringBuilder();

            foreach (var attribute in ValidationAttributes)
            {
                var result = attribute.GetValidationResult(value, validationContext);

                if (result != null && !string.IsNullOrWhiteSpace(result.ErrorMessage))
                {
                    errorMessageBuilder.Append($"{result.ErrorMessage} ");
                }
            }

            if (errorMessageBuilder.Length == 0)
            {
                return ValidationResult.Success;
            }
            var errorMessage = errorMessageBuilder.ToString().TrimEnd();

            return new ValidationResult(
                errorMessage: errorMessage, 
                memberNames: new List<string> { validationContext.MemberName });
        }
    }
}
