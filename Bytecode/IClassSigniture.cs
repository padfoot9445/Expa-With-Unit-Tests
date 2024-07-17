namespace Bytecode;
/// <summary>
/// Records the class signature for any given class. This has sections for parent classes and interfaces, such that any function call is passed through this object and redirected to the apporopiate function pointer.
/// For instance, where Class A and B have functions Foo and Bar, and class C overrides Bar, and defines F
/// Class A | METHOD (void Foo ARG) PTR 1
/// Class B | METHOD PTR 2
/// Class C | METHOD PTR 3 || PARENT A | METHOD void FOO ARG PTR 1 || PARENT B | METHOD void FOO ARG PTR 4
/// </summary> <summary>
/// 
/// </summary>
/// <returns></returns>
public interface IClassSigniture
{
    /// <summary>
    /// Class ID
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public int ID{ get; }
    /// <summary>
    /// Functions as defined or inherited in this class
    /// </summary>
    /// <value></value>
    public IFunction[] NewFunctions{ get; }
    /// <summary>
    /// Classes in ancestor tree. If Base -> A, Base -> B, A -> C, A -> D, C -> B, D -> B, A -> E, B -> E
    /// Such that
    /// A inherits from base;
    /// C and D inherit from A
    /// B inherits from Base, C, D;
    /// E inherits from B and A
    /// E's ancestor array would look like
    /// [[Base],[A],[C, D, Base],[B, A]]/// 
    /// should probably serialize this in inverse though
    /// </summary>
    /// <value></value>
    public IClassSigniture[][] Ancestors{ get; }
}