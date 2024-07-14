namespace Compiler;
using Tokens;
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
    /// <returns>A tuple of Bytecode and a bit to append onto the constants section</returns> 
    public (Bytecode, uint[]) Parse()
    {
        throw new NotImplementedException();
    }
}