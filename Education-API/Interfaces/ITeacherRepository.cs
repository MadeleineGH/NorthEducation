using Education_API.ViewModels;

namespace Education_API.Interfaces
{
  public interface ITeacherRepository
    {
        public Task<List<TeacherViewModel>> ListAllTeachersAsync();
        public Task<TeacherViewModel?> GetTeacherAsync(int id);
        public Task<List<TeacherViewModel>> GetTeacherByEmailAsync(string email);
        public Task AddTeacherAsync(PostTeacherViewModel model);
        public Task DeleteTeacherAsync(int id);
        public Task UpdateTeacherAsync(int id, PostTeacherViewModel model);
        public Task UpdateTeacherAsync(int id, PatchTeacherViewModel model);
        public Task<bool> SaveAllAsync();
    }
}