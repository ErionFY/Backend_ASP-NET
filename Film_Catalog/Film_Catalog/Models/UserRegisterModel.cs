using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        public DateTime? birthDate { get; set; }
        public Gender? gender { get; set; }
           
    }
}
