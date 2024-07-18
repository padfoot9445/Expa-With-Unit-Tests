using Bytecode.Serialized;
using Bytecode.ObjRepresentations;
using static Bytecode.Serialized.BytecodeMetadata;
using static Bytecode.Serialized.Opcode;
namespace Tests.Bytecode;
[TestFixture]
public class BytecodeMetadataTest
{
    private readonly Section section = new Section
    {
        Value = [MallocChunk.AsUInt(), InsertAt.AsUInt(), 1, ConstantProvider.ConstantPointer(2)]
    };
    private Opcode InvalidOpcode = (Opcode)0;
    private readonly Type TypeOfInvalidOpcodeException = typeof(InvalidOperationException);
    [SetUp]
    public void SetUp()
    {

        unchecked
        {
            InvalidOpcode = (Opcode)uint.MaxValue;
        }
    }
    public static object[] GetSigniture__GetSignitureArray__SignitureEquals__Cases =
    {
        new object[]{Opcode.AllocArray,new NumberType[0]{}},
        new object[]{Call, new NumberType[2]{NumberType.ClassCode, NumberType.ClassCode}}
    };
    [TestCaseSource(nameof(GetSigniture__GetSignitureArray__SignitureEquals__Cases))]
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
    [Test]
    public void GetArgNum__Various_Opcodes__ReturnsCorrectArgNum()
    {
        Assert.That(Peek.GetArgNum(), Is.EqualTo(1));
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
    [Test]
    public void AsInt__Various_Opcodes__Correct_Conversion()
    {
        Assert.That(Malloc.AsInt(), Is.EqualTo((int)Malloc));
    }
    [Test]
    public void AsUint__Various_Opcodes__Correct_Conversion()
    {
        Assert.That(Malloc.AsUInt(), Is.EqualTo((uint)Malloc));
    }
    [Test]
    public void GetInfo__Invalid_Opcode__Throws()
    {
        Assert.Throws(TypeOfInvalidOpcodeException, () => InvalidOpcode.GetInfo());
    }
    public static object[] GetInfo__Various_Opcodes__ReturnsCorrect__Cases =
    {
        new object[] {Malloc, 0, new NumberType[0]},
        new object[] {PopAt, 2, new NumberType[]{NumberType.InlineConst, NumberType.Address}}
    };
    [TestCaseSource(nameof(GetInfo__Various_Opcodes__ReturnsCorrect__Cases))]
    public void GetInfo__Various_Opcodes__ReturnsCorrect(Opcode opcode, int ArgNo, NumberType[] ArgTypes)
    {
        IOpcodeInfo actual = opcode.GetInfo();
        IOpcodeInfo expected = new OpcodeInfo(opcode, ArgNo, ArgTypes);

        Assert.That(actual, Is.EqualTo(expected));
    }
}