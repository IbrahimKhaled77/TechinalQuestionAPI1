namespace TechnicalQuestionAPI.DTO.Experince
{
    public class CreatNewExperinceDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
    }
}
