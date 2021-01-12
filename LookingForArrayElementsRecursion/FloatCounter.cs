using System;

namespace LookingForArrayElementsRecursion
{
    public static class FloatCounter
    {
        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException($"Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
            }

            return GetResult(arrayToSearch, rangeStart, rangeEnd, count: arrayToSearch.Length);
        }

        /// <summary>
        /// Searches an array of floats for elements that are in a specified range, and returns the number of occurrences of the elements that matches the range criteria.
        /// </summary>
        /// <param name="arrayToSearch">One-dimensional, zero-based <see cref="Array"/> of single-precision floating-point numbers.</param>
        /// <param name="rangeStart">One-dimensional, zero-based <see cref="Array"/> of the range starts.</param>
        /// <param name="rangeEnd">One-dimensional, zero-based <see cref="Array"/> of the range ends.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The number of occurrences of the <see cref="Array"/> elements that match the range criteria.</returns>
        public static int GetFloatsCount(float[] arrayToSearch, float[] rangeStart, float[] rangeEnd, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length != rangeEnd.Length)
            {
                throw new ArgumentException($"Method throws ArgumentException in case an arrays of range starts and range ends contain different number of elements.");
            }

            if (startIndex > arrayToSearch.Length || startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            return GetResult(arrayToSearch, rangeStart, rangeEnd, startIndex, count);
        }

        public static int GetResult(
                                    float[] arrayToSearch,
                                    float[] rangeStart,
                                    float[] rangeEnd,
                                    int startIndex = 0,
                                    int count = 0,
                                    int result = 0,
                                    int i = 0)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (rangeStart is null)
            {
                throw new ArgumentNullException(nameof(rangeStart));
            }

            if (rangeEnd is null)
            {
                throw new ArgumentNullException(nameof(rangeEnd));
            }

            if (rangeStart.Length > i)
            {
                if (rangeStart[i] > rangeEnd[i])
                {
                    throw new ArgumentException("Method throws ArgumentException in case the range start value is greater than the range end value.");
                }

                result += SearchInArray(arrayToSearch, rangeStart[i], rangeEnd[i], startIndex, count);
                i++;
                return GetResult(arrayToSearch, rangeStart, rangeEnd, startIndex, count, result, i);
            }

            return result;
        }

        public static int SearchInArray(
                                        float[] arrayToSearch,
                                        float start,
                                        float end,
                                        int i,
                                        int count,
                                        int result = 0)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }

            if (count > 0)
            {
                if (arrayToSearch[i] >= start && arrayToSearch[i] <= end)
                {
                    result++;
                }

                count--;
                i++;
                return SearchInArray(arrayToSearch, start, end, i, count, result);
            }

            return result;
        }
    }
}
