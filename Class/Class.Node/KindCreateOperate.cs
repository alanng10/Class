namespace Class.Node;

public class KindCreateOperate : CreateOperate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.List = this.ListInfra.ArrayCreate(0);
        this.String = "";
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Array List { get; set; }
    protected virtual string String { get; set; }

    public override Node Execute()
    {
        Create create;
        create = this.Create;
        
        CreateArg arg;
        arg = create.Arg;
        
        NodeKind kind;
        kind = create.OperateArg.Kind;

        int index;
        index = arg.NodeIndex;

        arg.NodeData.Set(index, kind.Index);

        index = index + 1;

        arg.NodeIndex = index;

        Node a;
        a = kind.Node;
        return a;
    }

    public override int ExecuteListNew()
    {
        CreateArg arg;
        arg = this.Create.Arg;

        int index;
        index = arg.ListIndex;

        int a;
        a = index;

        index = index + 1;

        arg.ListIndex = index;
        return a;
    }

    public override Array ExecuteListGet(int index)
    {
        return this.List;
    }

    public override bool ExecuteListCount(int index, int count)
    {
        long oa;
        oa = index;
        oa = oa * sizeof(uint);
        uint u;
        u = (uint)count;
        this.InfraInfra.DataMidSet(this.Create.Arg.ListData, oa, u);
        return true;
    }

    public override string ExecuteNameValue(Text text)
    {
        CreateArg arg;
        arg = this.Create.Arg;

        int index;
        index = arg.NameValueIndex;
        int indexA;
        indexA = arg.NameValueTextIndex;

        InfraRange range;
        range = text.Range;

        int count;
        count = range.Count;
        uint u;
        u = (uint)count;
        long oa;
        oa = index;
        oa = oa * sizeof(uint);
        this.InfraInfra.DataMidSet(arg.NameValueCountData, oa, u);

        Data source;
        source = text.Data;
        int sourceIndex;
        sourceIndex = range.Index;
        Data dest;
        dest = arg.NameValueTextData;
        int destIndex;
        destIndex = indexA;

        this.CopyText(dest, destIndex, source, sourceIndex, count);

        index = index + 1;
        indexA = indexA + count;

        arg.NameValueTextIndex = indexA;
        arg.NameValueIndex = index;
        return this.String;
    }

    public override string ExecuteStringValue(Text text)
    {
        int index;
        index = this.Create.StringValueIndex;
        int indexA;
        indexA = this.Create.StringValueTotalIndex;

        StringValueWrite write;
        write = this.Create.StringValueWrite;
        write.WriteOperate = write.CountWriteOperate;
        write.Index = 0;
        write.ExecuteValueString(text);
        int count;
        count = write.Index;
        uint u;
        u = (uint)count;
        long oa;
        oa = index * sizeof(uint);
        this.InfraInfra.DataMidSet(this.Create.StringValueData, oa, u);
        
        write.WriteOperate = write.AddWriteOperate;
        write.Index = indexA;
        write.Data = this.Create.StringValueText;
        write.ExecuteValueString(text);
        write.Data = null;

        index = index + 1;
        indexA = indexA + count;

        this.Create.StringValueTotalIndex = indexA;
        this.Create.StringValueIndex = index;
        return this.String;
    }


    protected virtual bool CopyText(Data dest, int destIndex, Data source, int sourceIndex, int count)
    {
        char oc;
        int i;
        i = 0;
        while (i < count)
        {
            oc = this.TextInfra.DataCharGet(source, sourceIndex + i);

            this.TextInfra.DataCharSet(dest, destIndex + i, oc);
            
            i = i + 1;
        }
        return true;
    }
}