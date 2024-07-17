namespace Bytecode;
/// <summary>
/// the Information surrounding a particular Opcode. Opcode is the Opcode, ArgNo is the number of arguments, and ArgTypes is the type of the arguments. The arguments do not include arguments pushed to stack.
/// </summary>
/// <value></value>
public class OpcodeInfo: IOpcodeInfo
{
    public Opcode Opcode{ get; init; }
    public BytecodeMetadata.NumberType[] ArgTypes{ get; }
    public int ArgNo{ get; }
    public OpcodeInfo(Opcode opcode, int argNo, BytecodeMetadata.NumberType[] argTypes)
    {
        this.Opcode = opcode;
        this.ArgNo = argNo;
        this.ArgTypes = argTypes;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not OpcodeInfo other)
        {
            return false;
        }
        return Opcode == other.Opcode && ArgNo == other.ArgNo && Enumerable.SequenceEqual(ArgTypes, other.ArgTypes);
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}