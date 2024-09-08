namespace TechnicalQuestionAPI.DTO.Assignment
{
    public class CreateAssignmentDTO
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Duration_HOURS { get; set; }       
        public string conditions { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime DeadLine { get; set; }
        public string Level { get; set; }
    }
}
