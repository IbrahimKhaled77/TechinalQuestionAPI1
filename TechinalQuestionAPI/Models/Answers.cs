namespace TechnicalQuestionAPI.Models
{
    public class Answers
    {
        public int AnswersId { get; set; }
        public bool IsCorrect { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public bool IsActive { get; set; }
        public virtual Question Question { get; set; }

    }



}
