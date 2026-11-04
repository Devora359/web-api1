using Entities;

namespace Services
{
    public interface IclassService
    {
        User AddUser(User user);
        User AddUserLogin(userLogin loginUser);
        User GetUserById(int id);
        void updateUser(int id, User userToUpdate);
    }
}