namespace Bytecode.ObjRepresentations;
public interface IHasUniquePointerAndStorage<T>
{
    public IUniquePointerAndStorageProvider<T> PointerAndStorageProvider{ get; }
}