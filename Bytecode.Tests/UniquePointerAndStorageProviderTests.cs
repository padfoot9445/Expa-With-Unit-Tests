using Bytecode.ObjRepresentations;
namespace Tests.Bytecode;
abstract class BaseUniquePointerAndStorageProviderTests<T>
{
    /// <summary>
    /// A Deterministic creation of a sample value from a seed
    /// </summary>
    /// <param name="seed"></param>
    /// <returns></returns>
    private protected abstract T CreateSampleValue(int seed = 0);
    private protected UniquePointerAndStorageProvider<T>? PASP = null;
    [SetUp]
    public void SetUp()
    {
        PASP = new UniquePointerAndStorageProvider<T>();
    }
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(30)]
    public void GetConstantArray__Various_states_of_storage__Returns_Correct(int NumberOfValues)
    {
        List<T> ExpectedList = new();
        for(int i = 0; i < NumberOfValues; i++)
        {
            PASP!.Add(CreateSampleValue(i));
            ExpectedList.Add(CreateSampleValue(i));
        }
        Assert.That(PASP!.Array, Is.EquivalentTo(ExpectedList.ToArray()));
    }
    
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(30)]
    public void Last__Various_Numbers_Of_Additions__Returns_Correct(int NumberOfValues)
    {
        for(int i = 0; i < NumberOfValues; i++)
        {
            PASP!.Add(CreateSampleValue(i));
        }
        Assert.That(PASP!.LastPointer, Is.EqualTo(NumberOfValues - 1));
    }
    
    public void Add__Various_Numbers__Returns_Correct()
    {
        Assert.That(PASP!.Add(CreateSampleValue()), Is.EqualTo(0));
        Assert.That(PASP!.Add(CreateSampleValue(1)), Is.EqualTo(1));
        Assert.That(PASP!.Array, Is.EquivalentTo(new T[2] { CreateSampleValue(), CreateSampleValue(1)}));
    }
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(30)]
    public void Add__Array_Various_Lengths__Returns_Correct(int NumberOfValues)
    {
        T[] ArrayToBeAdded = new T[NumberOfValues];
        for(int i = 0; i < NumberOfValues; i++)
        {
            ArrayToBeAdded[i] = CreateSampleValue(i);
        }
        Assert.That(PASP!.Add(ArrayToBeAdded), Is.EqualTo(0));
        Assert.That(PASP.Array, Is.EquivalentTo(ArrayToBeAdded));
    }
}

[TestFixture]
class UniquePointerAndStorageProviderTestInt : BaseUniquePointerAndStorageProviderTests<int>
{
    private protected override int CreateSampleValue(int seed = 0)
    {
        return seed;
    }
}
[TestFixture]
class UniquePointerAndStorageProviderTestRef: BaseUniquePointerAndStorageProviderTests<MockRefType>
{
    private protected override MockRefType CreateSampleValue(int seed = 0)
    {
        return new MockRefType(seed);
    }
}