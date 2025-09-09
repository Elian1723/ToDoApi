using AutoMapper;
using ToDoApi.Models.DTOs;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> CreateAsync(CategoryCreateDto entity)
    {
        if (_categoryRepository.GetByNameAsync(entity.Name).Result is not null)
        {
            throw new Exception("Category with the same name already exists.");
        }

        var category = _mapper.Map<Category>(entity);

        var categoryCreated = await _categoryRepository.CreateAsync(category);
        await _categoryRepository.SaveChangesAsync();

        return _mapper.Map<CategoryDto>(categoryCreated);
    }

    public async Task DeleteAsync(int id)
    {
        if (_categoryRepository.GetByIdAsync(id).Result is null)
        {
            throw new KeyNotFoundException("Category not found.");
        }

        await _categoryRepository.DeleteAsync(id);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(string name)
    {
        var category = await _categoryRepository.GetByNameAsync(name);
        
        return category is not null;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<CategoryDto>>(categories ?? []);
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null) return null;

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto?> GetByNameAsync(string name)
    {
        var category = await _categoryRepository.GetByNameAsync(name);

        if (category is null) return null;

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<int> GetUsageCountAsync(int categoryId)
    {
        var usageCount = await _categoryRepository.GetUsageCountAsync(categoryId);

        return usageCount;
    }

    public Task<int> GetUsageCountByUserAsync(int categoryId, int userId)
    {
        var usageCount = _categoryRepository.GetUsageCountByUserAsync(categoryId, userId);

        return usageCount;
    }

    public async Task UpdateAsync(CategoryUpdateDto entity, int id)
    {
        if (await _categoryRepository.GetByIdAsync(id) is null)
        {
            throw new KeyNotFoundException($"Category with ID {id} not found.");
        }

        var category = _mapper.Map<Category>(entity);

        _categoryRepository.Update(category);
        await _categoryRepository.SaveChangesAsync();
    }
}
