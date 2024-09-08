using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TechnicalQuestionAPI.Models
{
    public class EducationHistory
    {
        public int EducationHistoryId {get;set;}
        public string Title { get; set; }
        public string Specification { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public string NationalityId { get; set; }
        public bool IsActive { get; set; }
        public virtual User User { get; set; }

    }
}
