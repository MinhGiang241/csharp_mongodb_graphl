namespace PlatformService.Models
{
    public interface IDataSetting
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string DatabaseName { get; set; }
    }

    public class DataSetting : IDataSetting
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
    }
}
