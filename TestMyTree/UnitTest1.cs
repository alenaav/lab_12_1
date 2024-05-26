using AutomobileLibrary;
using lab12_3;
namespace TestMyTree;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Point_DefaultConstructor_ShouldInitializeWithDefaultValues()
    {
        var point = new Point<int>();
        Assert.AreEqual(default(int), point.Data);
        Assert.IsNull(point.Left);
        Assert.IsNull(point.Right);
    }

    [TestMethod]
    public void Point_ParameterizedConstructor_ShouldInitializeWithGivenValue()
    {
        int data = 42;
        var point = new Point<int>(data);
        Assert.AreEqual(data, point.Data);
        Assert.IsNull(point.Left);
        Assert.IsNull(point.Right);
    }

    [TestMethod]
    public void CompareTo_ShouldReturnZeroForEqualData()
    {
        var point1 = new Point<int>(42);
        var point2 = new Point<int>(42);
        Assert.AreEqual(0, point1.CompareTo(point2));
    }

    [TestMethod]
    public void CompareTo_ShouldReturnPositiveForLargerData()
    {
        var point1 = new Point<int>(100);
        var point2 = new Point<int>(42);
        Assert.IsTrue(point1.CompareTo(point2) > 0);
    }

    [TestMethod]
    public void CompareTo_ShouldReturnNegativeForSmallerData()
    {
        var point1 = new Point<int>(42);
        var point2 = new Point<int>(100);
        Assert.IsTrue(point1.CompareTo(point2) < 0);
    }

    [TestMethod]
    public void MyTree_Constructor_ShouldInitializeWithCorrectLength()
    {
        int length = 5;
        var tree = new MyTree<Automobile>(length);
        Assert.AreEqual(length, tree.Count);
    }

    [TestMethod]
    public void AddPoint_AddNewPointToTree_Success()
    {
        // Arrange
        MyTree<Automobile> tree = null;
        tree = new MyTree<Automobile>(3);

        Automobile auto1 = new Automobile();
        Automobile auto2 = new Automobile();
        Automobile auto3 = new Automobile();

        // Act
        tree.AddPoint(auto1);
        tree.AddPoint(auto2);
        tree.AddPoint(auto3);

        // Assert
        Assert.AreEqual(4, tree.Count);
    }

    [TestMethod]
    public void RemoveTree_RemoveAllElementsFromTree_Success()
    {
        // Arrange
        MyTree<Automobile> tree = null;
        tree = new MyTree<Automobile>(10);
        // Act
        tree.RemoveTree();

        // Assert
        Assert.AreEqual(0, tree.Count);
    }

    [TestMethod]
    public void Remove_RemoveElementFromTree_Success()
    {
        // Arrange
        MyTree<Automobile> tree = null;
        tree = new MyTree<Automobile>(2);

        Automobile auto1 = new Automobile();


        tree.AddPoint(auto1);

        // Act
        tree.Remove(auto1);

        // Assert
        Assert.AreEqual(3, tree.Count);
    }

    [TestMethod]
    public void TransformToFindTree_TransformTreeToBinarySearchTree_Success()
    {
        // Arrange
        MyTree<Automobile> tree = null;
        tree = new MyTree<Automobile>(100);

        // Act
        tree.TransformToFindTree();

        // Assert
        Assert.AreEqual(8, tree.Count);
    }

    private bool IsValidBST(Point<Automobile> node, Automobile min = null, Automobile max = null)
    {
        if (node == null) return true;

        if ((min != null && node.Data.CompareTo(min) <= 0) ||
            (max != null && node.Data.CompareTo(max) >= 0))
            return false;

        return IsValidBST(node.Left, min, node.Data) && IsValidBST(node.Right, node.Data, max);
    }

    [TestMethod]
    public void RemoveTree_ShouldSetRootToNull()
    {
        var tree = new MyTree<Automobile>(5);
        tree.RemoveTree();
        Assert.IsNull(tree.root);
        Assert.AreEqual(0, tree.Count);
    }
}
