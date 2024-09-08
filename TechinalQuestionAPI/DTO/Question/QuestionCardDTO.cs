using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.DTO.Question
{
    public class QuestionCardDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionID { get; set; }
        public bool IsActive { get; set; }
        public string QuestionType { get; set; }
    }
}
