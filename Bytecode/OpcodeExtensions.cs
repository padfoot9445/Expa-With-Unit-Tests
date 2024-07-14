namespace Bytecode;
using static Opcode;
using static OpcodeExtensions.NumberType;
public static class OpcodeExtensions
{
    public enum NumberType
    {
        //Address to either memory or constant field
        Address,
        //Inline constant
        InlineConst,
    }
    public static NumberType[] GetSigniture(this Opcode opcode)
    {
        switch(opcode)
        {
            #region Stack Operations
            case Push:
            case Pop:
            case Peek:
                return [Address];
            case InsertAt:
            case PopAt:
                return [InlineConst, Address];
            #endregion
            #region Memory Operations
            #region malloc
            case Malloc:
            case MallocChunk:
            case AllocArray:
                return [];
            #endregion
            #endregion
            #region Functions
            case Call:
                return [InlineConst, InlineConst];
            #endregion
            default:
                throw new InvalidOperationException($"Opcode {opcode} is not a supported opcode in the GetSigniture function. This is likely a developer error.");

        }
    }
}