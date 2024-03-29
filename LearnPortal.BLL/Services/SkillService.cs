﻿using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class SkillService : IService<SkillDTO>
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Skill> _skillRepo;

        public SkillService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _skillRepo = new GenericRepository<Skill>(_context);
        }

        public async Task CreateAsync(SkillDTO skill)
        {
            await _skillRepo.CreateAsync(new Skill
            {
                Id = new Guid(),
                Title = skill.Title,
                Description = skill.Description,
                OwnerId = _currentUser.Id,
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            await _skillRepo.DeleteAsync(id);
        }

        public IEnumerable<SkillDTO> Find(Func<Skill, bool> predicate)
        {
            var skills = _skillRepo.Find(predicate);
            List<SkillDTO> skillDTOs = new List<SkillDTO>();
            foreach (var skill in skills)
            {
                SkillDTO skillDTO = new SkillDTO
                {
                    Id = skill.Id,
                    Title = skill.Title,
                    Description = skill.Description,
                    OwnerId = skill.OwnerId,
                };
            }

            return skillDTOs;
        }

        public async Task<SkillDTO> GetAsync(Guid id)
        {
            var skill = await _skillRepo.GetAsync(id);
            return new SkillDTO
            {
                Id = skill.Id,
                Title = skill.Title,
                Description = skill.Description,
                OwnerId = skill.OwnerId,
            };
        }

        public async Task<IEnumerable<SkillDTO>> GetAllAsync()
        {
            var skills = await _skillRepo.GetAllAsync();
            List<SkillDTO> skillDTOs = new List<SkillDTO>();
            foreach (var skill in skills)
            {
                SkillDTO skillDTO = new SkillDTO
                {
                    Id = skill.Id,
                    Title = skill.Title,
                    Description = skill.Description,
                    OwnerId = skill.OwnerId,
                };
            }

            return skillDTOs;
        }

        public async Task UpdateAsync(SkillDTO skill)
        {
            await _skillRepo.UpdateAsync(new Skill
            {
                Id = skill.Id,
                Title = skill.Title,
                Description = skill.Description,
                OwnerId = skill.OwnerId,
            });
        }
    }
}