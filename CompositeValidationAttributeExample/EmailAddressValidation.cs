using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompositeValidationAttributeExample
{
    public class EmailAddressValidation
    {
        [StringLength(5)]
        [EmailAddress]
        public string EmailConstraint { get; set; }
    }
}
