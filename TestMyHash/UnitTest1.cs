using AutomobileLibrary;
using lab12_2;
namespace TestMyHash;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Point_Constructor_1()
    {
        // Arrange
        Point<Automobile> point = new Point<Automobile>();

        // Act

        // Assert
        Assert.IsNull(point.Data);
    }

    [TestMethod]
    public void Constructor_WithData_ShouldInitializeWithData()
    {
        int data = 42;
        var point = new Point<int>(data);

        Assert.AreEqual(data, point.Data);
        Assert.IsNull(point.Next);
        Assert.IsNull(point.Prev);
    }

    [TestMethod]
    public void ToString_ShouldReturnDataToString()
    {
        int data = 42;
        var point = new Point<int>(data);

        Assert.AreEqual(data.ToString(), point.ToString());
    }

    [TestMethod]
    public void GetHashCode_ShouldReturnDataHashCode()
    {
        int data = 42;
        var point = new Point<int>(data);

        Assert.AreEqual(data.GetHashCode(), point.GetHashCode());
    }

    [TestMethod]
    public void AddPoint_ShouldAddElementToTable()
    {
        var table = new MyHashTable<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        table.AddPoint(auto);

        Assert.IsTrue(table.Contains(auto));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrueForExistingElement()
    {
        var table = new MyHashTable<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        table.AddPoint(auto);

        Assert.IsTrue(table.Contains(auto));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalseForNonExistingElement()
    {
        var table = new MyHashTable<Automobile>();
        var auto1 = new Automobile("Test1", 2020, "Red", 20000, 10, new IdNumber(1));
        var auto2 = new Automobile("Test2", 2021, "Blue", 25000, 12, new IdNumber(2));

        table.AddPoint(auto1);

        Assert.IsFalse(table.Contains(auto2));
    }

    [TestMethod]
    public void RemoveData_ShouldRemoveElementFromTable()
    {
        var table = new MyHashTable<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        table.AddPoint(auto);
        bool result = table.RemoveData(auto);

        Assert.IsTrue(result);
        Assert.IsFalse(table.Contains(auto));
    }

    [TestMethod]
    public void RemoveData_ShouldReturnFalseForNonExistingElement()
    {
        var table = new MyHashTable<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        bool result = table.RemoveData(auto);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void RemoveByKey_ShouldRemoveElementFromTable()
    {
        var table = new MyHashTable<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        table.AddPoint(auto);
        bool result = table.RemoveByKey(auto);

        Assert.IsTrue(result);
        Assert.IsFalse(table.ContainsKey(auto));
    }

    [TestMethod]
    public void RemoveByKey_ShouldReturnFalseForNonExistingElement()
    {
        var table = new MyHashTable<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        bool result = table.RemoveByKey(auto);

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void ContainsKey_ShouldReturnTrueForExistingElement()
    {
        var table = new MyHashTable<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        table.AddPoint(auto);

        Assert.IsTrue(table.ContainsKey(auto));
    }

    [TestMethod]
    public void ContainsKey_ShouldReturnFalseForNonExistingElement()
    {
        var table = new MyHashTable<Automobile>();
        var auto1 = new Automobile("Test1", 2020, "Red", 20000, 10, new IdNumber(1));
        var auto2 = new Automobile("Test2", 2021, "Blue", 25000, 12, new IdNumber(2));

        table.AddPoint(auto1);

        Assert.IsFalse(table.ContainsKey(auto2));
    }
}
