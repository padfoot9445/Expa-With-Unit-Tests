namespace Bytecode.Serialized;
/// <summary>
/// ISection, length should be >= 1
/// </summary> <summary>
/// 
/// </summary>
public interface ISection
{
    public List<uint> Value{ get; init; }
    public IOpcodeInfo[] GetInfo();
}