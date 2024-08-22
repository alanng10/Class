namespace Class.Infra;

public class AddWriteOperate : WriteOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    public virtual StringValueWrite Write { get; set; }
    protected virtual TextInfra TextInfra { get; set; }

    public override bool ExecuteChar(uint n)
    {
        long index;
        index = this.Write.Index;

        Data data;
        data = this.Write.Data;
        this.TextInfra.DataCharSet(data, index, n);
        
        index = index + 1;

        this.Write.Index = index;
        return true;
    }
}