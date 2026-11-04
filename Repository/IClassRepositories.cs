using Entities;

namespace Repositories
{
    public interface IClassRepositories
    {
        User AddUser(User user);
        User AddUserLogin(userLogin loginUser);
        User GetUserById(int id);
        void updateUser(int id, User userToUpdate);
    }
}