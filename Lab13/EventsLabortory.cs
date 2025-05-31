using ElementGeneratorClass = Lab12.ElementGeneratorClass;

namespace Lab13;

using Lab12;
using Lab10;
using static ElementGeneratorClass;
using static AdditionalFunctions.AdditionalFunctions;

public class EventsLabortory
{
    private static void Menu()
    {
        Console.WriteLine("Меню для MyObservableCollection<int, MusicalInstrument>:");
        Console.WriteLine("1. Добавить элемент в коллекцию");
        Console.WriteLine("2. Удалить элемент из коллекции (по ID ключа)");
        Console.WriteLine("3. Обновить/Добавить элемент в коллекции (по ID ключа, через индексатор)");
        Console.WriteLine("4. Очистить коллекцию");
        Console.WriteLine("5. Вывести элементы коллекции (через foreach)");
        Console.WriteLine("6. Вывести журнал 1");
        Console.WriteLine("7. Выход");
    }

    public static void Experiments()
    {
        Console.WriteLine("Экспериментальная зона MyObservableCollection");
        TextSeparator();
        
        MyObservableCollection<int, MusicalInstrument> collection1 = 
            new MyObservableCollection<int, MusicalInstrument>("Коллекция 1");
        
        Journal journal1 = new Journal();
        
        Console.WriteLine("Подписка журналов на события");
        TextSeparator();
        collection1.CollectionCountChanged += journal1.CollectionCountChanged;
        collection1.CollectionReferenceChanged += journal1.CollectionReferenceChanged;
        
        bool isNeedExit = false;
        while (!isNeedExit)
        {
            Menu();
            Console.Write("Введите команду: ");
            string input = Console.ReadLine();
            TextSeparator();

            switch (input)
            {
                case "1": // Добавление элемента в коллекцию
                    Console.WriteLine("Добавление элемента в коллекцию:");
                    MusicalInstrument instrumentToAdd = ElementGenerator();
                    
                    if (instrumentToAdd.Id == null || instrumentToAdd.Id.Id == 0) 
                    {
                        Console.WriteLine("Элемент не добавлен");
                        break;
                    }
                    
                    if (collection1.ContainsKey(instrumentToAdd.Id.Id))
                    {
                         Console.WriteLine($"Элемент с ID ключа {instrumentToAdd.Id.Id} уже существует в коллекции. Используйте опцию 3 для обновления.");
                    }
                    else
                    {
                        collection1.Add(instrumentToAdd.Id.Id, instrumentToAdd);
                        Console.WriteLine($"Элемент {instrumentToAdd.Name} (ID: {instrumentToAdd.Id.Id}) добавлен в коллекцию.");
                    }
                    break;

                case "2": // Удаление элемента из коллекции
                    Console.WriteLine("Удаление элемента из коллекции по ID ключа:");
                    if (collection1.Count == 0)
                    {
                        Console.WriteLine("Коллекция пуста.");
                        break;
                    }
                    Console.WriteLine("Введите ID ключа элемента для удаления: ");
                    int keyToRemove = CorrectPositiveIntegerInput();
                    
                    MusicalInstrument valueBeforeRemove;
                    bool foundForRemove = collection1.TryGetValue(keyToRemove, out valueBeforeRemove);
                    
                    if (foundForRemove)
                    {
                        collection1.Remove(keyToRemove);
                        Console.WriteLine($"Элемент с ID {keyToRemove} {valueBeforeRemove?.Name} удален из коллекции.");
                    }
                    else
                    {
                        Console.WriteLine($"Элемент с ID ключа {keyToRemove} не найден в коллекции.");
                    }
                    break;

                case "3": // Использование индексатора
                    Console.WriteLine("Обновление/Добавление элемента в коллекции по ID ключа:");
                    Console.WriteLine("Введите ID ключа для обновления/добавления: ");
                    int indexerKey = CorrectPositiveIntegerInput();
                    
                    Console.WriteLine("Создание нового значения для элемента:");
                    MusicalInstrument valueToSet = ElementGenerator();
                    if (valueToSet.Id == null || valueToSet.Id.Id == 0)
                    {
                        Console.WriteLine("Операция не выполнена.");
                        break;
                    }
                    
                    bool existedBeforeUpdate = collection1.ContainsKey(indexerKey);
                    try
                    {
                        collection1[indexerKey] = valueToSet; 
                        if (existedBeforeUpdate)
                        {
                            Console.WriteLine($"Значение для ключа {indexerKey} в коллекции успешно обновлено на {valueToSet.Name}.");
                        }
                        else
                        {
                            Console.WriteLine($"Новый элемент {valueToSet.Name} с ключом {indexerKey} успешно добавлен в коллекцию.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                
                case "4": // Очистка коллекции
                    Console.WriteLine("Очистка коллекции");
                    collection1.Clear();
                    Console.WriteLine("Коллекция была очищена.");
                    break;

                case "5": // Вывод коллекции
                    Console.WriteLine("Элементы коллекции 1:");
                    if (collection1.Count == 0)
                    {
                        Console.WriteLine("Коллекция пуста.");
                    }
                    else
                    {
                        int itemCount = 0;
                        foreach (KeyValuePair<int, MusicalInstrument> pair in collection1)
                        {
                            Console.WriteLine($" Ключ: {pair.Key}, Значение: {pair.Value}");
                            itemCount++;
                        }
                    }
                    break;

                case "6": // Вывод Журнала
                    Console.WriteLine("Журнал 1 (События коллекции)");
                    journal1.PrintJournal();
                    break;

                case "7": // Выход
                    isNeedExit = true;
                    Console.WriteLine("Выход из программы");
                    break;

                default:
                    Console.WriteLine("Нет такой команды!");
                    break;
            }
            if (!isNeedExit) TextSeparator();
        }
    }
}
