namespace Avalon.Console;

class ConsoleIntern : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        return true;
    }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private ulong Intern { get; set; }

    public virtual bool Write(long stream, String a)
    {
        bool b;
        b = (stream == 0);
        if (b)
        {
            this.OutWrite(a);
        }
        if (!b)
        {
            this.ErrWrite(a);
        }
        return true;
    }


    public virtual bool OutWrite(String a)
    {
        ulong uo;
        uo = this.InternInfra.StringCreate(a);
        
        Extern.Console_OutWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    public virtual bool ErrWrite(String a)
    {
        ulong uo;
        uo = this.InternInfra.StringCreate(a);
        
        Extern.Console_ErrWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    public virtual String Read()
    {
        ulong u;
        u = Extern.Console_InnRead(this.Intern);

        ulong value;
        ulong count;
        value = Extern.String_ValueGet(u);
        count = Extern.String_CountGet(u);

        ulong dataCount;
        dataCount = count * sizeof(uint);

        long ka;
        ka = (long)dataCount;

        byte[] k;
        k = new byte[ka];

        this.InternIntern.CopyToByteArray(value, k, 0, dataCount);

        long countA;
        countA = (long)count;

        String a;
        a = new String();
        a.Value = k;
        a.Count = countA;
        a.Init();

        Extern.String_Final(u);
        Extern.String_Delete(u);

        Extern.Delete(value);
        return a;
    }
}