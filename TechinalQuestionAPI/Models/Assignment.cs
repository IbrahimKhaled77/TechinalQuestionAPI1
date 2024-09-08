namespace TechnicalQuestionAPI.Models
{
    public class Assignment
    {
        public string Title           { get; set; }
        public DateTime Date            { get; set; }
        public int Duration_Hours  { get; set; }
        public float Mark            { get; set; }
        public string Conditions      { get; set; }
        public string Description     { get; set; }
        public string Requirements    { get; set; }
        public DateTime DeadLine        { get; set; }
        public bool IsPassed        { get; set; }
        public string Level           { get; set; }
        public int AssignmentId { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserAssignment> UserAssignments { get; set; }
    }
}
