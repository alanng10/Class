namespace Class.Infra;

public class NameCheck : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.Keyword = KeywordList.This;

        this.StringData = new StringData();
        this.StringData.Init();

        Text text;
        text = new Text();
        text.Init();
        text.Range = new InfraRange();
        text.Range.Init();
        this.Text = text;

        this.DotText = this.TextInfra.TextCreateStringData(".", null);
        return true;
    }

    public virtual TextLess TextLess { get; set; }
    public virtual LessMid CharLess { get; set; }
    public virtual CharForm CharForm { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual KeywordList Keyword { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual Text DotText { get; set; }

    public virtual bool IsName(Text text)
    {
        if (this.IsKeyword(text))
        {
            return false;
        }

        return this.IsNamePart(text);
    }

    public virtual bool IsNamePart(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        CharForm charForm;
        charForm = this.CharForm;

        if (text.Range.Count < 1)
        {
            return false;
        }

        Data data;
        data = text.Data;
        int start;
        start = text.Range.Index;

        int index;
        index = start;
        char oc;
        oc = textInfra.DataCharGet(data, index);

        oc = (char)charForm.Execute(oc);

        if (!(textInfra.IsLetter(oc, true) | textInfra.IsLetter(oc, false)))
        {
            return false;
        }

        bool b;
        b = false;

        int count;
        count = text.Range.Count;
        count = count - 1;

        start = start + 1;

        int i;
        i = 0;
        while (!b & i < count)
        {
            index = start + i;

            oc = textInfra.DataCharGet(data, index);

            oc = (char)charForm.Execute(oc);

            bool ba;
            ba = textInfra.IsLetter(oc, true) | textInfra.IsLetter(oc, false) | textInfra.IsDigit(oc) | oc == '_';

            if (!ba)
            {
                b = true;
            }
            i = i + 1;
        }

        bool a;
        a = !b;
        return a;
    }

    public virtual bool IsModuleName(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Less less;
        less = this.TextLess;

        Text dot;
        dot = this.DotText;

        InfraRange range;
        range = text.Range;

        int aa;
        int ab;
        aa = range.Index;
        ab = range.Count;
        int ac;
        ac = aa + ab;

        bool b;
        b = false;

        int u;
        u = textInfra.Index(text, dot, less);

        int index;
        int count;
        index = aa;
        count = ab;
        while (!b & !(u == -1))
        {
            count = u;
            range.Count = count;

            if (!this.IsNamePart(text))
            {
                b = true;
            }

            if (!b)
            {
                index = index + u + 1;
                count = ac - index;

                range.Index = index;
                range.Count = count;

                u = textInfra.Index(text, dot, less);
            }
        }

        bool ba;
        ba = false;

        if (!ba)
        {
            if (b)
            {
                ba = true;
            }
        }
        if (!ba)
        {
            count = ac - index;
            range.Count = count;

            if (!this.IsNamePart(text))
            {
                ba = true;
            }
        }

        range.Index = aa;
        range.Count = ab;

        bool a;
        a = !ba;
        return a;
    }

    public virtual bool IsKeyword(Text text)
    {
        TextInfra textInfra;
        textInfra = this.TextInfra;
        KeywordList keyword;
        keyword = this.Keyword;

        TextLess less;
        less = this.TextLess;

        Text oo;
        oo = this.Text;
        int count;
        count = keyword.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Keyword a;
            a = keyword.Get(i);
            string o;
            o = a.Text;

            this.TextStringGet(oo, o);

            if (textInfra.Equal(text, oo, less))
            {
                return true;
            }
            i = i + 1;
        }
        return false;
    }

    protected virtual bool TextStringGet(Text text, string o)
    {
        StringData d;
        d = this.StringData;
        d.ValueString = o;

        text.Data = d;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }
}