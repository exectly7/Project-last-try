using System.Globalization;
using System.Text.RegularExpressions;

namespace Project_last_try
{
    /// <summary>
    /// Класс для отзывов, элементов csv файла.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Регулярное выражение для дня из даты.
        /// </summary>
        private const string Day = "[0-9][0-9]?";
        
        /// <summary>
        /// Регулярное выражение для месяца из даты.
        /// </summary>
        private const string Month = @"(?<= )[A-Za-z]+\.*";
        
        /// <summary>
        /// Регулярное выражение для года из даты.
        /// </summary>
        private const string Year = "[0-9]{4}";
        
        /// <summary>
        /// Храню вид записи в Csv,
        /// потому что собирать строку каждый раз из кусочков считаю более затратным,
        /// чем хранить ее на диске.
        /// </summary>
        public readonly string CsvLine;
        
        /// <summary>
        /// Имя человека, который оставил отзыв.
        /// </summary>
        private readonly string _name;
        
        /// <summary>
        /// Текст отзыва.
        /// </summary>
        private readonly string _text;
        
        /// <summary>
        /// Дата, когда был оставлен отзыв.
        /// </summary>
        public DateTime Date { get; }
        
        /// <summary>
        ///  Место, где был оставлен отзыв
        /// </summary>
        public string Location { get; }
        
        /// <summary>
        /// Рейтинг, оставленный в отзыве.
        /// Число от 1 до 5.
        /// Хранится 0, если рейтинг не был оставлен.
        /// </summary>
        public int Rating { get; }
        
        /// <summary>
        /// Наличие изображения в отзыве.
        /// </summary>
        public bool WithImage { get; }
        
        /// <summary>
        /// Конструктор класса review, получает на вход разделенную строку и целую.
        /// </summary>
        /// <param name="parsedLine">Массив строк частей исходной.</param>
        /// <param name="csvLine">Исходная строка.</param>
        public Review(string[] parsedLine, string csvLine)
        {
            _name = parsedLine[0];
            Location = parsedLine[1];
            Date = ParseDate(parsedLine[2]);
            Rating = ParsedRating(parsedLine[3]);
            _text = parsedLine[4];
            WithImage = parsedLine[5] == "['No Images']" ? false : true;
            CsvLine = csvLine;
        }

        /// <summary>
        /// Переводит рейтинг из строки в число, ставя 0, если рейтинга не было изначально.
        /// </summary>
        /// <param name="rating">Рейтинг в текстовом формате.</param>
        /// <returns>Рейтинг в числовом виде.</returns>
        private int ParsedRating(string rating)
        {
            return rating == "N/A" ? 0 : int.Parse(rating);
        }

        /// <summary>
        /// Переводит дату из текста формата в формат DateTime.
        /// </summary>
        /// <param name="date">Дата в форме строки.</param>
        /// <returns>Дату в формате DateTime.</returns>
        private DateTime ParseDate(string date)
        {
            string day = GetMatch(Day, date).Length == 2
                ? GetMatch(Day, date)
                : "0" + GetMatch(Day, date);
            string month = GetMatch(Month, date) switch
            {
                "January" or "Jan." => "01",
                "February" or "Feb." => "02",
                "March" or "Mar." => "03",
                "April" or "Apr." => "04",
                "May" => "05",
                "June" or "Jun." => "06",
                "July" or "Jul." => "07",
                "August" or "Aug." => "08",
                "September" or "Sept." => "09",
                "October" or "Oct." => "10",
                "November" or "Nov." => "11",
                "December" or "Dec." => "12",
                _ =>  ""
            };
            string year = GetMatch(Year, date);
            string dateString = $"{day}/{month}/{year}";
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
        
        /// <summary>
        /// Возвращает первое совпадение паттерну если есть совпадение,
        /// если его нет - пустую строку.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetMatch(string pattern, string input)
        {
            Match match = Regex.Match(input, pattern);
            return match.Success ? match.Value : string.Empty;
        }
        
        /// <summary>
        /// Выводит отзыв в ЧеЛоВеКоЧиТаЕмОм виде.
        /// </summary>
        /// <returns>Строку с отзывов.</returns>
        public override string ToString()
        {
            return $"Имя: {_name}\n" +
                   $"Место: {Location}\n" +
                   $"Рейтинг: {Rating}\n" +
                   $"Дата: {Date}\n" +
                   $"Текст отзыва: {_text}\n" +
                   $"Ссылка на изображение: {WithImage}\n" +
                   $"{CsvLine}";
        }
        
        /// <summary>
        /// Выводит отзыв, не учитываю локацию.
        /// Нужен для вывода отзыва в подборке отзывов по локации.
        /// </summary>
        /// <returns>Строку с отзывом, без локации.</returns>
        public string ToStringNoLocation()
        {
            return $"Имя: {_name}\n" +
                   $"Рейтинг: {Rating}\n" +
                   $"Дата: {Date}\n" +
                   $"Текст отзыва: {_text}\n" +
                   $"Ссылка на изображение: {WithImage}\n";
        }
    }
}