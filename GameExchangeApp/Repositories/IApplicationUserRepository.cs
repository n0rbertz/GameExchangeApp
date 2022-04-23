using System;
using System.Collections.Generic;
using GameExchangeApp.Models;

namespace GameExchangeApp.Repositories
{
    public interface IApplicationUserRepository : IDisposable
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUserById(int id);
        void InsertUser(ApplicationUser user);
        void Save();
    }
}
