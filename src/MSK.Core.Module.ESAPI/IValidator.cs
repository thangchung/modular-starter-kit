namespace MSK.Core.Module.ESAPI
{
    /// <summary>
    /// The IValidator interface defines a set of methods for validating untrusted input.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Checks whether input is valid according to a given rule. The rule is determined by passing a rule
        /// name key, which is used to identify a particular ValidationRule object.
        /// </summary>
        /// <param name="rule">The rule name key to use for validation.</param>
        /// <param name="input">The input to validate.</param>
        /// <returns>True, if the data is valid. False, otherwise.</returns>
        bool IsValid(string rule, string input);

        /// <summary>
        /// Adds a rule object with the associated rule name key. This rule can be used to
        /// validate data later using the <see cref="Owasp.Esapi.Interfaces.IValidator.IsValid(string, string)"/> method.
        /// </summary>
        /// <param name="name">The rule name key to use for the new rule.</param>
        /// <param name="rule">
        ///     The rule object, which implements <see cref="Owasp.Esapi.Interfaces.IValidationRule"/>
        /// </param>
        void AddRule(string name, IValidationRule rule);

        /// <summary>
        /// Returns the rule object with the specified key.
        /// </summary>
        /// <param name="name">The rule name key to lookuip.</param>
        /// <returns>
        /// The <see cref="Owasp.Esapi.Interfaces.IValidationRule"/> object associated witht the rule name
        /// key
        /// </returns>
        IValidationRule GetRule(string name);

        /// <summary>
        /// Removes the rule object with the specified key.
        /// </summary>
        /// <param name="name">The rule name key for the rule to remove</param>
        void RemoveRule(string name);
    }
}