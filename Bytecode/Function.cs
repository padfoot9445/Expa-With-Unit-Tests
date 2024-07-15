namespace Bytecode;
public class Function : IFunction
{
    private static UniquePointerAndStorageProvider<ISection> BackingList = new();
    public IClassSigniture? ReturnType { get; init; }
    public IClassSigniture[] ArgTypes { get; init; }
    public uint FunctionPointer { get; init; }
    public uint[] InversedDefaultArgValuePointers { get; init; }
    ISection[] IFunction.GetFunctionsArray => GetFunctionsArray;
    public static ISection[] GetFunctionsArray => BackingList.Array;
    private static uint NextFunctionPointer = 0;
    private Function(IClassSigniture? ReturnType, IClassSigniture[] ArgTypes, uint[] InversedDefaultArgValuePointers)
    {
        this.ReturnType = ReturnType;
        this.ArgTypes = ArgTypes;
        this.FunctionPointer = NextFunctionPointer;
        this.InversedDefaultArgValuePointers = InversedDefaultArgValuePointers;
        NextFunctionPointer++;
    }
    IFunction IFunction.New(Bytecode.IClassSigniture? ReturnType, Bytecode.IClassSigniture[] ArgTypes, uint[] InversedDefaultValues, Bytecode.ISection FunctionBody) => New(ReturnType, ArgTypes, InversedDefaultValues, FunctionBody);
    public static Function New(IClassSigniture? ReturnType, IClassSigniture[] ArgTypes, uint[] InversedDefaultValues, ISection FunctionBody)
    {
        BackingList.Add(FunctionBody);
        return new Function(ReturnType, ArgTypes, InversedDefaultValues);
    }
}