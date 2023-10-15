using Newtonsoft.Json;

namespace Week_5_2.Services
{
    public class JsonService
    {
        public static Dictionary<string, dynamic>? GetJson(string path)
        {
            using StreamReader reader = new(path);
            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(reader.ReadToEnd());
        }
    }
}
