using Microsoft.AspNetCore.Mvc;
using SBNHCRSWFAA.Models.DTOs;
using SBNHCRSWFAA.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBNHCRSWFAA.Controllers
{
    [Route("api/health-profiles")]
    [ApiController]
    public class HealthProfileController : ControllerBase
    {
        private readonly IHealthProfileServices _healthProfileServices;

        public HealthProfileController(IHealthProfileServices healthProfileServices)
        {
            _healthProfileServices = healthProfileServices;
        }

        /// <summary>
        /// Retrieves all health profiles.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<GetHealthProfileDTO>>> GetAllHealthProfiles()
        {
            try
            {
                var profiles = await _healthProfileServices.GetAllHealthProfilesAsync();
                return Ok(profiles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching health profiles.", Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a health profile by ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<GetHealthProfileDTO>> GetHealthProfileById(string id)
        {
            try
            {
                var profile = await _healthProfileServices.GetHealthProfileByIdAsync(id);
                if (profile == null) return NotFound(new { Message = "Health profile not found." });
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching the health profile.", Error = ex.Message });
            }
        }

        /// <summary>
        /// Creates a new health profile.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateHealthProfile([FromBody] CreateHealthProfileDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var isCreated = await _healthProfileServices.CreateHealthProfileAsync(dto);
                if (!isCreated) return BadRequest(new { Message = "Health profile already exists for this user." });

                return StatusCode(201, new { Message = "Health profile created successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the health profile.", Error = ex.Message });
            }
        }

        /// <summary>
        /// Updates an existing health profile.
        /// </summary>
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EditHealthProfile( [FromBody] EditHealthProfileDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var isUpdated = await _healthProfileServices.EditHealthProfileAsync( dto);
                if (!isUpdated) return NotFound(new { Message = "Health profile not found." });

                return Ok(new { Message = "Health profile updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the health profile.", Error = ex.Message });
            }
        }
    }
}