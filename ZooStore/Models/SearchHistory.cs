namespace ZooStore.Models
{
    public class SearchHistory
    {
        public long Id { get; set; }
        public string ToFind { get; set; }
        public long Quantity { get; set; }
        public virtual AppUser User { get; set; }
    }
}
