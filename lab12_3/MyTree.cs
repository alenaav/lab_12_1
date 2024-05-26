using System;
using System.Diagnostics.CodeAnalysis;
using AutomobileLibrary;

namespace lab12_3
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        // Корневой узел дерева
        public Point<T>? root = null;

        // Количество узлов в дереве
        int count = 0;

        // Публичное свойство для получения количества узлов
        public int Count => count;

        // Конструктор, который инициализирует дерево с заданным количеством узлов
        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        // Метод для отображения дерева (для отладки, исключен из покрытия кода)
        [ExcludeFromCodeCoverage]
        public void ShowTree()
        {
            Show(root);//root - публичное поле, что означает, что оно доступно для чтения и записи извне класса.
        }

        // Метод для создания сбалансированного дерева с заданной длиной
        public Point<T>? MakeTree(int length, Point<T>? point)
        {
            // Создание нового экземпляра T и его инициализация
            T data = new T();//должен реализовывать интерфейсы IInit и IComparable, а также иметь конструктор по умолчанию
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);// создание нового узла

            // Базовый случай: если длина равна нулю, возвращаем null
            if (length == 0)
            {
                return null;
            }

            // Вычисление длины левого и правого поддеревьев
            int nl = length / 2;
            int nr = length - nl - 1;

            // Рекурсивное создание левого и правого поддеревьев
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }

        // Вспомогательный метод для отображения дерева рекурсивно (для отладки, исключен из покрытия кода)
        [ExcludeFromCodeCoverage]
        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5); // Рекурсивно показываем левое поддерево
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5); // Рекурсивно показываем правое поддерево
            }
        }

        // Метод для добавления новой точки в дерево
        public void AddPoint(T data)
        {
            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;

            // Поиск корректной позиции для вставки новой точки
            while (point != null && !isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0) { isExist = true; }
                else
                {
                    if (point.Data.CompareTo(data) < 0) { point = point.Left; }
                    else { point = point.Right; }
                }
            }

            // Если точка уже существует, ничего не делаем
            if (isExist) { return; }

            // Создание новой точки и вставка её на корректную позицию
            Point<T> newPoint = new Point<T>(data);
            if (current.Data.CompareTo(data) < 0)
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }

        // Вспомогательный метод для преобразования дерева в массив
        public void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current); // Обход левого поддерева
                array[current] = point.Data; // Добавление данных текущей точки в массив
                current++;
                TransformToArray(point.Right, array, ref current); // Обход правого поддерева
            }
        }

        // Метод для преобразования текущего дерева в дерево поиска
        // В дереве поиск не может быть повторяющихся элементов (пропадают машины одинакового бренда)
        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current); // Преобразование дерева в массив

            root = new Point<T>(array[0]); // Переинициализация корня с первым элементом
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]); // Добавление каждого элемента обратно в дерево
            }
        }

        // Метод для нахождения максимального значения в дереве (для отладки, исключен из покрытия кода)
        [ExcludeFromCodeCoverage]
        public T FindMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            Point<T>? current = root;
            while (current.Right != null)
            {
                current = current.Right; // Переход к правому крайнему узлу
            }

            return current.Data;
        }

        // Метод для удаления всех узлов из дерева
        public void RemoveTree()
        {
            root = null;
            count = 0;
        }

        // Метод для удаления узла с определённым ключом из дерева
        public bool Remove(T key)
        {
            if (root == null)
                return false;

            Point<T> parent = null;
            Point<T> current = root;

            // Поиск удаляемого узла и его родителя
            while (current != null)
            {
                int comparisonResult = key.CompareTo(current.Data);
                if (comparisonResult == 0)
                    break;
                else
                {
                    parent = current;
                    if (comparisonResult < 0)
                        current = current.Left;
                    else
                        current = current.Right;
                }
            }

            // Если узел не найден
            if (current == null)
                return false;

            // Случай 1: Узел - лист
            if (current.Left == null && current.Right == null)
            {
                if (parent == null)
                    root = null;
                else if (parent.Left == current)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            // Случай 2: Узел имеет одного потомка
            else if (current.Left == null || current.Right == null)
            {
                Point<T> child = current.Left ?? current.Right;
                if (parent == null)
                    root = child;
                else if (parent.Left == current)
                    parent.Left = child;
                else
                    parent.Right = child;
            }
            // Случай 3: Узел имеет двух потомков
            else
            {
                Point<T> successorParent = current;
                Point<T> successor = current.Right;
                while (successor.Left != null)
                {
                    successorParent = successor;
                    successor = successor.Left;
                }

                // Замена данных текущего узла на данные преемника
                current.Data = successor.Data;

                // Удаление преемника из правого поддерева
                if (successorParent.Left == successor)
                    successorParent.Left = successor.Right;
                else
                    successorParent.Right = successor.Right;
            }

            count--;
            return true;
        }
    }
}
