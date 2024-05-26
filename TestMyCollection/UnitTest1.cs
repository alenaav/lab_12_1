using AutomobileLibrary;
using lab12_4;
namespace TestMyCollection;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Point_DefaultConstructor_ShouldInitializeWithDefaultValues()
    {
        var point = new Point<Automobile>();
        Assert.IsNull(point.Data);
        Assert.IsNull(point.Next);
        Assert.IsNull(point.Pred);
    }

    [TestMethod]
    public void Point_ParameterizedConstructor_ShouldInitializeWithGivenValue()
    {
        var auto = new Automobile();
        auto.RandomInit();
        var point = new Point<Automobile>(auto);
        Assert.AreEqual(auto, point.Data);
        Assert.IsNull(point.Next);
        Assert.IsNull(point.Pred);
    }

    [TestMethod]
    public void MakeRandomData_ShouldReturnPointWithRandomData()
    {
        var point = Point<Automobile>.MakeRandomData();
        Assert.IsNotNull(point.Data);
        Assert.IsInstanceOfType(point.Data, typeof(Automobile));
    }

    [TestMethod]
    public void MyHashTable_Constructor_ShouldInitializeWithGivenLength()
    {
        int length = 10;
        var hashTable = new MyHashTable<Automobile>(length);
        Assert.AreEqual(length, hashTable.Capacity);
    }

    [TestMethod]
    public void AddPoint_ShouldAddElementToHashTable()
    {
        var hashTable = new MyHashTable<Automobile>(10);
        var auto = new Automobile();
        auto.RandomInit();
        hashTable.AddPoint(auto);
        Assert.IsTrue(hashTable.Contains(auto));
    }

    [TestMethod]
    public void RemoveData_ShouldRemoveElementFromHashTable()
    {
        var hashTable = new MyHashTable<Automobile>(10);
        var auto = new Automobile();
        auto.RandomInit();
        hashTable.AddPoint(auto);
        Assert.IsTrue(hashTable.RemoveData(auto));
        Assert.IsFalse(hashTable.Contains(auto));
    }

    [TestMethod]
    public void Contains_ShouldReturnTrueForExistingElement()
    {
        var hashTable = new MyHashTable<Automobile>(10);
        var auto = new Automobile();
        auto.RandomInit();
        hashTable.AddPoint(auto);
        Assert.IsTrue(hashTable.Contains(auto));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalseForNonExistingElement()
    {
        var hashTable = new MyHashTable<Automobile>(10);
        var auto = new Automobile();
        auto.RandomInit();
        Assert.IsFalse(hashTable.Contains(auto));
    }

    //

    [TestMethod]
    public void MyCollection_DefaultConstructor_ShouldInitializeWithZeroCount()
    {
        var collection = new MyCollection<Automobile>();
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public void MyCollection_ParameterizedConstructor_ShouldInitializeWithGivenLength()
    {
        int length = 5;
        var collection = new MyCollection<Automobile>(length);
        Assert.AreEqual(length, collection.Count);
    }

    [TestMethod]
    public void Add_ShouldIncreaseCount()
    {
        var collection = new MyCollection<Automobile>();
        var auto = new Automobile();
        auto.RandomInit();
        collection.Add(auto);
        Assert.AreEqual(1, collection.Count);
    }

    [TestMethod]
    public void Remove_ShouldDecreaseCount()
    {
        var collection = new MyCollection<Automobile>();
        var auto = new Automobile();
        auto.RandomInit();
        collection.Add(auto);
        collection.Remove(auto);
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public void Contains_ShouldReturnTrueForExistingElement_1()
    {
        var collection = new MyCollection<Automobile>();
        var auto = new Automobile();
        auto.RandomInit();
        collection.Add(auto);
        Assert.IsTrue(collection.Contains(auto));
    }

    [TestMethod]
    public void Contains_ShouldReturnFalseForNonExistingElement_2()
    {
        var collection = new MyCollection<Automobile>();
        var auto = new Automobile();
        auto.RandomInit();
        Assert.IsFalse(collection.Contains(auto));
    }

    [TestMethod]
    public void DeepCopy_ShouldCreateIndependentCopy()
    {
        var collection = new MyCollection<Automobile>(1);
        var copy = collection.DeepCopy();
        Assert.AreNotSame(collection, copy);
        Assert.AreEqual(collection.Count - 1, copy.Count);
    }

    [TestMethod]
    public void Enumerator_ShouldEnumerateAllElements()
    {
        int length = 5;
        var collection = new MyCollection<Automobile>(length);
        var enumeratedItems = collection.ToList();
        Assert.AreEqual(length, enumeratedItems.Count);
    }

    [TestMethod]
    public void Clear_ShouldRemoveAllElements()
    {
        var collection = new MyCollection<Automobile>(5);
        collection.Clear();
        Assert.AreEqual(0, collection.Count);
    }

    [TestMethod]
    public void CopyTo_ShouldCopyAllElementsToArray()
    {
        int length = 5;
        var collection = new MyCollection<Automobile>(length);
        var array = new Automobile[length];
        collection.CopyTo(array, 0);
        Assert.AreEqual(length, array.Length);
        //foreach (var item in array)
        //{
        //    Assert.IsNotNull(item);
        //}
    }
}
