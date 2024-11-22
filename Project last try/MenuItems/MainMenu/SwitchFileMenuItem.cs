namespace Project_last_try
{
    public class SwitchFileMenuItem : MenuItem
    {
        public override string Title { get; set; } = "Выбрать файл";

        public override void Start()
        {
            Menu.Message("Введите путь к файлу:");
            string path = Console.ReadLine() ?? string.Empty;
            FileHandler file = new(path);
            string[] data = file.Import();
            CsvProcessing csv = new(data);
            Program.AllReviews = csv.Parse();
            Menu.Message("Файл импортирован", true);
            Title = "Сменить файл";
            Menu.Run(Menu.MainMenuItems);
        }
    }
}