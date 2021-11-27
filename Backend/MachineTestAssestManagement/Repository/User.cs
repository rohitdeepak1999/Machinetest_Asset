using MachineTestAssestManagement.Models;
using MachineTestAssestManagement.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTestAssestManagement.Repository
{
    public class User : IUser
    {
        AssestManagementContext _db;

        public User(AssestManagementContext db)
        {
            _db = db;
        }
        public async Task<List<UserRegistration>> GetUsers()
        {
            if (_db != null)
            {
                return await _db.UserRegistration.ToListAsync();
            }
            return null;
        }
        public async Task<int> AddUser(UserRegistration user)
        {
            if (_db != null)
            {
                await _db.UserRegistration.AddAsync(user);
                await _db.SaveChangesAsync();
                return (int)user.UId;
            }
            return 0;
        }
        public async Task UpdateUser(UserRegistration user)
        {
            if (_db != null)
            {
                _db.UserRegistration.Update(user);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<UserRegistration> DeleteUser(int id)
        {
            if (_db != null)
            {
                UserRegistration dbuser = _db.UserRegistration.Find(id);
                _db.UserRegistration.Remove(dbuser);
                await _db.SaveChangesAsync();
                return (dbuser);
            }
            return null;
        }
        public async Task<UserList> GetUserById(int id)
        {
            if (_db != null)
            {
                //LINQ
                //join UserRegistration and Login
                return await (from u in _db.UserRegistration
                              from l in _db.Login
                              where u.UId == id && u.UId == l.LId
                              select new UserList
                              {
                                  UId = u.UId,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  Age = u.Age,
                                  Gender = u.Gender,
                                  Username = l.Username,
                                  Password = l.Password,
                                  UserType = l.UserType



                              }).FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
