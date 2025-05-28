using System.Threading.Channels;

namespace Lab12;

using static AdditionalFunctions.AdditionalFunctions;
using Lab10;
using static ElementGeneratorClass;

public class BinaryTreesLaboratory
{
    private static void MenuAVL()
    {
        Console.WriteLine("Меню для АВЛ-дерева (BalancedTree<int, MusicalInstrument>):");
        Console.WriteLine("1. Вывести элементы АВЛ-дерева (по уровням)");
        Console.WriteLine("2. Вывести элемент АВЛ-дерева с минимальным ID");
        Console.WriteLine("3. Добавить элемент в АВЛ-дерево");
        Console.WriteLine("4. Преобразовать АВЛ-дерево в Дерево Поиска");
        Console.WriteLine("5. Очистить АВЛ-дерево");
        Console.WriteLine("6. Вернуться в главное меню");
    }

    private static void MenuBST()
    {
        Console.WriteLine("Меню для дерева поиска (SearchTree<int, MusicalInstrument>):");
        Console.WriteLine("1. Вывести элементы дерева поиска (по уровням)");
        Console.WriteLine("2. Поиск элемента в дереве поиска по ID");
        Console.WriteLine("3. Удалить элемент из дерева поиска по ID");
        Console.WriteLine("4. Очистить дерево поиска");
        Console.WriteLine("5. Вернуться в главное меню");
    }
    
    public static void Experiments()
    {
        Console.WriteLine("Экспериментальная зона: Бинарные деревья АВЛ и дерево поиска");
        Console.WriteLine("<int, MusicalInstrument>");
        TextSeparator();
        
        BalancedTree<int, MusicalInstrument> balancedTree = new BalancedTree<int, MusicalInstrument>();
        SearchTree<int, MusicalInstrument> searchTree = new SearchTree<int, MusicalInstrument>();

        MusicalInstrument instrument;
        int key;
        bool isNeedExit = false;
        bool isChangedTree = false;
        

        while (!isNeedExit && !isChangedTree)
        {
            MenuAVL();
            Console.Write("Введите команду: ");
            string input = Console.ReadLine();
            TextSeparator();

            switch (input)
            {
                case "1":
                    if (balancedTree.Root == null)
                    {
                        Console.WriteLine("АВЛ-дерево пустое!");
                        break;
                    }
                    Console.WriteLine("АВЛ-дерево:");
                    balancedTree.PrintByLevel(3, balancedTree.Root);
                    break;
                
                case "2":
                    if (balancedTree.Root == null) Console.WriteLine("Дерево пустое!");
                    else Console.WriteLine(balancedTree.GetMinNode().ToString());
                    break;

                case "3": 
                    Console.WriteLine("Добавление элемента в таблицу");
                    instrument = ElementGenerator();

                    if (instrument.Equals(new MusicalInstrument()))
                    {
                        Console.WriteLine("Элемент не добавлен!");
                        break;
                    }

                    key = instrument.Id.Id; 
                    balancedTree.Insert(key, instrument);
                    Console.WriteLine($"Элемент {instrument.Name} с ID = {key} добавлен!");
                    break;

                case "4":
                    Console.WriteLine("Преобразование в дерево поиска...");
                    searchTree = balancedTree.ConvertToSearchTree();
                    Console.WriteLine("Успешно!");
                    Console.WriteLine("Переход к работе с деревом поиска!");
                    isChangedTree = true;
                    break;

                case "5": 
                    Console.WriteLine("Очистка АВЛ-дерева...");
                    balancedTree.Clear();
                    Console.WriteLine("АВЛ-дерево очищено!");
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
        
        while (!isNeedExit)
        {
            MenuBST();
            Console.Write("Введите команду: ");
            string input = Console.ReadLine();
            TextSeparator();

            switch (input)
            {
                case "1":
                    if (searchTree.Root == null)
                    {
                        Console.WriteLine("Дерево поиска пустое!");
                        break;
                    }
                    Console.WriteLine("Дерево поиска:");
                    searchTree.PrintByLevel(3, searchTree.Root);
                    break;
                
                case "2":
                    Console.WriteLine("Поиск элемента в дереве поиска!");
                    if (searchTree.Root == null)
                    {
                        Console.WriteLine("Дерево поиска пустое!");
                        break;
                    }
                    Console.Write("Введите ID элемента, который хотите найти: ");
                    key = CorrectPositiveIntegerInput();
                    SearchTreeNode<int, MusicalInstrument>? findedElement = searchTree.Find(key);
                    if (findedElement == null) Console.WriteLine($"Элемент с ID - {key} не найден!");
                    else Console.WriteLine(findedElement.Value.ToString());
                    break;

                case "3": 
                    Console.WriteLine("Удаление элемента из дерева поиска");
                    Console.Write("Введите ID элемента, который хотите удалить: ");
                    key = CorrectPositiveIntegerInput();
                    if (searchTree.Find(key) == null) Console.WriteLine("Нет элемента с данным ID в дереве поиска!");
                    else
                    {
                        searchTree.Delete(key);
                        Console.WriteLine($"Удаление элемента с ID - {key} успешно!");
                    }
                    break;

                case "4":
                    Console.WriteLine("Очистка дерева поиска...");
                    searchTree.Clear();
                    Console.WriteLine("Дерево поиска очищено!");
                    break;

                case "5": 
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