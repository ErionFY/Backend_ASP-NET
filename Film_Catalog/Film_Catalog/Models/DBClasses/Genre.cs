using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models.DBClasses
{
    public class Genre
    {
        [Key]
        public Guid Genre_Id { get; set; }
        public string? Name { get; set; }

        //###############
        //#Relationships#
        //###############
        public ICollection<Movie> Movies { get; set; }
    }
}
