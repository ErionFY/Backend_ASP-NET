namespace Film_Catalog.Models.DTO
{
    public class MovieElementModel
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? poster { get; set; }
        public int year { get; set; }
        public string? country { get; set; }
        public ICollection<GenreModel>? genres { get; set; }
        public ICollection<ReviewShortModel>? reviews { get; set; }
    }
}
