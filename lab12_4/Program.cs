using System;
using AutomobileLibrary;
using lab12_4;

namespace lab12_4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<Automobile> collection = new MyCollection<Automobile>(0);
            int answer = 1;
            while (answer != 6)
            {
                try
                {
                    PrintMenu();
                    answer = IsInt(1, 6);
                    switch (answer)
                    {
                        case 1:
                            // создание коллекции
                            Console.WriteLine("Введите количество элементов коллекции");
                            collection = new MyCollection<Automobile>(IsInt(1, 100));
                            break;
                        case 2:
                            // печать коллекции
                            collection.PrintTable();
                            break;
                        case 3:
                            // добавление элемента
                            Automobile newItem = new Automobile();
                            newItem.RandomInit();
                            collection.AddPoint(newItem);
                            Console.WriteLine("\nПосле добавления элемента:");
                            collection.PrintTable();
                            break;
                        case 4:
                            // поиск элемента
                            Console.WriteLine("Введите элемент, наличие которого хотите проверить");
                            Automobile itemForSearch = new Automobile();
                            itemForSearch.Init();
                            bool containsNewItem = collection.Contains(itemForSearch);
                            Console.WriteLine($"\nКоллекция содержит объект: {containsNewItem}");
                            break;
                        case 5:
                            // удаление элемента
                            Console.WriteLine("Введите элемент, который хотите удалить");
                            Automobile itemForRemove = new Automobile();
                            itemForRemove.Init();
                            collection.RemoveData(itemForRemove);
                            Console.WriteLine("\nПосле удаления элемента:");
                            collection.PrintTable();
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
            Console.WriteLine("1. Создать коллекцию");
            Console.WriteLine("2. Напечатать коллекцию");
            Console.WriteLine("3. Добавить элемент в коллекцию");
            Console.WriteLine("4. Найти элемент в коллекции");
            Console.WriteLine("5. Удалить элемент из коллекции");
            Console.WriteLine("6. Выход");
        }

        static int IsInt(int min, int max)
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
