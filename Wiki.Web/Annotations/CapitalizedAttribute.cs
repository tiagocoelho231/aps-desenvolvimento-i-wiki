using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wiki.Web.Annotations
{
    public class CapitalizedAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return char.IsUpper(value.ToString()[0]);
        }
    }
}