using System;
using System.Collections.Generic;

namespace Polyakov.Search
{
    public static class BinarySearch
    {
        public static int ExactMatch<T>(T[] source, T target) 
            where T : IComparable<T>
        {
            if (source is null || target is null)
                throw new ArgumentNullException();

            return Search(source, target, target);
        }

        public static List<T> Range<T>(T[] source, T from, T to) 
            where T : IComparable<T>
        {
            if (source is null || from is null || to is null)
                throw new ArgumentNullException();

            int inRange = Search(source, from, to);
            if (inRange == -1) 
                return new List<T>();

            return FindNearby(source, inRange, from, to);
        }

        private static int Search<T>(T[] source, T from, T to)
            where T : IComparable<T>
        {
            int left = 0;
            int right = source.Length;
            int middle = -1;
            int targetIndex = -1;

            Func<bool> isFound;
            if (from.Equals(to))
                isFound = () => source[middle].Equals(from);
            else
                isFound = () => !(source[middle].CompareTo(from) < 0) &&
                                !(source[middle].CompareTo(to) > 0);

            while (left < right)
            {
                middle = left + (right - left) / 2;

                if (isFound.Invoke())
                {
                    targetIndex = middle;
                    break;
                }
                if (source[middle].CompareTo(from) < 0)
                    left = middle + 1;
                else
                    right = middle;
            }

            return targetIndex;
        }

        private static List<T> FindNearby<T>(T[] source, int index, T from, T to)
            where T : IComparable<T>
        {
            int i = index;
            var result = new List<T>();

            while (i >= 0 &&
                   !(source[i].CompareTo(from) < 0))
            {
                result.Add(source[i]);
                i--;
            }
            i = index + 1;
            while (i < source.Length &&
                   !(source[i].CompareTo(to) > 0))
            {
                result.Add(source[i]);
                i++;
            }

            return result;
        }
    }
}
