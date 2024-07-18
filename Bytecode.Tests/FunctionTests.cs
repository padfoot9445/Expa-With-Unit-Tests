using Bytecode.ObjRepresentations;
using Bytecode.Serialized;
namespace Tests.Bytecode;
[TestFixture] 
class FunctionTests
{
    //TODO: Make setup and teardown methods
    delegate IFunction ConstructBlankFunction(ISection section);
    private static ConstructBlankFunction CBF = (ISection section) => FunctionProvider.New(null, [], [], section);
    [Test]
    public void New__Construct_Multiple_Instances__They_Have_Different_Pointers()
    {
        HashSet<uint> UsedPointers = new HashSet<uint>();
        for(int i = 0; i < 5; i++)
        {
            uint Pointer = CBF(new SectionMock()).FunctionPointer;;
            Assert.That(UsedPointers, Does.Not.Contain(Pointer));
            UsedPointers.Add(Pointer);
        }
    }
    [Test]
    public void New__Construct_Multiple_Instances__They_Have_Sequential_Pointers()
    {
        uint? LastPointer = null;
        for(int i = 0; i < 5; i++)
        {
            uint Pointer = CBF(new SectionMock()).FunctionPointer;
            if(LastPointer is not null)
            {
                Assert.That(Pointer, Is.EqualTo(LastPointer + 1));
                LastPointer = Pointer;
            }
            else
            {
                LastPointer = Pointer;
            }
        }
    }
    [Test]
    public void New__Construct_Multiple_Instances__The_Sections_Are_Accessible_From_The_Function_Pointers()
    {
        ISection[] Sections = new ISection[5] { new SectionMock(1), new SectionMock(2), new SectionMock(3), new SectionMock(4), new SectionMock(5) };
        uint[] Pointers = new uint[5] { CBF(Sections[0]).FunctionPointer, CBF(Sections[1]).FunctionPointer, CBF(Sections[2]).FunctionPointer, CBF(Sections[3]).FunctionPointer, CBF(Sections[4]).FunctionPointer };
        foreach((uint pointer, ISection section) in Pointers.Zip(Sections, (x, y) => new Tuple<uint, ISection>(x, y)))
        {
            Assert.That(((SectionMock)FunctionProvider.GetFunctionsArray[pointer]).__debug_id, Is.EqualTo(((SectionMock)section).__debug_id));
        }
        
    }
    [Test]
    public void GetFunctionsArray__Construct_Multiple_Instances__Returns_Correct()
    {
        SectionMock[] Sections = { new SectionMock(1), new SectionMock(2), new SectionMock(3), new SectionMock(4) };
        foreach(SectionMock section in Sections)
        {
            CBF(section);
        }
        Assert.That(FunctionProvider.GetFunctionsArray, Is.EquivalentTo(Sections));
    }
}