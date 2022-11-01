namespace Film_Catalog.Models
{
    public class MovieDetailsModel
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? poster { get; set; }
        public  Int32 year { get; set; }
        public string? country { get; set; }
        public ICollection<GenreModel>? genres { get; set; }
        public ICollection<ReviewModel>? reviews { get; set; }
        public Int32 time { get; set; }
        public string? tagline { get; set; }
        public string? description { get; set; }
        public string? director  { get; set; }
        public Int32? budget { get; set; }
        public Int32? fees {get; set; }
        public Int32 ageLimit { get; set; }
    }
}
