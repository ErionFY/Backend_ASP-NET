using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models.DBClasses
{
    public class User
    {
        [Key]
        public Guid User_Id { get; set; } 
        public string UserName { get; set; } //UserName=NickName -Unique
        public string Name { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }//Unique
        [Url]
        public string? AvatarLink { get; set; }
        public DataType BirthDate { get; set; }
        [Range(0, 1)]
        public Int32? Gender { get; set; }
        
        //###############
        //#Relationships#
        //###############
        public ICollection<Movie> Movies { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
