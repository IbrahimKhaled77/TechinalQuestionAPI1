using TechnicalQuestionAPI.DTO.Answers;
using TechnicalQuestionAPI.Models;

namespace TechinalQuestionAPI.DTO.Question
{
    public class QuestionDetailsDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuestionID { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public string QuestionType { get; set; }
        public  List<GetAllAnswesDTO> Answers { get; set; }
    }
}
