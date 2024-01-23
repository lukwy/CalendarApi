using CalendarAPI.Config;
using CalendarAPI.Models;
using MongoDB.Driver;

namespace CalendarAPI.Repositories
{
    public class Context : IContext
    {
        private readonly IMongoDatabase _database;

        public Context()
        {
            var mongoDBConfig = new MongoDBConfig();
            var client = new MongoClient(mongoDBConfig.ConnectionString);
            _database = client.GetDatabase(mongoDBConfig.DatabaseName);
        }

        public IMongoCollection<UserDateTime> UserDateTimeCollection => _database.GetCollection<UserDateTime>("user_datetime");

        public IMongoCollection<DBUser> UserCollection => _database.GetCollection<DBUser>("user");
    }
}
