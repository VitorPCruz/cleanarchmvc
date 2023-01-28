using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetByIdAsync(int? id);
    Task<ProductDTO> GetProductCategoryAsync(int? id);
    Task AddAsync(ProductDTO product);
    Task UpdateAsync(ProductDTO product);
    Task RemoveAsync(int? id);
}
