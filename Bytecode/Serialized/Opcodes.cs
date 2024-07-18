using ClassEnum;

namespace Bytecode.Serialized;
/// <summary>
/// An Enumeration of all opcodes implemented in a normal class to support things such as interface implementation, methods, and more.
/// </summary>
public sealed partial class Opcode: ClassEnumBase<int>, ISingleWordSerializable, IWord
{
    
    private static readonly Dictionary<int, Opcode> value_to_enum = new();
    protected override void AddToValueToEnum()
    {
        value_to_enum[Value] = this;
    }


    ILengthOneSection ISingleWordSerializable.Serialize()
    {
        throw new NotImplementedException();
    }

    ISection ISerializableToBytecode.Serialize()
    {
        throw new NotImplementedException();
    }

    private Opcode(string Name): base(Name){ }
    public static explicit operator int(Opcode opcode) => opcode.Value;
    public static explicit operator Opcode(int to_be_opcode) => value_to_enum[to_be_opcode];
    public static explicit operator Opcode(uint to_be_opcode) => (Opcode)(int)to_be_opcode;
    public static explicit operator uint(Opcode opcode) => (uint)(int)opcode;

    #region enums
    #region Stack Operations
    public static readonly Opcode Push = new Opcode("Push"); //Push <[ConstAddress | Address]>
    public static readonly Opcode Pop = new Opcode("Pop"); //Pop <[Address]> OR <[Address]>
    public static readonly Opcode Peek = new Opcode("Peek"); //Peek <[Address]>
    public static readonly Opcode InsertAt = new Opcode("InsertAt"); //InsertAt <[Stack offset from bottom]> <[ConstAddress | Address]> (Should not insert at stack from runtime offset)
    public static readonly Opcode PopAt = new Opcode("PopAt"); //PopAt <[Stack offset from bottom]> <[Address]> (Should not Pop at stack from runtime value)
    #endregion

    #region Memory Operations
    #region malloc
    public static readonly Opcode Malloc = new Opcode("Malloc"); //Malloc (No Args, pushes the address to the stack)
    public static readonly Opcode MallocChunk = new Opcode("MallocChunk"); //MallocChunk [STACK: length of chunk] (Pushes the start of the address to the stack)
    public static readonly Opcode AllocArray = new Opcode("AllocArray"); //AllocArray [STACK: Length of Array] (Allocates a block of memory l + 3 in length. The first value is the length; the second value is the type code, and the last value is null. Then, it pushes the start of the array(i.e. the address of the third location) to the stack.)
    #endregion
    #endregion
    #region Functions
    public static readonly Opcode Call = new Opcode("Call"); //Call [STACK: Object type code] <[Interface type code]> <[Method offset]> 
    #endregion
    #endregion
}
