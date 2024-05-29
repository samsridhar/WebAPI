using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.Domain;
using WebAPI.Models.DTO;
using WebAPI.Repositories.Interface;

namespace WebAPI.Controllers
{
    // https://localhost:xxxx/api/ManageUser
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUserController : ControllerBase
    {
        private readonly IUser user;

        public ManageUserController(IUser user)
        {
            this.user = user;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
        {

        // Map DTO to Domain Model
        var userInfo = new UserInfo
            {
            samAccountName = request.samAccountName,
            firstName = request.firstName,
            lastName = request.lastName,
            eMail = request.eMail,
            telephoneNumber = request.telephoneNumber,
            password = request.password,
            roles = request.roles,
        };

            await user.CreateAsync(userInfo);

            // Domain model to DTO
            var response = new UserDto
            {

                activeDirectoryUserId = userInfo.activeDirectoryUserId,
                samAccountName = userInfo.samAccountName,
                firstName = userInfo.firstName,
                lastName = userInfo.lastName,
                eMail = userInfo.eMail,
                telephoneNumber = userInfo.telephoneNumber,
                password = userInfo.password,
                roles = userInfo.roles,
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await user.GetAllAsync();

            // Map Domain model to DTO

            var response = new List<UserDto>();
            foreach (var user in users)
            {
                response.Add(new UserDto
                {
                    activeDirectoryUserId = user.activeDirectoryUserId,
                    samAccountName = user.samAccountName,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    eMail = user.eMail,
                    telephoneNumber = user.telephoneNumber,
                    password = user.password,
                    roles = user.roles,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var existingUser = await user.GetById(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                activeDirectoryUserId = existingUser.activeDirectoryUserId,
                samAccountName = existingUser.samAccountName,
                firstName = existingUser.firstName,
                lastName = existingUser.lastName,
                eMail = existingUser.eMail,
                telephoneNumber = existingUser.telephoneNumber,
                password = existingUser.password,
                roles = existingUser.roles,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditUser([FromRoute] Guid id, UpdateUserRequestDto request)
        {
            // Convert DTO to Domain Model
            var userInfo = new UserInfo
            {
                activeDirectoryUserId = id,
                samAccountName = request.samAccountName,
                firstName = request.firstName,
                lastName = request.lastName,
                eMail = request.eMail,
                telephoneNumber = request.telephoneNumber,
                password = request.password,
                roles = request.roles,
            };

            userInfo = await user.UpdateAsync(userInfo);

            if (userInfo == null)
            {
                return NotFound();
            }

            // Convert Domain model to DTO
            var response = new UserDto
            {
                activeDirectoryUserId = userInfo.activeDirectoryUserId,
                samAccountName = userInfo.samAccountName,
                firstName = userInfo.firstName,
                lastName = userInfo.lastName,
                eMail = userInfo.eMail,
                telephoneNumber = userInfo.telephoneNumber,
                password = userInfo.password,
                roles = userInfo.roles,
            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var userInfo = await user.DeleteAsync(id);

            if (userInfo is null)
            {
                return NotFound();
            }

            // Convert Domain model to DTO
            var response = new UserDto
            {
                activeDirectoryUserId = userInfo.activeDirectoryUserId,
                samAccountName = userInfo.samAccountName,
                firstName = userInfo.firstName,
                lastName = userInfo.lastName,
                eMail = userInfo.eMail,
                telephoneNumber = userInfo.telephoneNumber,
                password = userInfo.password,
                roles = userInfo.roles,
            };

            return Ok(response);
        }
    }
}
