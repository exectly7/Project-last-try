namespace Project_last_try
{
    public class BestRatingMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Вывести лучшие отзывы за 2020-2021 года";
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
            int maxRating = 0;
            foreach (Review review in Program.AllReviews)
            {
                maxRating = Math.Max(maxRating, review.Rating);
            }
            List<string> maxRatedReviews = [];
            foreach (Review review in Program.AllReviews)
            {
                if (review.Rating == maxRating)
                {
                    maxRatedReviews.Add(review.ToString());
                }
            }
            Menu.Message(maxRatedReviews.ToArray(), true);
        }
    }
}