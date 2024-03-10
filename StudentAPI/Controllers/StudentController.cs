using Microsoft.AspNetCore.Mvc;

namespace StudentsAPI;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var students = await _studentService.GetStudentsAsync();
        if (students == null)
            return NotFound();
            else
            return students;
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetStudents(int id)
    {
        var s= _studentService.GetStudent(id);
        if (s == null)
           return NotFound(new {Error = "Student not found", ErrorCode = 900, ErrorDescription = "Student not found"});
           else
           return s;
    }

    [HttpPost]
    public ActionResult AddStudent(Student student)
    {
        _studentService.AddStudent(student);
        return CreatedAtAction(nameof(AddStudent), new { id = student.ID }, new {Student = student, code = 700, Description = "Student added successfully"});
       
    }

    [HttpPut]
    public void UpdateStudent(Student student)
    {
        _studentService.UpdateStudent(student);
    }

    [HttpDelete("{id}")]
    public void DeleteStudent(int id)
    {
        _studentService.DeleteStudent(id);
    }

    [HttpPatch("{id}")]
    public ActionResult UpdateMatMarks(int id, int Marks)
{
    var s = _studentService.GetStudent(id);
    if (s == null)
        return NotFound(new {Error = "Student not found", ErrorCode = 900, ErrorDescription = "Student not found"});
        s.Mat = Marks;
        _studentService.UpdateStudent(s);
        return Ok(new {Student = s, code = 700, Description = "Student updated successfully"});
}


    [HttpPatch("Marks/{id}")]
    public ActionResult UpdateMarks(int id, [FromBody] StudentMarks student)
    {
        var s = _studentService.GetStudent(id);
        var OldMarks = new StudentMarks { Eng = s.Eng, Mat = s.Mat, Sci = s.Sci };
        if (s == null)
            return NotFound(new {Error = "Student not found", ErrorCode = 900, ErrorDescription = "Student not found"});
            s.Mat = student.Mat;
            s.Eng = student.Eng;
            s.Sci = student.Sci;
            _studentService.UpdateStudent(s);
            return Ok(new {Student = s, code = 700, Description = "Student updated successfully", OldMarks = OldMarks});
    }
}
    public struct StudentMarks
    {
        public int Eng { get; set; }
        public int Mat { get; set; }
        public int Sci { get; set; }
    }
    

 

