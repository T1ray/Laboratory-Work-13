using System.Net.Mime;
using System.Threading.Channels;

namespace Lab12;
using Lab10;
using static AdditionalFunctions.AdditionalFunctions;

public class DemonstrateProgram
{
    public static void DemonstrateDoubleLinkedList()
    {
        #region Инициализация переменных
        MusicalInstrument basicMusicalInstrumnet = new MusicalInstrument();
        basicMusicalInstrumnet.RandomInit();
        Guitar gutar = new Guitar(6, 700);
        ElectricGuitar electricGuitar = new ElectricGuitar("аккумулятор", 9, 123);
        Piano piano = new Piano(88, "шкальная", 234);
        MusicalInstrument musicalInstrument = new MusicalInstrument("Саксофон", 15);
        #endregion

        #region Создание и добавление элементов в список
        DoubleLinkedList<MusicalInstrument> instrumentsList = new DoubleLinkedList<MusicalInstrument>();
        instrumentsList.Add(basicMusicalInstrumnet);
        instrumentsList.Add(gutar);
        instrumentsList.Add(electricGuitar);
        instrumentsList.Add(piano);
        instrumentsList.Add(musicalInstrument);
        DoubleLinkedList<MusicalInstrument> copyInstrumentsList = (DoubleLinkedList<MusicalInstrument>)instrumentsList.Clone();
        #endregion
        
        #region Печать списка
        instrumentsList.PrintList();
        TextSeparator();
        #endregion
        
        #region Выполнение задания
        instrumentsList.RemoveLast((Piano)piano.Clone());
        Console.WriteLine("Список элементов после удаления элемента пианино");
        instrumentsList.PrintList();
        TextSeparator();

        ElectricGuitar addedElement = new ElectricGuitar("usb", 9, 69);
        Console.WriteLine($"Добавление элемента: {addedElement}\nпосле элемента {gutar}");
        instrumentsList.Insert(gutar, addedElement);
        Console.WriteLine("Список элементов добавления элемента");
        instrumentsList.PrintList();
        TextSeparator();
        #endregion
        
        #region Копия списка
        Console.WriteLine("Копия изначального списка инструментов");
        copyInstrumentsList.PrintList();
        TextSeparator();
        #endregion
        
        #region Удаление списка из памяти
        Console.WriteLine("Удаление списка из памяти");
        instrumentsList.Clear();
        instrumentsList.PrintList();
        TextSeparator();
        #endregion
    }

    public static void DemonstrateHashTable()
    {
        #region Инициализация переменных
        MyHashTable<int, MusicalInstrument> hashTable = new MyHashTable<int, MusicalInstrument>(10);
        
        MusicalInstrument violin = new MusicalInstrument("Скрипка", 510);
        Guitar gutar = new Guitar(18, 700);
        ElectricGuitar electricGuitar = new ElectricGuitar("аккумулятор", 9, 123);
        Piano piano = new Piano(88, "шкальная", 234);
        MusicalInstrument musicalInstrument = new MusicalInstrument("Саксофон", 15);
        #endregion

        #region Заполнение таблицы
        hashTable.Add(violin.Id.Id, violin);
        hashTable.Add(gutar.Id.Id, gutar);
        hashTable.Add(electricGuitar.Id.Id, electricGuitar);
        hashTable.Add(piano.Id.Id, piano);
        hashTable.Add(musicalInstrument.Id.Id, musicalInstrument);

        Console.WriteLine("Таблица заполнена:");
        hashTable.PrintHashTable();
        TextSeparator();
        #endregion

        #region Поиск элемента
        Console.WriteLine($"Поиск элемента: {piano} по ID");
        PointHS<int, MusicalInstrument>? searchedElemnt = hashTable.SearchElemnt(piano.Id.Id);
        if (searchedElemnt == null) Console.WriteLine("Элемент не найден!");
        else Console.WriteLine($"Элемент найден: {searchedElemnt.Value}");
        Console.WriteLine();
        
        ElectricGuitar specialElectricGuitar = new ElectricGuitar("usb", 9, 874);
        Console.WriteLine($"Поиск элемента: {specialElectricGuitar} - по ID");
        searchedElemnt = hashTable.SearchElemnt(specialElectricGuitar.Id.Id);
        if (searchedElemnt == null) Console.WriteLine("Элемент не найден!");
        else Console.WriteLine($"Элемент по ключу {searchedElemnt.Key} найден: {searchedElemnt.Value}");
        TextSeparator();
        #endregion

        #region Удаление элемента
        Console.WriteLine("Хеш-таблица до удаления");
        hashTable.PrintHashTable();
        Console.WriteLine();

        Console.WriteLine($"Удаление элмента: {piano}");
        hashTable.Remove(piano.Id.Id);
        Console.WriteLine();

        Console.WriteLine("Хеш-таблица после удаления");
        hashTable.PrintHashTable();
        TextSeparator();
        #endregion
    }
    
