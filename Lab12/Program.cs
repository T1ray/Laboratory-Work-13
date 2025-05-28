// namespace Lab12;
// using static AdditionalFunctions.AdditionalFunctions;
// using static DemonstrateProgram;
//
// public class Program
// {
//     static void Menu()
//     {
//         Console.WriteLine("1. Задание №1 (Двунаправленный список)");
//         Console.WriteLine("2. Задание №2 (Хеш-таблица)");
//         Console.WriteLine("3. Задание №3 (ИСД и дерево поиска)");
//         Console.WriteLine("4. Задание №4 (MyCollection)");
//     }
//     static void Main(string[] args)
//     {
//         while (true)
//         {
//             Menu();
//             TextSeparator();
//             Console.WriteLine("Выберите пункт меню: ");
//             string input = Console.ReadLine();
//             TextSeparator();
//             switch (input)
//             {
//                 case "1":
//                     DemonstrateDoubleLinkedList();
//                     DoubleLinkedListLaboratory.Experiments();
//                     break;
//                 case "2":
//                     DemonstrateHashTable();
//                     MyHashTableLaboratory.Experiments();
//                     break;
//                 case "3":
//                     DemonstrateBinaryTrees();
//                     BinaryTreesLaboratory.Experiments();
//                     break;
//                 case "4":
//                     DemonstrateMyCollection();
//                     MyCollectionLaboratory.Experiments();
//                     break;
//                 default:
//                     Console.WriteLine("Нет такого пункта меню!");
//                     break;
//             }
//         }
//     }
// }