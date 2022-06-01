using AutoMapper;
using AutoMapper.QueryableExtensions;
using Education_API.Data;
using Education_API.Interfaces;
using Education_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Education_API.Repositories
{
  public class CompetenceRepository : ICompetenceRepository
  {
    private readonly EducationContext _context;
    private readonly IMapper _mapper;
    public CompetenceRepository(EducationContext context, IMapper mapper)
    {
      _mapper = mapper;
      _context = context;
    }

    public async Task AddCompetenceAsync(CompetenceViewModel model)
    {
        var competenceToAdd = await _context.Competence.FindAsync();

        await _context.Competence.AddAsync(competenceToAdd);
    }

    public async Task DeleteCompetenceAsync(int id)
    {
      var response = await _context.Competence.FindAsync(id);

      if(response is not null)
      {
        _context.Competence.Remove(response);
      }
    }

    public async Task<List<CompetenceViewModel>> GetCompetenceByTitleAsync(string title)
    {
      return await _context.Competence
        .Where(c => c.Title!.ToLower() == title.ToLower())
        .ProjectTo<CompetenceViewModel>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<List<CompetenceViewModel>> ListAllCompetencesAsync()
    {
      return await _context.Competence.ProjectTo<CompetenceViewModel>
      (_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<CompetenceViewModel?> GetCompetenceAsync(int id)
    {
      return await _context.Competence.Where(c => c.Id == id)
          .ProjectTo<CompetenceViewModel>(_mapper.ConfigurationProvider)
          .SingleOrDefaultAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public async Task UpdateCompetenceAsync(int id, CompetenceViewModel model)
    {
      var competence = await _context.Competence.FindAsync(id);

      if(competence is null)
      {
        throw new Exception($"Couldn't find any competence with id {id}.");
      }
  
        competence.Title = model.Title;

        _context.Competence.Update(competence);
    }

    public async Task<CompetenceViewModel?> GetCompetenceAsync(string title)
    {
      return await _context.Competence.Where(c => c.Title!.ToLower() == title.ToLower())
        .ProjectTo<CompetenceViewModel>(_mapper.ConfigurationProvider)
          .SingleOrDefaultAsync();
    }
  }
}