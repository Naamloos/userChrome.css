# userChrome.css
My personal firefox userChrome.css file

## Enable custom styling
Read the guide [here](https://www.reddit.com/r/firefox/wiki/userchrome/) to find out how to enable custom styling.

To use this userChrome.css, copy it into your userChrome.css file.

## Enable experimental vertical tabs
1. Go to `about:config`
2. Enable `sidebar.revamp` and `sidebar.verticalTabs`
3. Restart firefox

## Features
- Expand experimental vertical tabs on hover

## What is the `/src` folder?
This is a WIP project specifically for installing Firefox userChrome themes. This will allow the user to both install a `userChrome.css` or a `user.js` configuration file, without having to dive into the profile directories.

### (Planned) Features
- Windows, Linux, MacOS(?) support.
- Merging multiple userChrome.css files from different creators.
- Merging multiple user.js files from different creators.
- Displaying what styles potentially conflict (override the same CSS rules).
- Giving one theme priority over another.
- Toggling single themes.
- Firefox version checking, giving a warning if a userChrome.css might not be compatible(?)

This also means that smaller patches could be toggled as separate themes!

### (Early) Screenshots