namespace LearnPortal.PL.UI
{
    public static class Printer
    {
        public static void GeneralMenu()
        {
            BreakLine();
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            BreakLine();
            Console.WriteLine("[1] Materials operations");
            Console.WriteLine("[2] Courses operations");
            Console.WriteLine("[3] Skills operations");
            Console.WriteLine("[4] User profile\n");
            Console.WriteLine("[0] Close the program");
            BreakLine();
        }

        //internal static void SkillOperationsMenu()
        //{
        //    BreakLine();
        //    Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
        //    BreakLine();
        //    Console.WriteLine("[1] Create skill");
        //    Console.WriteLine("[2] Find skill by Id");
        //    Console.WriteLine("[3] Update skill");
        //    Console.WriteLine("[4] Delete skill");
        //    Console.WriteLine("[5] Show all skills\n");
        //    Console.WriteLine("[9] <--- Back");
        //    Console.WriteLine("[0] Close the program");
        //    BreakLine();
        //}

        public static void CoursesOperationsMenu()
        {
            BreakLine();
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            BreakLine();
            Console.WriteLine("[1] Create course");
            Console.WriteLine("[2] Find by Id course");
            Console.WriteLine("[3] Update course");
            Console.WriteLine("[4] Delete course");
            Console.WriteLine("[5] Show all courses");
            Console.WriteLine("[6] Add skills to course\n");
            Console.WriteLine("[7] Take a course");
            Console.WriteLine("[8] Finish a course");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            BreakLine();
        }

        public static void CrudMenu(string nameOfType)
        {
            BreakLine();
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            BreakLine();
            Console.WriteLine($"[1] Create {nameOfType}");
            Console.WriteLine($"[2] Find {nameOfType} by Id");
            Console.WriteLine($"[3] Update {nameOfType}");
            Console.WriteLine($"[4] Delete {nameOfType}");
            Console.WriteLine($"[5] Show all {nameOfType}s\n");
            Console.WriteLine($"[9] <--- Back");
            Console.WriteLine($"[0] Close the program");
            BreakLine();
        }

        public static void ChooseMaterialTypeMenu()
        {
            BreakLine();
            Console.WriteLine("-- Select a menu item by pressing the desired number and Enter --");
            BreakLine();
            Console.WriteLine("[1] Book");
            Console.WriteLine("[2] Video");
            Console.WriteLine("[3] Publication\n");
            Console.WriteLine("[9] <--- Back");
            Console.WriteLine("[0] Close the program");
            BreakLine();
        }

        public static void BreakLine()
        {
            Console.WriteLine("\n-----------------------------------------------------------------");
        }
    }
}
