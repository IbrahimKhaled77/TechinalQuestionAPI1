using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalQuestionAPI.DTO.Answers;
using TechnicalQuestionAPI.DTO.Assignment;
using TechnicalQuestionAPI.DTO.Question;
using TechnicalQuestionAPI.Interfaces;
using TechnicalQuestionAPI.Models;
using TechnicalQuestionAPI.Context;
using TechnicalQuestionAPI.Models;
using TechinalQuestionAPI.DTO.QuestionType;

namespace TechnicalQuestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase, IPartenerInterface
    {
        private readonly TechnicalQuestionDbContext _context;
        public PartnerController(TechnicalQuestionDbContext context)
        {
            _context = context;
        }
        #region HttpGetAll
        [HttpGet]
        [Route("GetAnswersInfo")]
        public async Task<List<GetAllAnswesDTO>> GetAnswersAsync()
        {
            var AAnswers = await _context.Answers.ToListAsync();
            var result = from A in AAnswers
                         select new GetAllAnswesDTO
                         {
                             AnswersId = A.AnswersId,
                             IsCorrect = A.IsCorrect,
                             Title = A.Title,
                             QuestionId = A.QuestionId
                         };
            return (result.ToList());


        }
        [HttpGet]
        [Route("GetQuestions")]
        public async Task<List<QuestionCardDTO>> GetQuestionsAsync()
        {
            //var questions = await _context.Questions.Include(x => x.QuestionType).ToListAsync();

            //var result = questions.Select(q => new QuestionCardDTO
            //{
            //    QuestionID = q.QuestionID,
            //    Title = q.Title,
            //    Description = q.Description,
            //    IsActive = q.IsActive,
            //    QuestionType = new QuestionType
            //    {
            //        QuestionTypeID = q.QuestionType.QuestionTypeID,
            //        Name= q.QuestionType.Name,
            //    }
            //}).ToList();
            var questions = await _context.Questions.ToListAsync();
            var result = questions.Select(q => new QuestionCardDTO
            {
                QuestionID = q.QuestionID,
                Title = q.Title,
                Description = q.Description,
                IsActive = q.IsActive
            }).ToList();
            return result;
        }
        [HttpGet]
        [Route("GetQuestionTypeInfo")]
        public async Task<List<QuestionTypeDTO>> GetQuestionTypeAsync()
        {
            var QuestionType = await _context.QuestionTypes.ToListAsync();
            var result = from q in QuestionType
                         select new QuestionTypeDTO
                         {
                             QuestionTypeID = q.QuestionTypeID,
                             Name = q.Name,
                         };
            return (result.ToList());
        }
        #endregion

        #region HttpGetById
        [HttpGet]
        [Route("GetAnswersByAnswerId/{AnswerId}")]
        public async Task<Answers> GetAnswersByIdAsync([FromRoute] int AnswerId)
        {

            var result = await _context.Answers.FindAsync(AnswerId);

            return result;
        }
        [HttpGet]
        [Route("GetQuestionTypeByQuestionTypeID/{QuestionTypeID}")]
        public async Task<QuestionTypeDTO> GetQuestionTypeByIdAsync([FromRoute] int QuestionTypeID)
        {

            var result = await _context.QuestionTypes.FindAsync(QuestionTypeID);
            QuestionTypeDTO questionTypeDTO = new QuestionTypeDTO();
            questionTypeDTO.QuestionTypeID = result.QuestionTypeID;
            questionTypeDTO.Name = result.Name;
            questionTypeDTO.IsActive = result.IsActive;
            return questionTypeDTO;
        }
        [HttpGet]
        [Route("GetQuestionById/{Id}")]
        public async Task<Question> GetQuestionByIdAsync([FromRoute] int Id)
        {
            var question = await _context.Questions
                    .Include(q => q.QuestionType)
                    .FirstOrDefaultAsync(q => q.QuestionID == Id);

            if (question == null)
            {
                return null;
            }
            var result = new Question
            {
                QuestionID = question.QuestionID,
                Title = question.Title,
                Description = question.Description,
                IsActive = question.IsActive,
                QuestionType = new QuestionType
                {
                    QuestionTypeID = question.QuestionType.QuestionTypeID,
                    Name = question.QuestionType.Name,
                }
            };
            return result;
        }
        #endregion

        #region HttpPostCreate
        [HttpPost]
        [Route("CreateAssignment")]
        public async Task CreateAssignment([FromBody] CreateAssignmentDTO dto)
        {
            Assignment A = new Assignment();
            A.Title = dto.Title;
            A.Date = dto.Date;
            A.Duration_Hours = dto.Duration_HOURS;
            A.Conditions = dto.conditions;
            A.Description = dto.Description;
            A.Requirements = dto.Requirements;
            A.DeadLine = dto.DeadLine;
            A.Level = dto.Level;
            A.IsActive = true;
            await _context.AddAsync(A);
            await _context.SaveChangesAsync();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task CreateAnswers([FromBody] AddAnswersDTO dto)
        {
            //Answers ANS = new Answers(dto.AnswersId,dto.IsCorrect,dto.Title,dto.QuestionId);
            // ANS.IsActive = true;

            Answers ANS = new Answers();

            ANS.IsCorrect = dto.IsCorrect;
            ANS.Title = dto.Title;
            ANS.QuestionId = dto.QuestionId;
            ANS.IsActive = true;



            await _context.AddAsync(ANS);
            await _context.SaveChangesAsync();

        }

        [HttpPost]
        [Route("[action]")]
        public async Task CreateQuestion([FromBody] QuestionCreateDTO dto)
        {
            Question question = new Question();
            question.Title = dto.Title;
            question.Description = dto.Description;
            question.Link = dto.Link;
            question.ImagePath = dto.ImagePath;
            if (dto.QuestionTypeId != null)
            {
                question.QuestionType = new QuestionType { QuestionTypeID = dto.QuestionTypeId };
            }
            question.IsActive = true;

            await _context.AddAsync(question);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region HttpPutUpdate
        [HttpPut]
        [Route("UpdateAssignment")]
        public async Task UpdateAssignment([FromBody]UpdateAssignmentDTO dto)
        {
            var result = await _context.Assignments.FindAsync(dto.AssignmentID);
            if (result != null)
            {
                result.Title = dto.Title;
                result.Date = dto.Date;
                result.Duration_Hours = dto.Duration_HOURS;
                result.Conditions = dto.conditions;
                result.Description = dto.Description;
                result.Requirements = dto.Requirements;
                result.DeadLine = dto.DeadLine;
                result.Level = dto.Level;
                result.IsActive = dto.IsActive;
                _context.Update(result);
                await _context.SaveChangesAsync();               
            }
         
        }
        [HttpPut]
        [Route("[action]")]
        public async Task UpdateAnswer(UpdateAnswersDTO dto)
        {
            var result = await _context.Answers.FindAsync(dto.AnswersId);
            if (result != null)
            {

                result.IsCorrect = dto.IsCorrect;
                result.Title = dto.Title;


                _context.Update(result);
                await _context.SaveChangesAsync();
            }


        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("DeleteAssignment/{Id}")]
        public async Task DeleteAssignment([FromRoute] int Id)
        {
            var result = await _context.Assignments.FindAsync(Id);
            if (result != null)
            {
                _context.Assignments.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteAnswer([FromRoute] int Id)
        {
            var result = await _context.Answers.FindAsync(Id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }

        }
        [HttpDelete]
        [Route("[action]/{Id}")]
        public async Task DeleteQuestion([FromRoute] int Id)
        {
            var result = await _context.Questions.FindAsync(Id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
