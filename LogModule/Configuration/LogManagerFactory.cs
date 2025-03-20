using LogModule.Interfaces;
using LogModule.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace LogModule.Configuration {
	/// <summary>
	/// Static class that creates an instance of LogsManager based on the internal Serilog configuration.
	/// </summary>
	public static class LogManagerFactory {
		/// <summary>
		/// Creates an instance of LogsManager based on the internal Serilog configuration.
		/// </summary>
		/// <returns>Instance of LogsManager.</returns>
		public static IServiceCollection CreateLogsManager(this IServiceCollection services,IConfiguration configuration) {
			// Configure Serilog using settings
			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.CreateLogger();
			Log.Information("Logger initialized.");

			// Register Serilog as the logging provider
			services.AddLogging(loggingBuilder => {
				loggingBuilder.AddSerilog(Log.Logger, dispose: true);
			});

			// Register LogsManager with Serilog's ILogger
			services.AddSingleton<ILogger>(Log.Logger);
			services.AddSingleton<ILogsManager, LogsManager>();

			return services;
		}
	}
}
