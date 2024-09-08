
namespace TechnicalQuestionAPI.Models
{
    public class Skill
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public int SkillsId { get; set; }
        public bool IsActive { get; set; }
        public virtual List<UserSkill> UserSkills { get; set; }
    }
}
