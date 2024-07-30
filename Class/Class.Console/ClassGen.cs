namespace Class.Console;

public class ClassGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = new CountClassGenOperate();
        this.CountOperate.Gen = this;
        this.CountOperate.Init();
        this.SetOperate = new SetClassGenOperate();
        this.SetOperate.Gen = this;
        this.SetOperate.Init();

        this.Traverse = new ClassGenTraverse();
        this.Traverse.Gen = this;
        this.Traverse.Init();
        
        this.StringCreate = new StringCreate();
        this.StringCreate.Init();

        this.Indent = new string(' ', 4);
        return true;
    }

    public virtual ClassClass Class { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual bool Export { get; set; }
    public virtual Table ClassImportName { get; set; }
    public virtual Table ClassShare { get; set; }
    public virtual ClassClass NullClass { get; set; }
    public virtual BuiltinClass System { get; set; }
    public virtual GenArg Arg { get; set; }
    public virtual ClassGenOperate Operate { get; set; }
    public virtual Maide AnyInitMaide { get; set; }
    public virtual Maide ModuleInfoNameMaide { get; set; }
    public virtual Maide ModuleInfoVersionMaide { get; set; }
    public virtual string Source { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountClassGenOperate CountOperate { get; set; }
    protected virtual SetClassGenOperate SetOperate { get; set; }
    protected virtual ClassGenTraverse Traverse { get; set; }
    protected virtual StringCreate StringCreate { get; set; }
    protected virtual int IndentCount { get; set; }
    protected virtual string Indent { get; set; }

    public virtual bool Execute()
    {
        this.Arg = new GenArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        long nn;
        nn = this.Arg.Index;
        nn = nn * sizeof(char);
        Data data;
        data = new Data();
        data.Count = nn;
        data.Init();
        this.Arg.Data = data;

        this.Operate = this.SetOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        this.Operate = null;
        this.Arg = null;

        string o;
        o = this.StringCreate.Data(data, null);

        this.Source = o;
        return true;
    }

    public virtual bool ResetStageIndex()
    {
        this.Arg.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        NodeClass nodeClass;
        nodeClass = (NodeClass)this.Class.Any;

        this.Traverse.ExecuteClass(nodeClass);
        return true;
    }

    public virtual bool TextIndent()
    {
        string indent;
        indent = this.Indent;
        int count;
        count = this.IndentCount;
        int i;
        i = 0;
        while (i < count)
        {
            this.Text(indent);
            i = i + 1;
        }
        return true;
    }

    public virtual bool Text(string text)
    {
        ClassGenOperate o;
        o = this.Operate;

        int count;
        count = text.Length;
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = text[i];

            o.ExecuteChar(oc);

            i = i + 1;
        }
        return true;
    }
}