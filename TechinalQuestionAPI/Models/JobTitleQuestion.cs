namespace TechnicalQuestionAPI.Models
{
    public class JobTitleQuestion
    {
        public int JobTitleQuestionId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual Question Question { get; set; }
    }
}

