using SAI.LogModule.Interfaces;
using SAI.LogModule.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.Logging;
using SAI.LogModule.Model;

namespace SAI.LogModule.Configuration {
	/// <summary>
	/// Static class that creates an instance of LogsManager based on the internal Serilog configuration.
	/// </summary>
	public static class LogManagerFactory {
		/// <summary>
		/// Creates an instance of LogsManager based on the internal Serilog configuration.
		/// </summary>
		/// <returns>Instance of LogsManager.</returns>
		public static IServiceCollection CreateLogsManager(this IServiceCollection services, IConfiguration configuration) {
			var logConfig = configuration.GetSection("LogConfig").Get<LogConfig>();

			if (logConfig == null) {
				logConfig = new LogConfig();
			}

			var serilogConfig = new ConfigurationBuilder()
				.AddConfiguration(configuration)
				.Build();

			if (!string.IsNullOrEmpty(logConfig.LogServiceFilePath)) {
				string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ServiceLog\\logMT5.txt");

				var section = serilogConfig.GetSection("Serilog:WriteTo");
				foreach (var item in section.GetChildren()) {
					if (item.GetValue<string>("Name") == "File") {
						item.GetSection("Args").GetSection("path").Value = logPath;
					}
				}
			}
			Serilog.ILogger logger = new LoggerConfiguration()
				.ReadFrom.Configuration(configuration)
				.Enrich.FromLogContext()
				.CreateLogger();

			logger.Information("Logger initialized.");

			// Register Serilog as the logging provider
			services.AddLogging(loggingBuilder => {
				loggingBuilder.ClearProviders();
				if (logConfig.AddSerilog)
					loggingBuilder.AddSerilog(logger);
			});

			// Register LogsManager with Serilog's ILogger
			services.AddSingleton<Serilog.ILogger>(logger);
			services.AddSingleton<ILogsManager>(provider => new LogsManager(logger, logConfig.FixedLengthForComponentName));

			return services;
		}
	}
}
