using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TaskPlanner.Data.Base;

namespace TaskPlanner.Models
{
    public class TaskItem : IEntityBase
    {
        private string? _unitCode;
        [Key]
        public int Id { get; set; }

        [Display(Name = "Unit Code")]
        [Required(ErrorMessage = "Invalid unit code.")]
        public string UnitCode
        {
            get { return _unitCode; }
            set { _unitCode = value.ToUpper(); } //always force unit code to uppercase
        }

        [Display(Name = "Task Name")]
        [Required(ErrorMessage = "Task name required")]
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
