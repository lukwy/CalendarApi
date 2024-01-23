using CalendarAPI.Models;
using MongoDB.Driver;

namespace CalendarAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckUserExistsAsync(string userName)
        {
            FilterDefinition<DBUser> filter = Builders<DBUser>.Filter.Eq(u => u.Name, userName);

            return await _context.UserCollection.CountDocumentsAsync(filter) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            FilterDefinition<DBUser> filter = Builders<DBUser>.Filter.Eq(u => u.Id, id);

            DeleteResult deleteResult = await _context.UserCollection.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task InsertAsync(User user)
        {
            var filter = Builders<DBUser>.Filter.Empty;
            DBUser dbUser = await _context.UserCollection.Find(filter).SortByDescending(u => u.Id).FirstOrDefaultAsync();

            var newDBUser = new DBUser() 
            { 
                Name = user.Name,
                Password = user.Password,
                Id = dbUser == null ? 1 : dbUser.Id,
            };

            await _context.UserCollection.InsertOneAsync(newDBUser);
        }

        public async Task<int> LogInAsync(string userName, string password)
        {
            var builder = Builders<DBUser>.Filter;
            FilterDefinition<DBUser> filter = builder.Eq(u => u.Name, userName)
                                            & builder.Eq(u => u.Password, password);

            var result = await _context.UserCollection.Find(filter).FirstOrDefaultAsync();

            return result == null ? 0 : result.Id;
        }
    }
}
