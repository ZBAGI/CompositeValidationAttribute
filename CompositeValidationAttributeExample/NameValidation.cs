using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompositeValidationAttributeExample
{
    public class NameValidation
    {
        [StringLength(5)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string NameConstraint { get; set; }
    }
}
