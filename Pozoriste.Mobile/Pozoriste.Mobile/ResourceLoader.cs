﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Text;

namespace Pozoriste.Mobile
{
    public class ResourceLoader : INotifyPropertyChanged
    {
        private readonly ResourceManager manager;
        private CultureInfo cultureInfo;

        public ResourceLoader(ResourceManager resourceManager)
        {
            this.manager = resourceManager;
            Instance = this;
            this.cultureInfo = CultureInfo.CurrentUICulture;
        }

        public static ResourceLoader Instance { get; private set; }

        public string GetString(string resourceName)
        {
            string stringRes = this.manager.GetString(resourceName, this.cultureInfo);
            return stringRes;
        }

        public string this[string key] => this.GetString(key);

        public void SetCultureInfo(CultureInfo cultureInfo)
        {
            this.cultureInfo = cultureInfo;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
