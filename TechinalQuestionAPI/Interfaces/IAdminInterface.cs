using Microsoft.AspNetCore.Mvc;
using TechinalQuestionAPI.DTO.Question;
using TechinalQuestionAPI.DTO.QuestionType;
using TechinalQuestionAPI.DTO.ServerOutPut;
using TechnicalQuestionAPI.DTO.Assignment;
using TechnicalQuestionAPI.DTO.JobTitles;
using TechnicalQuestionAPI.DTO.Question;
using TechnicalQuestionAPI.DTO.Skills;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Interfaces
{
    public interface IAdminInterface
    {
        //Manage Question Types 
        Task CreateQuestionType(QuestionTypeDTO dto);
        Task UpdateQuestionType(QuestionTypeDTO dto);
        Task DeleteQuestionType(int Id);
        //Manage JobTitles
        Task CreateJobTitle(JobTitleCreateDTO dto);
        Task UpdateJobTitle(JobTitleUpdateDTO dto);
        Task DeleteJobTitle(int Id);
        //Manage Skills
        Task<Skill> GetSkillsByIdAsync(int Id);
        Task<IActionResult> SearchSkillsAsync(string tokenString,string? name);
        Task CreateSkills(SkillsDTOCreate dto);
        Task UpdateSkills(UpdateSkillsDTO dto);
        Task DeleteSkills(int Id);
        
        //GetAllAssignments
        Task <IActionResult> GetAllAssignments(string accessKey);
        Task<List<AssignmentCardDTO>> SearchAssignments(string? title, string? description, string? requirements);
        Task<Assignment> GetAssignmentById(int Id);
        //GetAllQuestion --partener
        Task<IActionResult> GetQuestionsByPartnerId(int partnerId,string email, string pass);
        Task<QuestionDetailsDTO> GetQuestionDetailsById(int Id);    
        //GetAllExams -- jobsekker
    }
}
