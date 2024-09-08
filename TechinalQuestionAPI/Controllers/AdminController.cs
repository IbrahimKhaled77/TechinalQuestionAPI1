using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalQuestionAPI.DTO.Assignment;
using TechnicalQuestionAPI.DTO.JobTitles;
using TechnicalQuestionAPI.Context;
using TechnicalQuestionAPI.DTO.Assignment;
using TechnicalQuestionAPI.DTO.JobTitles;
using TechnicalQuestionAPI.DTO.Skills;
using TechnicalQuestionAPI.Interfaces;
using TechnicalQuestionAPI.Models;
using TechinalQuestionAPI.DTO.QuestionType;
using TechnicalQuestionAPI.DTO.Question;
using TechnicalQuestionAPI.Helper;
using TechinalQuestionAPI.DTO.Question;
using Serilog;
using TechinalQuestionAPI.DTO.ServerOutPut;
using Azure;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace TechnicalQuestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdminInterface
    {
        private readonly TechnicalQuestionDbContext _context;
        public AdminController(TechnicalQuestionDbContext context)
        {
            _context = context;
        }

        #region QuestionType
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/CreateQuestionType
        ///     {        
        ///       "Name": "Enter Your new Question Type Here",   
        ///     }
        /// </remarks>
        /// <returns>A newly created QuestionType</returns>
        /// <response code="201">Returns the newly created QuestionType</response>
        /// <response code="400">If the error was occured</response>       
        [HttpPost]
        [Route("CreateQuestionType")]
        public async Task CreateQuestionType([FromBody] QuestionTypeDTO dto)
        {
            QuestionType QA = new QuestionType();
            QA.Name = dto.Name;
            QA.IsActive = true;
            await _context.AddAsync(QA);
            await _context.SaveChangesAsync();
        }
        [HttpPut]
        [Route("UpdateQuestionType")]
        public async Task UpdateQuestionType(QuestionTypeDTO dto)
        {
            var result = await _context.QuestionTypes.FindAsync(dto.QuestionTypeID);
            result.Name = dto.Name;
            result.IsActive = dto.IsActive;
            _context.Update(result);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        [Route("DeleteQuestionType")]
        public async Task DeleteQuestionType(int Id)
        {
            var result = _context.QuestionTypes.FindAsync(Id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region JobTitle

        [HttpPost]
        [Route("[action]")]
        public async Task CreateJobTitle([FromBody] JobTitleCreateDTO dto)
        {
            JobTitle job = new JobTitle();
            job.Name = dto.Name;
            job.Description = dto.Description;
            job.Requirements = dto.Requirements;
            job.MinSalary = dto.MinSalary;
            job.MaxSalary = dto.MaxSalary;
            job.Level = dto.Level;
            job.ExpirencesTime = dto.Expirences_Time;
            job.Tasks = dto.Tasks;
            job.Conditions = dto.Conditions;
            job.IsActive = true;
            await _context.AddAsync(job);
            await _context.SaveChangesAsync();
        }


        [HttpPut]
        [Route("[action]")]
        public async Task UpdateJobTitle(JobTitleUpdateDTO dto)
        {
            //check if the element exist
            var result = await _context.JobTitles.FindAsync(dto.Id);
            if (result != null)
            {
                //replacement 
                result.Name = dto.Name;
                result.Description = dto.Description;
                result.Requirements = dto.Requirements;
                result.Level = dto.Level;
                result.ExpirencesTime = dto.Expirences_Time;
                result.Tasks = dto.Tasks;
                result.Conditions = dto.Conditions;
                result.MinSalary = dto.MinSalary;
                result.MaxSalary = dto.MaxSalary;
                //update
                _context.Update(result);
                //save changes 
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteJobTitle([FromRoute] int Id)
        {
            //check if the element exist
            var result = await _context.JobTitles.FindAsync(Id);
            if (result != null)
            {
                //delete element 
                _context.Remove(result);
                //save changes
                await _context.SaveChangesAsync();
            }
        }
        [HttpGet]
        [Route("GetAllAssignments")]
        public async Task<IActionResult> GetAllAssignments([FromHeader]string accessKey)
        {
            if (string.IsNullOrEmpty(accessKey))
                return BadRequest("Please Provide Your Access Key");
            if(await _context.Users.AnyAsync(x=>x.AccessKey==accessKey &&
            x.AccesskeyExpireDate > DateTime.Now
            && x.UserType=="Admin"))
            {
                var result = await _context.Assignments.ToListAsync();
                return Ok(result);
            }
            else
            {
                return Unauthorized("Please Provide Your Access Key");

            }
        }

        [HttpGet]
        [Route("SearchAssignments")]
        public async Task<List<AssignmentCardDTO>> SearchAssignments(string? title, string? description, string? requirements)
        {
            var Assign = await _context.Assignments.ToListAsync();
            if (title != null) Assign = _context.Assignments.Where(x => x.Title.Contains(title)).ToList();
            if (description != null) Assign = _context.Assignments.Where(x => x.Description.Contains(description)).ToList();
            if (requirements != null) Assign = _context.Assignments.Where(x => x.Requirements.Contains(requirements)).ToList();
            var result = from a in Assign
                         select new AssignmentCardDTO
                         {
                             Id = a.AssignmentId,
                             Title = a.Title,
                             Date = a.Date,
                             Duration_Hours = a.Duration_Hours,
                             conditions = a.Conditions,
                             Description = a.Description,
                             Requirements = a.Requirements,
                             DeadLine = a.DeadLine,
                             Level = a.Level,
                             IsActive = a.IsActive,
                         };
            return result.ToList();
        }
        [HttpGet]
        [Route("GetAssignmentsById/{Id}")]
        public async Task<Assignment> GetAssignmentById([FromRoute] int Id)
        {
            var result = await _context.Assignments.FindAsync(Id);
            return result;
        }
        #endregion

        #region SKills


        [HttpGet]
        [Route("GetSkillsById/{Id}")]
        public async Task<Skill> GetSkillsByIdAsync([FromRoute] int Id)
        {
            var result = await _context.Skills.FindAsync(Id);
            return result;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SearchSkillsAsync([FromHeader]string tokenString, string? name)
        {
            String token = "Bearer " + tokenString;
            var jwtEncodedString = token.Substring(7);
            var toke = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            if (toke.ValidTo > DateTime.UtcNow)
            {
                //valid

            }
            int roleId = Int32.Parse((toke.Claims.First(c => c.Type == "UserId").Value.ToString()));
            //return roleId;
        var Skills = await _context.Skills.ToListAsync();
            if (name != null)
                Skills = await _context.Skills.Where(x => x.Title.Contains(name)).ToListAsync();

            var result = from Skill in Skills

                         select new SkillsCardDTO
                         {
                             SkillsId = Skill.SkillsId,
                             Rate = Skill.Rate,
                             Description = Skill.Description,
                             Title = Skill.Title,

                         };
            return (result.ToList());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task CreateSkills([FromBody] SkillsDTOCreate dto)
        {
            Skill Skill = new Skill();
            Skill.Title = dto.Title;
            Skill.Description = dto.Description;
            Skill.Rate = dto.Rate;
            Skill.IsActive = true;
            await _context.AddAsync(Skill);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task UpdateSkills(UpdateSkillsDTO dto)
        {
            //check if the element exist
            var result = await _context.Skills.FindAsync(dto.SkillsId);
            if (result != null)
            {
                //replacement 
                result.Title = dto.Title;
                result.Description = dto.Description;
                //result.Rate = dto.Rate;

                //update
                _context.Update(result);
                //save changes 
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteSkills([FromRoute] int Id)
        {
            //check if the element exist
            var result = await _context.Skills.FindAsync(Id);
            if (result != null)
            {
                //delete element 
                _context.Remove(result);
                //save changes
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Partner
        [HttpGet]
        [Route("GetQuestionsByPartnerId/{partnerId}")]
        public async Task<IActionResult> GetQuestionsByPartnerId(int partnerId,[FromHeader]string email, [FromHeader] string pass)
        {
            if(await _context.Users.AnyAsync(x=>x.Email== email && x.Password == pass && x.UserType=="Admin"))
            {
                if(await _context.Users.AnyAsync(x=> x.Email == email && x.Password == pass && x.UserType == "Admin" && x.IsLoggedIn==true))
                {
                    ResponesDTO<QuestionCardDTO> respones = new ResponesDTO<QuestionCardDTO>();
                    if (await _context.Users.AnyAsync(x => x.UserId == partnerId))
                    {
                        Log.Information("Partner Is Exisigt");
                        var result = await _context.Questions
                            .Include(q => q.QuestionType)
                            .Include(q => q.Partner)
                            .Where(x => x.Partner.UserId == partnerId)
                            .ToListAsync();
                        Log.Information($"Db Query has been Finised with {result.Count} items");
                        Log.Debug($"Debugging GetQuestionsByPartnerId Has been Finised Successfully With Partner Id = {partnerId}");
                        respones.Message = "GetQuestionsByPartnerId Has been Finised Successfully";
                        respones.Code = 200;
                        respones.Items = MappingHelper.QuestionsMapper(result);

                    }
                    else
                    {
                        respones.Code = 204;
                        respones.Message = "Partner Not Found";
                        return NoContent();
                    }
                    //return Ok(new { respones });

                    return Ok(new { StatusMassage = respones.Message, StatusCode = respones.Code, Response = respones.Items });
                }
                else
                {
                    return Unauthorized(new { Response = "You Must Login In To Your Account" });
                }
               
            }
            else
            {
                string msg = "You Don't have the required Permission";
                return Unauthorized(new {Response= msg });
            }

        }
        /// <summary>
        /// Gets the list of all answers and some details about question.
        /// </summary>
        [HttpGet]
        [Route("GetQuestionDetailsById/{Id}")]
        public async Task<QuestionDetailsDTO> GetQuestionDetailsById(int Id)
        {
            //check if question exisit
            if (await _context.Questions.AnyAsync(x => x.QuestionID == Id))
            {
                var result = await _context.Questions.Where(x => x.QuestionID == Id)
                    .Include(x => x.Answers)
                    .Include(x => x.QuestionType)
                    .FirstOrDefaultAsync();
                if (result != null)
                {
                    QuestionDetailsDTO detailsDTO = new QuestionDetailsDTO();
                    detailsDTO.QuestionID = Id;
                    detailsDTO.Answers = MappingHelper.AnswerMapper(result.Answers.ToList());
                    detailsDTO.QuestionType = result.QuestionType.Name;
                    detailsDTO.Title = result.Title;
                    detailsDTO.Description = result.Description;
                    detailsDTO.ImagePath = result.ImagePath;
                    detailsDTO.Link = result.Link;
                    return detailsDTO;
                }
                throw new Exception("Something Went Wrong");
            }
            else
            {
                throw new Exception("Question Not Found");
            }
        }

        #endregion
    }
}

