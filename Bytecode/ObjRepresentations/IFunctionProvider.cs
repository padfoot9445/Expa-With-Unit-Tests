namespace Bytecode.ObjRepresentations;
/// <summary>
/// A Function Provider which stores the Sections and allows creation of 
/// </summary>
public interface IFunctionProvider
{
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