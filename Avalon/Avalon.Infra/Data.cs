namespace Avalon.Infra;

public class Data : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = Infra.This;
        this.InitValue();
        return true;
    }

    public virtual long Count { get { return __D_Count; } set { __D_Count = value; } }
    protected long __D_Count;
    protected virtual Infra InfraInfra { get { return __D_InfraInfra; } set { __D_InfraInfra = value; } }
    protected Infra __D_InfraInfra;
    public virtual byte[] Value { get; set; }

    protected virtual bool InitValue()
    {
        this.Value = new byte[this.Count];
        return true;
    }

    public virtual int Get(long index)
    {
        if (!this.Valid(index))
        {
            return -1;
        }
        return this.Value[index];
    }

    public virtual bool Set(long index, int value)
    {
        if (!this.Valid(index))
        {
            return false;
        }
        this.Value[index] = (byte)value;
        return true;
    }

    public virtual bool Valid(long index)
    {
        return this.InfraInfra.ValidLongIndex(this.Count, index);
    }
}