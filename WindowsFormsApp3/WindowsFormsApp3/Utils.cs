using System.Collections.Generic;

namespace WindowsFormsApp3
{
    class Utils
    {
        public static string listToString(List<int> entries)
        {
            string sortingEntries = "";
            foreach (int i in entries)
            {
                sortingEntries += i + ",";
            }
            if (sortingEntries.Length > 0)
            {
                sortingEntries = sortingEntries.Substring(0, sortingEntries.Length - 1);
            }
            return sortingEntries;
        }
    }
}