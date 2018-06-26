using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompositeValidationAttributeExample
{
    public abstract class CompositeValidationAttribute : Attribute, IModelValidator
    {
        protected List<ValidationAttribute> ValidationAttributes { get; } = new List<ValidationAttribute>();

        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var validationResult = new List<ModelValidationResult>();

            var validationContext = new ValidationContext(context.Model);

            foreach (var attribute in ValidationAttributes)
            {
                var result = attribute.GetValidationResult(context.Model, validationContext);
                if (result != null && !string.IsNullOrWhiteSpace(result.ErrorMessage))
                {
                    validationResult.Add(new ModelValidationResult(validationContext.MemberName, result.ErrorMessage));
                }
            }

            return validationResult;
        }
    }
}
