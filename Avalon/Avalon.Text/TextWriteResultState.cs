namespace Avalon.Text;

public class TextWriteResultState : FormatResultState
{
    public override bool Execute()
    {
        FormatResultArg kke;
        kke = (FormatResultArg)this.Arg;
        FormatArg arg;
        arg = kke.Arg;
        Text result;
        result = kke.Result;
        Format format;
        format = this.Format;

        long valueCount;
        valueCount = arg.ValueCount;
        long count;
        count = arg.Count;
        Text value;
        value = (Text)arg.Value.Any;

        bool alignLeft;
        alignLeft = arg.AlignLeft;

        long fillCount;
        fillCount = 0;
        long clampCount;
        clampCount = 0;

        if (valueCount < count)
        {
            fillCount = count - valueCount;
        }

        if (count < valueCount)
        {
            clampCount = valueCount - count;
        }

        long fillChar;
        fillChar = arg.FillChar;

        long fillStart;
        fillStart = 0;
        long valueStart;
        valueStart = 0;
        long valueIndex;
        valueIndex = 0;

        long valueWriteCount;
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

        format.ResultText(result, arg.Form, value, valueWriteCount, valueStart, valueIndex);

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}