using System.Diagnostics;

namespace Dev.Naamloos.Firefoxer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trying to find firefox profile...");
            var finder = new ProfileFinder();
            var profilePath = finder.FindMainProfilePath();
            Console.WriteLine(profilePath);

            Console.WriteLine("Configuring user...");
            var configurator = new UserConfigurator();
            configurator.ConfigureUser(profilePath);
            Console.WriteLine("Done. (Re)starting firefox!");

            // kill firefox if running
            var processes = Process.GetProcessesByName("firefox");
            foreach (var process in processes)
            {
                process.Kill();
            }
            Console.WriteLine("Firefox killed.");
            Console.WriteLine("Please manually restart firefox!");
        }
    }
}
