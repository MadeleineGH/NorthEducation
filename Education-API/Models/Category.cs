using System.ComponentModel.DataAnnotations;

namespace Education_API.Models
{
  public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}