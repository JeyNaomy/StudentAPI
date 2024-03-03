using Microsoft.EntityFrameworkCore;

namespace StudentsAPI;

public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=students.db");
       //optionsBuilder.UseInMemoryDatabase("Students");
    }

}

