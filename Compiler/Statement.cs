namespace Compiler;
using Tokens;
using Bytecode.Serialized;
class Statement
{
    public Token[] Value { get; init; }
    public Statement(Token[] value)
    {
        Value = value;
    }
    public record FunctionCall
    {
        public required Statement[] Args { get; init; }
        public required string Name { get; init; }
    }
    /// <summary>
    /// Parses the Statement into Bytecode which pushes the result of the Statement onto the stack.
    /// </summary>
    /// <returns>A Chunk</returns> 
    public Chunk Parse()
    {
        throw new NotImplementedException();
    }
}