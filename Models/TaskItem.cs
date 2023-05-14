using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaskPlanner.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
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
    }
}
