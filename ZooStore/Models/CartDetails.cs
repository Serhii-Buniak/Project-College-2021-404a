namespace ZooStore.Models
{
    public class CartDetails
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public virtual Product Product { get; set; }

    }
}
