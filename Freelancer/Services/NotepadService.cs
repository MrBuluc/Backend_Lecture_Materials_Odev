using Freelancer.Abstract;
using Freelancer.Constants;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Freelancer.Services
{
    internal class NotepadService
    {
        public void checkPath(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public void SaveToNotepad(ICSVConvertible data)
        {
            string path = $"{FileLocations.ProjectFolder}\\Database";
            string type = data.GetType().ToString().Split(".").LastOrDefault();
            checkPath(path);
            string filePath = $"{path}\\{type}s.txt";

            File.AppendAllText(filePath, $"{data.GetValuesCSV()}\n");
        }

        public string GetOnNotepad(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            throw new Exception("File Doesn't Exist");
        }

        public void WriteToJson(IJSONConvertible data)
        {
            string path = $"{FileLocations.ProjectFolder}\\Database";
            string type = data.GetType().ToString().Split(".").LastOrDefault();
            string typePlural = $"{type}s";
            checkPath(path);

            List<Dictionary<string, dynamic>> list = GetJson(typePlural);
            list.Add(data.ToJSON());
            File.WriteAllText($"{path}\\{typePlural}.json", JsonConvert.SerializeObject(list));
        }

        public List<Dictionary<string, dynamic>>? GetJson(string jsonName)
        {
            string path = $"{FileLocations.ProjectFolder}\\Database";
            checkPath(path);

            using StreamReader reader = new($"{path}\\{jsonName}.json");
            return JsonConvert.DeserializeObject<List<Dictionary<string, dynamic>>>(reader.ReadToEnd());
        }
    }
}
