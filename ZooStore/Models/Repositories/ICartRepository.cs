namespace ZooStore.Models.Repositories
{
    public interface ICartRepository
    {
        public void Add(Product product, AppUser user);
        public void Remove(Product product, AppUser user);
        public bool Contains(Product product, AppUser user);
    }
}
