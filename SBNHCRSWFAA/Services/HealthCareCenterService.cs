using SBNHCRSWFAA.Models;
using SBNHCRSWFAA.Models.DTOs;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SBNHCRSWFAA.Services
{
    public class HealthcareCenterService : IHealthcareCenterService
    {
        private readonly IMongoCollection<HealthcareCenter> _healthcareCenters;

        public HealthcareCenterService(IMongoDatabase database,IConfiguration config)
        {
            _healthcareCenters = database.GetCollection<HealthcareCenter>(config["MongoDBSettings:HealthcareCollectionName"]);
        }

               public async Task<List<GetHealthcareCenterDTO>> SearchHealthcareCentersAsync(string name, string specialty, double? latitude, double? longitude, int page, int pageSize)
        {
            var filterBuilder = Builders<HealthcareCenter>.Filter;
            var filters = new List<FilterDefinition<HealthcareCenter>>();

            if (!string.IsNullOrEmpty(name))
                filters.Add(filterBuilder.Regex("name", new BsonRegularExpression($".*{name}.*", "i"))); // Case-insensitive search

            if (!string.IsNullOrEmpty(specialty))
                filters.Add(filterBuilder.AnyEq("specialties", specialty));

            if (latitude.HasValue && longitude.HasValue)
            {
                var locationFilter = filterBuilder.NearSphere("location",
                    GeoJson.Point(GeoJson.Position(longitude.Value, latitude.Value)), 5000); // 5km radius
                filters.Add(locationFilter);
            }

            var finalFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

            var healthcareCenters = await _healthcareCenters
                .Find(finalFilter)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return healthcareCenters.Select(h => new GetHealthcareCenterDTO
            {
                Id = h.Id.ToString(),  // Convert ObjectId to string
                Name = h.Name,
                Address = h.Address,
                Latitude = h.Location.Coordinates.Y,  // Use Y for Latitude
                Longitude = h.Location.Coordinates.X, // Use X for Longitude
                Specialties = h.Specialties,
                ContactNumber = h.ContactNumber,
                Rating = h.Rating,
                CreatedAt = h.CreatedAt
            }).ToList();
        }

        public async Task<int> GetTotalHealthcareCentersCountAsync(string name, string specialty)
        {
            var filterBuilder = Builders<HealthcareCenter>.Filter;
            var filters = new List<FilterDefinition<HealthcareCenter>>();

            if (!string.IsNullOrEmpty(name))
                filters.Add(filterBuilder.Regex("name", new BsonRegularExpression($".*{name}.*", "i")));

            if (!string.IsNullOrEmpty(specialty))
                filters.Add(filterBuilder.AnyEq("specialties", specialty));

            var finalFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

            return (int)await _healthcareCenters.CountDocumentsAsync(finalFilter); // Explicit cast to int
        }
    }
}
