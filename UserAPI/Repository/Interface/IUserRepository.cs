using Microsoft.AspNetCore.Mvc;
using UserAPI.Entity;
using UserAPI.Models;

namespace UserAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        User Map(UserViewModel userViewModel);

        Task Commit();
    }
}
