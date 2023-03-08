namespace LearnPortal.PL
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Starter starter = new Starter();
            await starter.RunAsync();
        }
    }
}