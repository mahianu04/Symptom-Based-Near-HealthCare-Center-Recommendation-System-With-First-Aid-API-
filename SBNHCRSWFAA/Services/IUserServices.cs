using SBNHCRSWFAA.Models;
using SBNHCRSWFAA.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBNHCRSWFAA.Services
{
    public interface IUserServices
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<Users?> GetUserByIdAsync(string id);
        Task<Users?> GetUserByPhoneAsync(string phoneNumber);
        Task<bool> CreateUserAsync(CreateUser dto);
        Task<bool> DeleteUserAsync(string id);
    }
}