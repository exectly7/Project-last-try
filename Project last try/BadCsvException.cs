namespace Project_last_try
{
    public class BadCsvException : Exception
    {
        public override string Message => "Can't parse CSV file";
    }
}