using MongoDB.Driver;
using SBNHCRSWFAA.Models;
using SBNHCRSWFAA.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SBNHCRSWFAA.Services
{
    public class HealthProfileServices : IHealthProfileServices
    {
        private readonly IMongoCollection<HealthProfile> _healthProfiles;

        public HealthProfileServices(IMongoDatabase database,IConfiguration config)
        {
          _healthProfiles = database.GetCollection<HealthProfile>(config["MongoDBSettings:CollectionName"]);
        }

        public async Task<GetHealthProfileDTO?> GetHealthProfileByIdAsync(string id)
        {
            var ObId = ObjectId.Parse(id);
            var profile = await _healthProfiles.Find(p => p.Id == ObId).FirstOrDefaultAsync();
            if (profile == null) return null;

            return new GetHealthProfileDTO
            {
                Id = profile.Id.ToString(),
                UserId = profile.UserId,
                BloodType = profile.BloodType,
                Allergies = profile.Allergies,
                ChronicConditions = profile.ChronicConditions,
                Medications = profile.Medications,
                EmergencyContact = profile.EmergencyContact,
                LastUpdated = profile.LastUpdated
            };
        }

        public async Task<List<GetHealthProfileDTO>> GetAllHealthProfilesAsync()
        {
            var profiles = await _healthProfiles.Find(_ => true).ToListAsync();
            return profiles.ConvertAll(profile => new GetHealthProfileDTO
            {
                Id = profile.Id.ToString(),
                UserId = profile.UserId,
                BloodType = profile.BloodType,
                Allergies = profile.Allergies,
                ChronicConditions = profile.ChronicConditions,
                Medications = profile.Medications,
                EmergencyContact = profile.EmergencyContact,
                LastUpdated = profile.LastUpdated
            });
        }

        public async Task<bool> CreateHealthProfileAsync(CreateHealthProfileDTO dto)
        {
            var profile = new HealthProfile
            {
                UserId = dto.UserId,
                BloodType = dto.BloodType,
                Allergies = dto.Allergies,
                ChronicConditions = dto.ChronicConditions,
                Medications = dto.Medications,
                EmergencyContact = dto.EmergencyContact,
                LastUpdated = DateTime.UtcNow
            };
            await _healthProfiles.InsertOneAsync(profile);
            return true;
        }

        public async Task<bool> EditHealthProfileAsync(EditHealthProfileDTO dto)
        {
            var update = Builders<HealthProfile>.Update
                .Set(p => p.BloodType, dto.BloodType)
                .Set(p => p.Allergies, dto.Allergies)
                .Set(p => p.ChronicConditions, dto.ChronicConditions)
                .Set(p => p.Medications, dto.Medications)
                .Set(p => p.EmergencyContact, dto.EmergencyContact)
                .Set(p => p.LastUpdated, DateTime.UtcNow);
            var ObId = ObjectId.Parse(dto.Id);
            var result = await _healthProfiles.UpdateOneAsync(p => p.Id == ObId, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteHealthProfileAsync(string id)
        {
            var ObId = ObjectId.Parse(id);
            var result = await _healthProfiles.DeleteOneAsync(p => p.Id == ObId);
            return result.DeletedCount > 0;
        }
    }
}