    public static void DemonstrateBinaryTrees()
    {
        #region Инициализация переменных
        BalancedTree<int, MusicalInstrument> balancedTree = new BalancedTree<int, MusicalInstrument>();
        
        Guitar guitar = new Guitar(6, 20);
        ElectricGuitar electricGuitar = new ElectricGuitar("аккумулятор", 9, 17);
        Piano piano = new Piano(88, "шкальная", 35);
        MusicalInstrument musicalInstrument = new MusicalInstrument("Саксофон", 30);
        Piano piano1 = new Piano(97, 82);
        ElectricGuitar electricGuitar1 = new ElectricGuitar("usb", 8, 62);
        #endregion

        #region Добавление элементов в идеально сбалансированное дерево
        balancedTree.Insert(guitar.Id.Id, electricGuitar);
        balancedTree.Insert(electricGuitar.Id.Id, electricGuitar);
        balancedTree.Insert(piano.Id.Id, piano);
        balancedTree.Insert(musicalInstrument.Id.Id, musicalInstrument);
        balancedTree.Insert(piano1.Id.Id, piano1);
        balancedTree.Insert(electricGuitar1.Id.Id, electricGuitar1);

        Console.WriteLine("Элементы добавлены в идеально сбалансированное дерево!");
        Console.WriteLine();
        #endregion

        #region Печать идеально сбалансированного дерева
        Console.WriteLine("Печать идеально сбалансированного дерева");
        balancedTree.PrintByLevel(3, balancedTree.Root);
        TextSeparator();
        #endregion

        #region Поиск минимального ключа в дереве
        Console.WriteLine("Поиск минимального ключа в дереве");
        BalancedTreeNode<int, MusicalInstrument> minNode = balancedTree.GetMinNode();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Ключ: ");
        Console.ResetColor();
        Console.Write($"{minNode.Key.ToString()}; ");
            
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Значение: ");
        Console.ResetColor();
        Console.WriteLine(minNode.Value.ToString());
        TextSeparator();
        Console.WriteLine();
        #endregion

        #region Преобразование сбалансированного дерева в дерево поиска

        Console.WriteLine("Преобразование сбалансированного дерева в дерево поиска");
        SearchTree<int, MusicalInstrument> searchTree = balancedTree.ConvertToSearchTree();
        TextSeparator();

        #endregion

        #region Удаление элемента из дерева поиска
        
        Console.WriteLine("Удаление элемента из дерева поиска");
        Console.WriteLine("Вывод дерева поиска до удаления элемента");
        searchTree.PrintByLevel(3, searchTree.Root);
        Console.WriteLine();

        Console.WriteLine($"Удаление элемента: {piano.ToString()}");
        searchTree.Delete(piano.Id.Id);

        Console.WriteLine("Вывод дерева поиска после удаления элемента");
        searchTree.PrintByLevel(3, searchTree.Root);
        TextSeparator();

        #endregion

        #region Демонстрация выделения отдельной памяти для дерева поиска

        Console.WriteLine("Исходное сбалансированное дерево");
        balancedTree.PrintByLevel(3, balancedTree.Root);
        Console.WriteLine();
        
        Console.WriteLine("Дерево поиска (после удаления элемента)");
        searchTree.PrintByLevel(3, searchTree.Root);
        TextSeparator();

        #endregion

        #region Очистка деревьев из памяти

        Console.WriteLine("Очистка деревьев из памяти");
        Console.WriteLine("Идеально сбалансированное дерево:");
        balancedTree.Clear();
        balancedTree.PrintByLevel(3, balancedTree.Root);

        Console.WriteLine();

        Console.WriteLine("Дерево поиска:");
        searchTree.Clear();
        searchTree.PrintByLevel(3, searchTree.Root);
        Console.WriteLine();

        #endregion
    }

