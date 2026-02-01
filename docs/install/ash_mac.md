# A Short Hike Manual Installation (Mac)

### Installing or updating the modding tools
1. Download the [Mac version](https://github.com/BrandenEK/AShortHike.ModdingTools/raw/main/macos64.zip) of the modding tools
1. Extract the contents of the zip file into the game's root directory
1. You should now have a folder called "Modding" in the same folder as "AShortHike.app"
1. Mark the start script as executable with the command ```chmod u+x start_shorthike_modded.sh```
1. If using Steam, set the steam launch options to ```<PATH>/start_shorthike_modded.sh # %command%``` where ```<PATH>``` is the full path to the game folder

> [!NOTE]  
> If this guide doesn't work or is missing information, please bring this up in Discord or make an issue on GitHub

### Installing or updating individual mods
1. On the mod's github page, navigate to the latest release
1. Download the file called "ModName.zip" and extract the contents of the zip file into the "Modding" folder
1. You should now have a file called "ModName.dll" in the "Modding/plugins" folder
1. Repeat this step for all of the mod's dependencies