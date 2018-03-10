namespace MSK.Core.Module.ESAPI
{
    /// <summary>
    /// A class that implements IValidationRule performs validation of a single 
    /// piece of data from an untrusted source.
    /// </summary>
    public interface IValidationRule
    {
        /// <summary>
        /// Returns boolean value indicating whether input is considered valid.
        /// </summary>
        /// <param name="input">The input to validate.</param>
        /// <returns>True, if input value is valid. False, otherwise.</returns>
        bool IsValid(string input);
    }
}