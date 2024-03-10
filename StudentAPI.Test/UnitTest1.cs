namespace StudentAPI.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(1, 1);
    }
    //create testmethod if multiplication of two numbers n and m is correct
    [TestMethod]
    public void TestMethod2()
    {
        //Arrange
        int n = 5;
        int m = 5;
        int expected = 25;
        //Act
        int actual = n * m;
        //Assert
        Assert.AreEqual(expected, actual);
    }
}