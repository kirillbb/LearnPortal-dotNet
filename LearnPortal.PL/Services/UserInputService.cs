namespace LearnPortal.PL.Services
{
    public static class UserInputService
    {
        public static Guid GetId()
        {
            PrinterService.Message("Enter id:");
            Guid id = Guid.Empty;
            Guid.TryParse(Console.ReadLine(), out id);

            PrinterService.BreakLine();
            return id;
        }

        public static int GetMenuItemNumber()
        {
            int menuItem;
            while (!int.TryParse(Console.ReadLine(), out menuItem))
            {
            }

            PrinterService.BreakLine();
            return menuItem;
        }
    }
}