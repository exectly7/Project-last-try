using Project_last_try.SubMenu;

namespace Project_last_try
{
    public static class Menu
    {
        private static int _selectedItem;
        public static readonly MenuItem[] MainMenuItems = [new SwitchFileMenuItem(),  new BestRatingMenuItem(), 
                                                        new StatsMenuItem(), new WriteTopReviewsMenuItem(),
                                                        new LocationFilterMenuItem(), new SortByRatingAndDateMenuItem(),
                                                        new ExitMenuItem()];
        public static readonly MenuItem[] SubMenuItems = [new ReviewPerYeatMenuItem(), new RatingPercentMenuItem(), 
            new BadReviewsImagesMenuItem(), new GoodAndBadPerYearMenuItem()];

        /// <summary>
        /// Логика управления меню.
        /// </summary>
        public static void Run(MenuItem[] items)
        {
            _selectedItem = 0;
            Show(items);
            
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        _selectedItem = _selectedItem == 0 ? items.Length - 1 : --_selectedItem;
                        Show(items);
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedItem = _selectedItem ==  items.Length - 1 ? 0 : ++_selectedItem;
                        Show(items);
                        break;
                    case ConsoleKey.Enter:
                        SafeRun(items[_selectedItem]);
                        return;
                }
            }
        }
        
        /// <summary>
        /// Выводит меню в консоль.
        /// </summary>
        public static void Show(MenuItem[] items)
        {
            Console.Clear();

            for (int i = 0; i < items.Length; i++)
            {
                if (i == _selectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine(items[i].Title);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Активирует пункты меню, отлавливая исключения.
        /// Сообщение из исключения передается в метод Message().
        /// После снова активирует меню.
        /// </summary>
        /// <param name="item">Выбранный пункт меню для запуска</param>
        private static void SafeRun(MenuItem item)
        {
            try
            {
                item.Start();
            }
            catch (Exception e)
            {
                Message(e.Message, true);
            }
            Run(MainMenuItems);
        }
        
        /// <summary>
        /// Выводит сообщение на очищенную консоль.
        /// Дожидается нажатия любой кнопки. Зависит от параметра.
        /// </summary>
        /// <param name="message">Сообщение для вывода.</param>
        /// <param name="wait">Ждать ли нажатия любой кнопки.</param>
        public static void Message(string message, bool wait = false)
        {
            Console.Clear();
            Console.WriteLine(message);
            if (!wait)
            {
                return;
            }
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
        }
        
        /// <summary>
        /// Выводит сообщения на очищенную консоль.
        /// Дожидается нажатия любой кнопки. Зависит от параметра.
        /// </summary>
        /// <param name="message">Сообщения для вывода.</param>
        /// <param name="wait">Ждать ли нажатия любой кнопки.</param>
        public static void Message(string[] message, bool wait = false)
        {
            Console.Clear();
            foreach (string item in message)
            {
                Console.WriteLine(item);
            }
            if (!wait)
            {
                return;
            }
            Console.WriteLine("Нажмите любую кнопку для продолжения");
            Console.ReadKey();
        }
    }
}
