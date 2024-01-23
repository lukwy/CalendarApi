using CalendarAPI.Models;

namespace CalendarAPI.Repositories
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<int> LogInAsync(string userName, string password);
        Task<bool> CheckUserExistsAsync(string userName);
    }
}
