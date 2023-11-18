using YetGenAkbankJump.Shared.Services;

namespace YetGenAkbankJump.WebApi.Services
{
    public class TextService : ITextService
    {
        private readonly string _path;

        public TextService()
        {
            _path = "D:\\Users\\HAKKICAN\\Desktop\\Software\\C#\\YetGen Jump & Akbank Backend Programı Eğitimi\\YetGenAkbankJump\\YetGenAkbankJump.WebApi\\Services\\passwords.txt";
        }

        public void Save(string text)
        {
            File.WriteAllText(_path, text);
        }
    }
}
