using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Naamloos.Firefoxer
{
    public class ProfileFinder
    {
        const string EXPECTED_FIREFOX_PATH = "%appdata%\\Mozilla\\Firefox";

        public ProfileFinder()
        {
            Console.WriteLine("ProfileFinder instantiated.");
        }

        // Find Main Firefox Profile Path
        public string FindMainProfilePath()
        {
            var firefoxPath = Environment.ExpandEnvironmentVariables(EXPECTED_FIREFOX_PATH);
            var iniReader = new IniFileReader(Path.Combine(firefoxPath, "profiles.ini"));

            List<string> profiles = new List<string>();
            List<string> profilePaths = new List<string>();
            var lastValue = 0;
            do
            {
                var profileName = iniReader.Get("Profile" + lastValue, "Name");
                if (profileName != null && iniReader.Get("Profile" + lastValue, "Default") != "1")
                {
                    profiles.Add(profileName);
                    profilePaths.Add(iniReader.Get("Profile" + lastValue, "Path"));
                }
                lastValue++;
            } while (iniReader.Get("Profile" + lastValue, "Name") != null);

            Console.WriteLine("Found profiles: " + string.Join(", ", profiles));

            // pick a profile with input
            if(profiles.Count > 1)
            {
                Console.WriteLine("Multiple valid profiles found. Please select a profile:");
                for (int i = 0; i < profiles.Count; i++)
                {
                    Console.WriteLine(i + ": " + profiles[i]);
                }
                var selectedProfile = profilePaths[int.Parse(Console.ReadLine())];
                return Path.Combine(firefoxPath, selectedProfile);
            }
            else
            {
                return Path.Combine(firefoxPath, profilePaths[0]);
            }
        }
    }
}
