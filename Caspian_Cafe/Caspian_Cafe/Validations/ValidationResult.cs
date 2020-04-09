using System;
using System.Collections.Generic;
using System.Text;

namespace Caspian_Cafe.Validations
{
    public class ValidationResult
    {
        public string Message { get; set; }

        public ValidationSeverity Severity { get; set; }
    }
}
