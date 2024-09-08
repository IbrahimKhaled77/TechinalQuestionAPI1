namespace TechnicalQuestionAPI.DTO.Answers
{
    public class AddAnswersDTO
    {

        
        public bool IsCorrect { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }

        //public bool IsActive { get; set; }
    }
}
