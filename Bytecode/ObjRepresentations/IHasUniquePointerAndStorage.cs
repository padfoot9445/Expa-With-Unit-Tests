namespace Bytecode;
public interface IHasUniquePointerAndStorage<T>
{
    public IUniquePointerAndStorageProvider<T> PointerAndStorageProvider{ get; }
}