using System;
using Lab9_1;
using static AdditionalFunctions.AdditionalFunctions;
namespace Lab10;

public class MusicalInstrument : IInit, ICloneable, IComparable<MusicalInstrument>, IComparable
{
    private static int numberMusicalInstruments = 0; 
    private static string[] randomInstruments = new string[]
    {
        "Гитара", "Фортепиано", "Барабаны", "Саксофон", "Скрипка",
        "Бас-гитара", "Клавишные", "Труба", "Акустическая гитара", "Маракасы"
    };

    public static int NumberMusicalInstruments {get => numberMusicalInstruments;}
    
    public string Name { get; set; }
    public IdNumber Id { get; set; }

    public MusicalInstrument()
    {
        Name = "";
        Id = new IdNumber();
        numberMusicalInstruments++;
    }

    public MusicalInstrument(string name, int id)
    {
        Name = name;
        Id = new IdNumber(id);
        numberMusicalInstruments++;
    }

    public void Show()
    {
        Console.WriteLine($"Id инструмента - {Id.Id}\n Название инструмента - {Name}");
    }

    public virtual void VirtualShow()
    {
        Console.WriteLine($"Id инструмента - {Id.Id}\n Название инструмента - {Name}");
    }

    public virtual void Init()
    {
        Console.Write("Введите ID инструмента (>0): ");
        Id = new IdNumber(CorrectIntegerInput());
        Console.Write("Введите название инструмента: ");
        string input = Console.ReadLine();
        Name = input;
        numberMusicalInstruments++;
    }

    public virtual void RandomInit()
    {
        Random rand = new Random();
        Name = randomInstruments[rand.Next(randomInstruments.Length)];
        Id = new IdNumber(rand.Next(1000));
        numberMusicalInstruments++;
    }

    public int CompareTo(MusicalInstrument? other)
    {
        if (other == null) return -1;
        return Name.CompareTo(other.Name);
    }
    
    public int CompareTo(object? other)
    {
        if (other == null) return -1;
        return Name.CompareTo(((MusicalInstrument)other).Name);
    }

    public override bool Equals(object obj)
    {
        if (obj is MusicalInstrument instrument)
        {
            return Name == instrument.Name;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return Id.Id.GetHashCode() ^ Name.GetHashCode();
    }

    public override string ToString()
    {
        return $"ID инструмента: {Id.Id}, Название инструмента: {Name}";
    }

    public virtual object Clone()
    {
        return new MusicalInstrument(this.Name, this.Id.Id);
    }

    public object ShallowClone()
    {
        return this.MemberwiseClone();
    }
}

