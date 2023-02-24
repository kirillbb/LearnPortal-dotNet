using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.Interfaces;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    internal class UiCourseService : IUiService<CourseViewModel>
    {
        private readonly CourseService _courseService;

        public UserDTO CurrentUser { get; private set; }

        public UiCourseService(UserDTO currentUser)
        {
            _courseService = new CourseService(currentUser);
            CurrentUser = currentUser;
        }

        public CourseViewModel EnteringFields()
        {
            PrinterService.Message("Enter a Title of a course:");
            string title = Console.ReadLine();
            PrinterService.Message("Enter a Description of a course:");
            string description = Console.ReadLine();

            return new CourseViewModel
            {
                Title = title,
                Description = description,
            };
        }

        public async Task CreateAsync()
        {
            try
            {
                CourseViewModel course = EnteringFields();

                PrinterService.BreakLine();
                if (course != null)
                {
                    await _courseService.CreateAsync(new CourseDTO
                    {
                        Title = course.Title,
                        Description = course.Description,
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
                await _courseService.DeleteAsync(id);
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
                var courses = await _courseService.GetAllAsync();
                if (courses != null)
                {
                    foreach (var course in courses)
                    {
                        PrinterService.Print(new BookViewModel
                        {
                            Id = course.Id,
                            OwnerId = course.Id,
                            Title = course.Title,
                            Description = course.Description,
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

        public async Task GetAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var course = await _courseService.GetAsync(id);
                PrinterService.Print(new CourseViewModel
                {
                    Id = course.Id,
                    OwnerId = course.Id,
                    Title = course.Title,
                    Description = course.Description,
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
                CourseViewModel course = EnteringFields();
                course.Id = id;

                PrinterService.BreakLine();
                if (course != null)
                {
                    await _courseService.UpdateAsync(new CourseDTO
                    {
                        Title = course.Title,
                        Description = course.Description,
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
    }
}