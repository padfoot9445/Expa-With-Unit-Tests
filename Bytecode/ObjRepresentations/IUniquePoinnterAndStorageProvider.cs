namespace Bytecode;
/// <summary>
/// A component which provides functionality for storing stuff and providing unique pointers
/// </summary>
/// <typeparam name="StorageType">The type of the things you are storing</typeparam> <summary>
/// 
/// </summary>
/// <typeparam name="StorageType"></typeparam>
public interface IUniquePointerAndStorageProvider<StorageType>
{
    public StorageType[] Array{ get; }
    public int LastPointer{ get; }
    /// <summary>
    /// Adds an object and returns the pointer(index) to the object
    /// </summary>
    /// <param name="input">The thing to be added</param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <returns>The pointer to the object. 0 <= pointer <= int.MaxValue</returns>
    public int Add(StorageType input);
    /// <summary>
    /// Adds a contingous amount of objects and returns the pointer to the first one
    /// </summary>
    /// <param name="input"></param>
    /// <returns>The pointer to the object. 0 <= pointer <= int.MaxValue</returns>
    public int Add(IEnumerable<StorageType> input);
    
}