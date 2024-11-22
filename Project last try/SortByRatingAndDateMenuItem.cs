namespace Project_last_try
{
    public class SortByRatingAndDateMenuItem : MenuItem
    {
        public override string Title { get; set; } = "Сделать выборку по рейтингу отсортировав по дате.";
        private static string[] _buildDirectory = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
        private static string _solutionDirectory = string.Join(Path.DirectorySeparatorChar, _buildDirectory, 0,
            _buildDirectory.Length - 3) + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar
                                           + "Output" + Path.DirectorySeparatorChar;
        public override void Start()
        {
            if (Program.AllReviews == Array.Empty<Review>())
            {
                throw new EmptyFileException();
            }
            Dictionary<int, List<Review>> sortedReviews = new();
            foreach (Review review in Program.AllReviews)
            {
                if (sortedReviews.ContainsKey(review.Rating))
                {
                    sortedReviews[review.Rating].Add(review);
                }
                else
                {
                    sortedReviews.Add(review.Rating, [review]);
                }
            }
            Menu.Message("Отзывы будут выводиться постранично начиная с рейтинга 5 до 0 (0 - отзывы без рейтинга).");
            List<string>[] results = new List<string>[6];
            
            foreach ( KeyValuePair<int, List<Review>> pair in sortedReviews)
            {
                pair.Value.Sort((x, y) => y.Date.CompareTo(x.Date));
                List<string> result = new();
                result.Add("Отзывы с рейтингом " + pair.Key + ':');
                foreach (Review review in pair.Value)
                {
                    result.Add(review.ToString());
                }
                results[pair.Key] = result;
            }
        
            List<string> data = new();
            foreach (List<string> result in results.Reverse())
            {
                foreach (string s in result)
                {
                    data.Add(s);
                }
                Menu.Message(result.ToArray(), true);
            }
            ExportTopReviewsMenuItem(sortedReviews);
        }

        private void ExportTopReviewsMenuItem(Dictionary<int, List<Review>> sortedReviews)
        {
            List<string> data = new();
            data.Add(WriteTopReviewsMenuItem.Header);
            
            List<int> sortedKeys = new List<int>(sortedReviews.Keys);
            sortedKeys.Sort((x, y) => y.CompareTo(x));
            
            foreach (int rating in sortedKeys)
            {
                sortedReviews[rating].Sort((x, y) => y.Date.CompareTo(x.Date));
                
                foreach (Review review in sortedReviews[rating])
                {
                    data.Add(review.CsvLine);
                }
            }
            
            FileHandler file = new(_solutionDirectory, "grouped-rates.csv");
            file.Export(data.ToArray());

            Menu.Message("Файл grouped-rates.csv записан в папку Data/Output", true);
        }
    }
}