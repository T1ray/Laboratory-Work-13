namespace AdditionalFunctions;

public class AdditionalFunctions
{
    public static int CorrectIntegerInput()
    {
        bool isNumber = false;
        int intNumber = 0;
        while (!isNumber)
        {
            string input = Console.ReadLine();
            isNumber = int.TryParse(input, out intNumber);
            if (!isNumber)
            {
                Console.WriteLine("Вы ввели не число!");
            }
        }
        return intNumber;
    }
    
    public static int CorrectPositiveIntegerInput()
    {
        bool isNumber = false;
        int intNumber = 0;
        while (!isNumber && intNumber < 1)
        {
            string input = Console.ReadLine();
            isNumber = int.TryParse(input, out intNumber);
            if (!isNumber && intNumber < 1)
            {
                Console.WriteLine("Вы ввели не положительное число!");
            }
        }
        return intNumber;
    }
    
    public static double CorrectDoubleInput()
    {
        bool isNumber = false;
        double doubleNumber = 0.0;
        while (!isNumber)
        {
            string input = Console.ReadLine();
            isNumber = double.TryParse(input, out doubleNumber);
            if (!isNumber)
            {
                Console.WriteLine("Вы ввели не число с плавающей запятой!");
            }
        }
        return doubleNumber;
    }
    
    public static void TextSeparator() => Console.WriteLine("------------------------");
}