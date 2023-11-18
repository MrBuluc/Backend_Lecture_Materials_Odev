using System.Text;
using YetGenAkbankJump.Shared.Services;

namespace YetGenAkbankJumpOOPConsole.Utilities
{
    public class PasswordGenerator
    {
        private readonly ITextService _textService;
        private readonly IIPService _ipService;

        public int GeneratedPasswordsCount { get; set; } = 0;

        private string _lastIp = string.Empty;

        private readonly Random _random;
        private const string Numbers = "0123456789";
        private const string SpecialChars = "!@#$%^&*()";
        private const string LowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Full = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()";



        public PasswordGenerator(ITextService textService, IIPService ipService)
        {
            _textService = textService;
            _ipService = ipService;
            _random = new Random();
        }

        public string Generate(int passwordLength, bool includeNumbers, bool includeLowerCase, bool includeUpperCase, bool includesSpecialChars)
        {
            StringBuilder charsBuilder = new();
            StringBuilder passwordBuilder = new();

            if (includeNumbers)
            {
                charsBuilder.Append(Numbers);
            }
            if (includeLowerCase)
            {
                charsBuilder.Append(LowerCaseChars);
            }
            if (includeUpperCase)
            {
                charsBuilder.Append(UpperCaseChars);
            }
            if (includesSpecialChars)
            {
                charsBuilder.Append(SpecialChars);
            }

            string acceptedChars = charsBuilder.ToString();

            for (int i = 0; i < passwordLength; i++)
            {
                int randomNo = _random.Next(0, acceptedChars.Length);

                passwordBuilder.Append(acceptedChars[randomNo]);
            }

            GeneratedPasswordsCount++;

            string password = passwordBuilder.ToString();

            _textService.Save(password);

            _lastIp = _ipService.Ip;

            return password;
        }
    }
}
