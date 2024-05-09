namespace Avalon.Intern;

public class MaideAddress : object
{
    public virtual bool Init()
    {
        this.InternIntern = Intern.This;

        this.Value = this.InternIntern.MaidePointer(this.Delegate);
        return true;
    }

    public virtual ulong Value { get; set; }
    
    public virtual SystemDelegate Delegate { get; set; }
    
    protected virtual Intern InternIntern { get; set; }
}