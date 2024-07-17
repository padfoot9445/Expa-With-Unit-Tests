
namespace Bytecode;
public class ConstantProvider : IConstantProvider
{
    private static IUniquePointerAndStorageProvider<uint> StorageProvider = new UniquePointerAndStorageProvider<uint>();
    uint[] IConstantProvider.GetConstantArray => GetConstantArray;
    public static uint[] GetConstantArray => StorageProvider.Array;
    uint IConstantProvider.Last => Last;
    public static uint Last => ConstantPointer((uint)StorageProvider.LastPointer);
    uint IConstantProvider.Add(uint constant) => Add(constant);
    uint IConstantProvider.Add(IEnumerable<uint> constants) => Add(constants);

    public static uint Add(uint constant)
    {
        StorageProvider.Add(constant);
        return Last;
    }

    public static uint Add(IEnumerable<uint> constants)
    {
        return ConstantPointer((uint)StorageProvider.Add(constants));
    }
    public static uint FirstBit => 0x80000000;
    /// <summary>
    /// Makes the value a constant pointer to that value's offset
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static uint ConstantPointer(uint value) => value | FirstBit;
    public static uint ConstantPointer(int value)
    {
        if(value < 0){ throw new ArgumentOutOfRangeException($"ConstantPointer canot be created from negative value {value}"); }
        return ConstantPointer((uint)value);
    }
}