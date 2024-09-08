namespace TechnicalQuestionAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Specification { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NationlityId { get; set; }
        public string UserType { get; set; }//**
        public string? Bio { get; set; }
        public string? PersonalPhotoPath { get; set; }
        public string? Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AccessKey { get; set; }
        public DateTime AccesskeyExpireDate { get; set; }
        public string Nationality { get; set; }
        public bool IsLoggedIn { get; set; }    
        public bool IsActive { get; set; }
        public virtual List<EducationHistory> EductionHistories { get; set; }//**
        public virtual List<Experience> Expierinces { get; set; }
        public virtual List<UserSkill> UserSkills { get; set; }    
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<UserAssignment> UserAssignments { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual Organization? Orginization { get; set; }  
        public bool? IsOrganizationManager { get; set; }   
        public virtual Subscription? Subsucription { get; set; }
    }
}
