namespace Lab12;

using Lab10;
using System.Collections.Generic;
using static AdditionalFunctions.AdditionalFunctions;
using static Lab12.ElementGeneratorClass;

public static class MyCollectionLaboratory
{
    private static void Menu()
    {
        Console.WriteLine("Меню для MyCollection<int, MusicalInstrument>:");
        Console.WriteLine("1. Добавить элемент в коллекцию");
        Console.WriteLine("2. Вывести элементы коллекции (структура дерева)");
        Console.WriteLine("3. Удалить элемент из коллекции (по ID ключа)");
        Console.WriteLine("4. Использовать индексатор (получить/установить значение по ID ключа)");
        Console.WriteLine("5. Проверить наличие ключа в коллекции (ContainsKey)");
        Console.WriteLine("6. Проверить наличие пары ключ-значение в коллекции (Contains)");
        Console.WriteLine("7. Скопировать коллекцию в массив и вывести его (CopyTo)");
        Console.WriteLine("8. Очистить коллекцию");
        Console.WriteLine("9. Вывести элементы коллекции (через foreach)");
        Console.WriteLine("0. Вернуться в главное меню");
    }

    public static void Experiments()
    {
        Console.WriteLine("Экспериментальная зона: MyCollection<int, MusicalInstrument>");
        TextSeparator();

        MyCollection<int, MusicalInstrument> collection = new MyCollection<int, MusicalInstrument>();
        bool isNeedExit = false;


        while (!isNeedExit)
        {
            Menu();
            Console.Write("Введите команду: ");
            string input = Console.ReadLine();
            TextSeparator();

            switch (input)
            {
                case "1": // Добавление элемента
                    Console.WriteLine("Добавление элемента в коллекцию:");
                    MusicalInstrument instrumentToAdd = ElementGenerator();
                    if (instrumentToAdd.Equals(new MusicalInstrument()))
                    {
                        Console.WriteLine("Элемент не добавлен");
                        break;
                    }
                    int keyToAdd = instrumentToAdd.Id.Id;
                    if (collection.ContainsKey(keyToAdd))
                    {
                        Console.WriteLine($"Элемент с ID ключа {keyToAdd} уже существует. Используйте опцию 4 для обновления.");
                    }
                    else
                    {
                        collection.Add(keyToAdd, instrumentToAdd);
                        Console.WriteLine($"Элемент {instrumentToAdd.Name} с ID ключа {keyToAdd} успешно добавлен.");
                    }
                    break;

                case "2": // Вывод коллекции в консоль
                    if (collection.Count == 0)
                    {
                        Console.WriteLine("Коллекция пуста");
                        break;
                    }
                    collection.CollectionPrintTree();
                    break;

                case "3": // Удаление элемента
                    Console.WriteLine("Удаление элемента из коллекции по ID ключа:");
                    if (collection.Count == 0)
                    {
                        Console.WriteLine("Коллекция пуста. Нечего удалять.");
                        break;
                    }
                    Console.Write("Введите ID ключа элемента для удаления: ");
                    int keyToRemove = CorrectPositiveIntegerInput();
                    if (collection.Remove(keyToRemove))
                    {
                        Console.WriteLine($"Элемент с ID ключа {keyToRemove} успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Элемент с ID ключа {keyToRemove} не найден в коллекции.");
                    }
                    break;

                case "4": // Использование индексатора
                    Console.WriteLine("Использование индексатора:");
                    Console.Write("Выберите действие: (1-получить, 2-установить): ");
                    string indexerChoice = Console.ReadLine();
                    Console.Write("Введите ID ключа: ");
                    int indexerKey = CorrectPositiveIntegerInput();
                    
                    if (indexerChoice == "1") // Получение значения с помощью индексатора
                    {
                        try
                        {
                            MusicalInstrument foundValue = collection[indexerKey];
                            Console.WriteLine($"Найденное значение для ключа {indexerKey}: {foundValue}");
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine($"Элемент с ID ключа {indexerKey} не найден");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (indexerChoice == "2") // Установка значения с помощью индексатора
                    {
                        Console.WriteLine("Создание нового значения для установки/добавления:");
                        MusicalInstrument valueToSet = ElementGenerator();
                        if (valueToSet.Equals(new MusicalInstrument()))
                        {
                            Console.WriteLine("Операция не выполнена.");
                            break;
                        }
                        try
                        {
                            bool existed = collection.ContainsKey(indexerKey);
                            collection[indexerKey] = valueToSet;
                            if (existed)
                            {
                                Console.WriteLine($"Значение для ключа {indexerKey} успешно обновлено на {valueToSet.Name}.");
                            }
                            else
                            {
                                Console.WriteLine($"Новый элемент {valueToSet.Name} с ключом {indexerKey} успешно добавлен.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор действия для индексатора");
                    }
                    break;

                case "5": // ContainsKey
                    Console.WriteLine("Проверка наличия ключа в коллекции:");
                    Console.Write("Введите ID ключа для проверки: ");
                    int keyToCheck = CorrectPositiveIntegerInput();
                    if (collection.ContainsKey(keyToCheck))
                    {
                        Console.WriteLine($"Коллекция содержит элемент с ID ключа {keyToCheck}.");
                    }
                    else
                    {
                        Console.WriteLine($"Коллекция НЕ содержит элемент с ID ключа {keyToCheck}.");
                    }
                    break;

                case "6": // Contains
                    Console.WriteLine("Проверка наличия пары ключ-значение в коллекции:");
                    Console.Write("Введите ID ключа: ");
                    int containsKeyPart = CorrectPositiveIntegerInput();
                    Console.WriteLine("Создание объекта значения для проверки:");
                    MusicalInstrument containsValuePart = ElementGenerator();
                     if (containsValuePart.Id.Id == 0 && string.IsNullOrEmpty(containsValuePart.Name))
                    {
                        Console.WriteLine("Создание элемента значения отменено. Проверка не выполнена.");
                        break;
                    }
                    KeyValuePair<int, MusicalInstrument> itemToCheck = new KeyValuePair<int, MusicalInstrument>(containsKeyPart, containsValuePart);
                    if (collection.Contains(itemToCheck))
                    {
                        Console.WriteLine($"Коллекция содержит указанную пару ключ-значение (Ключ: {itemToCheck.Key}, Значение: {itemToCheck.Value.Name}).");
                    }
                    else
                    {
                        Console.WriteLine($"Коллекция не содержит указанную пару ключ-значение.");
                    }
                    break;

                case "7": // CopyTo
                    Console.WriteLine("Копирование коллекции в массив и вывод массива:");
                    if (collection.Count == 0)
                    {
                        Console.WriteLine("Коллекция пуста!");
                        break;
                    }
                    KeyValuePair<int, MusicalInstrument>[] array = new KeyValuePair<int, MusicalInstrument>[collection.Count];
                    try
                    {
                        collection.CopyTo(array, 0);
                        Console.WriteLine("Элементы, скопированные в массив:");
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.WriteLine($"{i}: Ключ: {array[i].Key}, Значение: {array[i].Value}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при копировании в массив: {ex.Message}");
                    }
                    break;

                case "8": // Clear
                    Console.WriteLine("Очистка коллекции...");
                    collection.Clear();
                    Console.WriteLine("Коллекция успешно очищена.");
                    break;
                
                case "9": // Вывод элементов с помощью foreach
                    Console.WriteLine("Вывод элементов коллекции через foreach:");
                    if (collection.Count == 0)
                    {
                        Console.WriteLine("Коллекция пуста");
                        break;
                    }
                    int itemCount = 0;
                    foreach (KeyValuePair<int, MusicalInstrument> pair in collection)
                    {
                        Console.WriteLine($"Ключ: {pair.Key}, Значение: {pair.Value}");
                        itemCount++;
                    }
                    Console.WriteLine($"Всего элементов выведено: {itemCount}");
                    break;

                case "0": // Выход
                    isNeedExit = true;
                    Console.WriteLine("Возврат в главное меню...");
                    break;

                default:
                    Console.WriteLine("Нет такой команды!");
                    break;
            }
            if (!isNeedExit) TextSeparator();
        }
    }
}