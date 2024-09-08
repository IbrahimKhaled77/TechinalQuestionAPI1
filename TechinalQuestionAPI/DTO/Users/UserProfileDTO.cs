using TechnicalQuestionAPI.DTO.EducationHistorys;
using TechnicalQuestionAPI.DTO.Exam;
using TechnicalQuestionAPI.DTO.Experince;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.DTO.Users
{
    public class UserProfileDTO
    {
        public int    UserId             { get; set; }
        public string FullName           { get; set; }
        public int    Age                { get; set; }
        public string Specification       { get; set; }
        public string Email                  { get; set; }
        public string NationlityId           { get; set; }
        public string UserType                { get; set; }
        public string? Bio                    { get; set; }
        public string? PersonalPhotoPath { get; set; }
        public string? Address             { get; set; }
        public string PhoneNumber          { get; set; }
        public string Nationality          { get; set; }
        public List<EducationHistoryDTO> EducationHistories { get; set; }
        public List<ExperinceCardDTO> Experinces { get; set; }
        public List<ExamDTO> Exams { get; set; }
        public string SubsucriptionName { get; set; }
    }
}
