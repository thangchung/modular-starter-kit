using System.Collections.Generic;
using System.Security.Principal;

namespace MSK.Core.Module.ESAPI
{
    /// <summary> 
    /// The ISecurityConfiguration interface stores all configuration information
    /// that directs the behavior of the ESAPI implementation. 
    /// </summary>
    public interface ISecurityConfiguration
    {
        /// <summary> 
        /// The master password.
        /// </summary>
        string MasterPassword
        {
            get;

        }

        /// <summary> 
        /// The master salt.        
        /// </summary>        
        byte[] MasterSalt
        {
            get;
        }

        /// <summary> 
        /// The allowed file extensions.        
        /// </summary>
        IList<string> AllowedFileExtensions
        {
            get;
        }

        /// <summary> 
        /// The allowed file upload size.        
        /// </summary>
        int AllowedFileUploadSize
        {
            get;
        }

        /// <summary> 
        /// The encryption algorithm.        
        /// </summary>
        string EncryptionAlgorithm
        {
            get;
        }
        /// <summary> 
        /// The hasing algorithm.        
        /// </summary>
        string HashAlgorithm
        {
            get;
        }
        /// <summary> 
        /// The character encoding.        
        /// </summary>
        string CharacterEncoding
        {
            get;
        }
        /// <summary> 
        /// The digital signature algorithm.        
        /// </summary>
        string DigitalSignatureAlgorithm
        {
            get;
        }
        /// <summary> 
        /// The random number generation algorithm.
        /// </summary>
        string RandomAlgorithm
        {
            get;
        }

        /// <summary>
        /// The log level to use for logging.
        /// </summary>
        int LogLevel
        {
            get;
        }

        /// <summary>
        /// Whether or not HTML encoding is required in the log file.
        /// </summary>
        bool LogEncodingRequired
        {
            get;
        }

        /// <summary>
        /// Current user
        /// </summary>
        IPrincipal CurrentUser
        {
            get;
        }
    }
}