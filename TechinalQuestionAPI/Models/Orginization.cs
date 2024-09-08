using System.Data;

namespace TechnicalQuestionAPI.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string FullName { get; set; }
        public DateTime FoundingDate { get; set; }
        public string ComericalDocumentId { get; set; }
        public string PropfilePhotoPath { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
