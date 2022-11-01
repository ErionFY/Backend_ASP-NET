namespace Film_Catalog.Models
{
    public class UserRegisterModel
    {
        public string userName { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime? birthDate { get; set; }
        public Gender? gender { get; set; }
           
    }
}
