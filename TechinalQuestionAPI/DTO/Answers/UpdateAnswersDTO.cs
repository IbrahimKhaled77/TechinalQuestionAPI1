using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.DTO.Answers
{
    public class UpdateAnswersDTO
    {
        public int AnswersId { get; set; }
        public bool IsCorrect { get; set; }
        public string Title { get; set; }
        
        
        
    }
}
