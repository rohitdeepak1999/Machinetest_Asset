using MachineTestAssestManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTestAssestManagement.Repository
{
    public class Authentication :IAuthentication
    {
        AssestManagementContext _db;

        public Authentication(AssestManagementContext db)
        {
            _db = db;
        }
        public Login validateUser(string username, string password)
        {
            if (_db != null)
            {
                Login dbuser = _db.Login.FirstOrDefault(em => em.Username == username && em.Password == password);
                if (dbuser != null)
                {
                    return dbuser;
                }
            }
            return null;
        }

        #region GetUserByPassword
        public async Task<ActionResult<Login>> GetUserByPassword(string un, string pwd)
        {
            if (_db != null)
            {
                Login user = await _db.Login.FirstOrDefaultAsync(em => em.Username == un && em.Password == pwd);
                return user;
            }
            return null;
        }
        #endregion
    }
}
