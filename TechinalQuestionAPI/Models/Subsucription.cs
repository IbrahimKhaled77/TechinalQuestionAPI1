using TechnicalQuestionAPI.Models;

namespace TechnicalQuestionAPI.Models
{
    public class Subscription
    {
        public int SubsucriptionId { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public float  Price { get; set; }
        public int    DurationInDays { get; set; }
        public virtual ICollection<SubscriptionBenefits> SubsucriptionBenifits { get; set; }   
        public virtual ICollection<User> Users { get; set; }
    }
}
