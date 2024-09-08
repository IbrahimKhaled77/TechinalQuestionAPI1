using TechnicalQuestionAPI.DTO.Answers;
using TechnicalQuestionAPI.DTO.Assignment;
using TechnicalQuestionAPI.DTO.EducationHistorys;
using TechnicalQuestionAPI.DTO.Exam;
using TechnicalQuestionAPI.DTO.Experince;
using TechnicalQuestionAPI.DTO.Question;
using TechnicalQuestionAPI.DTO.Skills;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Helper
{
    public static class MappingHelper
    {
        public static List<ExamDTO> ExamDtoMapper(List<Exam> exams)
        {
            List<ExamDTO> examDTOs = new List<ExamDTO>();
            foreach (Exam exam in exams)
            {
                ExamDTO dTO = new ExamDTO();
                dTO.Title = exam.Title;
                dTO.Mark = exam.Mark;
                dTO.QuestionCount = exam.QuestionCount;
                dTO.Duration = exam.Duration;
                dTO.Level = exam.level;
                dTO.ActualMark = exam.ActualMark;
                dTO.ExamId = exam.ExamId;
                examDTOs.Add(dTO);
            }
            return examDTOs;
        }
        public static List<ExperinceCardDTO> ExperienceDTOMapper(List<Experience> experiences)
        {
            List<ExperinceCardDTO> ExperiencesDTOs = new List<ExperinceCardDTO>();
            foreach (var item in ExperiencesDTOs)
            {
                ExperinceCardDTO DTO = new ExperinceCardDTO();
                DTO.Title = item.Title;
                DTO.StartDate = item.StartDate;
                DTO.EndDate = item.EndDate;
                DTO.CompanyName = item.CompanyName;
                ExperiencesDTOs.Add(DTO);
            }
            return ExperiencesDTOs;

        }
        public static List<EducationHistoryDTO> EducationHistoryMapper(List<EducationHistory> educations)
        {
            List<EducationHistoryDTO> educationHistoryDTOs = new List<EducationHistoryDTO>();
            foreach (EducationHistory edu in educations)
            {
                EducationHistoryDTO dto = new EducationHistoryDTO();
                dto.Specification = edu.Specification;
                dto.Description = edu.Description;
                dto.StartTime = (DateTime)edu.StartDate;
                dto.EndTime = (DateTime)edu.EndDate;
                educationHistoryDTOs.Add(dto);
            }
            return educationHistoryDTOs;
        }
        public static List<AssignmentCardDTO> AssignmentMapper(List<Assignment> assignments)
        {
            List<AssignmentCardDTO> assignmentCardDTOs = new List<AssignmentCardDTO>();
            foreach (Assignment assignment in assignments)
            {
                AssignmentCardDTO dto = new AssignmentCardDTO();
                dto.Title = assignment.Title;
                dto.Date = assignment.Date;
                dto.Duration_Hours = assignment.Duration_Hours;
                dto.conditions = assignment.Conditions;
                dto.Description = assignment.Description;
                dto.Requirements = assignment.Requirements;
                dto.DeadLine = assignment.DeadLine;
                dto.Level = assignment.Level;
                dto.IsActive = assignment.IsActive;
                assignmentCardDTOs.Add (dto);
            }
            return assignmentCardDTOs;
        }
        public static List<SkillsCardDTO> SkillMapper(List<Skill> skills)
        {
            List<SkillsCardDTO> skillsCardDTOs = new List<SkillsCardDTO>();
            foreach (Skill skill in skills)
            {
                SkillsCardDTO dto = new SkillsCardDTO();
                dto.Title = skill.Title;
                dto.Description= skill.Description;
                dto.Description = skill.Description;
                skillsCardDTOs .Add (dto);
            }
            return skillsCardDTOs;
        }
        public static List<QuestionCardDTO> QuestionsMapper(List<Question> questionCards)
        {
            List<QuestionCardDTO> questions = new List<QuestionCardDTO>();
            foreach (Question ques in questionCards)
            {
                QuestionCardDTO dto = new QuestionCardDTO();
                dto.Title = ques.Title;
                dto.Description = ques.Description;
                dto.QuestionType = ques.QuestionType.Name;
                dto.QuestionID = ques.QuestionID;
                questions.Add(dto);
            }
            return questions;
        }
        public static List<GetAllAnswesDTO> AnswerMapper(List<Answers> answerses)
        {
            List<GetAllAnswesDTO> result = new List<GetAllAnswesDTO>();
            foreach (Answers ques in answerses)
            {
                GetAllAnswesDTO dto = new GetAllAnswesDTO();
                dto.Title = ques.Title;
                dto.IsCorrect = ques.IsCorrect;
                result.Add(dto);
            }
            return result;
        }
        
    }
}
