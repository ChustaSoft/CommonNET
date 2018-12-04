using ChustaSoft.Common.Models;
using System;
using System.Text;


namespace ChustaSoft.Common.Utilities
{

    public class SelectablePropertiesBuilder<T>
    {
        
        #region Fields

        private const char SEPARATOR_CHAR = ',';
        private const char NESTEDPROPERTY_CHAR = '.';

        private PropertyInfo _parentProperty;

        private static SelectablePropertiesContext _context => SelectablePropertiesContext.Instance();

        #endregion


        #region Properties

        public int Count => _context.TotalCount;

        #endregion


        #region Constructor

        private SelectablePropertiesBuilder() { }

        public static SelectablePropertiesBuilder<T> InitBuilder() => new SelectablePropertiesBuilder<T>();

        #endregion


        #region Public static methods

        public static T GetProperties() => (T)Activator.CreateInstance(typeof(T));

        #endregion


        #region Public methods

        public string FormatSelection()
        {
            var stringBuilder = new StringBuilder();

            IteratePropertiesForBuilder(stringBuilder);
            
            return stringBuilder.ToString();
        }

        #endregion


        #region Internal methods

        internal void AddSelected(PropertyInfo propertyInfo)
        {
            if(_parentProperty != null)
                _parentProperty.Name  = _parentProperty.Name + NESTEDPROPERTY_CHAR + propertyInfo.Name;

            _context.Add(propertyInfo);
        }

        internal void QueueSelected(PropertyInfo propertyInfo)
        {
            _parentProperty = propertyInfo;

            _context.Queue(propertyInfo);
        } 

        #endregion


        #region Private methods

        private void IteratePropertiesForBuilder(StringBuilder stringBuilder)
        {
            int currentIndex = 1, totalCount = _context.PropertiesSelected.Count;

            foreach (var prop in _context.PropertiesSelected)
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
