namespace Bytecode.Tests.Mocks;
using Bytecode.ObjRepresentations;
using Bytecode.Serialized;

class ClassSignitureMock : IClassSigniture
{
    public int ID => throw new NotImplementedException();

    public IFunction[] NewFunctions => throw new NotImplementedException();

    public IField[] NewFields => throw new NotImplementedException();

    public IClassSigniture[][] Ancestors => throw new NotImplementedException();

    public ISection Serialize()
    {
        throw new NotImplementedException();
    }
}