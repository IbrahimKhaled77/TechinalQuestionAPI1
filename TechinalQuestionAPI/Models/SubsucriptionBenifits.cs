namespace TechnicalQuestionAPI.Models
{
    public class SubscriptionBenefits
    {
        public int SubscriptionBenefitId { get; set; }
        public string Title {  get; set; }
        public virtual Subscription Subsucription { get; set; }
    }
}
