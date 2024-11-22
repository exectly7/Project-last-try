namespace Project_last_try
{
    /// <summary>
    /// Реализует задачу 6.
    /// </summary>
    public class LocationFilterMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Подборка отзывов по локации, запись в файл";
            set => throw new NotImplementedException();
        }
        private static readonly string[] BuildDirectory = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
        private static readonly string SolutionDirectory = string.Join(Path.DirectorySeparatorChar, BuildDirectory, 0,
                                                               BuildDirectory.Length - 3) + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar
                                                           + "Output" + Path.DirectorySeparatorChar;

        /// <summary>
        /// Запустить выполнение задачи.
        /// </summary>
        public override void Start()
        {
            if (Program.AllReviews.Length == 0)
            {
                throw new EmptyFileException();
            }
            Dictionary<string, List<string>> locationReview = new();
            List<string> csvToWrite = new();
            foreach (Review review in Program.AllReviews)
            {
                if (review.WithImage)
                {
                    continue;
                }
                csvToWrite.Add(review.CsvLine);
                if (locationReview.ContainsKey(review.Location))
                {
                    locationReview[review.Location].Add(review.ToStringNoLocation());
                }
                else
                {
                    locationReview.Add(review.Location, [review.ToStringNoLocation()]);
                }
            }
            List<string> result = new();
            foreach (KeyValuePair<string, List<string>> row in locationReview)
            {
                string rowToResult = $"{row.Key}:\n";
                foreach (string review in row.Value)
                {
                    rowToResult += $"{review}\n";
                }
                result.Add(rowToResult);
            }
            result.Sort();
            Menu.Message(result.ToArray(), true);
            Menu.Message("Название файла");
            string fileName = Console.ReadLine() ?? string.Empty;
            FileHandler file = new(SolutionDirectory, fileName);
            file.Export(csvToWrite.ToArray());
            Menu.Message("Файл успешно записан.", true);
        }
    }
}