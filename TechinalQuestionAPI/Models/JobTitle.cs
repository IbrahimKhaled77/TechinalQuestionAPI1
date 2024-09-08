using System.ComponentModel.DataAnnotations;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Models
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }   
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set;}   
        public int ExpirencesTime { get; set; }
        public string Tasks { get; set; }
        public string Conditions { get; set; }
        public int Level { get; set; }
        public bool IsActive { get; set; }
        public virtual List<JobTitleQuestion> TitleQuestions { get; set; }
    }
}
