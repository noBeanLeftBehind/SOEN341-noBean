using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOEN341_nobean.Class
{
    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
    {
        #region IComparer<TKey> Members

        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return -1;   // Adds the course with the same priority right after each other (puts it in the order it is added)
            else
                return result;
        }
    }
}
        #endregion