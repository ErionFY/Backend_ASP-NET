using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models
{
    public class ProfileModel
    {
        public Guid id { get; set; }
        public string? nickName { get; set; }
        [EmailAddress]
        public string email { get; set; }
        public string? avatarLink { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public Gender gender { get; set; }

    }
}
