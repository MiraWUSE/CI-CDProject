using System;
using System.Collections.Generic;

namespace ListOperationsLibrary
{
    /// Утилиты для безопасной работы со списками.
    /// Предоставляют упрощённый интерфейс, аналогичный операциям с массивами,
    /// с явной обработкой граничных случаев.
    public static class ListUtilities
    {
        /// Добавляет элемент в список.
        /// При некорректных данных выбрасывает информативное исключение.
        public static void SafeAdd<T>(List<T> list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "Целевой список не может быть равен null.");

            list.Add(item);
        }

        /// Удаляет первое вхождение элемента.
        /// Возвращает безопасное значение по умолчанию (false) при недопустимых данных.
        public static bool SafeRemove<T>(List<T> list, T item)
        {
            if (list == null || list.Count == 0)
                return false; // Безопасный дефолт для null/пустого списка

            return list.Remove(item);
        }

        /// Возвращает элемент по индексу.
        /// При выходе за границы или пустом списке возвращает default(T) вместо исключения.
        public static T SafeGetElementAt<T>(List<T> list, int index)
        {
            if (list == null || list.Count == 0)
                return default;

            if (index < 0 || index >= list.Count)
                return default; // Безопасное возвращаемое значение

            return list[index];
        }

        /// Ищет индекс первого вхождения элемента.
        /// Возвращает -1 при отсутствии элемента, пустом или null-списке.
        public static int SafeIndexOf<T>(List<T> list, T item)
        {
            if (list == null || list.Count == 0)
                return -1;

            return list.IndexOf(item);
        }

        /// Вставляет элемент по указанному индексу.
        /// Строго валидирует диапазон и выбрасывает исключение при ошибке.
        public static void SafeInsertAt<T>(List<T> list, int index, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list), "Список не может быть равен null.");

            if (index < 0 || index > list.Count)
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    $"Индекс должен быть в диапазоне от 0 до {list.Count}. Получено: {index}."
                );

            list.Insert(index, item);
        }

        /// Удаляет элемент по индексу и возвращает его.
        /// При недопустимых данных возвращает default(T).
        public static T SafeRemoveAt<T>(List<T> list, int index)
        {
            if (list == null || list.Count == 0 || index < 0 || index >= list.Count)
                return default;

            T removed = list[index];
            list.RemoveAt(index);
            return removed;
        }

        /// Проверяет наличие элемента. Безопасен для null и пустых коллекций.
        public static bool SafeContains<T>(List<T> list, T item)
        {
            if (list == null || list.Count == 0)
                return false;

            return list.Contains(item);
        }
    }
}