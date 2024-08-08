using Basalt.Framework.Logging;
using Ionic.Zip;
using System.Net;

namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class HikeValidator : IValidator
{
    private readonly string _exeName = "AShortHike.exe";
    private readonly string _defaultPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\A Short Hike";

    public async Task InstallModdingTools()
    {
        string toolsCache = Path.Combine(Core.CacheFolder, "tools", "hike.zip");
        Directory.CreateDirectory(Path.GetDirectoryName(toolsCache));

        // If tools dont already exist in cache, download from web
        if (!File.Exists(toolsCache))
        {
            Logger.Warn("Downloading blas1 tools from web");
            using (WebClient client = new WebClient())
            {
                string toolsPath = "https://github.com/BrandenEK/AShortHike.ModdingTools/raw/main/modding-tools-windows.zip";
                await client.DownloadFileTaskAsync(new Uri(toolsPath), toolsCache);
            }
        }

        // Extract data in cache to game folder
        string installPath = Core.SettingsHandler.Properties.HikeRootFolder;
        using (ZipFile zipFile = ZipFile.Read(toolsCache))
        {
            foreach (ZipEntry file in zipFile)
                file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
        }
    }

    public void SetRootPath(string path)
    {
        Core.SettingsHandler.Properties.HikeRootFolder = path;
    }

    public bool IsRootFolderValid
    {
        get
        {
            string path = Core.SettingsHandler.Properties.HikeRootFolder;
            if (File.Exists(path + "\\" + _exeName))
            {
                Directory.CreateDirectory(path + "\\Modding\\disabled");
                return true;
            }

            return false;
        }
    }

    public bool AreModdingToolsInstalled
    {
        get
        {
            return Directory.Exists(Core.SettingsHandler.Properties.HikeRootFolder + "\\BepInEx");
        }
    }

    public bool AreModdingToolsUpdated => true;

    public string ExeName => _exeName;
    public string DefaultPath => string.IsNullOrEmpty(Core.SettingsHandler.Properties.HikeRootFolder)
        ? _defaultPath
        : Core.SettingsHandler.Properties.HikeRootFolder;
}
