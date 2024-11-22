/*
 * Буров Иван Юрьевич
 * Вариант 15
 * БПИ249-1
 */

namespace Project_last_try
{
    /// <summary>
    ///  Класс в котором находится точка входа в программу.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Хранилище данных для импортированного файла.
        /// </summary>
        public static Review[] AllReviews { get; set; } = [];
        
        /// <summary>
        /// Точка входа.
        /// </summary>
        public static void Main()
        {
            Menu.Show(Menu.MainMenuItems);
            Menu.Run(Menu.MainMenuItems);
        }
    }
}