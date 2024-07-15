using System.Reflection;
using Bytecode;
namespace Tests.Bytecode;
[TestFixture]
class ConstantProviderTests
{
    [SetUp]
    [TearDown]
    public void ResetState()
    {
       typeof(ConstantProvider).GetField("StorageProvider", BindingFlags.NonPublic | BindingFlags.Static)!.SetValue(null, new UniquePointerAndStorageProvider<uint>());
    }
    [Test]
    public void ConstantPointer__8__Returns_Correct()
    {
        Assert.That(ConstantProvider.ConstantPointer(0b1000), Is.EqualTo(0x80000008));
    }
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(30)]
    public void GetConstantArray__Various_states_of_storage__Returns_Correct(int NumberOfValues)
    {
        List<uint> ExpectedList = new();
        for(int i = 0; i < NumberOfValues; i++)
        {
            ConstantProvider.Add((uint)i);
            ExpectedList.Add((uint)i);
        }
        Assert.That(ConstantProvider.GetConstantArray, Is.EquivalentTo(ExpectedList.ToArray()));
    }
    
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(30)]
    public void Last__Various_Numbers_Of_Additions__Returns_Correct(int NumberOfValues)
    {
        for(int i = 0; i < NumberOfValues; i++)
        {
            ConstantProvider.Add((uint)i);
        }
        Assert.That(ConstantProvider.Last, Is.EqualTo(ConstantProvider.ConstantPointer((uint)NumberOfValues - 1)));
    }
    [TestCase(uint.MinValue, (uint)1)]
    [TestCase((uint.MinValue + uint.MaxValue) / 2, (uint)2)]
    [TestCase(uint.MaxValue, (uint)3)]
    public void Add__Various_Numbers__Returns_Correct(uint Num1, uint Num2)
    {
        Assert.That(ConstantProvider.Add(Num1), Is.EqualTo(ConstantProvider.ConstantPointer(0)));
        Assert.That(ConstantProvider.Add(Num2), Is.EqualTo(ConstantProvider.ConstantPointer(1)));
        Assert.That(ConstantProvider.GetConstantArray, Is.EquivalentTo(new uint[2] { Num1, Num2 }));
    }
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(30)]
    public void Add__Array_Various_Lengths__Returns_Correct(int NumberOfValues)
    {
        uint[] ArrayToBeAdded = new uint[NumberOfValues];
        for(uint i = 0; i < NumberOfValues; i++)
        {
            ArrayToBeAdded[i] = i;
        }
        Assert.That(ConstantProvider.Add(ArrayToBeAdded), Is.EqualTo(ConstantProvider.ConstantPointer(0)));
        Assert.That(ConstantProvider.GetConstantArray, Is.EquivalentTo(ArrayToBeAdded));
    }
    [Test]
    public void ConstantPointer__With_Negative_Int__Throws_Argument_Exception()
    {
        Assert.That(() => ConstantProvider.ConstantPointer(-1), Throws.InstanceOf(typeof(ArgumentOutOfRangeException)));
    }
    [TestCase(int.MaxValue)]
    [TestCase(0)]
    public void ConstantPointer__With_Positive_Int__Returns_Same_As_Uint(int input)
    {
        Assert.That(ConstantProvider.ConstantPointer(input), Is.EqualTo(ConstantProvider.ConstantPointer((uint)input)));
    }
}