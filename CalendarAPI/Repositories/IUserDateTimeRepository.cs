using CalendarAPI.Models;

namespace CalendarAPI.Repositories
{
    public interface IUserDateTimeRepository
    {
        Task<IEnumerable<UserDateTime>> GetUserDateTimesByIdAsync(int id);
        Task<IEnumerable<UserDateTime>> GetUserDateTimeByIdAndDayAsync(int id, DateTime day);
        Task InsertAsync(UserDateTime userDateTime);
        Task<bool> UpdateAsync(UserDateTime userDateTime);
        Task<bool> DeleteAsync(int id);
    }
}
