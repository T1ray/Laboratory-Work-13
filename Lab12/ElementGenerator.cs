namespace Lab12;
using Lab10;

public class ElementGeneratorClass
{
    public static MusicalInstrument ElementGenerator()
    {
        Console.WriteLine("Выберите тип элемента:");
        Console.WriteLine("1. Музыкальный инструмент");
        Console.WriteLine("2. Гитара");
        Console.WriteLine("3. Электрическая гитара");
        Console.WriteLine("4. Фортепиано");
        
        MusicalInstrument instrument = new MusicalInstrument();
        bool isEnteredCorrectly = false;
        Console.Write("> ");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                instrument = new MusicalInstrument();
                while (!isEnteredCorrectly)
                {
                    Console.WriteLine("Введите 1, если хотите рандомно сгенерировать элемент");
                    Console.WriteLine("Введите 2, если хотите задать элемент вручную");
                    Console.Write("> ");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            instrument.RandomInit();
                            isEnteredCorrectly = true;
                            break;
                        case "2":
                            instrument.Init();
                            isEnteredCorrectly = true;
                            break;
                        default:
                            Console.WriteLine("Нет такой команды!");
                            break;
                    }
                }

                break;
            
            case "2":
                instrument = new Guitar();
                while (!isEnteredCorrectly)
                {
                    Console.WriteLine("Введите 1, если хотите рандомно сгенерировать элемент");
                    Console.WriteLine("Введите 2, если хотите задать элемент вручную");
                    Console.Write("> ");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            instrument.RandomInit();
                            isEnteredCorrectly = true;
                            break;
                        case "2":
                            instrument.Init();
                            isEnteredCorrectly = true;
                            break;
                        default:
                            Console.WriteLine("Нет такой команды!");
                            break;
                    }
                }
                break;
            
            case "3":
                instrument = new ElectricGuitar();
                while (!isEnteredCorrectly)
                {
                    Console.WriteLine("Введите 1, если хотите рандомно сгенерировать элемент");
                    Console.WriteLine("Введите 2, если хотите задать элемент вручную");
                    Console.Write("> ");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            instrument.RandomInit();
                            isEnteredCorrectly = true;
                            break;
                        case "2":
                            instrument.Init();
                            isEnteredCorrectly = true;
                            break;
                        default:
                            Console.WriteLine("Нет такой команды!");
                            break;
                    }
                }
                break;
            
            case "4":
                instrument = new Piano();
                while (!isEnteredCorrectly)
                {
                    Console.WriteLine("Введите 1, если хотите рандомно сгенерировать элемент");
                    Console.WriteLine("Введите 2, если хотите задать элемент вручную");
                    Console.Write("> ");
                    input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            instrument.RandomInit();
                            isEnteredCorrectly = true;
                            break;
                        case "2":
                            instrument.Init();
                            isEnteredCorrectly = true;
                            break;
                        default:
                            Console.WriteLine("Нет такой команды!");
                            break;
                    }
                }
                break;
            
            default:
                Console.WriteLine("Нет такой опции!");
                break;
        }
        return instrument;
    }
}