using Bytecode.Serialized;

namespace Tests.Bytecode;
class SectionMock : ISection
{
    public List<uint> Value { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
    public int __debug_id { get; set; }
    public SectionMock(int i=0)
    {
        __debug_id = i;
    }

    public IOpcodeInfo[] GetInfo()
    {
        throw new NotImplementedException();
    }
}