using System.Text.Json;
using Entities;


namespace Repositories
{
    public class ClassRepositories : IClassRepositories
    {

        public User AddUser(User user)
        {
            string filePath = "M:\\web api\\MyWebApi\\Repository\\file.txt";

            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.userId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return user;
        }



        public User AddUserLogin(userLogin loginUser)
        {
            string filePath = "M:\\web api\\MyWebApi\\Repository\\file.txt";
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == loginUser.email && user.password ==
                    loginUser.password)
                        return user;
                }
            }
            return null;


        }

        public void updateUser(int id, User userToUpdate)
        {
            string filePath = "M:\\web api\\MyWebApi\\Repository\\file.txt";

            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }

        }

        public User GetUserById(int id)
        {
            string filePath = "M:\\web api\\MyWebApi\\Repository\\file.txt";

            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userId == id)
                        return user;
                }
            }
            return null;

        }

    }
}

    
