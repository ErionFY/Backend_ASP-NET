namespace Film_Catalog.Models
{
    public class MoviesPagedListModel
    {
        public ICollection<MovieElementModel>? movies { get; set; }
        public PageInfoModel pageInfo { get; set; }
    }
}
