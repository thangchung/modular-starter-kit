using System;

namespace MSK.Core.Module.ESAPI
{
    /// <summary> 
    /// The ILogger interface defines a set of methods that can be used to log events.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// The logging level associated with this Logger.
        /// </summary>
        int Level { get; set; }

        /// <summary> Log a fatal event if 'fatal' level logging is enabled.</summary>
        /// <param name="type">The type of event.
        /// </param>
		/// <param name="message">The message to log.
		/// </param>
		void Fatal(int type, string message);

        /// <summary> 
        /// Log a fatal level security event if 'fatal' level logging is enabled 
        /// and also record the stack trace associated with the event.
        /// </summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        /// <param name="exception">The exception to log.
        /// </param>
        void Fatal(int type, string message, Exception exception);

        /// <summary>
        /// Allows the caller to determine if messages logged at this level
        /// will be discarded, to avoid performing expensive processing.
        /// </summary>
        /// <returns>true, if fatal level messages will be output to the log.</returns>
        bool IsFatalEnabled();

        /// <summary>Log an error level security event if 'error' level logging is enabled.</summary>
        /// <param name="type">The type of event
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        void Error(int type, string message);

        /// <summary>
        /// Log an error level security event if 'error' level logging is enabled 
        /// and also record the stack trace associated with the event.
        /// </summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        /// <param name="throwable">The exception to log.
        /// </param>	
        void Error(int type, string message, Exception throwable);

        /// <summary>
        /// Allows the caller to determine if messages logged at this level
	    /// will be discarded, to avoid performing expensive processing.
        /// </summary>
        /// <returns>true, if error level messages will be output to the log.</returns>
        bool IsErrorEnabled();

        /// <summary> Log a warning level security event if 'warning' level logging is enabled.</summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        void Warning(int type, string message);

        /// <summary>
        /// Log a warning level security event if 'warning' level logging is enabled 
        /// and also record the stack trace associated with the event.
        /// </summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        /// <param name="throwable">The exception to log.
        /// </param>			
        void Warning(int type, string message, Exception throwable);

        /// <summary>
        /// Allows the caller to determine if messages logged at this level
        /// will be discarded, to avoid performing expensive processing.
        /// </summary>
        /// <returns>true, if warning level messages will be output to the log.</returns>
        bool IsWarningEnabled();

        /// <summary> Log a warning level security event if 'info' level logging is enabled.</summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        void Info(int type, string message);

        /// <summary>
        /// Log a warning level security event if 'info' level logging is enabled 
        /// and also record the stack trace associated with the event.
        /// </summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        /// <param name="throwable">The exception to log.
        /// </param>			
        void Info(int type, string message, Exception throwable);

        /// <summary>
        /// Allows the caller to determine if messages logged at this level
        /// will be discarded, to avoid performing expensive processing.
        /// </summary>
        /// <returns>true, if info level messages will be output to the log.</returns>
        bool IsInfoEnabled();

        /// <summary> Log a warning level security event if 'debug' level logging is enabled.</summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
		void Debug(int type, string message);

        /// <summary>
        /// Log a warning level security event if 'debug' level logging is enabled 
        /// and also record the stack trace associated with the event.
        /// </summary>
        /// <param name="type">The type of event.
        /// </param>
        /// <param name="message">The message to log.
        /// </param>
        /// <param name="throwable">The exception to log.
        /// </param>	
		void Debug(int type, string message, Exception throwable);

        /// <summary>
        /// Allows the caller to determine if messages logged at this level
        /// will be discarded, to avoid performing expensive processing.
        /// </summary>
        /// <returns>true, if debug level messages will be output to the log.</returns>
        bool IsDebugEnabled();
    }
}