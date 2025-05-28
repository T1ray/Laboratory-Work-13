namespace Lab10;

public class IdNumber
{
    private int id;

    public int Id
    {
        get => id;
        set
        {
            if (value < 0)
                throw new Exception("Число не может быть меньше 0!");
            id = value;
        }
    }
    
    public IdNumber(int number = 0) => Id = number;
    
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj == this) return true;
        if (obj is IdNumber other)
            return Id == other.Id;
        return false;
    }
    
    public override string ToString() => Id.ToString();
}