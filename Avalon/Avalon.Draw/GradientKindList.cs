namespace Avalon.Draw;

public class GradientKindList : Any
{
    public static GradientKindList This { get; } = ShareCreate();

    private static GradientKindList ShareCreate()
    {
        GradientKindList share;
        share = new GradientKindList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        ulong share;
        share = Extern.Infra_Share();
        ulong stat;
        stat = Extern.Share_Stat(share);

        this.Linear = this.AddItem(Extern.Stat_GradientKindLinear(stat));
        this.Radial = this.AddItem(Extern.Stat_GradientKindRadial(stat));
        return true;
    }

    public virtual GradientKind Linear { get; set; }
    public virtual GradientKind Radial { get; set; }

    protected virtual GradientKind AddItem(ulong o)
    {
        int index;
        index = this.Index;

        GradientKind item;
        item = new GradientKind();
        item.Init();
        item.Index = index;
        item.Intern = o;
        this.Array.SetAt(index, item);
        this.Index = index + 1;
        return item;
    }

    protected virtual bool InitArray()
    {
        this.Array = new Array();
        this.Array.Count = this.ArrayCount;
        this.Array.Init();
        return true;
    }

    protected virtual Array Array { get; set; }

    protected virtual int ArrayCount { get { return 2; } set { } }

    public virtual int Count { get; set; }
    
    protected virtual int Index { get; set; }

    public virtual GradientKind Get(int index)
    {
        return (GradientKind)this.Array.GetAt(index);
    }
}