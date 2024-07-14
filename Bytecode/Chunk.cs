namespace Bytecode;
/// <summary>
/// A Chunk which ultimately could be passed to the VM, or concatenated with another chunk
/// </summary>
public class Chunk
{
    public required List<Section> Bytecodes{ get; init; }
    public required List<ClassSigniture> Classes{ get; init; }
    public required Constants Constants{ get; init; }
    public void Append(Chunk chunk)
    {
        throw new NotImplementedException();
    }
    public void Append(IEnumerable<Chunk> chunk)
    {
        foreach(Chunk c in chunk)
        {
            Append(c);
        }
    }
}