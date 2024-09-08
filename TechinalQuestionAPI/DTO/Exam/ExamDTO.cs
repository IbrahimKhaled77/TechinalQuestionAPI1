using System.ComponentModel.DataAnnotations;
using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.DTO.Exam
{
    public class ExamDTO
    {
        public string  Title         { get; set; }
        public int     Mark          { get; set; }
        public int     QuestionCount { get; set; }
        public int     Duration      { get; set; }
        public string? Level         { get; set; }
        public float?  ActualMark    { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
    }
}
