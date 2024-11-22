namespace Project_last_try.SubMenu
{
    public class ReviewPerYeatMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Количество отзывов за каждый год";
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Запустить выполнение задачи.
        /// </summary>
        public override void Start()
        {
            Dictionary<int, int> yearAmount = new();
            foreach (Review review in Program.AllReviews)
            {
                if (yearAmount.ContainsKey(review.Date.Year))
                {
                    yearAmount[review.Date.Year]++;
                }
                else
                {
                    yearAmount.Add(review.Date.Year, 1);
                }
            }
            List<string> result = new();
            foreach (KeyValuePair<int, int> pair in yearAmount)
            {
                string row = pair.Key + ": " + pair.Value;
                result.Add(row);
            }
            result.Sort();
            Menu.Message(result.ToArray(), true);
        }
    }
}