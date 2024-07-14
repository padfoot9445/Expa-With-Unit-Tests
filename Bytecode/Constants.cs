namespace Bytecode;
public record Constants
{
    public required List<uint> Value { get; set; }
    public uint[] Array => Value.ToArray();
    public const uint FirstBit = 0x80000000;
    public static uint ConstantPointer(uint value) => value | FirstBit;
}