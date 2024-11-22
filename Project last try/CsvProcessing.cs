namespace Project_last_try
{
    /// <summary>
    /// Класс для разделения данных на нужные поля.
    /// </summary>
    /// <param name="data">Данные для обработки</param>
    public class CsvProcessing(string[] data)
    {
        /// <summary>
        /// Запускает процесс обработки данных
        /// </summary>
        /// <returns>Массив обработанных данных</returns>
        /// <exception cref="BadCsvException"></exception>
        public Review[] Parse()
        {
            List<Review> reviews = [];
            if (data.Length == 1)
            {
                throw new BadCsvException();
            }

            try
            {
                foreach (string row in data[1..])
                {
                    reviews.Add(new Review(CsvLineParse(row), row));
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new BadCsvException();
            }

            return reviews.ToArray();
        }

        /// <summary>
        /// Обрабатывает одну строку файла.
        /// </summary>
        /// <param name="input">Строка.</param>
        /// <returns>Массив полей строки.</returns>
        private string[] CsvLineParse(string input)
        {
            string[] result = new string[6];
            for (int i = 0; i < 6; i++)
            {
                if (input[0] == '"')
                {
                    result[i] = input[(input.IndexOf('"') + 1)..(input[1..].IndexOf('"') + 1)];
                    if (input[1..].IndexOf('"') + 1 != input.Length - 1)
                    {
                        input = input[(input[1..].IndexOf("\",", StringComparison.Ordinal) + 3)..];
                    }
                }
                else if (input.IndexOf(',') != -1)
                {
                    result[i] = input[..(input[1..].IndexOf(',') + 1)];
                    input = input[(input.IndexOf(',') + 1)..];
                }
                else
                {
                    result[i] = input;
                }
            }
        
            return result;
        }
    }
}