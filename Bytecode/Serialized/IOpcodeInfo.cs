namespace Bytecode.Serialized;
public interface IOpcodeInfo
{
    public Opcode Opcode{ get; init; }
    public BytecodeMetadata.NumberType[] ArgTypes{ get; }
    public int ArgNo{ get; }
    
}