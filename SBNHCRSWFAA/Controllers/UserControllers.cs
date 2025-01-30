using Microsoft.AspNetCore.Mvc;
using SBNHCRSWFAA.Models;
using SBNHCRSWFAA.Models.DTOs;
using SBNHCRSWFAA.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SBNHCRSWFAA.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<Users>>> GetAllUsers()
        {
            try
            {
                var users = await _userServices.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching users.", Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a user by ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User details</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Users>> GetUserById(string id)
        {
            try
            {
                var user = await _userServices.GetUserByIdAsync(id);
                if (user == null) return NotFound(new { Message = "User not found." });
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while fetching the user.", Error = ex.Message });
            }
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="dto">User registration data</param>
        /// <returns>Success status</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var isCreated = await _userServices.CreateUserAsync(dto);
                if (!isCreated) return BadRequest(new { Message = "User with this phone number already exists." });

                return StatusCode(201, new { Message = "User created successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the user.", Error = ex.Message });
            }
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Success status</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var isDeleted = await _userServices.DeleteUserAsync(id);
                if (!isDeleted) return NotFound(new { Message = "User not found." });

                return Ok(new { Message = "User deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the user.", Error = ex.Message });
            }
        }
    }
}