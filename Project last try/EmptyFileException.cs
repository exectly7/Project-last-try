namespace Project_last_try
{
    /// <summary>
    /// Исключение для пустого файла.
    /// </summary>
    public class EmptyFileException : Exception
    {
        public override string Message => "File empty";
    }
}