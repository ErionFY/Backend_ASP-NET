namespace Film_Catalog.Models.DTO
{
    public class ReviewModel
    {
        public Guid id { get; set; }
        public int rating { get; set; }
        public string? reviewText { get; set; }
        public bool isAnonymous { get; set; }
        public DateTime createDateTime { get; set; }
        public UserShortModel author { get; set; }
    }
}
