namespace Bytecode;
public record Section
{
    public required List<uint> Value{ get; init; }
}