using Bytecode.Serialized;

namespace Bytecode.ObjRepresentations;
/// <summary>
/// Records the class signature for any given class. This has sections for parent classes and interfaces, such that any function call is passed through this object and redirected to the apporopiate function pointer.
/// </summary> <summary>
/// 
/// </summary>
/// <returns></returns>
public interface IClassSigniture: ISerializableToBytecode
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
    /// Types of fields as defined or inherited in this class. Property fields should also be included.
    /// </summary>
    /// <value></value>
    public IField[] NewFields{ get; }
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