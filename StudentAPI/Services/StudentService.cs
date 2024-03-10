
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentsAPI;

public class StudentService
{
    private readonly StudentDbContext _context;

    public StudentService(StudentDbContext context)
    {
        _context = context;
    }
    public List<Student> GetStudents()
    {
        return _context.Students.ToList();
    }

     public async Task<List<Student>> GetStudentsAsync()
    {
        var List = _context.Students.ToListAsync();
        Task.Delay(3000);
        return await List;
    }

    public Student GetStudent(int id)
    {
        return _context.Students.Find(id);
    }
    public void AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }
    public void UpdateStudent(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
    }
    public void DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);
        _context.Students.Remove(student);
        _context.SaveChanges();
    }
    //write a method to populate the database with ten students and total marks to be varied so that all grades are covered
    public void Populate()
    {
        _context.Students.Add(new Student(1, "John", 90, 80, 70));
        _context.Students.Add(new Student(2, "Jane", 80, 70, 60));
        _context.Students.Add(new Student(3, "Jim", 70, 60, 50));
        _context.Students.Add(new Student(4, "Jill", 60, 50, 40));
        _context.Students.Add(new Student(5, "Jack", 50, 40, 30));
        _context.Students.Add(new Student(6, "Joe", 40, 30, 20));
        _context.Students.Add(new Student(7, "Jenny", 30, 20, 10));
        _context.Students.Add(new Student(8, "Jerry", 20, 10, 5));
        _context.Students.Add(new Student(9, "Jesse", 10, 5, 2));
        _context.Students.Add(new Student(10, "Jasmine", 5, 2, 1));
        _context.SaveChanges();
    }
}
   