namespace ZooStore.Models
{
    public class ProductHistory
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public AppUser User { get; set; }
    }
}
