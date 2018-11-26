using ChustaSoft.Common.Models;


namespace ChustaSoft.Common.Utilities
{
    public interface ISelectablePropertiesBuilder<T>
    {

        char GetSeparator { get; }

        int Count { get; }


        void AddSelected(PropertyInfo propertyInfo);

        string FormatSelection();

    }
}