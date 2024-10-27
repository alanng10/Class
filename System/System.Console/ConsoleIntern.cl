class ConsoleIntern : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share InternIntern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.Intern : 0;
        return true;
    }

    field private InternIntern InternIntern { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }

    maide prusate Bool Write(var Int stream, var String a)
    {
        var Bool b;
        b : (stream = 0);
        inf (b)
        {
            this.OutWrite(a);
        }
        inf (~b)
        {
            this.ErrWrite(a);
        }
        return true;
    }

    maide prusate Bool OutWrite(var String a)
    {
        var Int uo;
        uo : this.InternInfra.StringCreate(a);
        
        this.Extern.Console_OutWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    maide prusate Bool ErrWrite(var String a)
    {
        var Int uo;
        uo : this.InternInfra.StringCreate(a);
        
        this.Extern.Console_ErrWrite(this.Intern, uo);

        this.InternInfra.StringDelete(uo);
        return true;
    }

    maide prusate String Read()
    {
        var Extern extern;
        extern : this.Extern;

        var Int u;
        u : extern.Console_InnRead(this.Intern);

        var Int data;
        var Int count;
        data : extern.String_DataGet(u);
        count : extern.String_CountGet(u);

        var Int dataCount;
        dataCount : count * 4;

        var Any k;
        k : this.InternIntern.DataNew(dataCount);

        this.InternInfra.CopyToDataValue(data, k, 0, dataCount);

        var String a;
        a : this.InternIntern.StringNew();
        
        this.InternIntern.StringValueSet(a, k);
        this.InternIntern.StringCountSet(a, count);

        extern.String_Final(u);
        extern.String_Delete(u);

        extern.Delete(data);
        return a;
    }
}