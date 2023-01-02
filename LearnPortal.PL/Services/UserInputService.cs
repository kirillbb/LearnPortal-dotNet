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

        //public static VideoDTO AddVideo(User user)
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter a Title of a video:");
        //        string title = Console.ReadLine();
        //        Console.WriteLine("Enter a resolution of a video (480,720,1080, etc):");
        //        int resolution = int.Parse(Console.ReadLine());
        //        Console.WriteLine("Enter a duration of a video in minutes:");
        //        int duration = int.Parse(Console.ReadLine());

        //        VideoDTO video = new VideoDTO
        //        {
        //            Title = title,
        //            Resolution = resolution,
        //            Duration = duration,
        //            Creator = user
        //        };

        //        Printer.BreakLine();
        //        return video;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return null;
        //}

        //public static PublicationDTO AddPublication(User user)
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter a Title of a publication:");
        //        string title = Console.ReadLine();
        //        Console.WriteLine("Enter a publication date:");
        //        DateTime date = DateTime.Parse(Console.ReadLine());
        //        Console.WriteLine("Enter a sourse of a publication:");
        //        string source = Console.ReadLine();

        //        PublicationDTO publication = new PublicationDTO
        //        {
        //            Title = title,
        //            CreationDate = date,
        //            Source = source,
        //            Creator = user
        //        };

        //        Printer.BreakLine();
        //        return publication;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return null;
        //}

        //public static SkillDTO AddSkill()
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter a Name of a skill:");
        //        string name = Console.ReadLine();
        //        Console.WriteLine("Enter a description of a skill:");
        //        string description = Console.ReadLine();

        //        SkillDTO skillDTO = new SkillDTO
        //        {
        //            Name = name,
        //            Description = description
        //        };

        //        Printer.BreakLine();
        //        return skillDTO;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return null;
        //}

        //public static CourseDTO AddCourse(User user)
        //{
        //    try
        //    {
        //        Console.WriteLine("Enter a Name of a course:");
        //        string name = Console.ReadLine();
        //        Console.WriteLine("Enter a description of a course:");
        //        string description = Console.ReadLine();

        //        CourseDTO course = new CourseDTO
        //        {
        //            Name = name,
        //            Description = description,
        //            CreatorId = user.Id
        //        };

        //        Printer.BreakLine();
        //        return course;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return null;
        //}
    }
}
