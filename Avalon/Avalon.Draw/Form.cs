namespace Avalon.Draw;

public class Form : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;

        this.Intern = Extern.Form_New();
        Extern.Form_Init(this.Intern);
        return true;
    }

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    internal virtual ulong Intern { get; set; }

    public virtual bool Final()
    {
        Extern.Form_Final(this.Intern);
        Extern.Form_Delete(this.Intern);
        return true;
    }

    public virtual long ValueGet(int row, int col)
    {
        if (!this.ValidRow(row))
        {
            return -1;
        }
        if (!this.ValidCol(col))
        {
            return -1;
        }

        ulong r;
        ulong c;
        r = (ulong)row;
        c = (ulong)col;
        ulong u;
        u = Extern.Form_ValueGet(this.Intern, r, c);
        long a;
        a = (long)u;
        return a;
    }

    public virtual bool ValueSet(int row, int col, long value)
    {
        if (!this.ValidRow(row))
        {
            return false;
        }
        if (!this.ValidCol(col))
        {
            return false;
        }

        ulong r;
        ulong c;
        r = (ulong)row;
        c = (ulong)col;
        ulong u;
        u = (ulong)value;

        ulong k;
        k = Extern.Form_ValueSet(this.Intern, r, c, u);

        if (k == 0)
        {
            return false;
        }
        return true;
    }

    public virtual bool Reset()
    {
        Extern.Form_Reset(this.Intern);
        return true;
    }

    public virtual bool IsIdentity()
    {
        ulong u;
        u = Extern.Form_IsIdentity(this.Intern);
        bool b;
        b = (!(u == 0));
        return b;
    }

    public virtual bool Offset(long left, long up)
    {
        ulong leftU;
        ulong upU;
        leftU = (ulong)left;
        upU = (ulong)up;
        Extern.Form_Offset(this.Intern, leftU, upU);
        return true;
    }

    public virtual bool Rotate(long angle)
    {
        ulong angleU;
        angleU = (ulong)angle;
        Extern.Form_Rotate(this.Intern, angleU);
        return true;
    }

    public virtual bool Scale(long horizScale, long vertScale)
    {
        ulong horizScaleU;
        ulong vertScaleU;
        horizScaleU = (ulong)horizScale;
        vertScaleU = (ulong)vertScale;
        Extern.Form_Scale(this.Intern, horizScaleU, vertScaleU);
        return true;
    }

    public virtual bool Multiply(Form other)
    {
        Extern.Form_Multiply(this.Intern, other.Intern);
        return true;
    }

    public virtual bool ValidRow(int index)
    {
        return this.InfraInfra.ValidIndex(3, index);
    }

    public virtual bool ValidCol(int index)
    {
        return this.InfraInfra.ValidIndex(3, index);
    }
}