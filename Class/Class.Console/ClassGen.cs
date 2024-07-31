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

        this.Space = " ";
        this.Indent = new string(' ', 4);
        this.Zero = "0";
        this.VarPrefix = "var";
        this.VarArgA = "ArgA";
        this.VarArgB = "ArgB";
        this.Eval = "e";
        this.EvalStackVar = "S";
        this.EvalIndexVar = "N";
        this.EvalFrameVar = "f";
        this.IntValuePre = "0x";
        this.IntValuePost = "ULL";
        this.RefKindClearMask = "0xfffffffffffffff";
        this.RefKindBoolMask = "0x1000000000000000";
        this.RefKindIntMask = "0x2000000000000000";
        this.DelimitDot = ".";
        this.DelimitDotPointer = "->";
        this.DelimitSquareLeft = "[";
        this.DelimitSquareRight = "]";
        this.DelimitSemicolon = ";";
        this.DelimitAre = "=";
        this.DelimitAnd = "&";
        this.DelimitOrn = "|";
        this.DelimitNot = "!";
        this.DelimitAdd = "+";
        this.DelimitSub = "-";
        this.DelimitMul = "*";
        this.DelimitDiv = "/";
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
    public virtual ClassInfra ClassInfra { get; set; }
    public virtual CountClassGenOperate CountOperate { get; set; }
    public virtual SetClassGenOperate SetOperate { get; set; }
    public virtual ClassGenTraverse Traverse { get; set; }
    public virtual StringCreate StringCreate { get; set; }
    public virtual int IndentCount { get; set; }
    public virtual string Space { get; set; }
    public virtual string Indent { get; set; }
    public virtual string Zero { get; set; }
    public virtual string VarPrefix { get; set; }
    public virtual string VarArgA { get; set; }
    public virtual string VarArgB { get; set; }
    public virtual string Eval { get; set; }
    public virtual string EvalStackVar { get; set; }
    public virtual string EvalIndexVar { get; set; }
    public virtual string EvalFrameVar { get; set; }
    public virtual string IntValuePre { get; set; }
    public virtual string IntValuePost { get; set; }
    public virtual string RefKindClearMask { get; set; }
    public virtual string RefKindBoolMask { get; set; }
    public virtual string RefKindIntMask { get; set; }
    public virtual string DelimitDot { get; set; }
    public virtual string DelimitDotPointer { get; set; }
    public virtual string DelimitSquareLeft { get; set; }
    public virtual string DelimitSquareRight { get; set; }
    public virtual string DelimitSemicolon { get; set; }
    public virtual string DelimitAre { get; set; }
    public virtual string DelimitAnd { get; set; }
    public virtual string DelimitOrn { get; set; }
    public virtual string DelimitNot { get; set; }
    public virtual string DelimitAdd { get; set; }
    public virtual string DelimitSub { get; set; }
    public virtual string DelimitMul { get; set; }
    public virtual string DelimitDiv { get; set; }

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

    public virtual bool OperateDelimit(string destArg, string left, string right, string delimit)
    {
        string space;
        space = this.Space;

        this.TextIndent();

        this.VarArg(destArg);
        
        this.Text(space);
        this.Text(this.DelimitAre);
        this.Text(space);

        this.VarArg(left);

        this.Text(space);
        this.Text(delimit);
        this.Text(space);

        this.VarArg(right);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool OperateDelimitOne(string destArg, string value, string delimit)
    {
        this.TextIndent();

        this.VarArg(destArg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(delimit);
        this.Text(this.Space);

        this.VarArg(value);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool VarSet(string destArg, string value)
    {
        this.TextIndent();

        this.VarArg(destArg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.Text(value);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool ClearVarMask(string arg, string mask)
    {
        this.TextIndent();

        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAnd);
        this.Text(this.Space);

        this.Text(mask);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool SetVarMask(string arg, string mask)
    {
        this.TextIndent();

        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitOrn);
        this.Text(this.Space);

        this.Text(mask);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool GetEvalValue(int index, string arg)
    {
        this.TextIndent();
        
        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);
        
        this.EvalValue(index);
        
        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool SetEvalValue(int index, string arg)
    {
        this.TextIndent();

        this.EvalValue(index);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.VarArg(arg);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool EvalValue(int index)
    {
        this.EvalStack();
        
        this.Text(this.DelimitSquareLeft);
        
        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.DelimitSub);
        this.Text(this.Space);
        
        this.TextInt(index);
        
        this.Text(this.DelimitSquareRight);
        return true;
    }

    public virtual bool GetEvalFrameValue(int index, string arg)
    {
        this.TextIndent();

        this.VarArg(arg);

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.EvalFrameValue(index);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool EvalFrameValue(int index)
    {
        this.EvalStack();

        this.Text(this.DelimitSquareLeft);

        this.Text(this.EvalFrameVar);

        this.Text(this.Space);
        this.Text(this.DelimitSub);
        this.Text(this.Space);

        this.TextInt(index);

        this.Text(this.DelimitSquareRight);
        return true;
    }

    public virtual bool SetEvalIndexPos(int pos)
    {
        this.TextIndent();

        this.EvalIndex();

        this.Text(this.Space);
        this.Text(this.DelimitAre);
        this.Text(this.Space);

        this.EvalIndex();

        this.Text(this.Space);

        this.TextPos(pos);

        this.Text(this.DelimitSemicolon);
        return true;
    }

    public virtual bool EvalStack()
    {
        this.Text(this.Eval);
        this.Text(this.DelimitDotPointer);
        this.Text(this.EvalStackVar);
        return true;
    }

    public virtual bool EvalIndex()
    {
        this.Text(this.Eval);
        this.Text(this.DelimitDotPointer);
        this.Text(this.EvalIndexVar);
        return true;
    }

    public virtual bool VarArg(string arg)
    {
        this.Text(this.VarPrefix);
        this.Text(arg);
        return true;
    }

    public virtual bool TextPos(long n)
    {
        bool b;
        b = (n < 0);

        string ka;
        ka = this.DelimitAdd;

        long k;
        k = n;
        
        if (b)
        {
            k = -k;

            ka = this.DelimitSub;
        }

        this.Text(ka);
        this.Text(this.Space);
        this.TextInt(k);
        return true;
    }

    public virtual bool TextInt(long n)
    {
        this.Text(this.IntValuePre);
        
        this.Operate.ExecuteIntFormat(n);

        this.Text(this.IntValuePost);
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