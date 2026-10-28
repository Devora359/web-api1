namespace MyWebApi
{
    //In C#, public properties are written in PascalCase (Email, Password, FirstName, FamilyName, UserId).
    //If you rename them, file.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class User
    {

        public string email { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string familyname { get; set; }
        public int userId { get; set; }
    }
}
