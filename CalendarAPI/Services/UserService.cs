using CalendarAPI.Models;
using CalendarAPI.Repositories;

namespace CalendarAPI.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckUserExistsAsync(string userName)
        {
            return await _userRepository.CheckUserExistsAsync(userName);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task InsertAsync(User user)
        {
            await _userRepository.InsertAsync(user);
        }

        public async Task<int> LogInAsync(string userName, string password)
        {
            return await _userRepository.LogInAsync(userName, password);
        }
    }
}
