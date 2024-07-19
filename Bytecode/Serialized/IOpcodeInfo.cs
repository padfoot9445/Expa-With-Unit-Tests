namespace Bytecode.Serialized;
public interface IOpcodeInfo
{
    public Opcode Opcode{ get; init; }
    public Opcode.NumberType[] ArgTypes{ get; }
    public int ArgNo{ get; }
    
}