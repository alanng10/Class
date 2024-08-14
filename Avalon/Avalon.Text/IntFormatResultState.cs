namespace Avalon.Text;

public class IntFormatResultState : WriteResultState
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }

    public override bool Execute()
    {
        WriteArg arg;
        arg = (WriteArg)this.Arg;
        Text result;
        result = this.ArgResult;
        Write format;
        format = this.Format;

        int valueCount;
        valueCount = arg.ValueCount;
        int count;
        count = arg.Count;
        long value;
        value = arg.ValueInt;
        
        long mask;
        mask = this.InfraInfra.IntCapValue - 1;
        value = value & mask;

        bool alignLeft;
        alignLeft = arg.AlignLeft;

        int fillCount;
        fillCount = 0;
        int clampCount;
        clampCount = 0;

        if (valueCount < count)
        {
            fillCount = count - valueCount;
        }

        if (count < valueCount)
        {
            clampCount = valueCount - count;
        }

        int varBase;
        varBase = arg.Base;
        int varCase;
        varCase = arg.Case;
        char fillChar;
        fillChar = arg.FillChar;

        int fillStart;
        fillStart = 0;
        int valueStart;
        valueStart = 0;
        int valueIndex;
        valueIndex = 0;

        int valueWriteCount;
        valueWriteCount = valueCount - clampCount;

        if (alignLeft)
        {
            fillStart = valueWriteCount;
            valueStart = 0;
            valueIndex = 0;
        }

        if (!alignLeft)
        {
            fillStart = 0;
            valueStart = fillCount;
            valueIndex = clampCount;
        }

        ulong valueA;
        valueA = (ulong)value;

        format.ResultInt(result, valueA, varBase, varCase, valueCount, valueWriteCount, valueStart, valueIndex);

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}