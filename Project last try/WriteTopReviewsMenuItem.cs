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

        /// <summary>
        /// Заголовок для csv.
        /// </summary>
        public const string Header = "name,location,Date,Rating,Review,Image_Links";
        
        /// <summary>
        /// Название файла данное по условию.
        /// </summary>
        private const string FileName = "top-reviews-20-21.csv";
        
        /// <summary>
        /// Вспомогательное поле для построения пути к папке Output.
        /// </summary>
        private static readonly string[] BuildDirectory = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
        
        /// <summary>
        /// Построение относительного пути к Папке Output.
        /// </summary>
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
                if (review.Rating >= n && review.Date.Year is 2020 or 2021)
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