using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Entity;
using UserAPI.Models;
using UserAPI.Repository.Interface;

namespace UserAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public UserRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
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

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
        }

        public User Map(UserViewModel userViewModel)
        {
            return _mapper.Map<User>(userViewModel);
        }
    }
}
