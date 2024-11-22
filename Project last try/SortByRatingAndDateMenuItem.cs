namespace Project_last_try
{
    public class SortByRatingAndDateMenuItem : MenuItem
    {
        public override string Title { get; set; } = "Сделать выборку по рейтингу отсортировав по дате.";

        public override void Start()
        {
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
            foreach (List<string> result in results.Reverse())
            {
                Menu.Message(result.ToArray(), true);
            }
        }
    }
}