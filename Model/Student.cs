using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsAPI;

[Table("Students")]
public class Student
{
    [Key]
    [Required]
    public int ID { get; set; }

    public string Name { get; set; }

    public int Eng { get; set; }

    public int Mat { get; set; }

    public int Sci { get; set; }

    public Student()
    {
        
    }

    public Student(int id, string name, int eng, int mat, int sci)
    {
        ID = id;
        Name = name;
        Eng = eng;
        Mat = mat;
        Sci = sci;
    }
    [NotMapped]
    public int TotalMarks
    {
        get
        {
            return Eng + Mat + Sci;
        }
    }

    [NotMapped]
    public double Average
    {
        get
        {
            return TotalMarks / 3.0;
        }
    }

    [NotMapped]
    public char Grade
    {
        get
        {
            double avg = Average;
            if (avg >= 70)
                return 'A';
            else if (avg >= 60)
                return 'B';
            else if (avg >= 50)
                return 'C';
            else if (avg >= 40)
                return 'D';
            else
                return 'F';
        }
    }

}
