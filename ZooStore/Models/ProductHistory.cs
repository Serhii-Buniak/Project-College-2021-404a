namespace ZooStore.Models
{
    public class ProductHistory
    {
        public long Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual AppUser User { get; set; }
    }
}
