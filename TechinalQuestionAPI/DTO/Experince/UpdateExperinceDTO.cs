﻿namespace TechnicalQuestionAPI.DTO.Experince
{
    public class UpdateExperinceDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
        public string NationalityId { get; set; }
    }
}
