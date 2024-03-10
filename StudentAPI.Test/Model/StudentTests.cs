using StudentsAPI;

namespace StudentAPI.Test;
[TestClass]

public class StudentsTests
{
    [TestMethod]
    public void TestTotalMarks()
    {
        var student = new Student(1, "John", 80, 90, 70);
        Assert.AreEqual(240, student.TotalMarks);
    }

    [TestMethod]
    public void TestAverage()
    {
        var student = new Student(1, "John", 80, 90, 70);
        Assert.AreEqual(80, student.Average);
    }

    [TestMethod]
    public void TestGradeA()
    {
        var student = new Student(1, "John", 80, 90, 70);
        Assert.AreEqual('A', student.Grade);
    }

    [TestMethod]
    public void TestGradeB()
    {
        var student = new Student(1, "John", 70, 80, 60);
        Assert.AreEqual('A', student.Grade);
    }

    [TestMethod]
    public void TestGradeC()
    {
        var student = new Student(1, "John", 60, 70, 50);
        Assert.AreEqual('B', student.Grade);
    }

    [TestMethod]
    public void TestGradeD()
    {
        var student = new Student(1, "John", 50, 60, 40);
        Assert.AreEqual('C', student.Grade);
    }

    [TestMethod]
    public void TestGradeF()
    {
        var student = new Student(1, "John", 40, 50, 30);
        Assert.AreEqual('D', student.Grade);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidScores()
    {
        var student = new Student(1, "John", -1, 50, 30);
    }
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestNegativeScore1()
    {
        var student = new Student(1, "John", -1, 50, 30);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestNegativeScore2()
    {
        var student = new Student(1, "John", 50, -1, 30);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestNegativeScore3()
    {
        var student = new Student(1, "John", 50, 50, -1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestNullName()
    {
        var student = new Student(1, null, 50, 50, 50);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestEmptyName()
    {
        var student = new Student(1, "", 50, 50, 50);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidId()
    {
        var student = new Student(-1, "John", 50, 50, 50);
    }

}
