using AssetManagement.Models;
using AssetManagement.Repository;
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

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        ILoginRepo loginRepo;
        //constructor dependancy injection
        public LoginController(IConfiguration config, ILoginRepo loginRepo)
        {
            _config = config;
            this.loginRepo = loginRepo;
        }

        #region Get user and token by username and password 
        [AllowAnonymous]
        [HttpGet("{Username}/{Password}")]
        //loginmethod--IActionResult
        public IActionResult Login(string Username, string Password)
        {
            IActionResult response = Unauthorized();

            Login dbUser = null;

            //Authenticate the user by passing username and password
            dbUser = AuthenticateUser(Username, Password);



            if (dbUser != null)
            {
                var tokenString = GenerateJSONWebToken(dbUser);
                response = Ok(new
                {
                    token = tokenString,
                    LoginId = dbUser.LId,
                    UserName = dbUser.Username,
                    Userpassword = dbUser.Password,
                    UserType = dbUser.UserType,
                    
                });
            }
            return response;
        }

        #endregion

        // get user details with username and password
        #region Get user  details giving username and password
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("User/{userName}/{password}")]
        public async Task<IActionResult> GetUserByNamePassword(string userName, string password)
        {
            try
            {
                var dbuser = await loginRepo.GetUserByNamePassword(userName, password);
                if (dbuser == null)
                {
                    return NotFound();
                }
                return Ok(dbuser);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        #endregion


        #region user  by id
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await loginRepo.GetUserById(id);
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

        #region Add user
        //add user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Login model)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await loginRepo.AddUser(model);
                    if (user > 0)
                    {
                        return Ok(user);
                    }
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }


        #endregion

        #region Delete user
        //delete user

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await loginRepo.DeleteUser(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        //generate token method
        private object GenerateJSONWebToken(Login dbUser)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //authenticate user 
        private Login AuthenticateUser(string Username, string Password)
        {
            //validate the user credentials
            //Retrieve data from the database


            Login dbuser = loginRepo.validateUser(Username, Password);//checking validity of user by username and password

            if (dbuser != null)
            {

                return dbuser;

            }
            return null;
        }


    }
}
