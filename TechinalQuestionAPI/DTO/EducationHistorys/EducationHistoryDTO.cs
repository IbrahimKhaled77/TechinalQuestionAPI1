namespace TechnicalQuestionAPI.DTO.EducationHistorys
{
       public class EducationHistoryDTO
    {
        public int EductionHistoryId { get; set; }
        public string Specification { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
