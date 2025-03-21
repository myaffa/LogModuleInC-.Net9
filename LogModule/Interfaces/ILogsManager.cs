using System.Runtime.CompilerServices;

namespace SAI.LogModule.Interfaces {
	/// <summary>
	/// Defines the interface for logging functionality in the application.
	/// Provides methods for logging messages with different log levels (e.g., Information, Error, Warning, Debug, Fatal, Trace)
	/// and ensures structured, formatted, and consistent logging.
	/// </summary>
	/// <remarks>
	/// The `ILogManager` interface is designed to abstract the logging functionality from the underlying logging framework.
	/// It supports centralized logging and is ideal for use in distributed systems.
	/// Example usage:
	/// <code>
	/// var logger = new LogsManager();
	/// logger.LogInformation("PaymentService", "Payment processed successfully", "Corr123");
	/// </code>
	/// </remarks>
	public interface ILogsManager {
		/// <summary>
		/// Logs an informational message.
		/// Use this for general information about the application's operation.
		/// </summary>
		/// <param name="message">The log message content.</param>
		/// <param name="componentName">The name of the component or service generating the log.</param>
		/// <param name="correlationId">Optional correlation ID for tracking related logs.</param>
		/// <param name="memberName">The name of the member invoking the log method. This is automatically provided by the compiler.</param>
		/// <param name="lineNumber">The line number of the source file where the log method is called. This is automatically provided by the compiler.</param>
		void Information(string message, string componentName, string correlationId = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

		/// <summary>
		/// Logs an error message.
		/// Use this for recording exceptions or critical failures.
		/// </summary>
		/// <param name="message">The log message content.</param>
		/// <param name="componentName">The name of the component or service generating the log.</param>
		/// <param name="correlationId">Optional correlation ID for tracking related logs.</param>
		/// <param name="memberName">The name of the member invoking the log method. This is automatically provided by the compiler.</param>
		/// <param name="lineNumber">The line number of the source file where the log method is called. This is automatically provided by the compiler.</param>
		void Error(string message, string componentName, string correlationId = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

		/// <summary>
		/// Logs a warning message.
		/// Use this for potential issues or non-critical problems.
		/// </summary>
		/// <param name="message">The log message content.</param>
		/// <param name="componentName">The name of the component or service generating the log.</param>
		/// <param name="correlationId">Optional correlation ID for tracking related logs.</param>
		/// <param name="memberName">The name of the member invoking the log method. This is automatically provided by the compiler.</param>
		/// <param name="lineNumber">The line number of the source file where the log method is called. This is automatically provided by the compiler.</param>
		void Warning(string message, string componentName, string correlationId = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

		/// <summary>
		/// Logs a debug message.
		/// Use this for development and troubleshooting information.
		/// </summary>
		/// <param name="message">The log message content.</param>
		/// <param name="componentName">The name of the component or service generating the log.</param>
		/// <param name="correlationId">Optional correlation ID for tracking related logs.</param>
		/// <param name="memberName">The name of the member invoking the log method. This is automatically provided by the compiler.</param>
		/// <param name="lineNumber">The line number of the source file where the log method is called. This is automatically provided by the compiler.</param>
		void Debug(string message, string componentName, string correlationId = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

		/// <summary>
		/// Logs a fatal error message.
		/// Use this for recording critical issues that cause the application to terminate or enter an unrecoverable state.
		/// </summary>
		/// <param name="message">The log message content.</param>
		/// <param name="componentName">The name of the component or service generating the log.</param>
		/// <param name="correlationId">Optional correlation ID for tracking related logs.</param>
		/// <param name="memberName">The name of the member invoking the log method. This is automatically provided by the compiler.</param>
		/// <param name="lineNumber">The line number of the source file where the log method is called. This is automatically provided by the compiler.</param>
		void Fatal(string message, string componentName, string correlationId = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);

		/// <summary>
		/// Logs a trace message.
		/// Use this for tracking the execution flow or debugging detailed steps in the application's processes.
		/// </summary>
		/// <param name="message">The log message content.</param>
		/// <param name="componentName">The name of the component or service generating the log.</param>
		/// <param name="correlationId">Optional correlation ID for tracking related logs.</param>
		/// <param name="memberName">The name of the member invoking the log method. This is automatically provided by the compiler.</param>
		/// <param name="lineNumber">The line number of the source file where the log method is called. This is automatically provided by the compiler.</param>
		void Trace(string message, string componentName, string correlationId = "", [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0);
	}
}
