namespace Bytecode.ObjRepresentations;
public interface IPointer
{
    public bool Const { get; init; }
    public bool Function { get; init; }
    public bool Type { get; init; }
    public int Address { get; init; }
    public IPointer ConstPointer(int address);
    public IPointer TypePointer(int address);
    public IPointer FunctionPointer(int address);
}