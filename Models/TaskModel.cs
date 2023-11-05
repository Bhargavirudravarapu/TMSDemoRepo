using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestApp1.Models
{
    public class TaskModel {
    [Key]
    public int TaskId { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime DueDate { get; set; }
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }
}
}
