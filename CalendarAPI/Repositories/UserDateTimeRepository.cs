using CalendarAPI.Models;
using MongoDB.Driver;

namespace CalendarAPI.Repositories
{
    public class UserDateTimeRepository : IUserDateTimeRepository
    {
        private readonly IContext _context;

        public UserDateTimeRepository(IContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            FilterDefinition<UserDateTime> filter = Builders<UserDateTime>.Filter.Eq(udt => udt.UserId, id);

            DeleteResult deleteResult = await _context.UserDateTimeCollection.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<UserDateTime>> GetUserDateTimeByIdAndDayAsync(int id, DateTime day)
        {
            return await _context.UserDateTimeCollection
                .Find(udt => udt.UserId == id
                            && udt.Date.Year == day.Date.Year
                            && udt.Date.Month == day.Date.Month
                            && udt.Date.Day == day.Date.Day)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserDateTime>> GetUserDateTimesByIdAsync(int id)
        {
            FilterDefinition<UserDateTime> filter = Builders<UserDateTime>.Filter.Eq(udt => udt.UserId, id);

            return await _context.UserDateTimeCollection.Find(filter).ToListAsync();
        }

        public async Task InsertAsync(UserDateTime userDateTime)
        {
            await _context.UserDateTimeCollection.InsertOneAsync(userDateTime);
        }

        public async Task<bool> UpdateAsync(UserDateTime userDateTime)
        {
            ReplaceOneResult updateResult = 
                await _context.UserDateTimeCollection.ReplaceOneAsync(
                    filter: udt => udt.UserId == userDateTime.UserId 
                            && udt.Date.Year == userDateTime.Date.Year 
                            && udt.Date.Month == userDateTime.Date.Month 
                            && udt.Date.Day == userDateTime.Date.Day, 
                    replacement: userDateTime);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
