using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Naamloos.FirefoxTheme.ViewModels
{
    public class ProfilePickerViewModel : ViewModelBase
    {
        const string FIREFOX_CONFIGS_PATH = @"%appdata%\Mozilla\Firefox";
        const string PROFILE_INI = "profiles.ini";

        public List<string> ProfileNames { get; private set; } = new List<string>();
        public List<string> ProfilePaths { get; private set; } = new List<string>();
        public int SelectedProfileIndex { get; set; } = 0;

        public ProfilePickerViewModel()
        {
            var configPath = Environment.ExpandEnvironmentVariables(FIREFOX_CONFIGS_PATH);
            var profilesIniPath = System.IO.Path.Combine(configPath, PROFILE_INI);

            var reader = new IniFileReader(profilesIniPath);

            int index = 0;

            do
            {
                var profileName = reader.Get("Profile" + index, "Name");
                var profilePath = reader.Get("Profile" + index, "Path");
                var isDefault = reader.Get("Profile" + index, "Default");

                if (profileName != null && profilePath != null && isDefault != "1")
                {
                    ProfileNames.Add(profileName);
                    ProfilePaths.Add(profilePath);
                }
                index++;
            } while (reader.Get("Profile" + index, "Name") != null);
        }
    }
}
