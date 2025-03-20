using LogModule.Configuration;
using LogModule.Interfaces;
using Serilog;
using Serilog.Context;
using System.Runtime.CompilerServices;

namespace LogModule.Services {
	/// <inheritdoc/>
	public class LogsManager(ILogger Logger) : ILogsManager {
		private const int fixedLengthForComponentName = 20;

		private enum EnLogType {
			Information,
			Error,
			Warning,
			Debug,
			Fatal,
			Trace
		}

		/// <inheritdoc/>
		public void Information(string message, string componentName, string correlationId = "",
			[CallerMemberName] string memberName = "",
			[CallerLineNumber] int lineNumber = 0) {
			LogWithContext(EnLogType.Information, componentName, message, correlationId, memberName, lineNumber);
		}

		/// <inheritdoc/>
		public void Error(string message, string componentName, string correlationId = "",
			[CallerMemberName] string memberName = "",
			[CallerLineNumber] int lineNumber = 0) {
			LogWithContext(EnLogType.Error, componentName, message, correlationId, memberName, lineNumber);
		}

		/// <inheritdoc/>
		public void Warning(string message, string componentName, string correlationId = "",
			[CallerMemberName] string memberName = "",
			[CallerLineNumber] int lineNumber = 0) {
			LogWithContext(EnLogType.Warning, componentName, message, correlationId, memberName, lineNumber);
		}

		/// <inheritdoc/>
		public void Debug(string message, string componentName, string correlationId = "",
			[CallerMemberName] string memberName = "",
			[CallerLineNumber] int lineNumber = 0) {
			LogWithContext(EnLogType.Debug, componentName, message, correlationId, memberName, lineNumber);
		}

		/// <inheritdoc/>
		public void Fatal(string message, string componentName, string correlationId = "",
			[CallerMemberName] string memberName = "",
			[CallerLineNumber] int lineNumber = 0) {
			LogWithContext(EnLogType.Fatal, componentName, message, correlationId, memberName, lineNumber);
		}

		/// <inheritdoc/>
		public void Trace(string message, string componentName, string correlationId = "",
			[CallerMemberName] string memberName = "",
			[CallerLineNumber] int lineNumber = 0) {
			LogWithContext(EnLogType.Trace, componentName, message, correlationId, memberName, lineNumber);
		}

		/// <summary>
		/// Generalized method to log messages with context (component name, correlation ID).
		/// </summary>
		private void LogWithContext(EnLogType level, string componentName, string message, string correlationId, string memberName, int lineNumber) {
			componentName = string.IsNullOrEmpty(componentName)
				? new string(' ', fixedLengthForComponentName) // If the component name is empty, fill it with spaces
				: componentName.Length > fixedLengthForComponentName
					? componentName[^fixedLengthForComponentName..] //If it was longer than the fixed length, take the last characters
					: componentName.PadLeft(fixedLengthForComponentName); // If it was shorter, add spaces to the left
			using (LogContext.PushProperty("ComponentName", componentName))
			using (LogContext.PushProperty("CorrelationId", correlationId))
			using (LogContext.PushProperty("MemberName", memberName))
			using (LogContext.PushProperty("LineNumber", lineNumber)) {

				switch (level) {
					case EnLogType.Information:
						Logger.Information($"{message}");
						break;
					case EnLogType.Error:
						Logger.Error($"{message}");
						break;
					case EnLogType.Warning:
						Logger.Warning($"{message}");
						break;
					case EnLogType.Debug:
						Logger.Debug($"{message}");
						break;
					case EnLogType.Fatal:
						Logger.Fatal($"{message}");
						break;
					case EnLogType.Trace:
						Logger.Verbose($"{message}");
						break;
					default:
						Logger.Information($"{message}");
						break;
				}
			}
		}
	}
}
