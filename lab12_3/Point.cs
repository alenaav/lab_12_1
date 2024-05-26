using System;
using System.Diagnostics.CodeAnalysis;
namespace lab12_3
{
    public class Point<T> where T : IComparable
    {
        // Данные, хранящиеся в узле
        public T? Data { get; set; }

        // Левый потомок узла
        public Point<T>? Left { get; set; }

        // Правый потомок узла
        public Point<T>? Right { get; set; }

        // Конструктор без параметров, инициализирует узел со значением по умолчанию
        public Point()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
        }

        // Конструктор, инициализирующий узел с заданными данными
        public Point(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        // Переопределение метода ToString для вывода данных узла (исключен из покрытия кода)
        [ExcludeFromCodeCoverage]
        public override string? ToString()
        {
            if (Data == null)
                return "";
            else
                return Data.ToString();
        }

        // Метод для сравнения текущего узла с другим узлом по значению Data
        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}