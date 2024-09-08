namespace TechnicalQuestionAPI.DTO.Answers
{
    public class GetAllAnswesDTO
    {
        public int AnswersId { get; set; }
        public bool IsCorrect { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
    }
}
