using System.ComponentModel.DataAnnotations;

namespace CompositeValidationAttributeExample
{
    public class EmailAttribute : CompositeValidationAttribute
    {
        public EmailAttribute()
        {
            ValidationAttributes.Add(new EmailAddressAttribute());
            ValidationAttributes.Add(new StringLengthAttribute(5));
        }
    }
}
