namespace Project_last_try
{
    /// <summary>
    /// Реализует задачу 3.
    /// </summary>
    public class WriteTopReviewsMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Записать отзывы рейтинга n+ в файл";
            set => throw new NotImplementedException();
        }

        public const string Header = "name,location,Date,Rating,Review,Image_Links";
        private const string FileName = "top-reviews-20-21.csv";
        private static readonly string[] BuildDirectory = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
        private static readonly string SolutionDirectory = string.Join(Path.DirectorySeparatorChar, BuildDirectory, 0,
                                                                BuildDirectory.Length - 3) + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar
                                                            + "Output" + Path.DirectorySeparatorChar;

        private readonly string _outputPath =
            "/Users/ivanyburov/RiderProjects/Project last try/Project last try/Data/Output/";
        /// <summary>
        /// Запустить выполнение задачи.
        /// </summary>
        public override void Start()
        {
            if (Program.AllReviews.Length == 0)
            {
                throw new EmptyFileException();
            }
            Menu.Message("Введите n. Отзывы с n+ рейтингом будут записаны в файл.");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);
            if (n is < 1 or > 5)
            {
                throw new ArgumentException("Введено некорректное числовое значение n");
            }
            List<string> reviewsToWrite = new();
            reviewsToWrite.Add(Header);
            foreach (Review review in Program.AllReviews)
            {
                if (review.Rating >= n && (review.Date.Year == 2020 || review.Date.Year == 2021))
                {
                    reviewsToWrite.Add(review.CsvLine);
                }
            }
            FileHandler file = new(SolutionDirectory, FileName);
            file.Export(reviewsToWrite.ToArray());
            Menu.Message("Файл успешно записан", true);
        }
    }
}