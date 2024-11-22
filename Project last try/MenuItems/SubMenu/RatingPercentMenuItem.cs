namespace Project_last_try.SubMenu
{
    public class RatingPercentMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Распределение рейтинга в процентном соотношении";
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Запустить выполнение задачи.
        /// </summary>
        public override void Start()
        {
            Dictionary<int, int> ratings = new();
            int amount = 0;
            foreach (Review review in Program.AllReviews)
            {
                if (review.Rating == 0) // Так как мы держим нули для отзывов без рейтинга.
                {
                    continue;
                }

                amount++;
                
                if (ratings.ContainsKey(review.Rating))
                {
                    ratings[review.Rating]++;
                }
                else
                {
                    ratings.Add(review.Rating, 1);
                }
            }
            List<string> result = new();
            foreach (KeyValuePair<int, int> pair in ratings)
            {
                string row = pair.Key + ": " + ((double)pair.Value / amount).ToString("P");
                result.Add(row);
            }
            result.Sort();
            Menu.Message(result.ToArray(), true);
        }
    }
}