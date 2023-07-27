using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetById(int id);

        void AddUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        Task<bool> Commit();
    }
}
