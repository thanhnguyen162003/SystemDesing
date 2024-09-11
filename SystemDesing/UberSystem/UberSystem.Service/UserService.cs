using System;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Interfaces.Services;
namespace UberSystem.Service
{
	public class UserService : IUserService
	{
		public UserService()
		{
		}

        public Task Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task CheckPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task Login(User user)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

