using System.Collections;
using System.Collections.Generic;


namespace ChustaSoft.Common.Utilities
{

    /// <summary>
    /// ThreadSafe Implementation based on lock
    /// Faster than ConcurrentBag
    /// </summary>
    /// <typeparam name="T">Object type inside collection</typeparam>
    public class ThreadSafeList<T> : IList<T>
    {

        #region Fields

        private IList<T> _internalList = new List<T>();
        private readonly object _lockList = new object();

        #endregion


        #region Properties

        public T this[int index]
        {
            get
            {
                lock (_lockList)
                {
                    return _internalList[index];
                }
            }
            set
            {
                lock (_lockList)
                {
                    _internalList[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                lock (_lockList)
                {
                    return _internalList.Count;
                }
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion


        #region Public methods

        public void Add(T item)
        {
            lock (_lockList)
            {
                _internalList.Add(item);
            }
        }

        public void Add(List<T> aElements)
        {
            lock (_lockList)
            {
                foreach (var iElement in aElements)
                {
                    _internalList.Add(iElement);
                }
            }
        }

        public void Clear()
        {
            lock (_lockList)
            {
                _internalList.Clear();
            }
        }

        public bool Contains(T item)
        {
            lock (_lockList)
            {
                return _internalList.Contains(item);
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (_lockList)
            {
                _internalList.CopyTo(array, arrayIndex);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Clone().GetEnumerator();
        }

        public int IndexOf(T item)
        {
            lock (_lockList)
            {
                return _internalList.IndexOf(item);
            }
        }

        public void Insert(int index, T item)
        {
            lock (_lockList)
            {
                _internalList.Insert(index, item);
            }
        }

        public bool Remove(T item)
        {
            lock (_lockList)
            {
                return _internalList.Remove(item);
            }
        }

        public void RemoveAt(int index)
        {
            lock (_lockList)
            {
                _internalList.RemoveAt(index);
            }
        }

        public List<T> Clone()
        {
            lock (_lockList)
            {
                return new List<T>(_internalList);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => Clone().GetEnumerator();
        
        #endregion

    }
}
