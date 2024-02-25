namespace Class.Node;

public class SetCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.DataRead = new DataRead();
        this.DataRead.Init();
        return true;
    }

    protected virtual DataRead DataRead { get; set; }

    public override Node Execute()
    {
        int index;
        index = this.Create.NodeIndex;

        Node node;        
        node = (Node)this.Create.NodeArray.Get(index);

        CreateOperateArg o;
        o = this.Create.OperateArg;

        NodeKind kind;
        kind = o.Kind;

        CreateOperateState state;
        state = kind.CreateOperateState;
        state.Node = node;
        state.Arg = o;
        state.Execute();

        this.Create.NodeInfo(node, o.Start, o.End);

        index = index + 1;

        this.Create.NodeIndex = index;
        return node;
    }

    public override int ExecuteListNew()
    {
        int index;
        index = this.Create.ListIndex;

        int a;
        a = index;

        index = index + 1;

        this.Create.ListIndex = index;
        return a;
    }

    public override Array ExecuteListGet(int index)
    {
        return (Array)this.Create.ListArray.Get(index);
    }

    public override bool ExecuteListSetItem(int index, int itemIndex, object item)
    {
        Array array;
        array = (Array)this.Create.ListArray.Get(index);

        array.Set(itemIndex, item);
        return true;
    }
    
    public override bool ExecuteError(ErrorKind kind, int start, int end)
    {
        int index;
        index = this.Create.ErrorIndex;

        Error error;
        error = (Error)this.Create.ErrorArray.Get(index);
        error.Kind = kind;
        error.Range.Start = start;
        error.Range.End = end;
        error.Source = this.Create.SourceItem;

        index = index + 1;

        this.Create.ErrorIndex = index;
        return true;
    }
}