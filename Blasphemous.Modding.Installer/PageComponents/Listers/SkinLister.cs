﻿using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Sorters;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Listers;

internal class SkinLister : ILister
{
    private readonly Panel _background;
    private readonly List<Skin> _skins;

    private readonly ISorter<Skin> _sorter;

    public SkinLister(Panel background, List<Skin> skins, ISorter<Skin> sorter)
    {
        _background = background;
        _skins = skins;

        _sorter = sorter;
    }

    public void ClearList()
    {
        foreach (Skin skin in _skins)
        {
            skin.SetUIVisibility(false);
        }
    }

    public void RefreshList()
    {
        Logger.Info("Refreshing list of skins");
        var display = _sorter.Sort(_skins);

        _background.VerticalScroll.Value = 0;

        int idx = 0;
        foreach (Skin skin in display)
        {
            skin.SetUIPosition(idx++);
            skin.SetUIVisibility(true);
        }

        _background.BackColor = display.Count() % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
    }
}
