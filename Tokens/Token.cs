namespace Tokens;
/// <summary>
/// A Token representing a lexed bit of source code
/// </summary> <summary>
/// 
/// </summary>
class Token
{
    public string Lexeme{ get; init; }
    public int LineNumber{ get; init; }
    public TokenType Type{ get; init; }
    public Token(string lexeme, TokenType tt, int LineNumber)
    {
        this.Lexeme = lexeme;
        this.LineNumber = LineNumber;
        this.Type = tt;
    }
}