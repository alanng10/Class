namespace Demo;

class ThreadState : State
{
    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.Math = MathMath.This;
        this.MathComp = new MathComp();
        this.MathComp.Init();
        return true;
    }

    public Demo Demo { get; set; }
    public ThreadPhore Phore { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }

    public override bool Execute()
    {
        Console console;
        console = Console.This;
        console.Out.Write(this.S("ThreadState.Execute START\n"));

        StorageInfra infra;
        infra = StorageInfra.This;

        String a;
        a = this.StorageInfra.TextRead(this.S("DemoData/ThreadRead.txt"));

        String ka;

        ka = this.AddClear().AddS("ThreadRead.txt text: \n").Add(a).AddS("\n").AddResult();

        console.Out.Write(ka);

        string writeFilePath;
        writeFilePath = "DemoData/ThreadWrite.txt";
        File.Delete(writeFilePath);

        String kkka;
        kkka = this.S(writeFilePath);

        bool b;        
        b = this.StorageInfra.TextWrite(kkka, this.S("阿 了 水 GR 8 &\nEu #@ ?\n卡"));
        if (!b)
        {
            console.Out.Write(this.S("ThreadWrite.txt write error\n"));
        }
        if (b)
        {
            a = this.StorageInfra.TextRead(kkka);

            ka = this.AddClear().AddS("ThreadWrite.txt text: \n").Add(a).AddS("\n").AddResult();
        }

        this.Phore.Close();

        Value aa;
        aa = new Value();
        aa.Init();
        aa.Int = 0x10000;

        this.Result = aa;

        console.Out.Write(this.S("ThreadState.Execute END\n"));
        return true;
    }

    protected virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(mathComp, n);
        return a;
    }

    public virtual ThreadState Add(String a)
    {
        this.Demo.Add(a);
        return this;
    }

    public virtual ThreadState AddS(string o)
    {
        this.Demo.AddS(o);
        return this;
    }

    public virtual ThreadState AddClear()
    {
        this.Demo.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.Demo.AddResult();
    }

    protected virtual String S(string o)
    {
        return this.Demo.S(o);
    }
}