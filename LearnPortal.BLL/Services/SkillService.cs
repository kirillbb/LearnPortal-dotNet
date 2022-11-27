using AutoMapper;
using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.Course;
using LearnPortal.DAL.Entities.Material;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class SkillService : ISkillService
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Skill> _skillRepo;
        private IMapper _mapper;

        public SkillService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            _context = new ApplicationContext();
            _skillRepo = new GenericRepository<Skill>(_context);
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Skill, SkillDTO>()).CreateMapper();
        }

        public async Task CreateSkill(SkillDTO skill)
        {
            skill.Id = new Guid();
            await _skillRepo.CreateAsync(_mapper.Map<Skill>(skill));
        }

        public async Task DeleteSkill(int id)
        {
            await _skillRepo.DeleteAsync(id);
        }

        public IEnumerable<SkillDTO> FindSkill(Func<Skill, bool> predicate)
        {
            return _mapper.Map<IEnumerable<Skill>, List<SkillDTO>>(_skillRepo.Find(predicate));
        }

        public async Task<SkillDTO> GetSkill(int id)
        {
            return _mapper.Map<SkillDTO>(await _skillRepo.GetAsync(id));
        }

        public async Task<IEnumerable<SkillDTO>> GetSkillsAsync()
        {
            return _mapper.Map<IEnumerable<Skill>, List<SkillDTO>>(await _skillRepo.GetAllAsync());
        }

        public async Task UpdateSkill(SkillDTO skill)
        {
            await _skillRepo.UpdateAsync(_mapper.Map<Skill>(skill));
        }
    }
}
