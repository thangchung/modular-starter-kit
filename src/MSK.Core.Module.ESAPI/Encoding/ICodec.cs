namespace MSK.Core.Module.ESAPI.Encoding
{
    /// <summary>
    ///  The ICodec interface defines a set of methods for encoding and decoding application level encoding schemes, 
    ///  such as HTML entity encoding and percent encoding (aka URL encoding).
    /// </summary>
    public interface ICodec
    {
        /// <summary>
        /// Decode a String that was encoded using the encode method in this Class.
        /// </summary>
        /// <param name="input">The string to decode.</param>
        /// <returns>The decoded string.</returns> 
        string Encode(string input);

        /// <summary>
        /// Decode a String that was encoded using the encode method in this Class.
        /// </summary>
        /// <param name="input">The string to decode.</param>
        /// <returns>The decoded string.</returns> 
        string Decode(string input);
    }
}