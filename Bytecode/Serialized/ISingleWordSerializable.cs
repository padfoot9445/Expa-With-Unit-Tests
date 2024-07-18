namespace Bytecode.Serialized;
/// <summary>
/// ISerializableToBytecode instances which serialize to a length 1 array
/// //TODO: self-write a wrapper for uint[] such that it must have >= 1 elements and 1 elements for ISerializableToBytecode and IBytecode
/// </summary> <summary>
/// 
/// </summary>
public interface ISingleWordSerializable: ISerializableToBytecode
{
    public abstract new ILengthOneSection Serialize();
}