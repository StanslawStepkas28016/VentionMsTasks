using System.Collections;

namespace DecoupleWithInterfaces;

public class Classroom : IEnumerable<Student>
{
    private List<Student> _students = new();

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
    
    public void SortStudentByAge()
    {
        // Since the compareTo method is implemented in the Student class, it will sort by age
        _students.Sort();
    }

    public IEnumerator<Student> GetEnumerator()
    {
        return _students.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}