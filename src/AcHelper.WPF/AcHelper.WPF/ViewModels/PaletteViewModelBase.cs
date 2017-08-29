﻿using GalaSoft.MvvmLight;

namespace AcHelper.WPF.ViewModels
{
    using System;
    using Themes;

    public abstract class PaletteViewModelBase : ViewModelBase
    {
        private readonly ThemeManager _themeManager;
        public PaletteViewModelBase()
        {
            _themeManager = ThemeManager.Current;
            _theme = _themeManager.CadThemeWatcher.CurrentCadTheme;
            MessengerInstance.Register<string>(this, Constants.ThemeChangedToken, ChangeTheme);
        }

        private void ChangeTheme(string theme)
        {
            Theme = theme;
        }

        /// <summary>
        /// The <see cref="Theme" /> property's name.
        /// </summary>
        public const string ThemePropertyName = "Theme";

        private string _theme;

        /// <summary>
        /// Sets and gets the Theme property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                Set(ThemePropertyName, ref _theme, value);
            }
        }
    }
}