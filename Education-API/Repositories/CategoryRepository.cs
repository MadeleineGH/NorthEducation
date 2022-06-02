using AutoMapper;
using AutoMapper.QueryableExtensions;
using Education_API.Data;
using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Education_API.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Repositories
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;
    public CategoryRepository(EducationContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }
    
    public async Task AddCategoryAsync(PostCategoryViewModel model)
    {
      var categoryToAdd = _mapper.Map<Category>(model);
      await _context.Category.AddAsync(categoryToAdd);
    }
    public async Task DeleteCategoryAsync(int id)
    {
      var response = await _context.Category.FindAsync(id);

      if(response is not null)
      {
        _context.Category.Remove(response);
      }
    }
    public async Task<List<CategoryViewModel>> GetCategoryByTitleAsync(string title)
    {
      return await _context.Category
        .Where(c => c.Title!.ToLower() == title.ToLower())
        .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }
    public async Task<List<CategoryViewModel>> ListAllCategoriesAsync()
    {
      return await _context.Category.ProjectTo<CategoryViewModel>
      (_mapper.ConfigurationProvider).ToListAsync();
    }
    public async Task<CategoryViewModel?> GetCategoryAsync(int id)
    {
      return await _context.Category.Where(c => c.Id == id)
          .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
          .SingleOrDefaultAsync();
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task UpdateCategoryAsync(int id, PutCategoryViewModel model)
    {
      var Category = await _context.Category.FindAsync(id);

      if(Category is null)
      {
        throw new Exception($"Couldn't find any Category with id {id}.");
      }
  
        Category.Title = model.Title;

        _context.Category.Update(Category);
    }
    public async Task<CategoryViewModel?> GetCategoryAsync(string title)
    {
      return await _context.Category.Where(c => c.Title!.ToLower() == title.ToLower())
        .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
          .SingleOrDefaultAsync();
    }
  }
}