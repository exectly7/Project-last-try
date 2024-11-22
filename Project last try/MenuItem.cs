namespace Project_last_try
{
    /// <summary>
    /// Шаблон для пункта меню.
    /// </summary>
    public abstract class MenuItem
    {
        /// <summary>
        /// Как пункт меню отображается в консоли.
        /// </summary>
        public abstract string Title { get; set; }

        /// <summary>
        /// Метод для запуска пункта меню/задачи.
        /// </summary>
        public abstract void Start();
    }
}