using lab12_2;
using AutomobileLibrary;
namespace lab12_2;

class Program
{
    static void Main(string[] args)
    {
        MyHashTable<Automobile> table = new MyHashTable<Automobile>();
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
                        Console.WriteLine("Размер таблицы? (по умолчанию 10)");
                        int size = IsInt(10, 100);
                        CreateTable(size, table);
                        break;
                    case 2:
                        table.PrintTable();
                        break;
                    case 3:
                        Automobile autoForSearch = new Automobile();
                        Console.WriteLine("Введите объект для поиска");
                        autoForSearch.Init();
                        Console.WriteLine("Таблица содержит данный объект объект: " + table.ContainsKey(autoForSearch));
                        break;
                    case 4:
                        Automobile autoForDelete = new Automobile();
                        Console.WriteLine("Введите объект для удаления");
                        autoForDelete.Init();
                        if (table.RemoveByKey(autoForDelete) == false)
                            Console.WriteLine("Элемент не найден в таблице");
                        else
                            Console.WriteLine("Удаление прошло успешно");
                        break;
                    case 5:
                        Console.WriteLine("Добавим в таблицу случайный элемент");
                        Automobile autoForAdd = new Automobile();
                        autoForAdd.RandomInit();
                        table.AddPoint(autoForAdd);
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
        Console.WriteLine("1. Создать таблицу");
        Console.WriteLine("2. Напечатать таблицу");
        Console.WriteLine("3. Поиск в таблице");
        Console.WriteLine("4. Удаление в таблице");
        Console.WriteLine("5. Добавление в таблицу");
        Console.WriteLine("6. Выход");
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

    static void CreateTable(int size, MyHashTable<Automobile> table)
    {
        Console.WriteLine("Введите 1, чтобы заполнить таблицу случайным образом" +
            "\nВведите 2, чтобы заполнить таблицу вручную");
        int choice = IsInt(1, 2);
        if (choice == 1)
        {
            for (int i = 0; i < size; i++)
            {
                Automobile autoForAdd = new Automobile();
                autoForAdd.RandomInit();
                table.AddPoint(autoForAdd);
            }
            table = new MyHashTable<Automobile>(size);
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                Automobile autoForAdd = new Automobile();
                autoForAdd.Init();
                table.AddPoint(autoForAdd);
            }
        }
        Console.WriteLine("Таблица создана");
    }
}

