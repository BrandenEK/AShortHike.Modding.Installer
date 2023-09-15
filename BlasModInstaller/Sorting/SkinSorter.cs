﻿using BlasModInstaller.Skins;
using BlasModInstaller.UIHolding;
using System.Collections.Generic;

namespace BlasModInstaller.Sorting
{
    internal class SkinSorter : ISorter
    {
        private readonly IUIHolder _uiHolder;
        private readonly List<Skin> _skins;

        public SkinSorter(IUIHolder uiHolder, List<Skin> skins)
        {
            _uiHolder = uiHolder;
            _skins = skins;
        }

        public void Sort()
        {
            _skins.Sort();

            _uiHolder.SectionPanel.VerticalScroll.Value = 0;

            int idx = 0;
            foreach (Skin skin in _skins)
            {
                skin.SetUIPosition(idx++);
            }
        }
    }
}