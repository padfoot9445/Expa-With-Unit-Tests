namespace Bytecode.Serialized;
public record Section: ISection
{
    public required List<uint> Value{ get; init; }
}