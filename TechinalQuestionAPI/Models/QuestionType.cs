using System.ComponentModel.DataAnnotations;

namespace TechnicalQuestionAPI.Models
{
    public class QuestionType
    {
        public int QuestionTypeID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Question> Questions { get; set;}

    }
}
