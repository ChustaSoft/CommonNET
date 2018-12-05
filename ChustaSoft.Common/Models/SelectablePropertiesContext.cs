using System.Collections.Generic;


namespace ChustaSoft.Common.Models
{
    public class SelectablePropertiesContext
    {

        #region Fields

        private static SelectablePropertiesContext _instance;

        #endregion

        
        #region Properties

        public List<PropertyInfo> PropertiesSelected { get; private set; }

        public int TotalCount => PropertiesSelected.Count;

        #endregion


        #region Constructor

        private SelectablePropertiesContext()
        {
            PropertiesSelected = new List<PropertyInfo>();
        }

        public static SelectablePropertiesContext Instance()
        {
            if (_instance == null)
                _instance = new SelectablePropertiesContext();

            return _instance;
        }

        public static void ResetContext() => _instance = new SelectablePropertiesContext();

        #endregion


        #region Public methods

        public void Add(PropertyInfo propertyInfo)
        {
            PropertiesSelected.Add(propertyInfo);
        }

        #endregion

    }
}
