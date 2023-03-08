using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.Interfaces;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    public class UiVideoService : IUiService<VideoViewModel>
    {
        private readonly VideoService _videoService;

        public UserDTO CurrentUser { get; set; }

        public UiVideoService(UserDTO currentUser)
        {
            _videoService = new VideoService(currentUser);
            CurrentUser = currentUser;
        }

        public VideoViewModel EnteringFields()
        {
            Console.WriteLine("Enter a Title of a video:");
            string title = Console.ReadLine();
            PrinterService.Message("Enter a Description of a book:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter a resolution of a video (480,720,1080, etc):");
            int resolution = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a duration of a video in minutes:");
            int duration = int.Parse(Console.ReadLine());

            return new VideoViewModel
            {
                Title = title,
                Description = description,
                Duration = duration,
                Resolution = resolution,
            };
        }

        public async Task CreateAsync()
        {
            try
            {
                VideoViewModel video = EnteringFields();

                PrinterService.BreakLine();
                if (video != null)
                {
                    await _videoService.CreateAsync(new VideoDTO
                    {
                        Title = video.Title,
                        Resolution = video.Resolution,
                        Description = video.Description,
                        Duration = video.Duration,
                    });
                }
                else
                {
                    PrinterService.ErrorMsg("Try again!");
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
                var video = await _videoService.GetAsync(id);
                PrinterService.Print(new VideoViewModel
                {
                    Id = video.Id,
                    OwnerId = video.OwnerId,
                    Title = video.Title,
                    Description = video.Description,
                    Duration = video.Duration,
                    Resolution = video.Resolution,
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
                VideoViewModel video = EnteringFields();
                video.Id = id;

                PrinterService.BreakLine();
                if (video != null)
                {
                    await _videoService.UpdateAsync(new VideoDTO
                    {
                        Title = video.Title,
                        Description = video.Description,
                        Duration = video.Duration,
                        Resolution = video.Resolution,
                        //OwnerId = video.OwnerId, check,i need that or not?
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
                await _videoService.DeleteAsync(id);
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
                var videos = await _videoService.GetAllAsync();
                if (videos != null)
                {
                    foreach (var video in videos)
                    {
                        PrinterService.Print(new VideoViewModel
                        {
                            Id = video.Id,
                            OwnerId = video.OwnerId,
                            Title = video.Title,
                            Description = video.Description,
                            Duration = video.Duration,
                            Resolution = video.Resolution,
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