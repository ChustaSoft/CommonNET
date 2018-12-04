using ChustaSoft.Common.Constants;
using System.Collections.Generic;
using System.Linq;


namespace ChustaSoft.Common.Models
{
    public class SelectablePropertiesContext
    {

        #region Fields

        private static SelectablePropertiesContext _instance;

        #endregion

        
        #region Properties

        public Queue<List<PropertyInfo>> PropertiesSelectionQueue { get; private set; }

        public List<PropertyInfo> PropertiesSelected { get; private set; }

        public int TotalCount => PropertiesSelectionQueue.Sum(x => x.Count) + PropertiesSelected.Count;

        #endregion


        #region Constructor

        private SelectablePropertiesContext()
        {
            PropertiesSelectionQueue = new Queue<List<PropertyInfo>>();
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

        public void Queue(PropertyInfo propertyInfo)
        {
            PropertiesSelectionQueue.Enqueue(PropertiesSelected);

            PropertiesSelected = new List<PropertyInfo>();

            Add(propertyInfo);
        }

        #endregion

    }
}
