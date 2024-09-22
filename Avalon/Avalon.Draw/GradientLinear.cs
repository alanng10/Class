namespace Avalon.Draw;

public class PolateLinear : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;

        Pos pos;
        pos = this.StartPos;
        this.InternStartPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternStartPos, pos.Col, pos.Row);
        
        pos = this.EndPos;
        this.InternEndPos = this.InternInfra.PosCreate();
        this.InternInfra.PosSet(this.InternEndPos, pos.Col, pos.Row);

        this.Intern = Extern.GradientLinear_New();
        Extern.GradientLinear_StartPosSet(this.Intern, this.InternStartPos);
        Extern.GradientLinear_EndPosSet(this.Intern, this.InternEndPos);
        Extern.GradientLinear_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.GradientLinear_Final(this.Intern);
        Extern.GradientLinear_Delete(this.Intern);

        this.InternInfra.PosDelete(this.InternEndPos);

        this.InternInfra.PosDelete(this.InternStartPos);
        return true;
    }

    public virtual Pos StartPos { get; set; }
    public virtual Pos EndPos { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternEndPos { get; set; }
    private ulong InternStartPos { get; set; }
}