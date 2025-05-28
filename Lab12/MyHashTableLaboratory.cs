namespace Lab12;
using Lab10;
using static AdditionalFunctions.AdditionalFunctions;
using static ElementGeneratorClass;

public class MyHashTableLaboratory
{
    private static void MenuHashTable()
    {
        Console.WriteLine("1. Вывести элементы таблицы");
        Console.WriteLine("2. Добавить элемент по ID муз. инструмента");
        Console.WriteLine("3. Найти элемент по ID");
        Console.WriteLine("4. Удалить элемент по ID");
        Console.WriteLine("5. Очистить таблицу");
        Console.WriteLine("6. Выход");
    }
    
    public static void Experiments()
        {
            Console.WriteLine("Экспериментальная зона: Хеш-таблица (Метод цепочек)");
            Console.WriteLine("MyHashTable<int, MusicalInstrument>");
            TextSeparator();
            
            MyHashTable<int, MusicalInstrument> hashTable = new MyHashTable<int, MusicalInstrument>();

            MusicalInstrument instrument;
            int key;
            bool isNeedExit = false;

            while (!isNeedExit)
            {
                MenuHashTable();
                Console.Write("Введите команду: ");
                string input = Console.ReadLine();
                TextSeparator();

                switch (input)
                {
                    case "1":
                        if (hashTable.Count == 0)
                        {
                            Console.WriteLine("Таблица пуста!");
                            break;
                        }
                        Console.WriteLine("Хеш-таблица:");
                        hashTable.PrintHashTable();
                        break;

                    case "2": 
                        Console.WriteLine("Добавление элемента в таблицу");
                        instrument = ElementGenerator();

                        if (instrument.Equals(new MusicalInstrument()))
                        {
                            Console.WriteLine("Элемент не добавлен!");
                            break;
                        }

                        key = instrument.Id.Id; 
                        hashTable.Add(key, instrument);
                        Console.WriteLine($"Элемент {instrument.Name} с ID = {key} добавлен!");
                        break;

                    case "3":
                        Console.Write("Введите ID элемента для поиска: ");
                        key = CorrectPositiveIntegerInput();
                        PointHS<int, MusicalInstrument>? findedElement = hashTable.SearchElemnt(key);
                        
                        if (findedElement != null)
                            Console.WriteLine($"Элемент с ID найден {key}: {findedElement}");
                        else
                            Console.WriteLine($"Элемент с ID = {key} не найден.");
                        break;

                    case "4": 
                        Console.Write("Введите ID элемента для удаления: ");
                        key = CorrectPositiveIntegerInput();
                        bool isRemoved = hashTable.Remove(key);
                        if (isRemoved)
                        { 
                            Console.WriteLine($"Элемент с ID = {key} успешно удален.");
                        }
                        else
                        { 
                            Console.WriteLine($"Элемент с ID = {key} не найден");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Очистка хеш-таблицы");
                        hashTable.Clear();
                        Console.WriteLine("Таблица очищена.");
                        break;

                    case "6":
                        isNeedExit = true;
                        break;

                    default:
                        Console.WriteLine("Нет такой команды!");
                        break;
                }
                TextSeparator();
            }
        }
}