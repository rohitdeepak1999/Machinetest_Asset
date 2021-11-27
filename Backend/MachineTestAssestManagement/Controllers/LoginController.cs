using MachineTestAssestManagement.Models;
using MachineTestAssestManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineTestAssestManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        IAuthentication loginRepository;

        public LoginController(IConfiguration config, IAuthentication _l)
        {
            _config = config;
            loginRepository = _l;
        }

        [AllowAnonymous]
        [HttpGet("{username}/{password}")]
        //loginmethod--IActionResult
        public IActionResult LoginValidation(string username, string password)
        {
            IActionResult response = Unauthorized();



            Login dbUser = null;



            //Authenticate the user by passing username and password
            dbUser = AuthenticateUser(username, password);





            if (dbUser != null)
            {
                var tokenString = GenerateJSONWebToken(dbUser);
                response = Ok(new
                {
                    
                    UserName = dbUser.Username,
                    token = tokenString
                });
            }
            return response;
        }
        private string GenerateJSONWebToken(Login dbUser)
        {
            //--- getting security ---//
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            //--- signing credentials ---//
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            //--- generate the token ---//
            var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //AuthenticateUser()
        private Login AuthenticateUser(string userName, string password)
        {
            //validate the user credentials
            //Retrieve data from the database



            //checking validity of user by username and password
            Login dbuser = loginRepository.validateUser(userName, password);
            if (dbuser != null)
            {
                return dbuser;
            }
            return null;
        }
        #region GetUser by Password
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("getuser/{userName}/{password}")]
        public async Task<ActionResult<Login>> GetUserByPassword(string userName, string password)
        {
            try
            {
                var tbluser = await loginRepository.GetUserByPassword(userName, password);
                if (tbluser == null)
                {
                    return NotFound();
                }
                return tbluser;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
