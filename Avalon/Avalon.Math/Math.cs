namespace Avalon.Math;

public class Math : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternMathCompose = new InternMathCompose();
        this.InternMathCompose.Init();
        return true;
    }

    private InternIntern InternIntern { get; set; }
    private ulong Intern { get; set; }
    private InternMathCompose InternMathCompose { get; set; }

    public virtual long Value(Comp compose)
    {
        long aa;
        aa = compose.Significand;
        long ab;
        ab = compose.Exponent;

        ulong ua;
        ulong ub;
        ua = (ulong)aa;
        ub = (ulong)ab;

        ulong u;
        u = Extern.Math_Value(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ValueTen(long significand, long exponentTen)
    {
        ulong ua;
        ulong ub;
        ua = (ulong)significand;
        ub = (ulong)exponentTen;

        ulong u;
        u = Extern.Math_ValueTen(this.Intern, ua, ub);
        long a;
        a = (long)u;
        return a;
    }
    
    public virtual bool Compose(Comp result, long value)
    {
        InternMathCompose u;
        u = this.InternMathCompose;
        this.InternIntern.MathCompose(this.Intern, u, value);

        long s;
        long e;
        s = (long)(u.Significand);
        e = (long)(u.Exponent);
        
        result.Significand = s;
        result.Exponent = e;
        return true;
    }

    public virtual long Sin(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Sin(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Cos(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Cos(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long Tan(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_Tan(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ASin(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ASin(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ACos(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ACos(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }

    public virtual long ATan(long value)
    {
        ulong ua;
        ua = (ulong)value;
        ulong u;
        u = Extern.Math_ATan(this.Intern, ua);
        long a;
        a = (long)u;
        return a;
    }
}