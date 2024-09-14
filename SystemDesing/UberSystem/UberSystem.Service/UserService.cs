﻿using System;
using UberSystem.Domain.Entities;
using UberSystem.Domain.Interfaces;
using UberSystem.Domain.Interfaces.Services;
namespace UberSystem.Service
{
	public class UserService : IUserService
	{
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
		{
            _unitOfWork = unitOfWork;
		}

        public async Task<bool> AddUserAsync(User user, CancellationToken cancellationToken)
        {
			try
			{
				await _unitOfWork.BeginTransaction();

				var userData = _unitOfWork.Repository<User>();
				await userData.InsertAsync(user);
				await _unitOfWork.CommitTransaction();
                return true;
			}
			catch (Exception e)
			{
				await _unitOfWork.RollbackTransaction();
                return false;
			}
		}

        public Task CheckPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(User user)
        {
            try{
                await _unitOfWork.BeginTransaction();
                var UserRepos = _unitOfWork.Repository<User>();
                var objUser = await UserRepos.FindAsync(user.Email);
                if (objUser == null)
                    return false;
                if (objUser.Password != user.Password)
                    return false; 
                else 
                    return true;
            }catch{
                return false;
            }
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

