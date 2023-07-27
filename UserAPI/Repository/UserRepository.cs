using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;
using UserAPI.Repository.Interface;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _dataContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void AddUser(User user)
        {
            _dataContext.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _dataContext.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _dataContext.Users.Remove(user);
        }

        public async Task<bool> Commit()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
