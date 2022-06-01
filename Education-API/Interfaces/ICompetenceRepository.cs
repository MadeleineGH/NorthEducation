using Education_API.ViewModels;

namespace Education_API.Interfaces
{
  public interface ICompetenceRepository
    {
        public Task<List<CompetenceViewModel>> ListAllCompetencesAsync();
        public Task<List<CompetenceViewModel>> GetCompetenceByTitleAsync(string title);
        public Task<CompetenceViewModel?> GetCompetenceAsync(int id);
        public Task<CompetenceViewModel?> GetCompetenceAsync(string title);
        public Task AddCompetenceAsync(CompetenceViewModel model);
        public Task DeleteCompetenceAsync(int id);
        public Task UpdateCompetenceAsync(int id, CompetenceViewModel model);
        public Task<bool> SaveAllAsync();
    }
}