namespace TechnicalQuestionAPI.DTO.Assignment
{
    public class AssignmentCardDTO
    {
        //missing Id -- TODO By Eyad
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Duration_Hours { get; set; }
        public string conditions { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime DeadLine { get; set; }
        public string Level { get; set; }
        public bool IsActive { get; set; }
    }
}
