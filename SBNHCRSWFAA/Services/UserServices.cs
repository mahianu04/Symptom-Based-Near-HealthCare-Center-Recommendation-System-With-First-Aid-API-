using MongoDB.Driver;
using SBNHCRSWFAA.Models;
using SBNHCRSWFAA.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SBNHCRSWFAA.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMongoCollection<Users> _usersCollection;

        public UserServices(IMongoDatabase database)
        {
            _usersCollection = database.GetCollection<Users>("Users");
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _usersCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Users?> GetUserByIdAsync(string id)
        {
            var ObId = ObjectId.Parse(id);
            return await _usersCollection.Find(user => user.Id == ObId).FirstOrDefaultAsync();
        }

        public async Task<Users?> GetUserByPhoneAsync(string phoneNumber)
        {
            return await _usersCollection.Find(user => user.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateUserAsync(CreateUser dto)
        {
            var existingUser = await GetUserByPhoneAsync(dto.PhoneNumber);
            if (existingUser != null) return false; // User already exists

            var newUser = new Users
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                Password = dto.Password, 
                Gender = dto.Gender,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow

            };

            await _usersCollection.InsertOneAsync(newUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var ObId = ObjectId.Parse(id);
            var result = await _usersCollection.DeleteOneAsync(user => user.Id == ObId);
            return result.DeletedCount > 0;
        }
    }
}