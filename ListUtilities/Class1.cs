using System;
using System.Collections.Generic;

namespace ListOperationsLibrary
{
    public static class ListUtilities
    {
        public static void SafeAdd<T>(List<T> list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "Целевой список не может быть равен null.");

            list.Add(item);
        }

       public static bool SafeRemove<T>(List<T> list, T item)
        {
            if (list == null || list.Count == 0)
                return false; 

            return list.Remove(item);
        }

        public static T SafeGetElementAt<T>(List<T> list, int index)
        {
            if (list == null || list.Count == 0)
                return default;

            if (index < 0 || index >= list.Count)
                return default;
            return list[index];
        }

        public static int SafeIndexOf<T>(List<T> list, T item)
        {
            if (list == null || list.Count == 0)
                return -1;

            return list.IndexOf(item);
        }

        public static void SafeInsertAt<T>(List<T> list, int index, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "Список не может быть равен null.");

            if (index < 0 || index > list.Count)
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс должен быть в диапазоне от 0 до {list.Count}. Получено: {index}."
                );

            list.Insert(index, item);
        }

        public static T SafeRemoveAt<T>(List<T> list, int index)
        {
            if (list == null || list.Count == 0 || index < 0 || index >= list.Count)
                return default;

            T removed = list[index];
            list.RemoveAt(index);
            return removed;
        }

        public static bool SafeContains<T>(List<T> list, T item)
        {
            if (list == null || list.Count == 0)
                return false;

            return list.Contains(item);
        }
    }
}