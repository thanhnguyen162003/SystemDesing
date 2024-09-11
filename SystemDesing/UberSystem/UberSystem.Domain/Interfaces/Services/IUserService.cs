using System;
using UberSystem.Domain.Entities;

namespace UberSystem.Domain.Interfaces.Services
{
	public interface IUserService
	{
        Task<User> FindByEmail(string  email);
        Task Update(User user);
        Task Add(User user);
        Task Login(User user);
        Task CheckPasswordAsync(User user);
    }
}

