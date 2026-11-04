using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Repositories;


namespace Services
{
    public class classService : IclassService
    {

        IClassRepositories repository;

        public classService(IClassRepositories repository)
        {
            this.repository = repository;
        }


        public User AddUser(User user)
        {
            return repository.AddUser(user);
        }


        public User AddUserLogin(userLogin loginUser)
        {
            return repository.AddUserLogin(loginUser);
        }


        public void updateUser(int id, User userToUpdate)
        {
            repository.updateUser(id, userToUpdate);
        }

        public User GetUserById(int id)
        {
            return repository.GetUserById(id);
        }
    }
}
