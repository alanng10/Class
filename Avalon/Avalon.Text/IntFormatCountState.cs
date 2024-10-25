namespace Avalon.Text;

public class IntFormatCountState : FormatCountState
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
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        long value;
        value = arg.Value.Int;

        long mask;
        mask = this.InfraInfra.IntCapValue - 1;
        value = value & mask;
        
        ulong o;
        o = (ulong)value;

        long count;
        count = this.Format.IntDigitCount(o, arg.Base);
        
        long a;
        a = count;

        Value aa;
        aa = (Value)this.Result;
        aa.Int = a;
        return true;
    }
}