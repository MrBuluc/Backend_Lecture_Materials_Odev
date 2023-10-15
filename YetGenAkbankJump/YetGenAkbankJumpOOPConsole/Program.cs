using YetGenAkbankJumpOOPConsole.Utilities;

PasswordGenerator passwordGenerator = new();

Console.WriteLine("Lütfen şifreniz için istediğiniz karakter sayısını giriniz: ");

string passwordLength = Console.ReadLine();

Console.WriteLine("Şifreniz sayıları içersin mi?");
bool includeNumbers = Console.ReadLine() == "evet";

Console.WriteLine("Şifreniz küçük karakteri içersin mi?");
bool includeLowerCase = Console.ReadLine() == "evet";

Console.WriteLine("Şifreniz büyük karakter içersin mi?");
bool includeUpperCase = Console.ReadLine() == "evet";

Console.WriteLine("Şifreniz özel karakter içersin mi?");
bool includeSpecialChars = Console.ReadLine() == "evet";

if (string.IsNullOrEmpty(passwordLength))
{
    Console.WriteLine("God damn it son!");

    return;
}

Console.WriteLine($"Şifreniz: {passwordGenerator.Generate(Convert.ToInt32(passwordLength), includeNumbers, includeLowerCase, includeUpperCase, includeSpecialChars)}");