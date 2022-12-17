using LearnPortal.BLL.DTO;
using LearnPortal.PL.Services;

namespace LearnPortal.PL
{
    public class Starter
    {
        private UserDTO TestUser { get; set; }
        public Starter()
        {
            TestUser = new UserDTO()
            {
                Email = "kirill@gmail.com",
                Id = Guid.NewGuid(),
                UserName = "kirill",
            };
        }

        public async Task RunAsync()
        {
            UiService uiService = new UiService(TestUser);
            await uiService.Start();
        }
    }
}
