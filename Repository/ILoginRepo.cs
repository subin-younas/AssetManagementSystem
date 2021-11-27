using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public interface ILoginRepo
    {

        //get user by username password
        Task<ActionResult<Login>> GetUserByNamePassword(string un, string pwd);

        //validate user
        public Login validateUser(string username, string password);

        //get user by id
        public Task<Login> GetUserById(int id);

        //add user
        public Task<int> AddUser(Login user);

        //delete user
        public Task<int> DeleteUser(int id);
    }
}
