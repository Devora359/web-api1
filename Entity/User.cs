namespace Entities
{
    public class User
    {

        //In C#, public properties are PascalCase (Email). Keep the names as they are, because the stored JSON would stop loading. Tip: PropertyNameCaseInsensitive = true in the JSON options reads both spellings.
        public string email { get; set; }

        public string password { get; set; }

        public string firstname { get; set; }
        public string familyname { get; set; }
        public int userId { get; set; }
    }
}
