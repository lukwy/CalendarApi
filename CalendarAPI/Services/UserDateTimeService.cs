using CalendarAPI.Models;
using CalendarAPI.Repositories;

namespace CalendarAPI.Services
{
    public class UserDateTimeService : IUserDateTimeService
    {
        public IUserDateTimeRepository _userDateTimeRepository;

        public UserDateTimeService(IUserDateTimeRepository userDateTimeRepository)
        {
            _userDateTimeRepository = userDateTimeRepository;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDateTimeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserDateTime>> GetUserDateTimeByIdAndDayAsync(int id, DateTime day)
        {
            return await _userDateTimeRepository.GetUserDateTimeByIdAndDayAsync(id, day);
        }

        public async Task<IEnumerable<UserDateTime>> GetUserDateTimesByIdAsync(int id)
        {
            return await _userDateTimeRepository.GetUserDateTimesByIdAsync(id);
        }

        public async Task InsertAsync(UserDateTime userDateTime)
        {
            userDateTime.Date = userDateTime.Date.Date;

            await _userDateTimeRepository.InsertAsync(userDateTime);
        }

        public async Task<bool> UpdateAsync(UserDateTime userDateTime)
        {
            userDateTime.Date = userDateTime.Date.Date;

            return await _userDateTimeRepository.UpdateAsync(userDateTime);
        }
    }
}
