using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models.DBClasses
{
    public class Movie
    {
        [Key]
        public Guid Movie_Id { get; set; }
        public string? Name { get; set; }
        public string? Poster { get; set; }
        public Int32? Year { get; set; }
        public string? country { get; set; }
        public Int32 Time { get; set; }
        public string? Tagline { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int? Budget { get; set; }
        public int? Fees { get; set; }
        public int AgeLimit { get; set; }


        //###############
        //#Relationships#
        //###############
        public ICollection<User> Users { get; set; }
        public ICollection<Genre> Genres { get; set; }
       public ICollection<Review> Reviews { get; set; }
    }
}
