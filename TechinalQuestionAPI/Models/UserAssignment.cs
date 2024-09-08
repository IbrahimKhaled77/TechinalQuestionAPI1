using TechnicalQuestionAPI.Models;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Models
{
    public class UserAssignment
    {
        public int UserAssignmentId { get; set; }
        public float ActualMark { get; set; }
        public DateTime SubmitTime { get; set; }
        public string Notes { get; set; }
        public virtual User User { get; set; }
        public virtual Assignment Assignment { get; set; }  
    }
}
