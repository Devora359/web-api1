namespace Entities
{
    public class User
    {

        //In C#, properties are written in PascalCase: Email. The data file stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
        public string email { get; set; }

        public string password { get; set; }

        public string firstname { get; set; }
        public string familyname { get; set; }
        public int userId { get; set; }
    }
}
