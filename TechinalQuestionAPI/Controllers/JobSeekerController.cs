using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalQuestionAPI.Context;
using TechnicalQuestionAPI.DTO.EducationHistorys;
using TechnicalQuestionAPI.DTO.Exam;
using TechnicalQuestionAPI.DTO.Experince;
using TechnicalQuestionAPI.Interfaces;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase,IJobSeekerInterface
    {
        private readonly TechnicalQuestionDbContext _context;
        public JobSeekerController(TechnicalQuestionDbContext context)
        {
            _context = context;
        }
        #region Exam_Region
        
        [HttpGet]
        [Route("GetExam")]
        public async Task<List<ExamDTO>> GetExamAsync()
        {
            var Exam = await _context.Exams.ToListAsync();
            var result = from e in Exam
                         select new ExamDTO
                         {
                             Title = e.Title,
                             Mark = e.Mark,
                             ExamId = e.ExamId,
                             Level = e.level,
                             QuestionCount = e.QuestionCount,
                             Duration = e.Duration,
                             ActualMark = e.ActualMark,
                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("SearchExam")]
        public async Task<List<ExamDTO>> SearchExamAsync(string? title, int? mark)
        {
            var Exam = await _context.Exams.ToListAsync();
            if (title != null)
                Exam = Exam.Where(x => x.Title.Contains(title)).ToList();
            if (mark != null)
                Exam = Exam.Where(x => x.Mark >= mark).ToList();
            var result = from e in Exam
                         select new ExamDTO
                         {
                             Title = e.Title,
                             Mark = e.Mark,
                             ExamId = e.ExamId,
                             Level = e.level,
                             QuestionCount = e.QuestionCount,
                             Duration = e.Duration,
                             ActualMark = e.ActualMark,
                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("GetExamById/{Id}")]
        public async Task<Exam> GetExamByIdAsync([FromRoute] int Id)
        {
            var result = await _context.Exams.FindAsync(Id);
            return result;
        }
        [HttpPost]
        [Route("CreateNewExam")]
        public async Task CreateNewExamAsync([FromBody] ExamDTO dto)
        {
            Exam ex = new Exam();
            ex.Title = dto.Title;
            ex.Mark = dto.Mark;
            ex.level = dto.Level;
            ex.QuestionCount = dto.QuestionCount;
            ex.Duration = dto.Duration;
            ex.ActualMark = dto.ActualMark;
            ex.NationalityId = "";
            ex.User = await _context.Users.FindAsync(dto.UserId);
            await _context.AddAsync(ex);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        [Route("[action]")]
        public async Task UpdateExam(ExamDTO dto)
        {
            //check if the element exist
            var result = await _context.Exams.FindAsync(dto.ExamId);
            if (result != null)
            {
                //replacement 
                result.ExamId = dto.ExamId;
                result.Title = dto.Title;
                result.Mark = dto.Mark;
                result.level = dto.Level;
                result.QuestionCount = dto.QuestionCount;
                result.Duration = dto.Duration;
                result.ActualMark = dto.ActualMark;
                //update
                _context.Update(result);
                //save changes 
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteExam([FromRoute] int Id)
        {
            //check if the element exist
            var result = await _context.Exams.FindAsync(Id);
            if (result != null)
            {
                //delete element 
                _context.Remove(result);
                //save changes
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Experince

        [HttpGet]
        [Route("GetAllExperience")]
        public async Task<List<ExperinceCardDTO>> GetAllExperienceAsync()
        {
            var Experience = await _context.Experiences.ToListAsync();
            var result = from E in Experience
                         select new ExperinceCardDTO
                         {
                             Id = E.ExperinceId,
                             CompanyName = E.CompanyName,
                             Title = E.Title,
                             StartDate = E.StartDate,
                             EndDate = E.EndDate
                         };
            return (result.ToList());
        }

        [HttpGet]
        [Route("SearchExperience")]
        public async Task<List<ExperinceCardDTO>> SearchExperienceAsync(string? title, string? companyName)
        {
            var Experience = await _context.Experiences.ToListAsync();
            if (title != null)
                Experience = Experience.Where(x => x.Title.Contains(title)).ToList();
            if (companyName != null)
                Experience = Experience.Where(x => x.CompanyName.Contains(companyName)).ToList();
            var result = from E in Experience
                         select new ExperinceCardDTO
                         {
                             Id = E.ExperinceId,
                             UserId = E.UserId,
                             StartDate = E.StartDate,
                             EndDate = E.EndDate,
                             CompanyName = E.CompanyName,
                             Title = E.Title

                         };
            return (result.ToList());
        }
        [HttpGet]
        [Route("GetExperienceById/{Id}")]

        public async Task<Experience> GetExperienceByIdAsync([FromRoute] int Id)
        {
            var result = await _context.Experiences.FindAsync(Id);
            return result;
        }
        [HttpPost]
        [Route("CreateNewExperince")]
        public async Task CreateNewExperienceAsync([FromBody] CreatNewExperinceDto dto)
        {
            Experience Experience = new Experience();
            Experience.UserId = dto.UserId;
            Experience.CompanyName = dto.CompanyName;
            Experience.Description = dto.Description;
            Experience.Title = dto.Title;
            Experience.StartDate = dto.StartDate;
            Experience.EndDate = dto.EndDate;
            Experience.NationalityId = "";
            Experience.IsActive = true;
            await _context.AddAsync(Experience);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        [Route("UpdateExperience")]

        public async Task UpdateExperienceAsync(UpdateExperinceDTO dto)
        {
            var result = await _context.Experiences.FindAsync(dto.Id);
            if (result != null)
            {

                result.CompanyName = dto.CompanyName;
                result.Title = dto.Title;
                result.UserId = dto.UserId;
                result.StartDate = dto.StartDate;
                result.EndDate = dto.EndDate;
                result.Description = dto.Description;
                result.NationalityId = dto.NationalityId;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("DeleteExperience/{Id}")]

        public async Task DeleteExperienceAsync([FromRoute] int Id)
        {
            var result = await _context.Experiences.FindAsync(Id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }

        }
        #endregion

        #region EducationHistory
        [HttpGet]
        [Route("[action]")]
        public async Task<List<EducationHistoryDTO>> SearchEducationHistoryAsync(string? specification, string? description)
        {
            var educationHistories = await _context.EducationsHistories.ToListAsync();
            if (specification != null)
                educationHistories = educationHistories.Where(x => x.Specification.Contains(specification)).ToList();
            if (description != null)
                educationHistories = educationHistories.Where(x => x.Description.Contains(description)).ToList();
            var result = from eh in educationHistories
                         select new EducationHistoryDTO
                         {
                             EductionHistoryId = eh.EducationHistoryId,
                             Description = eh.Description,
                             Specification = eh.Specification,
                         };
            return (result.ToList());
        }

        [HttpGet]
        [Route("GetEducationHistoryById/{Id}")]
        public async Task<EducationHistory> GetEducationHistoryByIdAsync([FromRoute] int Id)
        {
            var result = await _context.EducationsHistories.FindAsync(Id);
            return result;
        }

        [HttpGet]
        [Route("GetJobTitles")]
        public async Task<List<EducationHistoryDTO>> GetEducationHistoryAsync()
        {
            var educations = await _context.EducationsHistories.ToListAsync();
            var result = from eh in educations
                         select new EducationHistoryDTO
                         {
                             EductionHistoryId = eh.EducationHistoryId,
                             Description = eh.Description,
                             Specification = eh.Specification,
                         };
            return (result.ToList());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task CreateEducationHistory([FromBody] EducationHistoryCreateDTO dto)
        {
            EducationHistory education = new EducationHistory();
            education.Description = dto.Description;
            education.Title = dto.Title;
            education.StartDate = dto.Start_Date;
            education.EndDate = dto.End_Date;
            education.Specification = dto.Specification;
            education.NationalityId = "";
            education.User = await _context.Users.FindAsync(int.Parse(dto.UserId));
            education.IsActive = true;
            await _context.AddAsync(education);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task UpdateEducationHistory(EducationHistoryUpdateDTO dto)
        {
            var result = await _context.EducationsHistories.FindAsync(dto.EductionHistoryId);
            if (result != null)
            {
                result.Title = dto.Title;
                result.Description = dto.Description;
                result.StartDate = dto.Start_Date;
                result.EndDate = dto.End_Date;
                result.Specification = dto.Specification;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
        }

        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteEducationHistory([FromRoute] int EducationHistoryId)
        {
            var result = await _context.EducationsHistories.FindAsync(EducationHistoryId);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
