namespace TechnicalQuestionAPI.DTO.JobTitles
{
    public class JobTitleUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public int Expirences_Time { get; set; }
        public string Tasks { get; set; }
        public string Conditions { get; set; }
        public int Level { get; set; }
    }
}
