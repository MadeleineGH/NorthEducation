using Education_API.ViewModels;
using Education_API.ViewModels.Competence;

namespace Education_API.Interfaces
{
  public interface ICompetenceRepository
    {
        public Task<List<CompetenceViewModel>> ListAllCompetencesAsync();
        public Task<List<CompetenceViewModel>> GetCompetenceByTitleAsync(string title);
        public Task<CompetenceViewModel?> GetCompetenceAsync(int id);
        public Task<CompetenceViewModel?> GetCompetenceAsync(string title);
        public Task AddCompetenceAsync(PostCompetenceViewModel model);
        public Task DeleteCompetenceAsync(int id);
        public Task UpdateCompetenceAsync(int id, PutCompetenceViewModel model);
        public Task<bool> SaveAllAsync();
    }
}