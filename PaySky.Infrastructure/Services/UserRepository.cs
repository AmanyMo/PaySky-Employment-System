using Microsoft.EntityFrameworkCore;
using PaySky.Domain.Entities;
using PaySky.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySky.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly EmploymentDbContext _employmentDbContext;
        public UserRepository(EmploymentDbContext employmentDbContext)
        {
            _employmentDbContext = employmentDbContext;
        }
        public async Task AddAsync(User user)
        {
            await _employmentDbContext.Users.AddAsync(user);

        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _employmentDbContext.Users
                .SingleOrDefaultAsync<User>(u => u.Email == email);
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _employmentDbContext.SaveChangesAsync();
        }
        Task<User> IUserRepository.ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
