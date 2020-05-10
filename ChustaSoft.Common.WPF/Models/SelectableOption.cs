using ChustaSoft.Common.Base;

namespace ChustaSoft.Common.Models
{

    public class SelectableOption : ViewModelBase
    {

        private bool _selected;
        public bool Selected
        {
            get 
            { 
                return _selected; 
            }
            set
            {
                _selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        private string _name;
        public string Name
        {
            get 
            { 
                return _name; 
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

    }


    public class SelectableOption<T> : SelectableOption 
    {

        private T _value;
        public T Value
        {
            get 
            { 
                return _value; 
            }
            set 
            { 
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

    }

}
