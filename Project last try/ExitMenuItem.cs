namespace Project_last_try
{
    /// <summary>
    /// Реализует задачу 5.
    /// </summary>
    public class ExitMenuItem : MenuItem
    {
        /// <summary>
        /// Название пункта меню.
        /// </summary>
        public override string Title
        {
            get => "Завершить работу";
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Запустить выполнение задачи.
        /// </summary>
        public override void Start()
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }
}