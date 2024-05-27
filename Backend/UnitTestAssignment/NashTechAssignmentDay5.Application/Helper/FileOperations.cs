using NashTechAssignmentDay5.Application.Interfaces;
using NashTechAssignmentDay5.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NashTechAssignmentDay5.Application.Helper
{
    public class FileOperations : IFileOperations
    {
        private static readonly string DATA_FILE_PATH = @"\NashTechAssignmentDay5.Infrastructure\Data\MockData.json";

        public List<Person> GetDataFromFile()
        {
            var people = new List<Person>();
            string fileDirectory = GetDataFilePath();
            if (File.Exists(fileDirectory))
            {
                using (StreamReader reader = new StreamReader(fileDirectory))
                {
                    string json = reader.ReadToEnd();
                    people = JsonConvert.DeserializeObject<List<Person>>(json);
                }
            }
            return people;
        }

        public bool SaveDataToFile(List<Person> people)
        {
            string fileDirectory = GetDataFilePath();
            if (File.Exists(fileDirectory))
            {
                using (StreamWriter writer = new StreamWriter(fileDirectory))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, people);
                    return true;
                }
            }
            return false;
        }

        private static string GetDataFilePath()
        {
            var relativePath = Directory.GetParent(Environment.CurrentDirectory).FullName;
            return relativePath + DATA_FILE_PATH;
        }
    }
}
