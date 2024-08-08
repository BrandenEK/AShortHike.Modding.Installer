# A Short Hike Mod Installer

<img src="https://img.shields.io/github/downloads/BrandenEK/AShortHike.Modding.Installer/total?color=248721&style=for-the-badge">

---

### Automatic installation (Windows only)
1. Download the most recent version of the installer from the [Releases](https://github.com/BrandenEK/AShortHike.Modding.Installer/releases) page
1. Run the 'ShortHikeModInstaller.exe' program (You may need to install the .net runtime)

---

### Manual installation
1. Install the modding tools (One time only)
   - Click this link to download the [Windows](https://github.com/BrandenEK/AShortHike.ModdingTools/raw/main/modding-tools-windows.zip) or [Linux](https://github.com/BrandenEK/AShortHike.ModdingTools/raw/main/modding-tools-linux.zip) version of the modding tools
   - Extract the contents of the zip file into the game's root directory
   - You should now have a folder called "Modding" in the same folder as "AShortHike.exe"
2. Install the mod (Whenever there is an update)
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
