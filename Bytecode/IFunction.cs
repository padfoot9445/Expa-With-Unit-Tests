namespace Bytecode;
/// <summary>
/// A Function Signiture containing type, pointer, and  Argtypes
/// </summary>
public interface IFunction
{
    /// <summary>
    /// ClassSigniture of the return type
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public IClassSigniture? ReturnType{ get; init; }
    /// <summary>
    /// Array of Class Signitures for each Argument Type
    /// </summary>
    /// <value></value>
    public IClassSigniture[] ArgTypes{ get; init; }
    /// <summary>
    /// An Array of the Pointers to constant storage for the default arguments for the function, inversed - i.e. DefaultArgValuePointers[0] would be the default argument for ArgTypes[^1]
    /// This shouldn't need to be serialized, but we'll see.
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public uint[] InversedDefaultArgValuePointers{ get; init; }
    /// <summary>
    /// Index to the array index containing the appropiate Section
    /// </summary>
    /// <value></value>
    public uint FunctionPointer{ get; init; }
    /// <summary>
    /// The ultimate collection of all the functions, arrayed according to their function pointers.
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public ISection[] GetFunctionsArray{ get; }
    /// <summary>
    /// Creates a new Function object, which will represent a function. Appends the FunctionBody to the appropiate location.
    /// </summary>
    /// <param name="ReturnType"></param>
    /// <param name="ArgTypes"></param>
    /// <param name="InversedDefaultValues"></param>
    /// <param name="FunctionBody"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="ReturnType"></param>
    /// <param name="ArgTypes"></param>
    /// <param name="InversedDefaultValues"></param>
    /// <param name="FunctionBody"></param>
    /// <returns></returns>
    public IFunction New(IClassSigniture? ReturnType, IClassSigniture[] ArgTypes, uint[] InversedDefaultValues, ISection FunctionBody);

}