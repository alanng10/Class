namespace Avalon.Infra;

public class Handle : object
{
    public virtual bool Init()
    {
        this.InternIntern = Intern.This;
                
        this.GCHandle = SystemGCHandle.Alloc(this.Any);
        return true;
    }

    public virtual bool Final()
    {
        this.GCHandle.Free();
        return true;
    }

    public virtual object Any { get; set; }

    protected virtual Intern InternIntern { get; set; }

    private SystemGCHandle GCHandle;

    public virtual ulong ULong()
    {
        SystemIntPtr u;
        u = SystemGCHandle.ToIntPtr(this.GCHandle);

        ulong o;
        o = (ulong)u;
        return o;
    }
}