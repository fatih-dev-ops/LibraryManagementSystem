using LibraryManagementSystem.Enums;
using LibraryManagementSystem.Extensions;
using LibraryManagementSystem.Repository.Interfaces;
using Newtonsoft.Json;

namespace LibraryManagementSystem.Repository
{
    public class ReadAndWrite
    {
        public readonly string filePath;

        public ReadAndWrite(FilePathEnum filePathEnum)
        {
            filePath = filePathEnum.GetFilePath();
        }

        public string ReadFile()
        {
            string json = File.ReadAllText(filePath);
            return json;
        }
        public void WriteFile(object value)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(value, Formatting.Indented));
        }

        //public T FindMatchedObject<T>(List<T> values) where T : class
        //{
        //    var value = values.FirstOrDefault(x=> x.Id );
        //    return T;
        //}
    }
}
