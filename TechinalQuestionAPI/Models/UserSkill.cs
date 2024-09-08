namespace TechnicalQuestionAPI.Models
{
    public class UserSkill
    {
        public int UserSkillId { get; set; }
        public virtual User User { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
