using UberSystem.Domain.Entities;
using UberSystem.Domain.Enums;
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

        public async Task Add(User user)
        {
            try
            {
                var userRepository = _unitOfWork.Repository<User>();
                if (user is not null)
                {
                    await _unitOfWork.BeginTransaction();
                    // check duplicate user
                    var existedUser = await userRepository.FindAsync(user.Id, user.Email);
                    if (existedUser is not null) throw new Exception("User already exists.");
                    await userRepository.InsertAsync(user);

                    await _unitOfWork.CommitTransaction();
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public Task CheckPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _unitOfWork.Repository<User>().FindAsync(email);
        }

        public async Task<IEnumerable<User>> GetCustomers()
        {
            var userRepository = _unitOfWork.Repository<User>();
            var users = await userRepository.GetAllAsync();

            var customers = users.Where(u => u.Role == (int)UserRole.CUSTOMER);
            return customers;
        }

        public async Task<bool> Login(User user)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                var UserRepos = _unitOfWork.Repository<User>();
                var objUser = await UserRepos.FindAsync(user.Email);
                if (objUser == null)
                    return false;
                if (objUser.Password != user.Password)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                var userRepository = _unitOfWork.Repository<User>();
                if (user is not null)
                {
                    await _unitOfWork.BeginTransaction();
                    await userRepository.UpdateAsync(user);
                    await _unitOfWork.CommitTransaction();
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}

