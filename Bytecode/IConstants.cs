namespace Bytecode;
public interface IConstants
{
    public List<uint> Value { get; set; }
    public uint[] AsArray{ get; }
    public static uint FirstBit => 0x80000000;
    public static uint ConstantPointer(uint value) => value | FirstBit;
}