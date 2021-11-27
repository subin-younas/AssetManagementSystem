using AssetManagement.Models;
using AssetManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo userRepo;
        AssetManagementContext db;

        public UserController(IUserRepo userRepo, AssetManagementContext db)
        {
            this.userRepo = userRepo;
            this.db = db;
        }

        #region get users
        //get users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var user = await userRepo.GetUsers();
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion

        #region get user by id 
        //get user by id 
        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await userRepo.GetUserById(id);
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

        #region Add User
        //add user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserRegistration model)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await userRepo.AddUser(model);
                    if (userId > 0)
                    {
                        return Ok(userId);
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

        #region Update User

        //update User
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserRegistration model)
        {
            //check the validation of this body
            if (ModelState.IsValid)
            {
                try
                {
                    await userRepo.UpdateUser(model);

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
        //delete user

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await userRepo.DeleteUser(id);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion

        #region Get all enquiry details
        //[HttpGet]
        //[Route("EnquiryReport")]
        //public async Task<IActionResult> GetResourceEnquiryReport()
        //{
        //    try
        //    {
        //        var details = await resourceEnquiry.GetResourceEnquiryReport();

        //        if (details == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(details);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        #endregion
    }
}
