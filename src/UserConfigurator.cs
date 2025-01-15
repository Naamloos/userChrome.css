using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Naamloos.Firefoxer
{
    public class UserConfigurator
    {
        public UserConfigurator()
        {
            Console.WriteLine("UserConfigurator instantiated.");
        }

        public void ConfigureUser(string profilePath)
        {
            Console.WriteLine("Configuring user...");
            Console.WriteLine("Profile path: " + profilePath);

            // make sure chrome folder exists
            var chromePath = Path.Combine(profilePath, "chrome");
            if (!Directory.Exists(chromePath))
            {
                Directory.CreateDirectory(chromePath);
            }

            // put embedded resource "Assets.userChrome.css" in the folder
            var userChromePath = Path.Combine(chromePath, "userChrome.css");
            if (File.Exists(userChromePath))
            {
                File.Delete(userChromePath);
            }
            var userChromeResource = "Dev.Naamloos.Firefoxer.Assets.userChrome.css";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(userChromeResource))
            {
                using (var fileStream = File.Create(userChromePath))
                {
                    stream.CopyTo(fileStream);
                }
            }

            // delete user.js if it exists
            var userJsPath =Path.Combine(profilePath, "user.js");
            if (File.Exists(userJsPath))
            {
                File.Delete(userJsPath);
            }
            // copy from assets too
            var userJsResource = "Dev.Naamloos.Firefoxer.Assets.user.js";
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(userJsResource))
            {
                using (var fileStream = File.Create(userJsPath))
                {
                    stream.CopyTo(fileStream);
                }
            }
        }
    }
}
