using Education_API.ViewModels;

namespace Education_API.Interfaces
{
  public interface IStudentRepository
    {
        public Task<List<StudentViewModel>> ListAllStudentsAsync();
        public Task<StudentViewModel?> GetStudentAsync(int id);
        public Task<List<StudentViewModel>> GetStudentByEmailAsync(string email);
        public Task AddStudentAsync(PostStudentViewModel model);
        public Task DeleteStudentAsync(int id);
        public Task UpdateStudentAsync(int id, PostStudentViewModel model);
        public Task UpdateStudentAsync(int id, PatchStudentViewModel model);
        public Task<bool> SaveAllAsync();
    }
}