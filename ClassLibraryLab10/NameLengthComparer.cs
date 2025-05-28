using Lab9_1;

namespace Lab10;

public class NameLengthComparer : IComparer<MusicalInstrument>
{
    public int Compare(MusicalInstrument? x, MusicalInstrument? y)
    {
        if (x is null && y is null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return x.Name.Length.CompareTo(y.Name.Length);
    }
}