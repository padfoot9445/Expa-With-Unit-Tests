namespace Bytecode;
/// <summary>
/// A representation of a field within a class.
/// </summary> <summary>
/// 
/// </summary>
// Should be implemented as a nested record within ClassSigniture
public interface IField
{
    /// <summary>
    /// The Type of the field
    /// </summary> <summary>
    /// 
    /// </summary>
    /// <value></value>
    public IClassSigniture Type{ get; init; }
    //Offset should not be neccesary as this has now been transformed as part of the class signiture.
    ///// <summary>
    ///// The Offset of the field; i.e. if offset = 0, the field's pointer should reside at [CLASS, FIELDS, Ptr], or at offset 2 the field's pointer should reside at [CLASS, FIELDS, smth, smth, Ptr]
    ///// </summary>
    ///// <value></value>
    // //IField would know about its offset since idealy this would be initialized within IClassSigniture
    //// public int Offset{ get; }
}