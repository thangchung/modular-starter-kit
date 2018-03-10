using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MSK.Core.Module.ESAPI
{
    /// <summary>
    /// The IHttpUtilities interface is a collection of methods that provide additional security related to HTTP requests, responses, 
    /// sessions, cookies, headers, and logging.
    /// </summary>
    public interface IHttpUtilities
    {
        /// <summary>
        /// This method adds a CSRF token to all POST requests, automatically. This method should be called in a filter or
        /// front controller that is called for every request. Since POST requests are generally not idempotent, they should
        /// always be protected from CSRF. GET requests should follow an opt-in model for CSRF protection - see 
        /// <see href="Owasp.Esapi.Interfaces.AddCsrfToken(string)"/>.
        /// </summary>
        void AddCsrfToken();

        /// <summary>
        /// Adds a CSRF token to the URL for purposes of preventing CSRF attacks. This should be used for pages which accept
        /// GET requests and are not idempotent (have lasting side effects). This should work in correlation with the 
        /// <see href="Owasp.Esapi.Interfaces.AddCsrfToken()"/> method. This method is an opt-in way to specify pages which
        /// accept GET requests and need to be protected against CSRF.
        /// </summary>
        /// <param name="href">The URL to which the CSRF token will be appended</param>
        /// <returns>The updated URL with the CSRF token parameter added</returns>                       
        string AddCsrfToken(string href);

        /// <summary>
        /// This method verifies that the request has the appropriate CSRF tokens. 
        /// </summary>
        void VerifyCsrfToken();

        /// <summary>
        /// This method is used to add HTTP headers to prevent caching. This protects against sensitive information being
        /// left in the client-side browser cache.
        /// </summary>
        void AddNoCacheHeaders();

        /// <summary>
        /// This method changes the session identifier, while leaving the underlying session data consistent.
        /// </summary>
        void ChangeSessionIdentifier();

        /// <summary>
        /// Log HTTP request 
        /// </summary>
        /// <param name="request">Request to log</param>
        /// <param name="logger">Logger to use</param>
        /// <param name="obfuscatedParams">Parameter names to obfuscate</param>
        void LogHttpRequest(HttpRequest request, ILogger logger, ICollection<string> obfuscatedParams);

        /// <summary>
        /// Ensure request is secure (over SSL and using POST)
        /// </summary>
        /// <param name="request">Request to test</param>
        void AssertSecureRequest(HttpRequest request);
    }
}