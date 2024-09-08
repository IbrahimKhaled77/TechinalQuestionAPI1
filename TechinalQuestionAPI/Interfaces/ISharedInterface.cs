using Microsoft.AspNetCore.Mvc;
using TechnicalQuestionAPI.DTO.Authantication;
using TechnicalQuestionAPI.DTO.JobTitles;
using TechnicalQuestionAPI.DTO.Skills;
using TechnicalQuestionAPI.DTO.Users;
using TechnicalQuestionAPI.DTO2.UsersTwo;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Interfaces
{
    public interface ISharedInterface
    {
        //Search JobTitle
        Task<List<JobTitleCardDTO>> SearchJobTitleAsync(string? name,string? requirement,int? level);
        //Get Job Title By Id
        Task<JobTitle> GetJobTitleByIdAsync(int Id);
        //Get Skills
        Task<List<SkillsCardDTO>> GetAllSkillsAsync();
        //GetUsers
        Task<List<UserCardDTO>> GetAllUsersByTypeAsync(string userType);
        Task<List<UserCardDTO>> SearchUsersAsync(string? name,string? userType,string? jobTitle
            ,string? nationalityId,string? phone);
        Task<User> GetUserByIdAsync(int Id);
        //Registaration
        Task Register(RegisterDTO dto);
        //Login
        Task<IActionResult> Login(LoginDTO dto);
        //Logout
        Task Logout(int UserId);
        //ResetPassword
        Task ResetPassword(ResetPasswordDTO dTO);
        //UserProfile
        Task <UserProfileDTO> GetUserProfileById(int Id);
    }
}
