namespace WebApiApps.Models
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }

        int DbCommandTimeout { get; set; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public int DbCommandTimeout { get; set; }
    }
}
