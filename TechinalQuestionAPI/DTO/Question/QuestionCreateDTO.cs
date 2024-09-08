using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.DTO.Question
{
    public class QuestionCreateDTO
    {

        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Link { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int QuestionTypeId { get; set; }
    }
}
