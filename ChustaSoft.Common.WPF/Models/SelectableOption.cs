using ChustaSoft.Common.Base;

namespace ChustaSoft.Common.Models
{

    public class SelectableOption<T> : ViewModelBase
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

        private T _name;
        public T Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

    }


    public class SelectableOption : SelectableOption<string> { }

}
