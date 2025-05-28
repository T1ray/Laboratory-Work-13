using System.Diagnostics;
using Lab10;

namespace Lab12;
using static AdditionalFunctions.AdditionalFunctions;
using static ElementGeneratorClass;

public class DoubleLinkedListLaboratory
{
    private static void MenuDoubleLinkedList()
    {
        Console.WriteLine("1. Вывод в консоль элементов коллекции");
        Console.WriteLine("2. Добавление элемента в конец списка");
        Console.WriteLine("3. Вставка элемента после указанного элемента");
        Console.WriteLine("4. Удаление элемента");
        Console.WriteLine("5. Выход");
        Console.WriteLine("6. Копирование элементов в массив (CopyTo)");
        Console.WriteLine("7. Поиск элемента по значению (IndexOf)");
        Console.WriteLine("8. Вставка элемента по индексу (Insert(int index, T item))");
        Console.WriteLine("9. Изменение элемента по индексу (Индексатор)"); 
    }

    public static void Experiments()
    {
        Console.WriteLine("Экспериментальная зона");
        Console.WriteLine("Можно поэкспериментировать с двухсвязным списком");
        TextSeparator();
        
        DoubleLinkedList<MusicalInstrument> instrumentsList = new DoubleLinkedList<MusicalInstrument>();
        MusicalInstrument instrument;
        bool isNeedExit = false;
        while (!isNeedExit)
        {
            MenuDoubleLinkedList();
            Console.Write("Введите команду: ");
            string input = Console.ReadLine();
            TextSeparator();
            switch (input)
            {
                case "1":
                    if (instrumentsList.Count == 0)
                    {
                        Console.WriteLine("Список пуст!");
                        break;
                    }
                    Console.WriteLine("Список:");
                    instrumentsList.PrintList();
                    break;
                case "2":
                    Console.WriteLine("Добавление элемента в список");
                    instrument = ElementGenerator();
                    if (!instrument.Equals(new MusicalInstrument())) instrumentsList.Add(instrument);
                    break;
                case "3":
                    Console.WriteLine("Вставка элемента после указанного элемента");
                    if (instrumentsList.Count == 0)
                    {
                        Console.WriteLine("Список пуст!");
                        break;
                    }
                    Console.WriteLine("Элемент после которого будет вставляться элемент");
                    MusicalInstrument insertedInstrument = ElementGenerator();
                    if (!instrumentsList.Contains(insertedInstrument))
                    {
                        Console.WriteLine("В списке нет элемента, после которого необходимо вставлять элемент!");
                        break;
                    }
                    Console.WriteLine("Элемент, который будем вставлять");
                    instrument = ElementGenerator();
                    instrumentsList.Insert(insertedInstrument, instrument);
                    Console.WriteLine("Элемент добавлен в список!");
                    break;
                case "4":
                    Console.WriteLine("Удаление элемента");
                    if (instrumentsList.Count == 0)
                    {
                        Console.WriteLine("Список пуст!");
                        break;
                    }
                    instrument = ElementGenerator();
                    bool isInstrumentDeleted = instrumentsList.RemoveLast(instrument);
                    if (!isInstrumentDeleted) Console.WriteLine("Элемент не найден в списке");
                    else Console.WriteLine("Элемент удален из списка");
                    break;
                case "5":
                    isNeedExit = true;
                    break;
                case "6":
                    Console.WriteLine("Демонстрация метода CopyTo:");
                    if (instrumentsList.Count == 0)
                    {
                        Console.WriteLine("Список пуст");
                        break;
                    }
              
                    MusicalInstrument[] targetArray = new MusicalInstrument[instrumentsList.Count];
                    int startIndex = 0;

                    try
                    {
                        instrumentsList.CopyTo(targetArray, startIndex);
                        Console.WriteLine("Элементы успешно скопированы в массив:");
                        for (int k = 0; k < instrumentsList.Count; k++)
                        {
                            Console.WriteLine($"{k} = {targetArray[k]?.ToString() ?? "null"}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "7":
                    Console.WriteLine("Поиск индекса элемента по значению:");
                    if (instrumentsList.Count == 0)
                    {
                        Console.WriteLine("Список пуст!");
                        break;
                    }
                    MusicalInstrument searchItem = ElementGenerator();
                    int foundIndex = instrumentsList.IndexOf(searchItem);
                    if (foundIndex != -1)
                    {
                        Console.WriteLine($"Элемент {searchItem} найден по индексу: {foundIndex}.");
                    }
                    else
                    {
                        Console.WriteLine($"Элемент {searchItem} не найден в списке.");
                    }
                    break;
                case "8":
                    Console.WriteLine("Вставка элемента по индексу:");
                    int insertAtIndex = CorrectIntegerInput();
                    if (insertAtIndex < 0 || insertAtIndex >= instrumentsList.Count) throw new ArgumentOutOfRangeException();
                    
                    Console.WriteLine("Элемент, который будем вставлять:");
                    MusicalInstrument itemToInsert = ElementGenerator();

                    instrumentsList.Insert(insertAtIndex, itemToInsert);
                    Console.WriteLine($"Элемент {itemToInsert} успешно вставлен по индексу {insertAtIndex}");
                    break;

                case "9":
                    Console.WriteLine("Изменение элемента по индексу:");
                    if (instrumentsList.Count == 0)
                    {
                        Console.WriteLine("Список пуст! Нечего изменять.");
                        break;
                    }

                    int index = CorrectIntegerInput();
                    if (index < 0 || index >= instrumentsList.Count) throw new ArgumentOutOfRangeException();
                    Console.WriteLine($"Текущее значение элемента по индексу {index}: {instrumentsList[index]}");
                    Console.WriteLine("Введите новое значение:");
                    MusicalInstrument newItem = ElementGenerator();

                    instrumentsList[index] = newItem;
                    Console.WriteLine($"Элемент по индексу {index} успешно изменен на {newItem}");
                    break;
                default:
                    Console.WriteLine("Нет такой команды!");
                    break;
            }
            TextSeparator();
        }
    }
}