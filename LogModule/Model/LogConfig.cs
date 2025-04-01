namespace SAI.LogModule.Model
{
	internal class LogConfig {
		public string LogServiceFilePath { get; set; } = string.Empty;
		public bool AddSerilog { get; set; } = false;
		public int FixedLengthForComponentName { get; set; } = 20;
	}
}
