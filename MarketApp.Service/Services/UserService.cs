using MarketApp.Data.IRepositories;
using MarketApp.Domain.Entities.Users;
using MarketApp.Service.Exceptions;
using MarketApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Service.Services
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async ValueTask<User> GetAsync(string username, string password)
        {
            var user =
                await this.unitOfWork.Users.GetAsync(user => user.Username.Equals(username) && user.Password.Equals(password));
            if (user is null)
                throw new CustomException(404, "User not found");

            return user;
        }
    }
}
