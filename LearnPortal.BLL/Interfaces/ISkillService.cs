using LearnPortal.BLL.DTO;
using LearnPortal.DAL.Entities.CourseType;

namespace LearnPortal.BLL.Interfaces
{
    public interface ISkillService
    {
        Task CreateSkill(SkillDTO skill);

        Task DeleteSkill(int id);

        Task UpdateSkill(SkillDTO skill);

        IEnumerable<SkillDTO> FindSkill(Func<Skill, bool> predicate);

        Task<SkillDTO> GetSkill(int id);

        Task<IEnumerable<SkillDTO>> GetSkillsAsync();
    }
}
