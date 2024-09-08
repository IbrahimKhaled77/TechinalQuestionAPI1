using System.ComponentModel.DataAnnotations;

namespace TechnicalQuestionAPI.Models
{
    public class Exam
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Mark { get; set; }
        public int QuestionCount { get; set; }
        public int Duration { get; set; }
        public bool? IsPassed { get; set; }
        public string? level { get; set; }
        [Key]
        public int ExamId { get; set; }
        public string NationalityId { get; set; }
        public float? ActualMark { get; set; }
        public DateTime? SubmitTime { get; set; }
        public string? Note { get; set; }
        public virtual User User { get; set; }






    }
}
