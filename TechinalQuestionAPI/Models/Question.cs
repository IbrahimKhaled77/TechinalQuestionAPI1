using System.ComponentModel.DataAnnotations;

namespace TechnicalQuestionAPI.Models
{
    public class Question
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int QuestionID { get; set; }    
        public bool IsActive { get; set; }
        public virtual User Partner { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual ICollection<Answers> Answers { get; set; }   
        public virtual List<JobTitleQuestion> TitleQuestions { get; set; }
    }
}
