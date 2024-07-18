using System.Numerics;

namespace ClassEnum;

public abstract class ClassEnumBase<T> where T: INumber<T>, new()
{
    
    /// <summary>
    /// The next number to be used in the enumeration
    /// </summary>
    private static T next_number = new();
    /// <summary>
    /// incrememnts next_number and returns.
    /// </summary>
    /// <returns>T, next-number</returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static T GetNext() => ++next_number;
    public T Value{ get; init; }
    public string Name{ get; init; }
    private readonly HashSet<string> used_names = new();
    protected abstract void AddToValueToEnum();
    protected ClassEnumBase(string Name)
    {
        //require unique names
        if(used_names.Contains(Name)){ throw new ArgumentException("Name for ClassEnum must be unique"); }
        this.Name = Name;
        this.Value = GetNext();
        AddToValueToEnum();
    }
}