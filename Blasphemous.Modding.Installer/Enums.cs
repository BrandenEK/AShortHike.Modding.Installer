﻿
namespace Blasphemous.Modding.Installer;

public enum SectionType
{
    HikeMods,
    Blas1Mods,
    Blas1Skins,
    Blas2Mods,
}

public enum SortType
{
    Name,
    Author,
    InitialRelease,
    LatestRelease,
}

public enum FilterType
{
    All,
    NotInstalled,
    Installed,
    Disabled,
    Enabled,
}
