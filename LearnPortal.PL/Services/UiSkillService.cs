using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.Interfaces;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    public class UiSkillService : IUiService<SkillViewModel>
    {
        private readonly SkillService _skillService;

        public UserDTO CurrentUser { get; private set; }

        public UiSkillService(UserDTO currentUser)
        {
            _skillService = new SkillService(currentUser);
            CurrentUser = currentUser;
        }

        public SkillViewModel EnteringFields()
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

        public async Task CreateAsync()
        {
            try
            {
                SkillViewModel skill = EnteringFields();

                PrinterService.BreakLine();
                if (skill != null)
                {
                    await _skillService.CreateAsync(new SkillDTO
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

        public async Task GetAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var skill = await _skillService.GetAsync(id);
                PrinterService.Print(new SkillViewModel
                {
                    Id = skill.Id,
                    OwnerId = skill.Id,
                    Title = skill.Title,
                    Description = skill.Description,
                });
            }
            else
            {
                PrinterService.ErrorMsg("Incorrect Id");
            }
        }

        public async Task UpdateAsync()
        {
            try
            {
                var id = UserInputService.GetId();
                SkillViewModel skill = EnteringFields();
                skill.Id = id;

                PrinterService.BreakLine();
                if (skill != null)
                {
                    await _skillService.UpdateAsync(new SkillDTO
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

        public async Task DeleteAsync()
        {
            try
            {
                var id = UserInputService.GetId();
                await _skillService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                PrinterService.ErrorMsg(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            try
            {
                var skills = await _skillService.GetAllAsync();
                if (skills != null)
                {
                    foreach (var skill in skills)
                    {
                        PrinterService.Print(new SkillViewModel
                        {
                            Id = skill.Id,
                            OwnerId = skill.Id,
                            Title = skill.Title,
                            Description = skill.Description,
                        });
                    }
                }
                else
                {
                    PrinterService.ErrorMsg("Empty List!");
                }
            }
            catch (Exception ex)
            {
                PrinterService.ErrorMsg(ex.Message);
            }
        }
    }
}