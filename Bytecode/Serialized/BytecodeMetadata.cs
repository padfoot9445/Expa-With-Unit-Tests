namespace Bytecode.Serialized;
using static Opcode;
using static Opcode.NumberType;
public sealed partial class Opcode
{
    public enum NumberType
    {
        //Address to either memory or constant field
        Address,
        //Inline constant
        InlineConst,
        //Opcode
        Opcode,
        ClassCode,
        FunctionPtr
    }
    public NumberType[] GetSigniture()
    {
        #region Stack Operations
        if (this == Push || this == Pop || this == Peek)
        {
            return [ Address ];
        }
        else if (this == InsertAt || this == PopAt)
        {
            return [ InlineConst, Address ];
        }
        #endregion

        #region Memory Operations
        #region malloc
        else if (this == Malloc || this == MallocChunk || this == AllocArray)
        {
            return [ ];
        }
        #endregion
        #endregion

        #region Functions
        else if (this == Call)
        {
            return [ ClassCode, ClassCode ];
        }
        #endregion

        else
        {
            throw new InvalidOperationException($"Opcode {this.Name} is not a supported opcode in the GetSignature function. This is likely a developer error.");
        }

    }
    public int GetArgNum()
    {
        return GetSigniture().Length;
    }
    public int AsInt() => (int)this;
    public uint AsUInt() => (uint)this;
    public IOpcodeInfo GetInfo()
    {
        return new OpcodeInfo(this, this.GetArgNum(), this.GetSigniture());
    }
}