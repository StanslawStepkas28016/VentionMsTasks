namespace DecoupleWithInterfaces;

class Program
{
    public static void Main(string[] args)
    {
        IPerson teacher = new Teacher { Name = "Helen Karu", Age = 35 };
        IPerson student1 = new Student { Name = "Eba Lencho", Age = 20 };
        IPerson student2 = new Student { Name = "Frederiek Eppink", Age = 22 };

        PersonUtilities.PrintPersonDetails(teacher);
        PersonUtilities.PrintPersonDetails(student1);

        Classroom classroom = new();
        classroom.AddStudent((Student)student1);
        classroom.AddStudent((Student)student2);

        classroom.SortStudentByAge();

        Console.WriteLine("\nSorted Students by Age:");

        foreach (Student student in classroom)
        {
            student.DisplayInfo();
        }

        // Demonstrate ArgumentException for incompatible comparison
        try
        {
            Console.WriteLine("\nAttempting to compare a Student with a Teacher...");
            Student student = (Student)student1;
            int comparisonResult = student.CompareTo(teacher); // This will throw an exception
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}