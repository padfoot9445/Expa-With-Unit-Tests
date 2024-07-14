namespace Bytecode;
public record Constants: IConstants
{
    public required List<uint> Value { get; set; }
    public uint[] AsArray => Value.ToArray();
    public static uint FirstBit => 0x80000000;
    public static uint ConstantPointer(uint value) => value | FirstBit;
}