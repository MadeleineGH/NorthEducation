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
      await _context.Categories.AddAsync(categoryToAdd);
    }
    public async Task DeleteCategoryAsync(int id)
    {
      var response = await _context.Categories.FindAsync(id);

      if (response is not null)
      {
        _context.Categories.Remove(response);
      }
    }
    public async Task<List<CategoryViewModel>> GetCategoryByTitleAsync(string title)
    {
      return await _context.Categories
        .Where(c => c.Title!.ToLower() == title.ToLower())
        .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }
    public async Task<List<CategoryViewModel>> ListAllCategoriesAsync()
    {
      return await _context.Categories.ProjectTo<CategoryViewModel>
      (_mapper.ConfigurationProvider).ToListAsync();
    }
    public async Task<CategoryViewModel?> GetCategoryAsync(int id)
    {
      return await _context.Categories.Where(c => c.Id == id)
          .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
          .SingleOrDefaultAsync();
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task UpdateCategoryAsync(int id, PutCategoryViewModel model)
    {
      var category = await _context.Categories.FindAsync(id);

      if (category is null)
      {
        throw new Exception($"Couldn't find any Category with id {id}.");
      }

      category.Title = model.Title;

      _context.Categories.Update(category);
    }
    public async Task<CategoryViewModel?> GetCategoryAsync(string title)
    {
      return await _context.Categories.Where(c => c.Title!.ToLower() == title.ToLower())
        .ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
          .SingleOrDefaultAsync();
    }

    public async Task<List<CategoryWithCoursesViewModel>> ListCategoriesCourses()
    {
      return await _context.Categories.Include(c => c.Courses)

      .Select(c => new CategoryWithCoursesViewModel
      {
        CategoryId = c.Id,
        Title = c.Title,
        Courses = c.Courses

          .Select(c => new CourseViewModel
          {
            CourseId = c.Id,
            CourseNumber = c.CourseNumber,
            Title = c.Title,
            Duration = c.Duration,
            Description = c.Description,
            Details = c.Details,
            CategoryName = c.Category.Title,
            ImageUrl = c.ImageUrl
          }).ToList()
      })
      .ToListAsync();
    }

    public async Task<CategoryWithCoursesViewModel?> ListCategoriesCourses(int id)
    {
      return await _context.Categories.Where(c => c.Id == id).Include(c => c.Courses)

      .Select(c => new CategoryWithCoursesViewModel
      {
        CategoryId = c.Id,
        Title = c.Title,
        Courses = c.Courses

          .Select(c => new CourseViewModel
          {
            CourseId = c.Id,
            CourseNumber = c.CourseNumber,
            Title = c.Title,
            Duration = c.Duration,
            Description = c.Description,
            Details = c.Details,
            CategoryName = c.Category.Title,
            ImageUrl = c.ImageUrl
          }).ToList()
      })
      .SingleOrDefaultAsync();
    }
  }
}