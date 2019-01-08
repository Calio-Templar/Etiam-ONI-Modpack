﻿using System.Collections.Generic;

namespace MaterialColor.Data
{
    public class MaterialColorState
    {
        public bool Enabled { get; set; } = true;

        public bool LogElementsData { get; set; } = true;

        public bool ShowMissingElementColorInfos { get; set; }

        public FilterInfo TypeFilterInfo { get; set; } = new FilterInfo();
    }
}