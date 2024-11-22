namespace Project_last_try
{
    /// <summary>
    /// Реализует задачу 4.4.
    /// </summary>
    public class GoodAndBadPerYearMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Статистика по отзывам";
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Запустить выполнение задачи.
        /// </summary>
        public override void Start()
        {
            if (Program.AllReviews.Length == 0)
            {
                throw new EmptyFileException();
            }
            Dictionary<int, int[]> ratings = new();
            foreach (Review review in Program.AllReviews)
            {
                if (review.Rating == 0) // Так как мы держим нули для отзывов без рейтинга.
                {
                    continue;
                }
                
                if (ratings.ContainsKey(review.Date.Year))
                {
                    if (review.Rating < 3) // 1-2.
                    {
                        ratings[review.Date.Year][0]++;
                    }
                    else
                    {
                        ratings[review.Date.Year][1]++;
                    }
                }
                else
                {
                    if (review.Rating < 3) // 1-2.
                    {
                        ratings.Add(review.Date.Year, [1, 0]);
                    }
                    else
                    {
                        ratings.Add(review.Date.Year, [0, 1]);
                    }
                    
                }
            }
            List<string> result = new();
            result.Add("ГОД: Количество плохих отзывов - количество хороших отзывов (плохо 1-2, хорошо 3-5)");
            foreach (KeyValuePair<int, int[]> pair in ratings)
            {
                string row = pair.Key + ": " + pair.Value[0] + " - " + pair.Value[1];
                result.Add(row);
            }
            result.Sort();
            Menu.Message(result.ToArray(), true);
        }
    }
}