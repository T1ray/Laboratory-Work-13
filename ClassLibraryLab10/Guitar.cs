namespace Lab10;
using static AdditionalFunctions.AdditionalFunctions;

public class Guitar : MusicalInstrument
{
    private static int numberGuitars = 0; 
    private int numberStrings;
    
    public static int NumberGuitars {get => numberGuitars;}

    public int NumberStrings
    {
        get => numberStrings;
        
        set
        {
            if (value < 1) throw new Exception("Количество струн должно быть положительным числом");
            numberStrings = value;
        }
        
    }

    public MusicalInstrument GetBase
    {
        get => new MusicalInstrument(Name, Id.Id);
    }

    public Guitar() : base("Гитара", 0)
    {
        NumberStrings = 4;
        numberGuitars++;
    }

    public Guitar(int numberStrings, int id) : base("Гитара", id)
    {
        NumberStrings = numberStrings;
        numberGuitars++;
    }

    public new void Show()
    {
        base.Show();
        Console.WriteLine($"Количество струн - {NumberStrings}");
    }

    public override void VirtualShow()
    {
        base.VirtualShow();
        Console.WriteLine($"Количество струн - {NumberStrings}");
    }

    public override void Init()
    {
        base.Init();
        
        Console.Write("Введите количество струн (>0):");
        NumberStrings = CorrectIntegerInput();
    }

    public override void RandomInit()
    {
        Random rand = new Random();
        base.RandomInit();
        Name = "Гитара";
        NumberStrings = rand.Next(4, 13);
    }

    public override bool Equals(object obj)
    {
        if (obj is Guitar guitar)
        {
            return Name == guitar.Name && NumberStrings == guitar.NumberStrings && Id.Id == guitar.Id.Id;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return base.GetHashCode() ^ NumberStrings.GetHashCode();
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Количество струн: {NumberStrings}";
    }
    
    public override object Clone()
    {
        return new Guitar(this.NumberStrings, this.Id.Id);
    }

    public object ShallowClone()
    {
        return this.MemberwiseClone();
    }
}