using Microsoft.AspNetCore.Mvc;
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

        Task Commit();
    }
}
