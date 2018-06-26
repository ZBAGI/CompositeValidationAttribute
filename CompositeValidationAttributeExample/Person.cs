using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompositeValidationAttributeExample
{
    public class Person
    {
        [CompositeValidation(
        validationType: typeof(NameValidation),
        validationTypeMember: nameof(NameValidation.NameConstraint))]
        public string Name { get; set; }

        [CompositeValidation(
        validationType: typeof(EmailAddressValidation),
        validationTypeMember: nameof(EmailAddressValidation.EmailConstraint))]
        public string EmailAddress { get; set; }
    }
}
