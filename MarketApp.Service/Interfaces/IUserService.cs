using MarketApp.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<User> GetAsync(string username, string password);
    }
}
