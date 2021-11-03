using Microsoft.AspNetCore.Http;

namespace ZooStore.Models.ViewModels
{
    public abstract class ProductFormResult<T> where T : Product
    {
        public IFormFile Image { get; set; }
        public T Product { get; set; }
    }
}
