using Bytecode.Serialized;

namespace Bytecode.ObjRepresentations;
/// <summary>
/// Records the class signature for any given class. This has sections for parent classes and interfaces, such that any function call is passed through this object and redirected to the apporopiate function pointer.
/// For instance, where Class A and B have functions Foo and Bar, and class C overrides Bar, and defines F
/// Class A | METHOD void Foo ARG PTR 1
/// Class B | METHOD void Bar ARG PTR 2
/// Class C | METHOD void F ARG int PTR 3 || PARENT A | METHOD void FOO ARG PTR 1 || PARENT B | METHOD void FOO ARG PTR 4
/// </summary> <summary>
/// 
/// </summary>
/// <returns></returns>
public record ClassSigniture : IClassSigniture
{
    public ClassSigniture(int iD, IFunction[] newFunctions, IField[] newFields, IClassSigniture[][] ancestors)
    {
        ID = iD;
        NewFunctions = newFunctions;
        NewFields = newFields;
        Ancestors = ancestors;
    }

    public int ID{ get; init; }

    public IFunction[] NewFunctions{ get; init; }

    public IField[] NewFields{ get; init; }

    public IClassSigniture[][] Ancestors{ get; init; }

    public ISection Serialize()
    {
        throw new NotImplementedException();
    }
}