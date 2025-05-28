namespace Lab13;

using Lab12;
using Lab10;
using static AdditionalFunctions.AdditionalFunctions;

public class DemonstrateProgram
{
    public static void DemonstrateLab13()
    {
        Console.WriteLine("Демонстрация MyObservableCollection и Journal");
        TextSeparator();
        
        MyObservableCollection<int, MusicalInstrument> collection1 = 
            new MyObservableCollection<int, MusicalInstrument>("Первая музыкальная коллекция");
        MyObservableCollection<int, MusicalInstrument> collection2 = 
            new MyObservableCollection<int, MusicalInstrument>("Вторая музыкальная коллекция");
        
        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        Console.WriteLine("Подписка журналов на события");
        collection1.CollectionCountChanged += journal1.CollectionCountChanged;
        collection1.CollectionReferenceChanged += journal1.CollectionReferenceChanged;
        
        collection1.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
        collection2.CollectionReferenceChanged += journal2.CollectionReferenceChanged;
        
        TextSeparator();
        Console.WriteLine("Начальное состояние журналов:");
        Console.WriteLine("     Журнал 1");
        journal1.PrintJournal();
        Console.WriteLine("     Журнал 2");
        journal2.PrintJournal();
        TextSeparator();
        
        Console.WriteLine("Операции над первой музыкальной коллекцией:");
        Guitar guitar1 = new Guitar(6, 101);
        guitar1.Name = "Гитара Yamaha";
        Piano piano1 = new Piano(88, 102);
        piano1.Name = "Пианино Yamaha";
        MusicalInstrument barabany1 = new MusicalInstrument("Барабаны Fender", 102);

        Console.WriteLine($"Добавляем: {guitar1.Name} ID: {guitar1.Id.Id}");
        collection1.Add(guitar1.Id.Id, guitar1);
        Console.WriteLine($"Добавляем: {piano1.Name} ID: {piano1.Id.Id}");
        collection1.Add(new KeyValuePair<int, MusicalInstrument>(piano1.Id.Id, piano1));
         Console.WriteLine($"Добавляем: {barabany1.Name} ID: {barabany1.Id.Id}");
        collection1.Add(barabany1.Id.Id, barabany1);
        
        Console.WriteLine($"Удаляем по ключу: {piano1.Name} ID: {piano1.Id.Id} из первой музыкальной коллекции");
        collection1.Remove(piano1.Id.Id); 
        
        TextSeparator();
        Console.WriteLine($"Обновляем элемент с ID {guitar1.Id.Id} в Первая музыкальная коллекция");
        ElectricGuitar electroGitaraUpdated = new ElectricGuitar("usb", 101);
        Console.WriteLine($"Новое значение: [{electroGitaraUpdated.ToString()}]");
        collection1[guitar1.Id.Id] = electroGitaraUpdated; 
        
        TextSeparator();
        Console.WriteLine("    Журнал 1");
        journal1.PrintJournal();
        
        TextSeparator();
        Console.WriteLine("Операции над второй музыкальной Коллекцией");
        MusicalInstrument sintezator2 = new MusicalInstrument("Синтезатор Yamaha", 201);
        MusicalInstrument mikrofon2 = new MusicalInstrument("Микрофон Audio-Technica", 202);
        
        Console.WriteLine($"Добавляем: {sintezator2.Name} (ID: {sintezator2.Id.Id})");
        collection2.Add(sintezator2.Id.Id, sintezator2);
        Console.WriteLine($"Добавляем: {mikrofon2.Name} (ID: {mikrofon2.Id.Id})");
        collection2.Add(mikrofon2.Id.Id, mikrofon2);
        
        TextSeparator();
        Console.WriteLine("    Журнал 2");
        journal2.PrintJournal();
        
        TextSeparator();
        Console.WriteLine($"Обновляем элемент с ID {sintezator2.Id.Id} в второй музыкальной коллекции");
        MusicalInstrument pianoUpdated2 = new Piano(88, "октавная", 201);
        Console.WriteLine($"Новое значение: [{pianoUpdated2.ToString()}]");
        collection2[sintezator2.Id.Id] = pianoUpdated2;
        
        TextSeparator();
        Console.WriteLine("Попытка добавить элемент с существующим ключом в первой музыкальной коллекции (ID: 103)");
        MusicalInstrument drums = new MusicalInstrument("Барабаны Pearl", 103);
        collection1.Add(drums.Id.Id, drums);
        
        TextSeparator();
        Console.WriteLine("Удаление элемента по паре ключ-значение из Первая музыкальная коллекция");
        Console.WriteLine($"Удаляем: {barabany1.Name}, ID: {barabany1.Id.Id}");
        collection1.Remove(new KeyValuePair<int, MusicalInstrument>(barabany1.Id.Id, barabany1));
        
        
        TextSeparator();
        Console.WriteLine("Очистка Первая музыкальная коллекция");
        collection1.Clear();
        TextSeparator();
        
        Console.WriteLine("Итоговые состояния журналов");
        Console.WriteLine("    Журнал 1");
        journal1.PrintJournal();
        TextSeparator();
        Console.WriteLine("    Журнал 2");
        journal2.PrintJournal();
        TextSeparator();
    }
}