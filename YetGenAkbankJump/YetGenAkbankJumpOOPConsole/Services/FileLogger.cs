namespace YetGenAkbankJumpOOPConsole.Services
{
    public class FileLogger : LoggerBase
    {
        private readonly string _filePath;
        protected internal override string? Name { get; set; } = "Mr. Bülüç";
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        protected internal override void Log(string message) => File.AppendAllText(_filePath, $"{message} - {DateTime.Now:g}\n");

        protected internal override void LogError(string message)
        {
            File.AppendAllText(_filePath, $"Error => {message} - {DateTime.Now:g}\n");
        }

        protected internal override void LogInfo(string message)
        {
            File.AppendAllText(_filePath, $"Information => {message} - {DateTime.Now:g}\n");
        }

        protected internal override void LogSuccess(string message)
        {
            File.AppendAllText(_filePath, $"Success => {message} - {DateTime.Now:g}\n");
        }

        protected internal override void LogWarning(string message)
        {
            File.AppendAllText(_filePath, $"Warning => {message} - {DateTime.Now:g}\n");
        }

        protected internal override void LogFatal(string message)
        {
            File.AppendAllText(_filePath, $"Fatal => {message} - {DateTime.Now:g}");
            base.LogFatal(message);
        }

        protected internal override void LogFail(string message)
        {
            throw new NotImplementedException();
        }
    }
}
