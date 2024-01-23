using CalendarAPI.Models;
using MongoDB.Driver;

namespace CalendarAPI.Repositories
{
    public interface IContext
    {
        IMongoCollection<DBUser> UserCollection { get; }
        IMongoCollection<UserDateTime> UserDateTimeCollection { get; }
    }
}