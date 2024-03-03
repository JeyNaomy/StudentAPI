
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
}
   