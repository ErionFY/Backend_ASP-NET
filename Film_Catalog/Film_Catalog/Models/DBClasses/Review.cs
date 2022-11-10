using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Film_Catalog.Models.DBClasses
{
    public class Review
    {
        [Key]
        public Guid Review_Id { get; set; }
        [Range(0,10)]
        public Int32 Rating { get; set; }
        public string? ReviewText { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Movie Movie { get; set; }    
        public User Author { get; set; }
    } 
}
