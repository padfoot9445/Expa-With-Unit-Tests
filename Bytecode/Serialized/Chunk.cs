namespace Bytecode.Serialized;
using Bytecode.ObjRepresentations;
/// <summary>
/// A Chunk which ultimately could be passed to the VM, or concatenated with another chunk
/// </summary>
public class Chunk: IChunk
{
    public required List<ISection> Sections{ get; init; }
    public required List<IClassSigniture> Classes{ get; init; }
    public required IConstantProvider Constants{ get; init; }
    public Chunk(List<ISection> Bytecodes, List<IClassSigniture> Classes, IConstantProvider Constants)
    {
        Sections = Bytecodes;
        this.Constants = Constants;
        this.Classes = Classes;
    }
    /// <summary>
    /// Merges multiple chunks together such that each chunk only has one constant field and one class list
    /// </summary>
    /// <param name="chunk"></param>
    /// 
    /// </summary>
    /// <param name="chunk"></param>
    public void Append(IChunk chunk)
    {
        throw new NotImplementedException();
    }
    public void Append(IEnumerable<IChunk> chunk)
    {
        foreach(IChunk c in chunk)
        {
            Append(c);
        } 
    }
}