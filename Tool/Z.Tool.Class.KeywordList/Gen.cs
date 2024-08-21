namespace Z.Tool.Class.KeywordList;

public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();
        this.Module = this.S("Class.Infra");
        this.ClassName = this.S("KeywordList");
        this.BaseClassName = this.S("Any");
        this.AnyClassName = this.S("Any");
        this.ItemClassName = this.S("Keyword");
        this.ArrayClassName = this.S("Array");
        this.Export = true;
        this.ClassFileName = this.S("ToolData/Class/ClassKeyword.txt");
        this.InitMethodFileName = this.S("ToolData/Class/InitMaideKeyword.txt");
        this.ItemListFileName = this.S("ToolData/Class/ItemListKeyword.txt");
        this.AddMethodFileName = this.S("ToolData/Class/AddMaideKeyword.txt");
        this.OutputFilePath = this.S("../../Class/Class.Infra/KeywordList.cs");
        return true;
    }

    protected override TableEntry GetItemEntry(String line)
    {
        String index;
        index = line;

        Text aa;
        aa = this.TextCreate(this.S("Item"));

        Text k;
        k = this.TextCreate(index);

        if (this.TextStart(k, aa))
        {
            long kk;
            kk = aa.Range.Count;

            Range range;
            range = k.Range;

            range.Index = range.Index + kk;
            range.Count = range.Count - kk;
        }

        k = this.TextLower(k);

        String text;        
        text = this.StringCreate(k);

        Value value;
        value = new Value();
        value.Init();
        value.Text = text;

        TableEntry entry;
        entry = new TableEntry();
        entry.Init();
        entry.Index = index;
        entry.Value = value;
        return entry;
    }

    protected override bool AddInitFieldAddItem(String index, object value)
    {
        Value a;
        a = (Value)value;
        this.AddS("AddItem")
            .AddS("(")
            .AddS("\"").Add(a.Text).AddS("\"")
            .AddS(")");
        return true;
    }
}