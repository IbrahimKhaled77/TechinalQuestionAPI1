using System.ComponentModel.DataAnnotations;

namespace TechnicalQuestionAPI.Models
{
    public class Experience
    {
        public int ExperinceId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public string NationalityId { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }
    }
}
