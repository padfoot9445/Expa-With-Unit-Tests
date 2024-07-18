namespace Bytecode.ObjRepresentations;
/// <summary>
/// A more type-safe representation of a pointer in Expa
/// </summary> <summary>
/// 
/// </summary>
/// <value></value>
public record Pointer : IPointer
{
    private enum PointerType
    {
        Const,
        Function,
        Type
    }
    private Pointer(PointerType pt, int address)
    {
        switch(pt)
        {
            case PointerType.Const:
                Const = true;
                break;
            case PointerType.Function:
                Function = true;
                break;
            case PointerType.Type:
                Type = true;
                break;
        }
        Address = address;
    }
    /// <summary>
    /// if this is a pointer to a constant
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>

    public bool Const { get; init; } = false;
    /// <summary>
    /// if this is a pointer to a function
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public bool Function { get; init; } = false;
    /// <summary>
    /// or if this is a pointer to a type; aka a class declaration
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public bool Type { get; init; } = false;
    /// <summary>
    /// The Numerical Address of the pointer. This should be no longer than 29 bits
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public int Address { get; init; }
    IPointer IPointer.ConstPointer(int address) => ConstPointer(address);
    IPointer IPointer.FunctionPointer(int address) => FunctionPointer(address);
    IPointer IPointer.TypePointer(int address) => TypePointer(address);
    public static IPointer ConstPointer(int address)
    {
        return new Pointer(PointerType.Const, address);
    }

    public static IPointer FunctionPointer(int address)
    {
        return new Pointer(PointerType.Const, address);
    }

    public static IPointer TypePointer(int address)
    {
        return new Pointer(PointerType.Const, address);
    }
}
