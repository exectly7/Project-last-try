using System.Security;

namespace Project_last_try
{
    public class FileHandler
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public FileHandler(string filePath, string fileName)
        {
            FilePath = filePath;
            FileName = fileName;
        }
        public FileHandler(string filePath)
        {
            FilePath = filePath;
            FileName = "";
        }
        
        public string[] Import()
        {
            string[] data = File.ReadAllLines(FilePath);
            return data;
        }

        public void Export(string[] data)
        {
            File.WriteAllLines(FilePath + FileName, data);
        }
    }
    
} ///Users/ivanyburov/RiderProjects/Project last try/Project last try/Data/Output/loo.csvloo.csv