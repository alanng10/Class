namespace Avalon.Text;

public class TextFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        Text text;
        text = (Text)arg.Value.Any;

        long a;
        a = text.Range.Count;

        Value aa;
        aa = (Value)this.Result;
        aa.Int = a;
        return true;
    }
}