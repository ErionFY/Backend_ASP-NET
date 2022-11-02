namespace Film_Catalog.Models.DTO
{
    public class MovieDetailsModel
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? poster { get; set; }
        public int year { get; set; }
        public string? country { get; set; }
        public ICollection<GenreModel>? genres { get; set; }
        public ICollection<ReviewModel>? reviews { get; set; }
        public int time { get; set; }
        public string? tagline { get; set; }
        public string? description { get; set; }
        public string? director { get; set; }
        public int? budget { get; set; }
        public int? fees { get; set; }
        public int ageLimit { get; set; }
    }
}
