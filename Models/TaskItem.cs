using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TaskPlanner.Data.Base;

namespace TaskPlanner.Models
{
    public class TaskItem : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Unit Code")]
        [Required(ErrorMessage = "Unit code required")]
        public string UnitCode { get; set; }

        [Display(Name = "Task Description")]
        [Required(ErrorMessage = "Task description required")]
        public string TaskName { get; set; }

        [Display(Name = "Task Comments")]
        public string TaskComments { get; set; }

        [Display(Name = "Task Due Date")]
        [Required(ErrorMessage = "Date required")]
        public DateTime TaskDueDate { get; set; }

        [Display(Name = "Task Completed?")]
        public bool IsComplete { get; set; }

        [Display(Name = "Date Completed")]
        public DateTime? CompletedDate { get; set; }
    }
}
