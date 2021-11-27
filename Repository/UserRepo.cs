using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public class UserRepo : IUserRepo
    {
        AssetManagementContext db;

        public UserRepo(AssetManagementContext db)
        {
            this.db = db;
        }

        //add user
        public async Task<int> AddUser(UserRegistration user)
        {
            if (db != null)
            {
                await db.UserRegistration.AddAsync(user);

                await db.SaveChangesAsync();
                return user.UId;
            }
            return 0;
        }

        //delete user

        public async Task<int> DeleteUser(int id)
        {
            var user = await db.UserRegistration.FirstOrDefaultAsync(em => em.UId == id);
            if (user != null)
            {
                db.UserRegistration.Remove(user);
                await db.SaveChangesAsync();
            }
            return user.UId;
        }

        //get user by id
        public async Task<UserRegistration> GetUserById(int id)
        {
            var user = await db.UserRegistration.FirstOrDefaultAsync(em => em.UId == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        //get users
        public async Task<List<UserRegistration>> GetUsers()
        {
            if (db != null)
            {
                return await db.UserRegistration.ToListAsync();
            }
            return null;
        }


        public async Task<UserRegistration> UpdateUser(UserRegistration user)
        {
            if (db != null)
            {
                db.UserRegistration.Update(user);
                await db.SaveChangesAsync();

            }
            return null;
        }
    }
}
