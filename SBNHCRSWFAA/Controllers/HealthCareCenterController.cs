using SBNHCRSWFAA.Models.DTOs;
using SBNHCRSWFAA.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBNHCRSWFAA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcareCenterController : ControllerBase
    {
        private readonly IHealthcareCenterService _healthcareCenterService;

        public HealthcareCenterController(IHealthcareCenterService healthcareCenterService)
        {
            _healthcareCenterService = healthcareCenterService;
        }

        /// <summary>
        /// Search healthcare centers with filtering and pagination
        /// </summary>
        [HttpGet("search")]
        public async Task<IActionResult> SearchHealthcareCenters(
            [FromQuery] string name,
            [FromQuery] string specialty,
            [FromQuery] double? latitude,
            [FromQuery] double? longitude,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            try
            {
                var results = await _healthcareCenterService.SearchHealthcareCentersAsync(name, specialty, latitude, longitude, page, pageSize);
                var totalRecords = await _healthcareCenterService.GetTotalHealthcareCentersCountAsync(name, specialty);

                return Ok(new
                {
                    success = true,
                    data = results,
                    pagination = new
                    {
                        currentPage = page,
                        pageSize = pageSize,
                        totalRecords = totalRecords,
                        totalPages = (int)Math.Ceiling((double)totalRecords / pageSize)
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }
    }
}