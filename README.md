# A Short Hike Mod Installer

<img src="https://img.shields.io/github/downloads/BrandenEK/AShortHike.Modding.Installer/total?color=248721&style=for-the-badge">

---

### Automatic installation (Windows only)
1. Download the most recent version of the installer from the [Releases](https://github.com/BrandenEK/AShortHike.Modding.Installer/releases) page
   - You may need to make an exception for it in your antivirus
3. Run the 'ShortHikeModInstaller.exe' program
   - You may need to install the .net runtime
4. Locate the exe file for the game through the UI
5. Install the modding tools for the game through the UI

---

### Manual installation
1. Install or update the modding tools
   - Click the link to download the tools for your operating system ([Windows](https://github.com/BrandenEK/AShortHike.ModdingTools/raw/main/modding-tools-windows.zip)/[Linux](https://github.com/BrandenEK/AShortHike.ModdingTools/raw/main/modding-tools-linux.zip)/[Mac](https://github.com/BrandenEK/AShortHike.ModdingTools/raw/main/modding-tools-mac.zip))
   - Extract the contents of the zip file into the game's root directory
   - You should now have a folder called "Modding" in the same folder as "AShortHike.exe"
2. Install or update the mod
   - On the mod's github page, navigate to the latest release
   - Download the file called "ModName.zip" and extract the contents of the zip file into the "Modding" folder
   - You should now have a file called "ModName.dll" in the "Modding/plugins" folder
   - Repeat this step for all of the mod's dependencies

---

### Command line arguments
- ```-[g]ithub {token}``` Uses your GitHub OAuth token to increase the API rate limit
- ```-[i]gnore``` Ignores the wait time of 30 mins before mod versions are rechecked
- ```-[b]las``` Displays the original blasphemous buttons
- ```-[d]ebug``` Runs in debug mode with a console
