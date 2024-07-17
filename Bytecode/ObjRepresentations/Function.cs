namespace Bytecode.ObjRepresentations;
public partial class FunctionProvider
{
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
}