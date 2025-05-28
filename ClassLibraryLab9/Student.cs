using Lab10;
using static AdditionalFunctions.AdditionalFunctions;

namespace Lab9_1;

public class Student: IInit, ICloneable
{
    private static string[] availableNames = new string[] {
       "София",
       "Ева",
       "Анна",
       "Мария",
       "Виктория",
       "Михаил",
       "Артём ",
       "Александр",
       "Матвей",
       "Максим"
    };
    
    // переменные
    public string Name { get; set; }
    public IdNumber Id { get; set; }
    private int age;
    private double gpa;
    private static int numberStudents;
    
    // свойства
    
    public static int NumberStudents {get => numberStudents;}
    public int Age
    {
        get => age;
        set
        {
            try
            {
                if (value < 18) throw new Exception("Студенту не может быть меньше 18 лет");
                age = value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                age = -1;
            }
        }
    }

    public double Gpa
    {
        get => gpa;
        set
        {
            try
            {
                if (value < 0) throw new Exception("Средняя оценка не может быть меньше 0");
                if (value > 10) throw new Exception("Средняя оценка не может быть больше 10");
                
                gpa = value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                gpa = -1;
            }
        }
    }
    
    // конструкторы
    public Student(int id, string name, int age, double gpa)
    {
        Id = new IdNumber(id);
        Name = name;
        Age = age;
        Gpa = gpa;
        numberStudents++;
    }

    public Student()
    {
        Id = new IdNumber();
        Name = "Вася";
        Age = 18;
        Gpa = 0;
        numberStudents++;
    }
    
    // методы
    public void Info()
    {
        Console.WriteLine($"Имя: {Name}, Возраст:{Age}, gpa: {Gpa}");
    }
    
    public (string, string) CompareStudents(Student anotherStudent)
    {
        string ageComprassion = age < anotherStudent.Age ? "младше" : age > anotherStudent.Age ? "старше" : "ровесник";
        string gpaComrassion = gpa < anotherStudent.Gpa ? "ниже" : gpa > anotherStudent.Gpa ? "выше" : "равен";
    
        return (ageComprassion, gpaComrassion);
    }

    public static (string, string) CompareStudents(Student firstStudent, Student secondStudent)
    {
        string ageComprassion = firstStudent.Age < secondStudent.Age ? "младше" : firstStudent.Age > secondStudent.Age ? "старше" : "ровесник";
        string gpaComrassion = firstStudent.Gpa < secondStudent.Gpa ? "ниже" : firstStudent.Gpa > secondStudent.Gpa ? "выше" : "равен";
        
        return (ageComprassion, gpaComrassion);
    }

    public static Student operator ~(Student student)
    {
        student.Name = student.Name.Substring(0,1).ToUpper() + student.Name.Substring(1);
        return student;
    }

    public static Student operator ++(Student student)
    {
        student.Age++;
        return student;
    }

    public static explicit operator int(Student student)
    {
        if (student.Age < 18 || student.Age > 22) return -1;
        return student.Age - 17;
    }
    
    public static implicit operator bool(Student student)
    {
        return student.Gpa >= 6 ? true : false;
    }

    public static Student operator %(Student student, string newName)
    {
        Student newStudent = new Student(student.Id.Id, newName, student.Age, student.Gpa);
        return newStudent;
    }

    public static Student operator -(Student student, double d)
    {
            Student newStudent;
            if (student.Gpa - d > 0) newStudent = new Student(student.Id.Id, student.Name, student.Age, student.Gpa - d);
            else throw new Exception("Gpa не может стать отрицательным");
            return newStudent;
    }

    public override bool Equals(object obj)
    {
        if (obj is Student student) 
            return Id.Id == student.Id.Id
                   && Name == student.Name 
                   && Age == student.Age 
                   && Math.Abs(Gpa - student.Gpa) < 0.0001;
        return false;
    }

    public void Init()
    {
        Console.WriteLine("Введите имя студента: ");
        Name = Console.ReadLine();
        Console.WriteLine("Введите возраст студента (больше 17): ");
        Age = CorrectIntegerInput();
        Console.WriteLine("Введите среднюю оценку студента (от 0 до 10): ");
        Gpa = CorrectIntegerInput();
    }
    
    public void RandomInit()
    {
        Random rand = new Random();
        Name = availableNames[rand.Next(0, availableNames.Length)];
        Age = rand.Next(18, 23);
        Gpa = rand.NextDouble()*10;
    }
    
    public override string ToString()
    {
        return $"Id студента: {Id.Id} \nИмя студента: {Name} \nВозраст:{Age} \nGpa: {Math.Round(Gpa,2)}\n";
    }
    
    public object Clone()
    {
        return new Student(this.Id.Id, this.Name, this.Age, this.Gpa);
    }

    public object ShallowClone()
    {
        return this.MemberwiseClone();
    }
}