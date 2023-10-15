using System.Text;

namespace YetGenAkbankJumpOOPConsole.Utilities
{
    public class PasswordGenerator
    {
        private readonly Random _random;
        private const string Numbers = "0123456789";
        private const string SpecialChars = "!@#$%^&*()";
        private const string LowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";



        public PasswordGenerator()
        {
            _random = new Random();
        }

        public string Generate(int passwordLength, bool includeNumbers, bool includeLowerCase, bool includeUpperCase, bool includesSpecialChars)
        {
            StringBuilder charsBuilder = new();
            StringBuilder password = new();

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

                password.Append(acceptedChars[randomNo]);
            }

            return password.ToString();
        }
    }
}
