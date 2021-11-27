using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.Repository
{
    public interface IUserRepo
    {
        //CRUD 
        //get user
        public Task<List<UserRegistration>> GetUsers();

        //get user by id
        public Task<UserRegistration> GetUserById(int id);

        //add user
        public Task<int> AddUser(UserRegistration user);

        //delete user
        public Task<int> DeleteUser(int id);

        //update user
        public Task<UserRegistration> UpdateUser(UserRegistration user);

        //public Task<List<ResourceEnquiryModel>> GetResourceEnquiryReport();
    }
}
