namespace Bytecode.Serialized;
using static Opcode;
using static BytecodeMetadata.NumberType;
public static class BytecodeMetadata
{
    public enum NumberType
    {
        //Address to either memory or constant field
        Address,
        //Inline constant
        InlineConst,
        //Opcode
        Opcode,
        ClassCode,
        FunctionPtr
    }
    public static NumberType[] GetSigniture(this Opcode opcode)
    {
        #region Stack Operations
        if (opcode == Push || opcode == Pop || opcode == Peek)
        {
            return [ Address ];
        }
        else if (opcode == InsertAt || opcode == PopAt)
        {
            return [ InlineConst, Address ];
        }
        #endregion

        #region Memory Operations
        #region malloc
        else if (opcode == Malloc || opcode == MallocChunk || opcode == AllocArray)
        {
            return [ ];
        }
        #endregion
        #endregion

        #region Functions
        else if (opcode == Call)
        {
            return [ ClassCode, ClassCode ];
        }
        #endregion

        else
        {
            throw new InvalidOperationException($"Opcode {opcode} is not a supported opcode in the GetSignature function. This is likely a developer error.");
        }

    }
    public static int GetArgNum(this Opcode opcode)
    {
        return opcode.GetSigniture().Length;
    }
    public static int AsInt(this Opcode opcode) => (int)opcode;
    public static uint AsUInt(this Opcode opcode) => (uint)opcode;
    public static IOpcodeInfo[] GetInfo(this Section section)
    {
        List<IOpcodeInfo?> info = [];
        int args_remaining = 0;
        for(int i = 0; i < section.Value.Count; i++)
        {
            if (args_remaining != 0)
            {
                info.Add(null);
                args_remaining--;
                Console.WriteLine($"Adding null in lieu of {section.Value[i]}");
            }
            else
            {
                Console.WriteLine($"Adding {section.Value[i]} as opcode");
                IOpcodeInfo tinfo = ((Opcode)section.Value[i]).GetInfo();
                info.Add(tinfo);
                args_remaining += tinfo.ArgNo;
            }
        }
        return [.. info];
    }
    public static IOpcodeInfo GetInfo(this Opcode opcode)
    {
        return new OpcodeInfo(opcode, opcode.GetArgNum(), opcode.GetSigniture());
    }
}