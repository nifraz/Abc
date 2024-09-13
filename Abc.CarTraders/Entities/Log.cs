namespace ABC.CarTraders.Entities
{
    public class Log : Record
    {
        public string Title { get; set; }
        public LogAction Action { get; set; }
        public string Text { get; set; }
    }

    public enum LogAction : byte
    {
        Auth = 0,
        Select = 1,
        Insert = 2,
        Update = 3,
        Delete = 4,
        Save = 5
    }
}
