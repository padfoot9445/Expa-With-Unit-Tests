namespace Bytecode.ObjRepresentations;
using Bytecode.Serialized;
public partial class FunctionProvider : IFunctionProvider
{
    private static UniquePointerAndStorageProvider<ISection> BackingList = new();
    ISection[] IFunctionProvider.GetFunctionsArray => GetFunctionsArray;
    public static ISection[] GetFunctionsArray => BackingList.Array;
    private static uint NextFunctionPointer = 0;
    IFunction IFunctionProvider.New(IClassSigniture? ReturnType, IClassSigniture[] ArgTypes, uint[] InversedDefaultValues, ISection FunctionBody) => New(ReturnType, ArgTypes, InversedDefaultValues, FunctionBody);
    public static IFunction New(IClassSigniture? ReturnType, IClassSigniture[] ArgTypes, uint[] InversedDefaultValues, ISection FunctionBody)
    {
        uint functionPointer = (uint)BackingList.Add(FunctionBody);
        return new Function(ReturnType, ArgTypes, InversedDefaultValues, functionPointer);
    }
}