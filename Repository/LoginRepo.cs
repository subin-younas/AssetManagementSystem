using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public class LoginRepo : ILoginRepo
    {
        //dependancy injection for db
        AssetManagementContext db;
        public LoginRepo(AssetManagementContext db)
        {
            this.db = db;
        }


        #region Add User
        //add user
        public async Task<int> AddUser(Login user)
        {
            if (db != null)
            {
                await db.Login.AddAsync(user);

                await db.SaveChangesAsync();
                return user.LId;
            }
            return 0;
        }



        #endregion

        //delete user

        #region Delete User
        public async Task<int> DeleteUser(int id)
        {
            var user = await db.Login.FirstOrDefaultAsync(em => em.LId == id);
            if (user != null)
            {
                db.Login.Remove(user);
                await db.SaveChangesAsync();
            }
            return user.LId;
        }
        #endregion

        #region Get user by id
        public async Task<Login> GetUserById(int id)
        {
            var user = await db.Login.FirstOrDefaultAsync(em => em.LId == id);
            if (user != null)
            {
                db.Login.Remove(user);
                await db.SaveChangesAsync();
            }
            return user;
        }
        #endregion

        #region Get user by name and password
        public async Task<ActionResult<Login>> GetUserByNamePassword(string un, string pwd)
        {
            Login dbuser = await db.Login.FirstOrDefaultAsync(em => em.Username == un && em.Password == pwd);
            if (dbuser != null)
            {
                return dbuser;
            }
            return null;
        }

        #endregion


        #region Validate User
        public Login validateUser(string username, string password)
        {
            if (db != null)
            {
                Login dbuser = db.Login.FirstOrDefault(em => em.Username == username && em.Password == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;
        }

        #endregion
    }
}
