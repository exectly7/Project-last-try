namespace Project_last_try
{
    /// <summary>
    /// Исключение для файлов не подходящих по шаблону.
    /// </summary>
    public class BadCsvException : Exception
    {
        /// <summary>
        /// Сообщение для нового исключения.
        /// </summary>
        public override string Message => "Can't parse CSV file";
    }
}