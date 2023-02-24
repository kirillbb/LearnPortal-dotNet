using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.BLL.Services;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    public class UiSkillService
    {
        private readonly SkillService _skillService;

        public UserDTO CurrentUser { get; private set; }

        public UiSkillService(UserDTO currentUser)
        {
            _skillService = new SkillService(currentUser);
            CurrentUser = currentUser;
        }

        public SkillViewModel EnteringSkillFields()
        {
            PrinterService.Message("Enter a Title of a skill:");
            string title = Console.ReadLine();
            PrinterService.Message("Enter a Description of a skill:");
            string description = Console.ReadLine();

            return new SkillViewModel
            {
                Title = title,
                Description = description,
            };
        }

        public async Task CreateSkillAsync()
        {
            try
            {
                SkillViewModel skill = EnteringSkillFields();

                PrinterService.BreakLine();
                if (skill != null)
                {
                    await _skillService.CreateSkill(new SkillDTO
                    {
                        Title = skill.Title,
                        Description = skill.Description,
                    });
                }
                else
                {
                    PrinterService.ErrorMsg("Try again");
                }
            }
            catch (Exception ex)
            {
                PrinterService.ErrorMsg(ex.Message);
            }
        }

        public async Task ShowSkillAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var skill = await _skillService.GetSkill(id);
                PrinterService.Print(new SkillViewModel
                {
                    Id = skill.Id,
                    OwnerId = skill.Id,
                    Title = skill   .Title,
                    Description = skill.Description,
                });
            }
            else
            {
                PrinterService.ErrorMsg("Incorrect Id");
            }
        }
    }
}