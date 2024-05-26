using lab12_3;
using AutomobileLibrary;
namespace lab12_3;

class Program
{
    static void PrintMenu()
    {
        Console.WriteLine("1. Создать ИСД");
        Console.WriteLine("2. Напечатать дерево");
        Console.WriteLine("3. Преобразовать ИСД в дерево поиска");
        Console.WriteLine("4. Поиск минимального элемента в дереве");
        Console.WriteLine("5. Удалить из дерева поиска элемент с заданным ключом");
        Console.WriteLine("6. Удалить дерево и выйти");
    }

    static int IsInt(int min, int max) //функция для проверки на Int (параметры - минимальное и максимальное значение)
    {
        bool isConvert;
        int number;
        do
        {
            string buf = Console.ReadLine(); // Чтение ввода пользователя
            isConvert = int.TryParse(buf, out number);// Проверка на корректность ввода
            if (!isConvert || number < min || number > max)
            {
                Console.WriteLine($"Неправильно введено число. Введите значение от {min} до {max}");
            }
        } while (!isConvert || number < min || number > max);
        return number;// Возвращение корректного числа
    }

    static void Main(string[] args)
    {
        MyTree<Automobile> tree = null; // создание 
        int answer = 1;
        while (answer != 6)
        {
            try
            {
                PrintMenu(); // Вывод меню
                answer = IsInt(1, 6);// Получение выбора пользователя
                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Введите количество элементов в дереве:");
                        int length = IsInt(1, 100);// Получение количества элементов для создания дерева
                        tree = new MyTree<Automobile>(length); // создание дерева
                        Console.WriteLine("Дерево успешно создано.");
                        break;
                    case 2:
                        if (tree == null) // проверка на существование дерева
                            Console.WriteLine("Дерево пусто, сначала создайте его");
                        else
                            tree.ShowTree(); // вывод дерева
                        break;
                    case 3:
                        if (tree == null) // проверка на существование дерева
                        {
                            Console.WriteLine("Дерево пусто, сначала создайте его"); 
                            continue;
                        }
                        Console.WriteLine("Дерево до преобразования:");
                        tree.ShowTree(); // отображение текущего дерева

                        tree.TransformToFindTree(); // применение метода для преобразования в поисковое дерево

                        Console.WriteLine("\nДерево после преобразования в дерево поиска:");
                        tree.ShowTree(); // отображение дерева послеперобразования
                        break;
                    case 4:
                        if (tree == null)// проверка на существование дерева
                        {
                            Console.WriteLine("Дерево пусто, сначала создайте его");
                            continue;
                        }
                        Automobile minInstrument = tree.FindMax();
                        Console.WriteLine("Минимальный элемент:");
                        minInstrument.Show();
                        break;
                    case 5:
                        if (tree == null) // проверка на существование дерева
                        {
                            Console.WriteLine("Дерево пусто, сначала создайте его");
                            continue;
                        }
                        Console.Write("Введите ключ для удаления: ");
                        Automobile key = new Automobile();
                        key.Init();
                        if (tree.Remove(key))
                            Console.WriteLine($"Элемент с ключом {key} успешно удален.");
                        else
                            Console.WriteLine($"Элемент с ключом {key} не найден.");
                        break;
                    case 6:
                        if (tree == null) // проверка на существование дерева
                        {
                            Console.WriteLine("Дерево не было создано, программа завершает работу");
                            continue;
                        }
                        tree.RemoveTree(); // удаление дерева
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);// Обработка исключений
            }
        }
    }

    
}

