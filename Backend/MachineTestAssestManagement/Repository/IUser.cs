using MachineTestAssestManagement.Models;
using MachineTestAssestManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTestAssestManagement.Repository
{
    public interface IUser
    { 
        //get user
        Task<List<UserRegistration>> GetUsers();
        //GEt User by Id
        Task<UserList> GetUserById(int id);
        //Add user 
        Task<int> AddUser(UserRegistration user);

        //Update User
        Task UpdateUser(UserRegistration user);

        //Delete User
        Task<UserRegistration> DeleteUser(int id);

    }
}
