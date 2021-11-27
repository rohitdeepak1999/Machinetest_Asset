using MachineTestAssestManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineTestAssestManagement.Repository
{
    public interface IAuthentication
    {
        public Login validateUser(string username, string password);

        Task<ActionResult<Login>> GetUserByPassword(string un, string pwd);
    }
}
