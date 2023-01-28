using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infras.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public ApplicationDbContext _categoryContext;

    public CategoryRepository(ApplicationDbContext categoryContext)
    {
        _categoryContext = categoryContext;
    }

    public async Task<Category> GetByIdAsync(int? id)
    {
        return await _categoryContext.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryContext.Categories.ToListAsync();
    }

    public async Task<Category> CreateAsync(Category category)
    {
        _categoryContext.Categories.Add(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryContext.Categories.Update(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }

    public async Task<Category> RemoveAsync(Category category)
    {
        _categoryContext.Categories.Remove(category);
        await _categoryContext.SaveChangesAsync();
        return category;
    }
}
