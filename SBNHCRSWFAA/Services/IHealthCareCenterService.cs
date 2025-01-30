using SBNHCRSWFAA.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBNHCRSWFAA.Services
{
    public interface IHealthcareCenterService
    {
        Task<List<GetHealthcareCenterDTO>> SearchHealthcareCentersAsync(string name, string specialty, double? latitude, double? longitude, int page, int pageSize);
        Task<int> GetTotalHealthcareCentersCountAsync(string name, string specialty); 
    }
}