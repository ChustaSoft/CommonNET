using ChustaSoft.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace ChustaSoft.Common.Helpers
{
    public static class SelectableOptionExtensions
    {

        /// <summary>
        /// Get selected names from an IEnumerable of SelectableOption
        /// </summary>
        /// <param name="selectableOptions">IEnumerable list containing options</param>
        /// <returns>Names with Selected as true from the IEnumerable</returns>
        public static IEnumerable<string> GetSelected(this IEnumerable<SelectableOption> selectableOptions) 
        { 
            return selectableOptions.Where(x => x.Selected).Select(x => x.Name);
        }

        /// <summary>
        /// Get selected values from an IEnumerable of Generic SelectableOption
        /// </summary>
        /// <typeparam name="T">Generic value</typeparam>
        /// <param name="selectableOptions">IEnumerable list containing options</param>
        /// <returns>Values with Selected as true from the IEnumerable</returns>
        public static IEnumerable<T> GetSelected<T>(this IEnumerable<SelectableOption<T>> selectableOptions)
        {
            return selectableOptions.Where(x => x.Selected).Select(x => x.Value);
        }

    }
}
