using AutomobileLibrary;
using lab_12_1;
namespace TestMyList;

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
    public void AddToBegin_ShouldAddElementToBeginning()
    {
        var list = new MyList<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        list.AddToBegin(auto);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(auto, list.FindItem(auto).Data);
    }

    [TestMethod]
    public void AddToEnd_ShouldAddElementToEnd()
    {
        var list = new MyList<Automobile>();
        var auto1 = new Automobile("Test1", 2020, "Red", 20000, 10, new IdNumber(1));
        var auto2 = new Automobile("Test2", 2021, "Blue", 25000, 12, new IdNumber(2));

        list.AddToEnd(auto1);
        list.AddToEnd(auto2);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(auto1, list.FindItem(auto1).Data);
        Assert.AreEqual(auto2, list.FindItem(auto2).Data);
    }

    [TestMethod]
    public void RemoveItem_ShouldRemoveElement()
    {
        var list = new MyList<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        list.AddToEnd(auto);
        bool result = list.RemoveItem(auto);

        Assert.IsTrue(result);
        Assert.AreEqual(0, list.Count);
        Assert.IsNull(list.FindItem(auto));
    }

    [TestMethod]
    public void Clone_ShouldCreateDeepCopy()
    {
        var list = new MyList<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        list.AddToEnd(auto);
        var clonedList = list.Clone();

        Assert.AreEqual(list.Count, clonedList.Count);
        Assert.AreEqual(list.FindItem(auto).Data, clonedList.FindItem(auto).Data);
    }

    [TestMethod]
    public void Clear_ShouldRemoveAllElements()
    {
        var list = new MyList<Automobile>();
        var auto = new Automobile("Test", 2020, "Red", 20000, 10, new IdNumber(1));

        list.AddToEnd(auto);
        list.Clear();

        Assert.AreEqual(0, list.Count);
        Assert.IsNull(list.FindItem(auto));
    }

    [TestMethod]
    public void AddElementsWithOddIndices_ShouldAddCorrectNumberOfElements()
    {
        var list = new MyList<Automobile>();
        list.AddElementsWithOddIndices(5);

        Assert.AreEqual(5, list.Count);
    }

    [TestMethod]
    public void RemoveFromItemToEnd_ShouldRemoveCorrectElements()
    {
        var list = new MyList<Automobile>();
        var auto1 = new Automobile("Test1", 2020, "Red", 20000, 10, new IdNumber(1));
        var auto2 = new Automobile("Test2", 2021, "Blue", 25000, 12, new IdNumber(2));

        list.AddToEnd(auto1);
        list.AddToEnd(auto2);

        list.RemoveFromItemToEnd(item => item.Price == 20000);

        Assert.AreEqual(1, list.Count);
        Assert.IsNull(list.FindItem(auto1));
        Assert.IsNotNull(list.FindItem(auto2));
    }
}
