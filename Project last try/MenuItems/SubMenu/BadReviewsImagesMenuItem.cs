namespace Project_last_try.SubMenu
{
    public class BadReviewsImagesMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Сравнить количество отзывов с оценкой 1 с изображением и без";
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Запустить выполнение задачи.
        /// </summary>
        public override void Start()
        {
            int withImage = 0;
            int withNoImage = 0;
            foreach (Review review in Program.AllReviews)
            {
                if (review.Rating != 1) 
                {
                    continue;
                }

                if (review.WithImage)
                {
                    withImage++;
                }
                else
                {
                    withNoImage++;
                }
            }
            string result = $"Отзывов с рейтингом 1\n" +
                            $"с изображением - {withImage}:{withNoImage} - без изображения";
            Menu.Message(result, true);
        }
    }
}