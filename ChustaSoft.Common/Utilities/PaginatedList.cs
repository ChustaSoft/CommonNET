using ChustaSoft.Common.Constants;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


namespace ChustaSoft.Common.Utilities
{

    /// <summary>/// 
    /// IReadOnlyList list implementation for Paginated collections
    /// Creation could be done by using his constructor or using CollectionsHelper Paginate method
    /// <seealso cref="CollectionsHelper.Paginate"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Name = SerializedNames.PaginatedList)]
    public class PaginatedList<T> : IReadOnlyList<T>
    {

        #region Fields

        private readonly T[] _data;

        #endregion


        #region Properties

        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int TotalCount { get; private set; }

        [DataMember]
        public int TotalPages
        {
            get
            {
                var fullPages = TotalCount / PageSize;
                var partialPages = ((TotalCount % PageSize) > 0) ? 1 : 0;

                return fullPages + partialPages;
            }
        }

        public int Count => _data.Count();

        public T this[int index] => _data[index];

        #endregion


        #region Constructors

        public PaginatedList(IEnumerable<T> values, int totalCount, int pageIndex)
        {
            _data = values.ToArray();
            TotalCount = totalCount;
            PageSize = values.Count();
            PageIndex = pageIndex;
        }

        #endregion


        #region Public methods

        public IEnumerator<T> GetEnumerator() => _data.ToList().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
        
        #endregion

    }
}
