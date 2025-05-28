namespace Lab10;

public class ElectricGuitar : Guitar
{
    private static string[] availablePowerSupplies = new string[]
    {
        "батарейки",
        "аккумулятор",
        "фиксированный источник питания",
        "usb"
    };

    private string powerSource;
    private static int numberElectricGuitars = 0;
    
    public static int NumberElectricGuitars {get => numberElectricGuitars;}
    
    public string PowerSource
    {
        get => powerSource;
        set
        {
            if (!availablePowerSupplies.Contains(value.ToLower()))
            {
                throw new Exception("Нет данного источника питания!");
            }
            powerSource = value;
        }
    }

    public ElectricGuitar() : base(6, 0)
    {
        Name = "Электрическая гитара";
        PowerSource = "Аккумулятор";
        numberElectricGuitars++;
    }

    public ElectricGuitar(string powerSource, int id) : base(6, id)
    {
        Name = "Электрическая гитара";
        PowerSource = powerSource;
        numberElectricGuitars++;
    }

    public ElectricGuitar(string powerSource, int numberStrings, int id) : base(numberStrings, id)
    {
        Name = "Электрическая гитара";
        PowerSource = powerSource;
    }

    public new void Show()
    {
        base.Show();
        Console.WriteLine($"Источник питания - {PowerSource}");
    }
    
    public override void VirtualShow()
    {
        base.VirtualShow();
        Console.WriteLine($"Источник питания - {PowerSource}");
    }

    public override void Init()
    {
        base.Init();
        Console.Write("Введите источник  (\"батарейки\", \"аккумулятор\", \"фиксированный источник питания\", \"usb\"): ");
        PowerSource = Console.ReadLine();
    }

    public override void RandomInit()
    {
        base.RandomInit();
        Random rand = new Random();
        Name = "Электрическая гитара";
        PowerSource = availablePowerSupplies[rand.Next(0, availablePowerSupplies.Length)];
    }
    
    public override bool Equals(object obj)
    {
        if (obj is ElectricGuitar electricGuitar)
        {
            return Name == electricGuitar.Name 
                   && NumberStrings == electricGuitar.NumberStrings 
                   && PowerSource == electricGuitar.PowerSource;
        }
        return false;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Источник питания: {PowerSource}";
    }
    
    public override object Clone()
    {
        return new ElectricGuitar(this.PowerSource, this.NumberStrings, this.Id.Id);
    }

    public object ShallowClone()
    {
        return this.MemberwiseClone();
    }
}