using System.ComponentModel;

namespace ChustaSoft.Common.Base
{
    /// <summary>
    /// ViewModelBase, implementing INotifyPropertyChanged interface
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged 
    {

        public event PropertyChangedEventHandler PropertyChanged;


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    /// <summary>
    /// ViewModelBase for generic Models. Internally contains a generic Model isolating this from the main ViewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ViewModelBase<T> : ViewModelBase
        where T : new()
    {

        private T _model;
        public T Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged(nameof(Model));
            }
        }

        protected ViewModelBase()
        {
            Model = new T();
        }

    }
}
