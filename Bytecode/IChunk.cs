namespace Bytecode;
/// <summary>
/// A Chunk which ultimately could be passed to the VM, or concatenated with another chunk
/// </summary>
public interface IChunk
{
    public List<ISection> Bytecodes{ get; init; }
    public List<IClassSigniture> Classes{ get; init; }
    public IConstants Constants{ get; init; }
    /// <summary>
    /// Merges multiple chunks together such that each chunk only has one constant field and one class list
    /// </summary>
    /// <param name="chunk"></param>
    /// <exception cref="NotImplementedException"></exception> <summary>
    /// 
    /// </summary>
    /// <param name="chunk"></param>
    public void Append(IChunk chunk);
    public void Append(IEnumerable<IChunk> chunk);
}