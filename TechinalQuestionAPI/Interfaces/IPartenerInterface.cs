using Microsoft.AspNetCore.Mvc;
using TechinalQuestionAPI.DTO.QuestionType;
using TechnicalQuestionAPI.DTO.Answers;
using TechnicalQuestionAPI.DTO.Assignment;
using TechnicalQuestionAPI.DTO.Question;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Interfaces
{
    public interface IPartenerInterface
    {
        //ManageQuestions
        Task<List<QuestionCardDTO>> GetQuestionsAsync();
        Task CreateQuestion(QuestionCreateDTO dto);
        Task<Question> GetQuestionByIdAsync(int Id);
        Task DeleteQuestion(int Id);
        //ManageAssignment
        Task CreateAssignment(CreateAssignmentDTO dto);
        Task UpdateAssignment(UpdateAssignmentDTO dto);
        Task DeleteAssignment(int Id);
        //ManageAnswers
        Task<List<GetAllAnswesDTO>> GetAnswersAsync();
        Task<Answers> GetAnswersByIdAsync(int Id);
        Task CreateAnswers(AddAnswersDTO dto);
        Task UpdateAnswer(UpdateAnswersDTO dto);
        Task DeleteAnswer(int Id);
        //Get Question Type
        Task<List<QuestionTypeDTO>> GetQuestionTypeAsync();
        Task<QuestionTypeDTO> GetQuestionTypeByIdAsync(int QuestionTypeID);
        //Evaluation
    }
}
