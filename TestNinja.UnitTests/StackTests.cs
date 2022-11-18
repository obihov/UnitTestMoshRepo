using TestNinja.Fundamentals;
    
namespace TestNinja.UnitTests;

[TestFixture]
public class StackTests
{
    //Test here can be conflicting.
    //Stack is in two conflicting namespace.
    //Make sure to use the TestNinja.Fundamentals

    [SetUp]
    public void Setup()
    {
        
    }
    
    
    [Test]
    [TestCase(null)]
    public void Push_GivenEmptyCollectionAndItemToAddIsNull_ThrowArgumentNullException(string item)
    {
        //ARRANGE
        var collection = new Fundamentals.Stack<string>();
        
        //ACT
        var anonymousMethod = () => collection.Push(null);
        var expectedException = Throws.ArgumentNullException;
        
        //ASSERT
        Assert.That(anonymousMethod, expectedException);
    }
    
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    public void Push_GivenEmptyCollectionAndNewItemIsAdded_ValidateCollectionSizeIsNotZero(int item)
    {
        //ARRANGE
        var integerCollection = new Fundamentals.Stack<int>();
        
        //ACT
        integerCollection.Push(item);
        
        //ASSERT
        Assert.That(integerCollection.Count, Is.Not.EqualTo(0));
    }

    [Test]
    [TestCase(new int[] {1}, 1)]
    [TestCase(new int[] {1, 2}, 2)]
    [TestCase(new int[] {1, 2, 3}, 3)]
    public void Push_GivenEmptyCollectionAndMultipleItemsAreAdded_ValidateCollectionSize(int[] items, int expectedCollectionSize)
    {
        //ARRANGE
        var integerCollection = new Fundamentals.Stack<int>();
        
        //ACT
        items.ToList().ForEach(i => integerCollection.Push(i));
        
        //ASSERT
        Assert.That(integerCollection.Count, Is.EqualTo(expectedCollectionSize));
    }

    [Test]
    public void Pop_GivenEmptyCollectionGetItemAtTop_ThrowInvalidOperationException()
    {
        //ARRANGE
        var integerCollection = new Fundamentals.Stack<int>();
        
        //ACT
        var anonymousMethod = () => integerCollection.Pop();
        var exceptionThrown = Throws.Exception.TypeOf<InvalidOperationException>();
        
        //ASSERT - throw error if collection is empty and attempts to read top item from it.
        Assert.That(integerCollection.Count, Is.EqualTo(0)); //EMPTY Collection
        Assert.That(anonymousMethod, exceptionThrown);
    }
    
    [Test]
    public void Pop_GivenNonEmptyCollectionGetItemAtTop_ReturnTopItemThenRemoveItemFromCollection()
    {
        //ARRANGE
        var integerCollection = new Fundamentals.Stack<int>();
        var items = new int[] { 1, 2, 3 }; //NON-EMPTY Collection
        items.ToList().ForEach(i => integerCollection.Push(i));
        
        //ACT
        int collectionSizeBeforePop = integerCollection.Count;
        int topItem = integerCollection.Pop();
        int collectionSizeAfterPop = integerCollection.Count;
        
        //ASSERT - For Pop action, return the item and validate the collection size reduced after the pop action was executed.
        Assert.That(collectionSizeAfterPop, Is.LessThan(collectionSizeBeforePop));
        Assert.That(topItem, Is.EqualTo(3));
        
        //Note we cannot test if 3 is still in the collection directly because our custom created Stack class is not a collection class.
        //And the _list member which could have helped in testing this scenario is defined as private in the stack class. 
        //Therefore testing if the item on the stack was removed, would not be possible at this time.
        //Although we can test to see what item was returned, and whether the stack reduced or remained the same after the pop action was executed.
    }

    [Test]
    public void Peek_GivenEmptyCollectionGetItemAtTop_ThrowInvalidOperationException()
    {
        //ARRANGE
        var integerCollection = new Fundamentals.Stack<int>();
        
        //ACT
        var anonymousMethod = () => integerCollection.Peek();
        var exceptionThrown = Throws.Exception.TypeOf<InvalidOperationException>();
        
        //ASSERT - throw error if collection is empty and attempts to read top item from it.
        Assert.That(integerCollection.Count, Is.EqualTo(0)); //EMPTY Collection
        Assert.That(anonymousMethod, exceptionThrown);
    }
    
    [Test]
    public void Peek_GivenNonEmptyCollectionGetItemAtTop_ReturnTopItemDontRemoveItemFromCollection()
    {
        //ARRANGE
        var integerCollection = new Fundamentals.Stack<int>();
        var items = new int[] { 1, 2, 3 }; //NON-EMPTY Collection
        items.ToList().ForEach(i => integerCollection.Push(i));
        
        //ACT
        int collectionSizeBeforePeek = integerCollection.Count;
        int topItem = integerCollection.Peek();
        int collectionSizeAfterPeek = integerCollection.Count;
        
        //ASSERT - For Peek action, return the item and validate the collection size is unchanged after peek action was executed.
        Assert.That(collectionSizeBeforePeek, Is.EqualTo(collectionSizeAfterPeek));
        Assert.That(topItem, Is.EqualTo(3));
    }
}