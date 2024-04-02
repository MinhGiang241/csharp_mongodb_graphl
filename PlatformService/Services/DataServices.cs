using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PlatformService.Models;

namespace PlatformService.Services
{
    public class DatabaseServices
    {
        public MongoClient client;
        public IMongoDatabase database;

        public DatabaseServices(IOptions<DataSetting> settings)
        {
            try
            {
                MongoClientSettings linqSettings = MongoClientSettings.FromConnectionString(
                    $"http://{settings.Value.DatabaseName}:{settings.Value.Port}"
                );
                linqSettings.LinqProvider = LinqProvider.V3;
                client = new MongoClient(linqSettings);
                database = client.GetDatabase(settings.Value.DatabaseName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
