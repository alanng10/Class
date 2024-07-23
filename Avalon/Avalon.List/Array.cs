namespace Avalon.List;

public class Array : List
{
    public override bool Init()
    {
        this.InfraInfra = InfraInfra.This;
        this.Comparer = new Comparer();
        this.Comparer.Init();

        int k;
        k = this.Count;

        if (!this.ValidCount(k))
        {
            return false;
        }

        this.Value = new object[k];
        return true;
    }

    public override object FirstIndex { get { return null; } set { } }
    public override object LastIndex { get { return null; } set { } }

    protected virtual InfraInfra InfraInfra { get { return __D_InfraInfra; } set { __D_InfraInfra = value; } }
    protected InfraInfra __D_InfraInfra;

    private object[] Value { get; set; }
    private Comparer Comparer { get; set; }

    public override object Add(object item)
    {
        return null;
    }

    public override object Insert(object index, object item)
    {
        return null;
    }

    public override bool Remove(object index)
    {
        return false;
    }

    public override bool Clear()
    {
        return false;
    }

    public override bool Contain(object index)
    {
        return false;
    }

    public override object Get(object index)
    {
        return null;
    }

    public override bool Set(object index, object value)
    {
        return false;
    }

    public virtual bool ValidAt(int index)
    {
        return this.InfraInfra.ValidIndex(this.Count, index);
    }

    public virtual object GetAt(int index)
    {
        if (!this.ValidAt(index))
        {
            return null;
        }
        return this.Value[index];
    }

    public virtual bool SetAt(int index, object value)
    {
        if (!this.ValidAt(index))
        {
            return false;
        }
        this.Value[index] = value;
        return true;
    }

    public virtual bool ValidCount(int value)
    {
        return !(value < 0);
    }

    public virtual bool Sort(Range range, Compare compare)
    {
        int index;
        index = range.Index;
        int count;
        count = range.Count;
        Comparer comparer;
        comparer = this.Comparer;

        comparer.CompareAny = compare;

        SystemArray.Sort<object>(this.Value, index, count, comparer);

        comparer.CompareAny = null;
        return true;
    }

    public override Iter IterCreate()
    {
        Iter a;
        a = new ArrayIter();
        a.Init();
        return a;
    }

    public override bool IterSet(Iter iter)
    {
        ArrayIter a;
        a = (ArrayIter)iter;
        a.Array = this;
        a.IntIndex = 0;
        a.CurrentIndex = -1;
        return true;
    }
}