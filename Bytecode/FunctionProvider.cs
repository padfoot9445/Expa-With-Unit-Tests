namespace Bytecode;
public class FunctionProvider : IFunctionProvider
{
    private static UniquePointerAndStorageProvider<ISection> BackingList = new();
    ISection[] IFunctionProvider.GetFunctionsArray => GetFunctionsArray;
    public static ISection[] GetFunctionsArray => BackingList.Array;
    private static uint NextFunctionPointer = 0;
    record Function : IFunction
    {
        public IClassSigniture? ReturnType { get; init; }
        public IClassSigniture[] ArgTypes { get; init; }
        public uint[] InversedDefaultArgValuePointers { get; init; }
        public uint FunctionPointer { get; init; }
        public Function(IClassSigniture? rt, IClassSigniture[] at, uint[] idavp, uint fp)
        {
            this.ReturnType = rt;
            this.ArgTypes = at;
            this.InversedDefaultArgValuePointers = idavp;
            this.FunctionPointer = fp;
        }
    }
    IFunction IFunctionProvider.New(Bytecode.IClassSigniture? ReturnType, Bytecode.IClassSigniture[] ArgTypes, uint[] InversedDefaultValues, Bytecode.ISection FunctionBody) => New(ReturnType, ArgTypes, InversedDefaultValues, FunctionBody);
    public static IFunction New(IClassSigniture? ReturnType, IClassSigniture[] ArgTypes, uint[] InversedDefaultValues, ISection FunctionBody)
    {
        uint functionPointer = (uint)BackingList.Add(FunctionBody);
        return new Function(ReturnType, ArgTypes, InversedDefaultValues, functionPointer);
    }
}