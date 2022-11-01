using System.ComponentModel.DataAnnotations;

namespace Film_Catalog.Models
{
    public class ReviewModifyModel
    {
        [Required]
        public string reviewText { get; set; }
        [Range(0, 10)]
        public Int32 rating { get; set; }
        public bool isAnonymous { get; set; }
    }
}
