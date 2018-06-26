using System.ComponentModel.DataAnnotations;

namespace CompositeValidationAttributeExample
{
    public class NameAttribute : CompositeValidationAttribute
    {
        public NameAttribute()
        {
            ValidationAttributes.Add(new StringLengthAttribute(5));
            ValidationAttributes.Add(new RegularExpressionAttribute(@"^[A-Z]+[a-zA-Z""'\s-]*$"));
        }
    }
}
