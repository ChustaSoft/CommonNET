using System.Collections.Generic;


namespace ChustaSoft.Common.Models
{
    public class SelectablePropertiesContext
    {

        #region Properties

        public List<PropertyInfo> PropertiesSelected { get; private set; }

        public int TotalCount => PropertiesSelected.Count;

        #endregion


        #region Constructor

        public SelectablePropertiesContext()
        {
            PropertiesSelected = new List<PropertyInfo>();
        }

        #endregion


        #region Public methods

        public void Add(PropertyInfo propertyInfo)
        {
            PropertiesSelected.Add(propertyInfo);
        }

        public void AddRange(IList<PropertyInfo> propertyInfoList)
        {
            PropertiesSelected.AddRange(propertyInfoList);
        }

        #endregion

    }
}
