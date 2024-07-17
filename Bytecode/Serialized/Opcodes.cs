namespace Bytecode.Serialized;
/// <summary>
/// Enum of all opcodes
/// This is int-backed so we don't accidentally trip the constant flag
/// </summary>
public enum Opcode: int
{
    #region Stack Operations
    Push, //Push <[ConstAddress | Address]>
    Pop, //Pop <[Address]> OR <[Address]>
    Peek, //Peek <[Address]>
    InsertAt, //InsertAt <[Stack offset from bottom]> <[ConstAddress | Address]> (Should not insert at stack from runtime offset)
    PopAt, //PopAt <[Stack offset from bottom]> <[Address]> (Should not Pop at stack from runtime value)
    #endregion

    #region Memory Operations
    #region malloc
    Malloc, //Malloc (No Args, pushes the address to the stack)
    MallocChunk, //MallocChunk [STACK: length of chunk] (Pushes the start of the address to the stack)
    AllocArray, //AllocArray [STACK: Length of Array] (Allocates a block of memory l + 3 in length. The first value is the length; the second value is the type code, and the last value is null. Then, it pushes the start of the array(i.e. the address of the third location) to the stack.)
    #endregion
    #endregion
    #region Functions
    Call, //Call [STACK: Object type code] <[Interface type code]> <[Method offset]> 
    #endregion
}