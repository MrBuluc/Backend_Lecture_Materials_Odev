﻿namespace YetGenAkbankJumpOOPConsole.Services
{
    public class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger()
        {
        }

        public ConsoleLogger(string name) : base(name)
        {
        }


        protected internal override void Log(string message) => Console.WriteLine($"{message} - {DateTime.Now:g}");

        protected internal override void LogError(string message)
        {
            Console.WriteLine($"Error => {message} - {DateTime.Now:g}");
        }

        protected internal override void LogFail(string message)
        {
            throw new NotImplementedException();
        }

        protected internal override void LogInfo(string message)
        {
            Console.WriteLine($"Information => {message} - {DateTime.Now:g}");
        }

        protected internal override void LogSuccess(string message)
        {
            Console.WriteLine($"Success => {message} - {DateTime.Now:g}");
        }

        protected internal override void LogWarning(string message)
        {
            Console.WriteLine($"Warning => {message} - {DateTime.Now:g}");
        }
    }
}
