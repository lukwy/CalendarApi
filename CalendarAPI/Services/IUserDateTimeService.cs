using CalendarAPI.Models;

namespace CalendarAPI.Services
{
    public interface IUserDateTimeService
    {
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<UserDateTime>> GetUserDateTimesByIdAsync(int id);
        Task<IEnumerable<UserDateTime>> GetUserDateTimeByIdAndDayAsync(int id, DateTime day);
        Task InsertAsync(UserDateTime userDateTime);
        Task<bool> UpdateAsync(UserDateTime userDateTime);
    }
}