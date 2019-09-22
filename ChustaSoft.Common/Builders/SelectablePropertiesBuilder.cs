using ChustaSoft.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace ChustaSoft.Common.Builders
{

    public class SelectablePropertiesBuilder<T>
    {

        #region Fields

        private const char SEPARATOR_CHAR = ',';

        #endregion


        #region Properties

        protected SelectablePropertiesContext Context { get; set; }

        public int Count => Context.TotalCount;

        #endregion


        #region Constructor

        protected SelectablePropertiesBuilder()
        {
            Context = new SelectablePropertiesContext();
        }

        public static SelectablePropertiesBuilder<T> InitBuilder() => new SelectablePropertiesBuilder<T>();


        #endregion


        #region Public methods

        public static T GetProperties() => (T)Activator.CreateInstance(typeof(T));


        public string FormatSelection()
        {
            var stringBuilder = new StringBuilder();

            IteratePropertiesForBuilder(stringBuilder);

            return stringBuilder.ToString();
        }

        public IList<PropertyInfo> GetSelection()
        {
            return Context.PropertiesSelected;
        }

        #endregion


        #region Internal methods

        internal void AddSelected(PropertyInfo propertyInfo)
        {
            Context.Add(propertyInfo);
        }

        internal void AddSelected(IList<PropertyInfo> propertyInfoList)
        {
            Context.AddRange(propertyInfoList);
        }

        #endregion


        #region Private methods

        private void IteratePropertiesForBuilder(StringBuilder stringBuilder)
        {
            int currentIndex = 1, totalCount = Context.PropertiesSelected.Count;

            foreach (var prop in Context.PropertiesSelected)
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

        private SelectablePropertiesBuilder<TMain> _parentContext;

        #endregion


        #region Constructor

        private SelectablePropertiesBuilder(SelectablePropertiesBuilder<TMain> parentContext, PropertyInfo parentProperty)
        {
            _parentContext = parentContext;
            _parentProperty = parentProperty;
        }

        public static SelectablePropertiesBuilder<TMain, TSub> InitBuilder(SelectablePropertiesBuilder<TMain> parentContext, PropertyInfo parentProperty) 
            => new SelectablePropertiesBuilder<TMain, TSub>(parentContext, parentProperty);

        #endregion


        #region Public methods

        public SelectablePropertiesBuilder<TMain> BackToParent()
        {
            UpdateParentContext();

            return _parentContext;
        }

        public new IList<PropertyInfo> GetSelection()
        {
            UpdateParentContext();
            
            return _parentContext.GetSelection();
        }

        #endregion


        #region Internal methods

        internal new void AddSelected(PropertyInfo propertyInfo)
        {
            propertyInfo.Name = _parentProperty.Name + NESTEDPROPERTY_CHAR + propertyInfo.Name;

            Context.Add(propertyInfo);
        }

        #endregion


        #region Private methods

        private void UpdateParentContext()
        {
            _parentContext.AddSelected(base.GetSelection());
        }

        #endregion

    }

}
