namespace LearnPortal.DAL.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        IEnumerable<ICourse> FinishedCourses { get; set; }

        IEnumerable<ICourse> InProgressCourses { get; set; }

        IEnumerable<ISkill> Skills { get; set; }
    }
}
