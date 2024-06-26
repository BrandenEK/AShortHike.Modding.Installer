﻿using Basalt.CommandParser;
using Blasphemous.Modding.Installer.Grouping;
using Blasphemous.Modding.Installer.Loading;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.Previewing;
using Blasphemous.Modding.Installer.Properties;
using Blasphemous.Modding.Installer.Skins;
using Blasphemous.Modding.Installer.Sorting;
using Blasphemous.Modding.Installer.Starting;
using Blasphemous.Modding.Installer.UIHolding;
using Blasphemous.Modding.Installer.Validation;

namespace Blasphemous.Modding.Installer;

static class Core
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Logger.Show();

        InstallerCommand cmd = new();
        try
        {
            cmd.Process(args);
        }
        catch (CommandParserException ex)
        {
            Logger.Error(ex);
            Application.Exit();
            return;
        }

        UIHandler = new UIHandler();
        SettingsHandler = new SettingsHandler();
        GithubHandler = new GithubHandler(cmd.GithubToken);
        TempIgnoreTime = cmd.IgnoreTime;
        TempShowBlasphemous = cmd.ShowBlasphemous;

        List<Mod> blas1mods = new List<Mod>();
        List<Skin> blas1skins = new List<Skin>();
        List<Mod> blas2mods = new List<Mod>();
        List<Mod> hikeMods = new();

        string blas1modTitle = "Blasphemous Mods";
        string blas1skinTitle = "Blasphemous Skins";
        string blas2modTitle = "Blasphemous II Mods";
        string hikeModTitle = "Short Hike Mods";

        string blas1modLocalPath = DataCache + "/blas1mods.json";
        string blas1skinLocalPath = DataCache + "/blas1skins.json";
        string blas2modLocalPath = DataCache + "/blas2mods.json";
        string hikeModLocalPath = DataCache + "/hikemods.json";

        string blas1modRemotePath = "https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/BlasphemousMods.json";
        string blas2modRemotePath = "https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/BlasphemousIIMods.json";
        string hikeModRemotePath = "https://raw.githubusercontent.com/BrandenEK/AShortHike.ModInstaller/main/ShortHikeMods.json";

        var blas1modGrouper = new ModGrouper(blas1modTitle, blas1mods);
        var blas1skinGrouper = new SkinGrouper(blas1skinTitle, blas1skins);
        var blas2modGrouper = new ModGrouper(blas2modTitle, blas2mods);
        var hikeModGrouper = new ModGrouper(hikeModTitle, hikeMods);

        var blas1modUI = new GenericUIHolder<Mod>(UIHandler.GetUIElementByType(SectionType.Blas1Mods), blas1mods);
        var blas1skinUI = new GenericUIHolder<Skin>(UIHandler.GetUIElementByType(SectionType.Blas1Skins), blas1skins);
        var blas2modUI = new GenericUIHolder<Mod>(UIHandler.GetUIElementByType(SectionType.Blas2Mods), blas2mods);
        var hikeModUI = new GenericUIHolder<Mod>(UIHandler.GetUIElementByType(SectionType.HikeMods), hikeMods);

        var blas1modSorter = new ModSorter(blas1modUI, blas1mods, SectionType.Blas1Mods);
        var blas1skinSorter = new SkinSorter(blas1skinUI, blas1skins, SectionType.Blas1Skins);
        var blas2modSorter = new ModSorter(blas2modUI, blas2mods, SectionType.Blas2Mods);
        var hikeModSorter = new ModSorter(hikeModUI, hikeMods, SectionType.HikeMods);

        var blas1modLoader = new ModLoader(blas1modLocalPath, blas1modRemotePath, blas1modUI, blas1modSorter, blas1mods, SectionType.Blas1Mods);
        var blas1skinLoader = new SkinLoader(blas1skinLocalPath, "blasphemous1", blas1skinUI, blas1skinSorter, blas1skins, SectionType.Blas1Skins);
        var blas2modLoader = new ModLoader(blas2modLocalPath, blas2modRemotePath, blas2modUI, blas2modSorter, blas2mods, SectionType.Blas2Mods);
        var hikeModLoader = new ModLoader(hikeModLocalPath, hikeModRemotePath, hikeModUI, hikeModSorter, hikeMods, SectionType.HikeMods);

        var blas1Validator = new Blas1Validator();
        var blas2Validator = new Blas2Validator();
        var hikeValidator = new HikeValidator();

        var blas1Starter = new Blas1Starter(blas1Validator);
        var blas2Starter = new Blas2Starter(blas2Validator);
        var hikeStarter = new HikeStarter(hikeValidator);

        var modPreviewer = new ModPreviewer(UIHandler.PreviewName, UIHandler.PreviewDescription, UIHandler.PreviewVersion);
        var skinPreviewer = new SkinPreviewer(UIHandler.PreviewBackground);

        var blas1modPage = new InstallerPage(blas1modTitle, Resources.background1,
            blas1modGrouper,
            blas1modLoader,
            modPreviewer,
            blas1modSorter,
            blas1modUI,
            blas1Validator,
            blas1Starter);

        var blas1skinPage = new InstallerPage(blas1skinTitle, Resources.background1,
            blas1skinGrouper,
            blas1skinLoader,
            skinPreviewer,
            blas1skinSorter,
            blas1skinUI,
            blas1Validator,
            blas1Starter);

        var blas2modPage = new InstallerPage(blas2modTitle, Resources.background2,
            blas2modGrouper,
            blas2modLoader,
            modPreviewer,
            blas2modSorter,
            blas2modUI,
            blas2Validator,
            blas2Starter);

        var hikeModPage = new InstallerPage(hikeModTitle, Resources.background_sh,
            hikeModGrouper,
            hikeModLoader,
            modPreviewer,
            hikeModSorter,
            hikeModUI,
            hikeValidator,
            hikeStarter);

        _pages.Add(SectionType.Blas1Mods, blas1modPage);
        _pages.Add(SectionType.Blas1Skins, blas1skinPage);
        _pages.Add(SectionType.Blas2Mods, blas2modPage);
        _pages.Add(SectionType.HikeMods, hikeModPage);

        Application.Run(UIHandler);
    }

    public static bool TempIgnoreTime { get; private set; }
    public static bool TempShowBlasphemous { get; private set; }

    public static UIHandler UIHandler { get; private set; }
    public static SettingsHandler SettingsHandler { get; private set; }
    public static GithubHandler GithubHandler { get; private set; }

    private static readonly Dictionary<SectionType, InstallerPage> _pages = new Dictionary<SectionType, InstallerPage>();

    public static InstallerPage CurrentPage => _pages[SettingsHandler.Properties.CurrentSection];
    public static IEnumerable<InstallerPage> AllPages => _pages.Values;

    public static InstallerPage Blas1ModPage => _pages[SectionType.Blas1Mods];
    public static InstallerPage Blas1SkinPage => _pages[SectionType.Blas1Skins];
    public static InstallerPage Blas2ModPage => _pages[SectionType.Blas2Mods];
    public static InstallerPage HikeModPage => _pages[SectionType.HikeMods];

    public static string DataCache => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/BlasModInstaller";

    public static Version CurrentVersion => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version ?? new(0, 1, 0);
}
