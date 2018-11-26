using ChustaSoft.Common.Models;
using System.Collections.Generic;
using System.Text;


namespace ChustaSoft.Common.Utilities
{

    public class SelectablePropertiesBuilder<T> : ISelectablePropertiesBuilder<T>
    {
        
        #region Fields

        private const char SEPARATOR_CHAR = ',';

        private List<PropertyInfo> _propertiesSelected;

        #endregion

        
        #region Properties

        public char GetSeparator => SEPARATOR_CHAR;

        public int Count => _propertiesSelected.Count;

        #endregion


        #region Constructor

        public SelectablePropertiesBuilder()
        {
            _propertiesSelected = new List<PropertyInfo>();
        }

        #endregion

        
        #region Public methods

        public void AddSelected(PropertyInfo propertyInfo)
        {
            _propertiesSelected.Add(propertyInfo);
        }

        public string FormatSelection()
        {
            var stringBuilder = new StringBuilder();

            IteratePropertiesForBuilder(stringBuilder);

            return stringBuilder.ToString();
        }

        #endregion


        #region Private methods

        private void IteratePropertiesForBuilder(StringBuilder stringBuilder)
        {
            int currentIndex = 1, totalCount = _propertiesSelected.Count;

            foreach (var prop in _propertiesSelected)
            {
                stringBuilder.Append(prop.Name);

                if (currentIndex < totalCount)
                    stringBuilder.Append(SEPARATOR_CHAR);

                currentIndex++;
            }
        }

        #endregion

    }
}
