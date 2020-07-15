using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroWaste.Models
{
    public class GreaterThanZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var x = (int)value;
            return x > 0;
        }
    }
}