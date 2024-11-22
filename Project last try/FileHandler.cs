namespace Project_last_try
{
    /// <summary>
    /// Класс для записи и чтения в/из файла.
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// Путь к файлу.
        /// </summary>
        private string FilePath { get; set; }
        
        /// <summary>
        /// Имя файла.
        /// </summary>
        private string FileName { get; set; }

        /// <summary>
        /// Конструктор для записи фалйа.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public FileHandler(string filePath, string fileName)
        {
            FilePath = filePath;
            FileName = fileName;
        }
        
        /// <summary>
        /// Конструктор для чтения файла.
        /// </summary>
        /// <param name="filePath"></param>
        public FileHandler(string filePath)
        {
            FilePath = filePath;
            FileName = "";
        }
        
        /// <summary>
        /// Считывает данные из файла.
        /// </summary>
        /// <returns>Массив строк.</returns>
        public string[] Import()
        {
            string[] data = File.ReadAllLines(FilePath);
            return data;
        }

        /// <summary>
        /// Записывает данные в файл.
        /// </summary>
        /// <param name="data">Массив строк для записи.</param>
        public void Export(string[] data)
        {
            File.WriteAllLines(FilePath + FileName, data);
        }
    }
} 