    public static void DemonstrateMyCollection()
    {
        #region IEnumerable двухсвязного списка

        MusicalInstrument basicMusicalInstrumnet = new MusicalInstrument();
        basicMusicalInstrumnet.RandomInit();
        Guitar gutar = new Guitar(6, 700);
        ElectricGuitar electricGuitar = new ElectricGuitar("аккумулятор", 9, 123);
        Piano piano = new Piano(88, "шкальная", 234);
        MusicalInstrument musicalInstrument = new MusicalInstrument("Саксофон", 15);

        DoubleLinkedList<MusicalInstrument> instrumentsList = new DoubleLinkedList<MusicalInstrument>();
        instrumentsList.Add(basicMusicalInstrumnet);
        instrumentsList.Add(gutar);
        instrumentsList.Add(electricGuitar);
        instrumentsList.Add(piano);
        instrumentsList.Add(musicalInstrument);

        Console.WriteLine("Демонстрация foreach для двухсвязного списка");
        foreach (MusicalInstrument instrument in instrumentsList)
        {
            Console.WriteLine(instrument.ToString());
        }
        TextSeparator();

    #endregion
        
        #region Инициализация переменных

        MyCollection<int, MusicalInstrument> myCollection = new MyCollection<int, MusicalInstrument>();
        
        MusicalInstrument instrument10 = new MusicalInstrument("Маракасы", 10);
        Piano instrument5 = new Piano(88, "октавная", 5);
        Guitar instrument15 = new Guitar(6, 15);
        MusicalInstrument instrument3 = new MusicalInstrument("Барабаны", 3);
        ElectricGuitar instrument7 = new ElectricGuitar("usb", 7, 7);
        ElectricGuitar instrument12 = new ElectricGuitar("батарейки", 8, 12);

        #endregion

        #region Добавление элемента в MyCollection и вывод элементов в консоль

        Console.WriteLine($"Добавление элемента {instrument10.ToString()} в коллекцию с помощью метода из ICollection");
        myCollection.Add(instrument10.Id.Id, instrument10);

        Console.WriteLine($"Добавление элемента {instrument5.ToString()} в коллекцию с помощью метода из IDictionary");
        myCollection.Add(new KeyValuePair<int, MusicalInstrument>(instrument5.Id.Id, instrument5));

        Console.WriteLine("Остальные элементы также добавляются в MyCollection");
        myCollection.Add(instrument15.Id.Id, instrument15);
        myCollection.Add(instrument3.Id.Id, instrument3);
        myCollection.Add(instrument7.Id.Id, instrument7);
        myCollection.Add(instrument12.Id.Id, instrument12);

        Console.WriteLine("Вывод элементов ");
        myCollection.CollectionPrintTree();
        
        TextSeparator();

        #endregion

        #region Проверка на наличие ключа либо пары ключ-значение в дереве

        Console.WriteLine("Проверка есть ли элемент с ID 5 в дереве через ContainsKey");
        Console.WriteLine(myCollection.ContainsKey(instrument5.Id.Id) 
            ? "Да, элемент есть в коллекции" : "Нет, элемента нет в коллекции");
        Console.WriteLine();

        Console.WriteLine("Проверка есть ли элемент с ID 27 в дереве через ContainsKey");
        Console.WriteLine(myCollection.ContainsKey(27) 
            ? "Да, элемент есть в коллекции" : "Нет, элемента нет в коллекции");
        Console.WriteLine();

        Console.WriteLine($"Проверка есть ли элемент с ключем 12 " +
                          $"и значением {instrument12.ToString()} в дереве через Contains");
        bool resultContains =
            myCollection.Contains(new KeyValuePair<int, MusicalInstrument>(instrument12.Id.Id, instrument12));
        Console.WriteLine(resultContains ? "Да, элемент есть в коллекции" : "Нет, элемента нет в коллекции");
        Console.WriteLine();

        Piano nonAddedPiano = new Piano(90, "октавная", 29);
        Console.WriteLine($"Проверка есть ли элемент с ключем 15" +
                          $"и значением {nonAddedPiano.ToString()} в дереве через Contains");
        resultContains =
            myCollection.Contains(new KeyValuePair<int, MusicalInstrument>(15, nonAddedPiano));
        Console.WriteLine(resultContains ? "Да, элемент есть в коллекции" : "Нет, элемента нет в коллекции");
        TextSeparator();

        #endregion
        
        #region Получение значения узла дерева по ключу

        Console.WriteLine("Попытка получить значение по ключу 15");
        MusicalInstrument resultingValue;
        if (myCollection.TryGetValue(15, out resultingValue))
        {
            Console.WriteLine("Элемент с данным ключем есть в коллекции!");
            Console.WriteLine(resultingValue.ToString());
        }
        else Console.WriteLine("Данного ключа нет в дереве!");

        Console.WriteLine("Попытка получить значение по ключу 29");
        if (myCollection.TryGetValue(29, out resultingValue))
        {
            Console.WriteLine("Элемент с данным ключем есть в коллекции!");
            Console.WriteLine(resultingValue.ToString());
        }
        else Console.WriteLine("Данного ключа нет в дереве!");
        
        #endregion

        #region Удаление элемента из MyCollection
        
        Console.WriteLine("Удаление элемента из коллекции через Remove по ключу 10");
        if (myCollection.Remove(10)) Console.WriteLine("Элемент удален из дерева!");
        else Console.WriteLine("Элемент с ключем 10 не найден");
        Console.WriteLine();
        
        Console.WriteLine("Удаление элемента из коллекции через Remove по ключу 29");
        if (myCollection.Remove(29)) Console.WriteLine("Элемент удален из дерева!");
        else Console.WriteLine("Элемент с ключем 29 не найден");
        Console.WriteLine();
        
        Console.WriteLine($"Удаление элемента из коллекции через Remove по паре ключ-значение 7 и {instrument7.ToString()}");
        if (myCollection.Remove(new KeyValuePair<int, MusicalInstrument>(7, instrument7))) 
            Console.WriteLine("Элемент удален из дерева!");
        else Console.WriteLine("Элемент с ключем 7 не найден");
        Console.WriteLine();

        ElectricGuitar valueToDelete = new ElectricGuitar();
        Console.WriteLine($"Удаление элемента из коллекции через Remove " +
                          $"по паре ключ-значение 15 и {valueToDelete.ToString()}");
        if (myCollection.Remove(new KeyValuePair<int, MusicalInstrument>(15, valueToDelete)))
            Console.WriteLine("Элемент удален из дерева!");
        else Console.WriteLine($"Элемент с ключем 15 и значения {valueToDelete.ToString()} не найден");
        TextSeparator();

        #endregion

        #region Проверка работы индексатора

        Console.WriteLine("Получение значения с помощью индексатора");
        Console.WriteLine("Проверка получение элемента по ключу 5");
        Console.WriteLine(myCollection[5] != null ? myCollection[5] : "Элемента с данным номером нет в дереве!");
        Console.WriteLine();

        Console.WriteLine("Проверка получение элемента по ключу 29");
        try
        {
            Console.WriteLine(myCollection[29]);
        }
        catch
        {
            Console.WriteLine("Элемента с данным номером нет в дереве!");
        }
        Console.WriteLine();

        Console.WriteLine("Установка значения с помощью индексатора");
        Guitar addedElement = new Guitar(8,29);
        Console.WriteLine($"Добавление по ключу 29 значения {addedElement.ToString()}");
        myCollection[29] = addedElement;
        TextSeparator();
        
        #endregion

        #region Очистка MyCollection

        Console.WriteLine("Очистка коллекции");
        Console.WriteLine("Вывод элементов ");
        myCollection.CollectionPrintTree();
        
        myCollection.Clear();
        Console.WriteLine("Очистка успешна!");
        myCollection.CollectionPrintTree();

        #endregion
        
        TextSeparator();
    }
}