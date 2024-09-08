using TechnicalQuestionAPI.DTO.EducationHistorys;
using TechnicalQuestionAPI.DTO.Exam;
using TechnicalQuestionAPI.DTO.Experince;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Interfaces
{
    public interface IJobSeekerInterface
    {
        //DealsWithExam
        Task<List<ExamDTO>> GetExamAsync();
        Task<List<ExamDTO>> SearchExamAsync(string? title, int? mark);
        Task<Exam> GetExamByIdAsync(int Id);
        Task CreateNewExamAsync(ExamDTO dto);
        Task UpdateExam(ExamDTO dto);
        Task DeleteExam(int Id);
        //DealsWithAssignment
        //ManageUserEducations
        Task<List<EducationHistoryDTO>> SearchEducationHistoryAsync(string? Specification, string? Description);
        Task<EducationHistory> GetEducationHistoryByIdAsync(int Id);
        Task<List<EducationHistoryDTO>> GetEducationHistoryAsync();
        Task CreateEducationHistory(EducationHistoryCreateDTO dto);
        Task UpdateEducationHistory(EducationHistoryUpdateDTO dto);
        Task DeleteEducationHistory(int EductionHistoryId);
        //ManageUserExpriness
        Task CreateNewExperienceAsync(CreatNewExperinceDto dto);
        Task<List<ExperinceCardDTO>> GetAllExperienceAsync();
        Task<List<ExperinceCardDTO>> SearchExperienceAsync(string? title, string? companyname);
        Task<Experience> GetExperienceByIdAsync(int Id);
        Task UpdateExperienceAsync(UpdateExperinceDTO dto);
        Task DeleteExperienceAsync(int Id);
        //ManageUserSkilss

    }
}
