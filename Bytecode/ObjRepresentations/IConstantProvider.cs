namespace Bytecode.ObjRepresentations;
public interface IConstantProvider
{
    /// <summary>
    /// Returns a view of the constant section as a uint[] Array
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public uint[] GetConstantArray{ get; }
    /// <summary>
    /// Adds a singular constant to the constants storage
    /// </summary>
    /// <param name="constant">the constant value</param>
    /// <returns>The address of the new constant(with the bit flag)</returns>
    public uint Add(uint constant);
    /// <summary>
    /// Appends a series of constants to the constants storage
    /// </summary>
    /// <param name="constants">An IEnumerable of uint</param>
    /// <returns>the address of the first element added</returns> <summary>
    /// 
    /// </summary>
    /// <param name="constants"></param>
    /// <returns></returns>
    public uint Add(IEnumerable<uint> constants);
    /// <summary>
    /// The last address of the constants storage
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public uint Last{ get; }
}