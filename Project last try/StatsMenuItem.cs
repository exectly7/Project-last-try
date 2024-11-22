namespace Project_last_try
{
    /// <summary>
    /// Реализует вывоз сабменю задачи 4.
    /// </summary>
    public class StatsMenuItem : MenuItem
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
            Menu.Run(Menu.SubMenuItems, true);
        }
    }
}