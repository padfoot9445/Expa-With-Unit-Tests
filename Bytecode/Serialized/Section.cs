namespace Bytecode.Serialized;
public record Section: ISection
{
    public required List<uint> Value{ get; init; }
    public IOpcodeInfo[] GetInfo()
    {
        List<IOpcodeInfo?> info = [];
        int args_remaining = 0;
        for(int i = 0; i < this.Value.Count; i++)
        {
            if (args_remaining != 0)
            {
                info.Add(null);
                args_remaining--;
                Console.WriteLine($"Adding null in lieu of {this.Value[i]}");
            }
            else
            {
                Console.WriteLine($"Adding {this.Value[i]} as opcode");
                IOpcodeInfo tinfo = ((Opcode)this.Value[i]).GetInfo();
                info.Add(tinfo);
                args_remaining += tinfo.ArgNo;
            }
        }
        return [.. info];
    }
}