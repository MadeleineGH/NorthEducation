namespace Education_Admins.ViewModels
{
  public class CourseViewModel
    {       
        public int CourseId { get; set; }
        public int CourseNumber { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public int? TeacherId { get; set; }
    }
}