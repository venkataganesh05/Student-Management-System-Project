using StudentManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Core.Interfaces.Repositories
{
        public interface IUserRepository
        {
            Task<User> GetByEmail(string email);
        }
}

