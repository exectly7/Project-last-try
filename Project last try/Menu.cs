using System.Security;

namespace Project_last_try
{
    /// <summary>
    ///  Класс, отвечающий за вывод данных в консоль.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Хранит номер выбранного пункта меню, для того, чтобы его подсвечивать.
        /// </summary>
        private static int _selectedItem;
        
        /// <summary>
        /// Список элементов для работы главного меню.
        /// </summary>
        public static readonly MenuItem[] MainMenuItems = [new SwitchFileMenuItem(),  new BestRatingMenuItem(), 
                                                        new StatsMenuItem(), new WriteTopReviewsMenuItem(),
                                                        new LocationFilterMenuItem(), new SortByRatingAndDateMenuItem(),
                                                        new ExitMenuItem()];
        
        /// <summary>
        /// Список элементов меню для работы побочного меню 4 задачи.
        /// </summary>
        public static readonly MenuItem[] SubMenuItems = [new ReviewPerYearMenuItem(), new RatingPercentMenuItem(), 
                                                        new BadReviewsImagesMenuItem(), new GoodAndBadPerYearMenuItem()];

        /// <summary>
        /// Логика управления меню.
        /// </summary>
        public static void Run(MenuItem[] items,  bool submenu)
        {
            _selectedItem = 0;
            Show(items);
            
            while (true)
            {
                ConsoleKey input = Console.ReadKey().Key;
                
                switch (input)
                {
                    case ConsoleKey.UpArrow:
                        _selectedItem = _selectedItem == 0 ? items.Length - 1 : _selectedItem - 1;
                        Show(items);
                        break;
                    case ConsoleKey.DownArrow:
                        _selectedItem = _selectedItem ==  items.Length - 1 ? 0 : _selectedItem + 1;
                        Show(items);
                        break;
                    case ConsoleKey.Enter:
                        SafeRun(items[_selectedItem]);
                        if (submenu)
                        {
                            return;
                        }
                        break; 
                }
            }
        }
        
        /// <summary>
        /// Выводит меню в консоль.
        /// </summary>
        private static void Show(MenuItem[] items)
        {
            Console.Clear();

            for (int i = 0; i < items.Length; i++)
            {
                if (i == _selectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
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
            catch (EmptyFileException)
            {
                Message("Файл не был импортирован. Вы можете импортировать файл при помощи 1 пункта меню.", true);
            }
            catch (Exception e) when (e is FileNotFoundException or DirectoryNotFoundException)
            {
                Message("Файла по этому пути не существует.", true);
            }
            catch (Exception e) when (e is FormatException or NotSupportedException)
            {
                Message("Файл имеет некорректный формат.", true);
            }
            catch (BadCsvException)
            {
                Message("Данные в файле некорректны.", true);
            }
            catch (Exception e) when (e is UnauthorizedAccessException or SecurityException)
            {
                Message("Нет прав доступа к файлам.", true);
            }
            catch (Exception e) when (e is PathTooLongException or SecurityException)
            {
                Message("Путь к файлу слишком длинный.", true);
            }
            catch (Exception e) when (e is ArgumentOutOfRangeException or IndexOutOfRangeException 
                                          or ArgumentException or ArgumentOutOfRangeException or IOException)
            {
                Message("Произошла непредвиденная ошибка при выполнении.", true);
            }
            Show(MainMenuItems);
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

