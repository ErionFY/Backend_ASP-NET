namespace Film_Catalog.Models
{
    public class ReviewModel
    {
        public Guid id { get; set; }
        public Int32 rating { get; set; }
        public string? reviewText { get; set; }
        public bool isAnonymous { get; set; }
        public DateTime createDateTime { get; set; }
        public UserShortModel author { get; set; }
    }
}
