using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeValidationAttributeExample
{
    public class CompositeValidationAttribute : ValidationAttribute
    {
        private readonly Type _validationType;
        private readonly string _memberName;

        public CompositeValidationAttribute(Type validationType, string validationTypeMember)
        {
            _validationType = validationType;
            _memberName = validationTypeMember;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationAttributes = GetValidationAttributes();
            
            var errorMessageBuilder = new StringBuilder();

            foreach (var attribute in validationAttributes)
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

        private List<ValidationAttribute> GetValidationAttributes()
        {
            var attributes = _validationType
                .GetProperty(_memberName)
                .GetCustomAttributes(false);

            var validationAttributes = new List<ValidationAttribute>();

            foreach (var attribute in attributes)
            {
                validationAttributes.Add((ValidationAttribute)attribute);
            }

            return validationAttributes;
        }
    }
}
