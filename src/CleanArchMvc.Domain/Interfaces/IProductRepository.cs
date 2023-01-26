using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetCategoriesAsync();
        Task<Product> GetByIdAsync(int? id);
        Task<IEnumerable<Product>> GetProductCategoryAsync(int? id);
        Task<Product> CreateAsync(Product category);
        Task<Product> UpdateAsync(Product category);
        Task<Product> RemoveAsync(Product category);
    }
}
