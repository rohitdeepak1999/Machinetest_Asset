using MachineTestAssestManagement.Models;
using MachineTestAssestManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTestAssestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser UserRepository;
        public UserController(IUser _u)
        {
            UserRepository = _u;
        }
        #region Get user
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await UserRepository.GetUsers();
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Add user
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UserId = await UserRepository.AddUser(model);
                    if (UserId > 0)
                    {
                        return Ok(UserId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Update User
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await UserRepository.UpdateUser(model);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }



            }
            return BadRequest();
        }
        #endregion

        #region Delete User
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await UserRepository.DeleteUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Get User by Id
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await UserRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }


}
