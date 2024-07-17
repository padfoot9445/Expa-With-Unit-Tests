
namespace Bytecode.ObjRepresentations;
public class UniquePointerAndStorageProvider<T> : IUniquePointerAndStorageProvider<T>
{
    private List<T> BackingList = new();
    public T[] Array => BackingList.ToArray();

    public int LastPointer => BackingList.Count - 1;

    public int Add(T input)
    {
        BackingList.Add(input);
        return LastPointer;
    }

    public int Add(IEnumerable<T> input)
    {
        int rv = LastPointer + 1;
        BackingList = BackingList.Concat(input).ToList();
        return rv;
    }
}