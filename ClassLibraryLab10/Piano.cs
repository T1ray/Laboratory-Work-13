namespace Lab10;
using static AdditionalFunctions.AdditionalFunctions;

public class Piano : MusicalInstrument
{
    private static string[] availableKeyLayouts = new string[]
    {
        "октавная",
        "шкальная",
        "дигитальная"
    };
    
    private static int numberPianos = 0; 
    private string keyLayout;
    private int numberKeys;
    
    public static int NumberPianos {get => numberPianos;}

    public string KeyLayout
    {
        get => keyLayout;
        set
        {
            if (!availableKeyLayouts.Contains(value.ToLower()))
            {
                throw new Exception("Нет такой раскладки клавиш!");
            }
            keyLayout = value;
        }
    }
    public int NumberKeys
    {
        get => numberKeys;
        set
        {
            if (value < 1) throw new Exception("Количество клавиш не может быть отрицательным числом!");
            numberKeys = value;
        }
    }

    public Piano() : base("Фортепиано", 0)
    {
        KeyLayout = availableKeyLayouts[0];
        NumberKeys = 88;
        numberPianos++;
    }

    public Piano(int numberKeys, int id) : base("Фортепиано", id)
    {
        KeyLayout = availableKeyLayouts[0];
        NumberKeys = numberKeys;
        numberPianos++;
    }

    public Piano(int numberKeys, string keyLayout, int id) : base("Фортепиано", id)
    {
        KeyLayout = keyLayout;
        NumberKeys = numberKeys;
    }

    public new void Show()
    {
        base.Show();
        Console.WriteLine($"Количество клавиш у фортепиано - {NumberKeys}");
        Console.WriteLine($"Раскладка клавиш - {KeyLayout}");
    }

    public override void VirtualShow()
    {
        base.VirtualShow();
        Console.WriteLine($"Количество клавиш у фортепиано - {NumberKeys}");
        Console.WriteLine($"Раскладка клавиш - {KeyLayout}");
    }

    public override void Init()
    {
        base.Init();
        Console.Write("Введите количество клавиш (>0): ");
        NumberKeys = CorrectIntegerInput();
        Console.Write("Введите раскладку клавиш фортепиано (\"октавная\", \"шкальная\", \"дигитальная\"): ");
        KeyLayout = Console.ReadLine();
    }

    public override void RandomInit()
    {
        Random rand = new Random();
        base.RandomInit();
        Name = "Фортепиано";
        NumberKeys = rand.Next(88, 103);
        KeyLayout = availableKeyLayouts[rand.Next(0,availableKeyLayouts.Length)];
    }
    
    public override bool Equals(object obj)
    {
        if (obj is Piano piano)
        {
            return Id.Equals(piano.Id)
                   && Name == piano.Name 
                   && NumberKeys == piano.NumberKeys 
                   && KeyLayout == piano.KeyLayout;
        }
        return false;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Раскладка клавиш: {KeyLayout}, Количество клавиш: {NumberKeys}";
    }
    
    public override object Clone()
    {
        return new Piano(this.NumberKeys, this.KeyLayout, this.Id.Id);
    }

    public object ShallowClone()
    {
        return this.MemberwiseClone();
    }
}