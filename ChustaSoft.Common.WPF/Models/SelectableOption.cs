﻿using ChustaSoft.Common.Wpf.Base;

namespace ChustaSoft.Common.Wpf.Models
{
    public class SelectableOption : ViewModelBase
    {

        private bool _Selected;
        public bool Selected
        {
            get { return _Selected; }
            set
            {
                _Selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

    }
}
