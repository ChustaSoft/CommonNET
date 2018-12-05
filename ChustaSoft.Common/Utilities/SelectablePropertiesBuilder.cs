using ChustaSoft.Common.Models;
using System;
using System.Text;


namespace ChustaSoft.Common.Utilities
{

    public class SelectablePropertiesBuilder<T>
    {
        
        #region Fields

        private const char SEPARATOR_CHAR = ',';

        protected static SelectablePropertiesContext _context => SelectablePropertiesContext.Instance();

        #endregion


        #region Properties

        public int Count => _context.TotalCount;

        #endregion


        #region Constructor

        protected SelectablePropertiesBuilder() { }

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

            SelectablePropertiesContext.ResetContext();

            return stringBuilder.ToString();
        }

        #endregion


        #region Internal methods

        internal void AddSelected(PropertyInfo propertyInfo)
        {
            _context.Add(propertyInfo);
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

    public class SelectablePropertiesBuilder<TMain, TSub> : SelectablePropertiesBuilder<TMain>
    {
        
        #region Fields

        private const char NESTEDPROPERTY_CHAR = '.';

        private PropertyInfo _parentProperty;

        protected static SelectablePropertiesBuilder<TMain> _parentBuilder = InitBuilder();

        #endregion


        #region Constructor

        private SelectablePropertiesBuilder(PropertyInfo parentProperty)
        {
            _parentProperty = parentProperty;
        }

        public static SelectablePropertiesBuilder<TMain, TSub> InitBuilder(PropertyInfo parentProperty) => new SelectablePropertiesBuilder<TMain, TSub>(parentProperty);

        #endregion


        #region Public methods

        public SelectablePropertiesBuilder<TMain> GetParentBuilder() => _parentBuilder;

        #endregion


        #region Internal methods

        internal new void AddSelected(PropertyInfo propertyInfo)
        {
            propertyInfo.Name = _parentProperty.Name + NESTEDPROPERTY_CHAR + propertyInfo.Name;

            _context.Add(propertyInfo);
        }

        #endregion

    }

}
