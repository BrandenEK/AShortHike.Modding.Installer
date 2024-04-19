# Short Hike Mod Installer

<!-- <img src="https://img.shields.io/github/downloads/BrandenEK/Blasphemous.Modding.Installer/total?color=success&style=for-the-badge">

--- -->

## Usage
1. Download the most recent version of the installer from the [Releases](https://github.com/BrandenEK/AShortHike.ModInstaller/releases) page
2. Run the 'ShortHikeModInstaller.exe' program (You may need to install the .net runtime)
3. Locate your 'AShortHike.exe' file, which is most likely in 'C:\Program Files (x86)\Steam\steamapps\common\A Short Hike'
4. Download the modding tools

## Command line arguments
- ```-[g]ithub {token}``` Uses your GitHub OAuth token to increase the API rate limit
- ```-[i]gnore``` Ignores the wait time of 30 mins before mod versions are rechecked
- ```-[b]las``` Displays the original blasphemous buttons

## Adding your own mod to the installer
If you have created your own Short Hike mod and want it to be available in the mod installer, simply edit the 'ShortHikeMods.json' file in this repository with your mod's info, and submit a pull request.

## Manually installing mods
1. Follow the instructions for downloading the [Modding tools](https://github.com/BrandenEK/AShortHike.ModdingTools)
2. Download each mod you want from its releases page and extract the zip file into the Modding folder
