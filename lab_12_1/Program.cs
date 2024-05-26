using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary;

namespace lab_12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<Automobile> list = new MyList<Automobile>();
            int answer = 1;
            while (answer != 7)
            {
                try
                {
                    PrintMenu();
                    answer = IsInt(1, 7);
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Размер списка? (от 0 до 100)");
                            int size = IsInt(0, 100);
                            list = new MyList<Automobile>(size);
                            Console.WriteLine("Список создан");
                            break;
                        case 2:
                            list.PrintList();
                            break;
                        case 3:
                            Console.WriteLine("Введите количество элементов для добавления (с нечетными номерами):");
                            int countToAdd = IsInt(1, 50); // Предполагаем, что это количество элементов для добавления
                            list.AddElementsWithOddIndices(countToAdd);
                            Console.WriteLine($"Добавлено {countToAdd} элементов с нечетными номерами");
                            break;
                        case 4:
                            Console.WriteLine("Введите информационное поле для удаления элементов:");
                            int fieldToDelete = IsInt(0, 1000000); // Предполагаем, что это цена для автомобиля
                            list.RemoveFromItemToEnd(item => item.Price == fieldToDelete);
                            Console.WriteLine("Элементы удалены");
                            break;
                        case 5:
                            MyList<Automobile> clonedList = list.Clone(); // создание глубокой копии списка
                            clonedList.PrintList();
                            break;
                        case 6:
                            list.Clear();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("1. Создать список");
            Console.WriteLine("2. Напечатать список");
            Console.WriteLine("3. Добавить в список элементы с номерами 1, 3, 5 и т. д.");
            Console.WriteLine("4. Удалить из списка все элементы, начиная с элемента с заданным информационным полем (например, с заданным именем), и до конца списка");
            Console.WriteLine("5. Склонировать список");
            Console.WriteLine("6. Удалить список");
            Console.WriteLine("7. Выход");
        }

        static int IsInt(int min, int max) //функция для проверки на Int (параметры - минимальное и максимальное значение)
        {
            bool isConvert;
            int number;
            do
            {
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out number);
                if (!isConvert || number < min || number > max)
                {
                    Console.WriteLine($"Неправильно введено число. Введите значение от {min} до {max}");
                }
            } while (!isConvert || number < min || number > max);
            return number;
        }
    }
}