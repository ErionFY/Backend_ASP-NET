namespace Film_Catalog.Models.DTO
{
    public class MoviesPagedListModel
    {
        public ICollection<MovieElementModel>? movies { get; set; }
        public PageInfoModel pageInfo { get; set; }
    }
}
