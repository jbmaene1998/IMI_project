using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Attributes
{
    public class CheckDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value) => Convert.ToDateTime(value) <= DateTime.Now;
    }
}
