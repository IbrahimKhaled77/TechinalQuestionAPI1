﻿namespace TechnicalQuestionAPI.DTO.EducationHistorys
{
    public class EducationHistoryUpdateDTO
    {
        public int EductionHistoryId { get; set; }
        public string Title { get; set; }
        public string Specification { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string? Description { get; set; }
    }
}
