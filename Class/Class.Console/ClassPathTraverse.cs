namespace Class.Console;

public partial class ClassPathTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;

        this.IntParse = new IntParse();
        this.IntParse.Init();

        this.TextA = this.CreateText();
        this.TextB = this.CreateText();

        this.StringDataA = new StringData();
        this.StringDataA.Init();
        this.StringDataB = new StringData();
        this.StringDataB.Init();

        LessMid charLess;
        charLess = new LessMid();
        charLess.Init();
        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();
        this.TextLess = new TextLess();
        this.TextLess.CharLess = charLess;
        this.TextLess.LiteCharForm = charForm;
        this.TextLess.RightCharForm = charForm;
        this.TextLess.Init();

        this.Dot = this.TextInfra.TextCreateStringData(".", null);
        this.LeftSquare = this.TextInfra.TextCreateStringData("[", null);
        this.RightSquare = this.TextInfra.TextCreateStringData("]", null);
        return true;
    }

    public virtual NodeNode Result { get; set; }
    public virtual Text Path { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual InfraRange Field { get; set; }
    protected virtual InfraRange FieldName { get; set; }
    protected virtual int Index { get; set; }
    protected virtual int CurrentIndex { get; set; }
    protected virtual IntParse IntParse { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual Text TextB { get; set; }
    protected virtual StringData StringDataA { get; set; }
    protected virtual StringData StringDataB { get; set; }
    protected virtual TextLess TextLess { get; set; }
    protected virtual Text Dot { get; set; }
    protected virtual Text LeftSquare { get; set; }
    protected virtual Text RightSquare { get; set; }

    private Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new InfraRange();
        a.Range.Init();
        return a;
    }

    protected override bool ExecuteNode(NodeNode node)
    {
        if (!(this.CurrentIndex < this.Path.Range.Count))
        {
            this.Result = node;
            return true;
        }

        this.SetField();

        this.SetFieldNameIndex();

        this.CurrentIndex = this.CurrentIndex + this.FieldName.Count + 1;
        return true;
    }

    protected virtual bool SetField()
    {
        int start;
        start = this.CurrentIndex;

        int end;
        end = 0;

        Text path;
        path = this.Path;

        InfraRange range;
        range = path.Range;

        int ka;
        int kb;
        ka = range.Index;
        kb = range.Count;

        range.Index = ka + start;
        range.Count = kb - start;

        int u;
        u = this.TextInfra.Index(path, this.Dot, this.TextLess);

        bool b;
        b = (u < 0);
        if (b)
        {
            end = kb;
        }
        if (!b)
        {
            end = start + u;
        }

        int count;
        count = end - start;

        range.Index = ka;
        range.Count = kb;

        InfraRange a;
        a = this.Field;
        a.Index = start;
        a.Count = count;
        return true;
    }

    protected virtual bool SetFieldNameIndex()
    {
        Text path;
        path = this.Path;
        InfraRange range;
        range = path.Range;

        InfraRange field;
        field = this.Field;

        InfraRange fieldName;
        fieldName = this.FieldName;

        Text textA;
        textA = this.TextA;
        textA.Data = path.Data;
        InfraRange rangeA;
        rangeA = textA.Range;
        rangeA.Index = range.Index + field.Index;
        rangeA.Count = field.Count;

        int u;
        u = this.LeftSquareIndex(textA);

        bool b;
        b = (u < 0);

        if (!b)
        {
            int leftSquareIndex;
            leftSquareIndex = u;

            this.Index = this.GetIndex(this.Field, leftSquareIndex);

            fieldName.Index = field.Index;
            fieldName.Count = leftSquareIndex;
        }

        if (b)
        {
            this.Index = -1;

            fieldName.Index = field.Index;
            fieldName.Count = field.Count;
        }
        return true;
    }

    protected virtual int LeftSquareIndex(Text text)
    {
        int a;
        a = this.TextInfra.Index(text, this.LeftSquare, this.TextLess);
        return a;
    }

    protected virtual int GetIndex(InfraRange varField, int leftSquareIndex)
    {
        if (varField.Count < 1)
        {
            return -1;
        }

        Text path;
        path = this.Path;

        InfraRange range;
        range = path.Range;

        Text textA;
        textA = this.TextA;

        textA.Data = path.Data;
        
        InfraRange rangeA;
        rangeA = textA.Range;

        rangeA.Index = range.Index + varField.Index;
        rangeA.Count = varField.Count;

        bool b;
        b = this.TextInfra.End(textA, this.RightSquare, this.TextLess);

        if (!b)
        {
            return -1;
        }

        int start;
        start = leftSquareIndex + this.LeftSquare.Range.Count;

        int end;
        end = varField.Count - this.RightSquare.Range.Count;

        int count;
        count = end - start;

        rangeA.Index = rangeA.Index + start;
        rangeA.Count = count;

        long n;
        n = this.IntParse.Execute(textA, 10, false);

        if (n == -1)
        {
            return -1;
        }

        int a;
        a = (int)n;
        return a;
    }

    protected virtual bool HasResult()
    {
        return !(this.Result == null);
    }

    protected virtual bool FieldEqual(string name)
    {
        Text path;
        path = this.Path;

        Text textA;
        Text textB;
        textA = this.TextA;
        textB = this.TextB;

        InfraRange fieldName;
        fieldName = this.FieldName;

        textA.Data = path.Data;
        
        InfraRange ka;
        ka = textA.Range;
        ka.Index = path.Range.Index + fieldName.Index;
        ka.Count = fieldName.Count;

        this.TextStringGet(textB, this.StringDataB, name);

        bool a;
        a = this.TextInfra.Equal(textA, textB, this.TextLess);
        return a;
    }

    protected virtual bool TextStringGet(Text text, StringData data, string o)
    {
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }
}