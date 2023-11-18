using YetGenAkbankJump.Shared.Services;

namespace YetGenAkbankJump.MVCClient.Services
{
    public class MvcTextsService : ITextService
    {
        public void Save(string text)
        {
            File.WriteAllTextAsync("D:\\Users\\HAKKICAN\\Desktop\\Software\\C#\\YetGen Jump & Akbank Backend Programı Eğitimi\\YetGenAkbankJump\\YetGenAkbankJump.MVCClient\\TextFiles\\", text);
        }
    }
}
