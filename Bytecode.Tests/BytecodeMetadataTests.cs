using Bytecode;
using static Bytecode.BytecodeMetadata;
using static Bytecode.Opcode;
namespace Tests.Bytecode;
[TestFixture]
public class BytecodeMetadataTest
{
    private readonly Section section = new Section
    {
        Value = [MallocChunk.AsUInt(), InsertAt.AsUInt(), 1, ConstantProvider.ConstantPointer(2)]
    };
    private Opcode InvalidOpcode = 0;
    private readonly Type TypeOfInvalidOpcodeException = typeof(InvalidOperationException);
    [SetUp]
    public void SetUp()
    {

        unchecked
        {
            InvalidOpcode = (Opcode)uint.MaxValue;
        }
    }
    [TestCase(Opcode.AllocArray, new NumberType[0] { })]
    [TestCase(Opcode.Call, new NumberType[2] { NumberType.ClassCode, NumberType.ClassCode })]
    public void GetSigniture__GetSignitureArray__SignitureEquals(Opcode opcode, NumberType[] signiture)
    {
        Assert.That(signiture, Is.EqualTo(opcode.GetSigniture()));
    }
    [Test]
    public void GetSigniture__InvalidOpcode__ThrowsInvalidOperationException()
    {
        unchecked
        {
            Assert.Throws(TypeOfInvalidOpcodeException, () => InvalidOpcode.GetSigniture());
        }
    }
    [Test]
    public void GetArgNum__InvalidOpcode__ThrowsInvalidOperationException()
    {
        Assert.Throws(TypeOfInvalidOpcodeException, () => InvalidOpcode.GetArgNum());
    }
    [TestCase(Peek, 1)]
    [TestCase(Malloc, 0)]
    [TestCase(Call, 2)]
    public void GetArgNum__Various_Opcodes__ReturnsCorrectArgNum(Opcode opcode, int expected)
    {
        Assert.That(opcode.GetArgNum(), Is.EqualTo(expected));
    }

    [Test]
    public void GetInfo__Section_Contains_Invalid_Opcode__Throws()
    {
        Section tempsection = new Section
        {
            Value = section.Value.Concat([InvalidOpcode.AsUInt()]).Concat(section.Value).ToList()
        };
        Assert.Throws(TypeOfInvalidOpcodeException, () => tempsection.GetInfo());
    }
    [Test]
    public void GetInfo__Section__Returns_Correct()
    {
        IOpcodeInfo?[] expected =
        [
            new OpcodeInfo(MallocChunk, 0, []),
            new OpcodeInfo(InsertAt, 2, [NumberType.InlineConst, NumberType.Address]),
            null,
            null
        ];
        Assert.That(section.GetInfo(), Is.EqualTo(expected));
    }
    [TestCase(Malloc)]
    [TestCase(Call)]
    public void AsInt__Various_Opcodes__Correct_Conversion(Opcode opcode)
    {
        Assert.That(opcode.AsInt(), Is.EqualTo((int)opcode));
    }
    [TestCase(Malloc)]
    [TestCase(Call)]
    public void AsUint__Various_Opcodes__Correct_Conversion(Opcode opcode)
    {
        Assert.That(opcode.AsUInt(), Is.EqualTo((uint)opcode));
    }
    [Test]
    public void GetInfo__Invalid_Opcode__Throws()
    {
        Assert.Throws(TypeOfInvalidOpcodeException, () => InvalidOpcode.GetInfo());
    }
    [TestCase(Malloc, 0, new NumberType[0])]
    [TestCase(PopAt, 2, new NumberType[]{NumberType.InlineConst, NumberType.Address})]
    public void GetInfo__Various_Opcodes__ReturnsCorrect(Opcode opcode, int ArgNo, NumberType[] ArgTypes)
    {
        IOpcodeInfo actual = opcode.GetInfo();
        IOpcodeInfo expected = new OpcodeInfo(opcode, ArgNo, ArgTypes);

        Assert.That(actual, Is.EqualTo(expected));
    }
}