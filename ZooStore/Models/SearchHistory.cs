namespace ZooStore.Models
{
    public class SearchHistory
    {
        public long Id { get; set; }
        public string ToFind { get; set; }
        public AppUser User { get; set; }
    }
}
