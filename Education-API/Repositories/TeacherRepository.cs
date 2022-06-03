using AutoMapper;
using AutoMapper.QueryableExtensions;
using Education_API.Data;
using Education_API.Interfaces;
using Education_API.Models;
using Education_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Repositories
{
  public class TeacherRepository : ITeacherRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;
    public TeacherRepository(EducationContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task AddTeacherAsync(PostTeacherViewModel model)
    {
        if(!_context.Teacher.Any(s => s.Email == model.Email))
          {
            var TeacherToAdd = _mapper.Map<Teacher>(model);
            await _context.Teacher.AddAsync(TeacherToAdd);
          }
    }
    public async Task DeleteTeacherAsync(int id)
    {
      var response = await _context.Teacher.FindAsync(id);

      if(response is not null)
      {
        _context.Teacher.Remove(response);
      }
    }
    public async Task<TeacherViewModel?> GetTeacherAsync(int id)
    {
      return await _context.Teacher.Where(c => c.Id == id)
      .ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider)
      .SingleOrDefaultAsync();
    }
    public async Task<List<TeacherViewModel>> GetTeacherByEmailAsync(string email)
    {
      return await _context.Teacher
        .Where(s => s.Email!.ToLower() == email.ToLower())
        .ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }
    public async Task<List<TeacherViewModel>> ListAllTeachersAsync()
    {
      return await _context.Teacher.ProjectTo<TeacherViewModel>(_mapper.ConfigurationProvider).ToListAsync();
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task UpdateTeacherAsync(int id, PostTeacherViewModel model)
    {
      var teacher = await _context.Teacher.FindAsync(id);

      if(teacher is null)
      {
        throw new Exception($"Couldn't find any teacher with id {id}.");
      }

        teacher.FirstName = model.FirstName;
        teacher.LastName = model.LastName;
        teacher.Email = model.Email;
        teacher.PhoneNumber = model.PhoneNumber;

        _context.Teacher.Update(teacher);
    }
    public async Task UpdateTeacherAsync(int id, PatchTeacherViewModel model)
    {
      var teacher = await _context.Teacher.FindAsync(id);

      if(teacher is null)
      {
        throw new Exception($"Couldn't find any teacher with id {id}.");
      }
  
        teacher.Email = model.Email;
        teacher.PhoneNumber = model.PhoneNumber;

        _context.Teacher.Update(teacher);
    }
  }
} 