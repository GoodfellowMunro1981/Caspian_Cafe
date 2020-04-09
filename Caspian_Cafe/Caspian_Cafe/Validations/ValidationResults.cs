using System.Collections.Generic;
using System.Linq;

namespace Caspian_Cafe.Validations
{
    public class ValidationResults
    {
        #region Properties
        private readonly List<ValidationResult> items;
        #endregion

        #region Constructor
        public ValidationResults()
        {
            items = new List<ValidationResult>();
        }
        #endregion

        #region Public Methods
        public void AddValidation(ValidationSeverity severity, string message)
        {
            items.Add(new ValidationResult { Severity = severity, Message = message });
        }

        public bool AnyErrorOrInvalid()
        {
            return items.Any(x => x.Severity == ValidationSeverity.Error || x.Severity == ValidationSeverity.Invalid);
        }
        #endregion
    }
}
